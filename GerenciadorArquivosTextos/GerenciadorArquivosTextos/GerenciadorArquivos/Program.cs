using System;
using System.IO;

namespace GerenciadorArquivos {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\t\tGerenciador de Arquivos de Textos");
            Console.WriteLine("-");
            Console.WriteLine("-");
            Console.WriteLine("-");
            Console.WriteLine("-");
            Console.WriteLine("-");
            Console.WriteLine("-");
            Console.Write("\nDigite o Diretório: ");
            string path = Console.ReadLine();

            while (true) {
                Console.Clear();
                Gerenciador file = new Gerenciador(path);
                file.MostrarArquivos(path);
                Console.WriteLine("###########################################");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("\t1 - Criar");
                Console.WriteLine("\t2 - Editar");
                Console.WriteLine("\t3 - Ler");
                Console.WriteLine("\t4 - Copiar");
                Console.WriteLine("\t5 - Deletar");
                Console.WriteLine("\n\t6 - Sair");
                Console.WriteLine("###########################################");
                Console.Write("\nDigite: ");
                int option = int.Parse(Console.ReadLine());

                bool runnig = true;
                while (runnig == true) {
                    Console.Clear();
                    try {
                        if (option == 1) {
                            file.Criar();
                        }
                        else if (option > 1 && option < 6) {
                            file.MostrarArquivos(path);
                            Console.Write("\nEscolha um arquivo: ");
                            string fileName = Console.ReadLine();

                            if (option == 2) {
                                file.Editar(fileName);

                            }
                            else if (option == 3) {
                                file.Ler(fileName);

                            }
                            else if (option == 4) {
                                file.Copiar(fileName);
                            }
                            else if (option == 5) {
                                file.Delete(fileName);
                            }
                            else {
                            }
                        }
                        else if (option == 6) {
                            Console.WriteLine("Finalizando...");
                            return;
                        }
                        else {
                            Console.WriteLine("Error: Opção não encontrada.");
                            Console.Write("\nPressione ENTER para continuar... ");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        runnig = Decisao();
                    }
                    catch (IOException e) {
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                    }
                }
            }
        }
        static bool Decisao() {

            while (true) {
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("\t1 - Refazer");
                Console.WriteLine("\t2 - Inicio");
                Console.WriteLine("-------------------------------------------");
                Console.Write("\nDigite: ");
                int option = int.Parse(Console.ReadLine());

                Console.Clear();

                if (option == 1) {
                    return true;
                }
                else if (option == 2){
                    return false;
                }
                else {
                    Console.WriteLine("Error: Opção não encontrada!");
                }
            }
        }
    }
}
