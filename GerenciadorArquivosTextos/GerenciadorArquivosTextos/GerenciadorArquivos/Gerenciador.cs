using System;
using System.Text;
using System.IO;

namespace GerenciadorArquivos {
    class Gerenciador {
        public string Path { get; set; }

        public Gerenciador(string path) {
            Path = path;
        }

        public void Criar() {
            Console.Write("Digite o nome do arquivo: ");
            string file = Console.ReadLine();
            if (Validacao(file + ".txt")) {
                Console.WriteLine("Error: Nome do arquivo já existe!");
                return;
            }
            using (File.Create(Path + @"\" + file + ".txt"))
            Console.Clear();
            Console.WriteLine("Arquivo criado com Sucesso!");
        }

        public void Editar(string fileName) {
            string textos;
            if (!Validacao(fileName)) {
                Console.WriteLine("Error: Arquivo não encontrado");
                return;
            }
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("\t1 - Criar/Substituir");
            Console.WriteLine("\t2 - Acrescentar");
            Console.Write("\nDigite: ");
            int editOption = int.Parse(Console.ReadLine());
            
            if (editOption == 1) {
                Console.Clear();
                Console.WriteLine("OBS: Ctrl + Z e pressione ENTER para finalizar.");
                using (StreamWriter sw = File.CreateText(Path + "\\" + fileName)) {
                    Console.WriteLine("\nDigite o texto:\n");
                    
                    while ((textos = Console.ReadLine()) != null) {
                        sw.WriteLine(textos);
                    }
                }
            }
            else if (editOption == 2) {
                Console.Clear();
                Console.WriteLine("OBS: Ctrl + Z e pressione ENTER para finalizar.");
                using (StreamWriter sw = File.AppendText(Path + "\\" + fileName)) {
                    Console.WriteLine("\nDigite o texto:\n");
                    while ((textos = Console.ReadLine()) != null) {
                        sw.WriteLine(textos);
                    }
                }         
            }
            else {
                Console.WriteLine("Error: Opção não encontrada!");
                return;
            }
            Console.Clear();
            Console.WriteLine("Arquivo editado com Sucesso!");
        }

        public void Ler(string fileName) {
            if (!Validacao(fileName)) {
                Console.WriteLine("Error: Arquivo não encontrado");
                return;
            }
            Console.WriteLine("\n-------------------------------------------");
            using (FileStream fs = new FileStream(Path + "\\" + fileName, FileMode.Open)) {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8)) {
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public void Copiar(string fileName) {
            if (!Validacao(fileName)) {
                Console.WriteLine("Error: Arquivo não encontrado");
                return;
            }
            try {
                var copy = new FileInfo(Path + "\\" + fileName);
                Console.Write("Digite o nome do arquivo: ");
                string file = Console.ReadLine();
                copy.CopyTo(copy.Directory + @"\" + file + copy.Extension);
                Console.Clear();
                Console.WriteLine("Arquivo copiado com Sucesso!");
            }
            catch (IOException) {
                Console.WriteLine("Error: Arquivo ja existe!");
            }
        }

        public void Delete(string fileName) {
            if (!Validacao(fileName)) {
                Console.WriteLine("Error: Arquivo não encontrado");
                return;
            }
            File.Delete(Path + "\\" + fileName);
            Console.Clear();
            Console.WriteLine("Arquivo deletado com Sucesso!");
            return;
        }

        public void MostrarArquivos(string path) {
            Console.WriteLine("\t~ARQUIVOS EXISTENTES~");
            Console.WriteLine("-------------------------------------------");
            string[] files = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string f in files) {
                Console.WriteLine("- " + f);
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
        }

        public bool Validacao(string fileName) {
            var directory = new DirectoryInfo(Path);
            FileInfo[] files = directory.GetFiles("*.txt", SearchOption.TopDirectoryOnly);
            foreach (FileInfo f in files) {
                if (fileName == f.Name) {
                    return true;
                }
            }
            return false;
        }
    }
}
