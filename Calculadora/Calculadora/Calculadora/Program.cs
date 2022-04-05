using Calculadora.Service;
using System;
using System.Globalization;

namespace Calculadora {
    class Program {
        static void Main(string[] args) {

            CalculoService calculo = new CalculoService();

            Inicio:
            Console.WriteLine("Escolha umas das seguintes funções:");
            Console.WriteLine("\ta - Adição");
            Console.WriteLine("\ts - Subtração");
            Console.WriteLine("\tm - Multiplicação");
            Console.WriteLine("\td - Divisão");
            Console.Write("Digite: ");
            char funcao = char.Parse(Console.ReadLine());

            if (!(funcao == 'a' || funcao == 's' || funcao == 'm' || funcao == 'd')) {
                Console.WriteLine("Error: Função não encontrada");
                Console.WriteLine();
                goto Inicio;
            }

            Console.WriteLine("Entre com os números: ");
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            if (funcao == 'a') {
                calculo.Adicao(x, y);
            }
            else if(funcao == 's') {
                calculo.Subtracao(x, y);
            }
            else if(funcao == 'm') {
                calculo.Multiplicacao(x, y);
            }
            else if(funcao == 'd') {
                calculo.Divisao(x, y);
            }
            else { 
            }

            Console.WriteLine(calculo);
        }
    }
}
