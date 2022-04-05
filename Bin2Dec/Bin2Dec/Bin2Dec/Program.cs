using System;

namespace Bin2Dec {
    class Program {
        static void Main(string[] args) {
            Console.Write("Digite um número binário: ");
            string binary = Console.ReadLine();

            for(int i = 0; i < binary.Length; i ++) {
                int number = int.Parse(binary.ToCharArray(i, 1));
                if(number != 0 && number != 1) {
                    Console.WriteLine();
                    Console.WriteLine("Error: Um número diferente de 1 ou 0 foi inserido");
                    return;
                }
            }
            Conversor conversor = new Conversor();
            Console.WriteLine(conversor.ToDecimal(binary));
        }
    }
}
  