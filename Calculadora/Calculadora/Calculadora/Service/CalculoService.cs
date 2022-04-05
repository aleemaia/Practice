using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Service {
    class CalculoService {

        public double Result { get; set; }

        public CalculoService() {
        }

        public double Adicao(double x, double y) {
            Result = x + y;
            return Result;
        }

        public double Subtracao(double x, double y) {
            Result = x - y;
            return Result;
        }

        public double Multiplicacao(double x, double y) {
            Result = x * y;
            return Result;
        }

        public double Divisao(double x, double y) {
            Result = x / y;
            return Result;
        }

        public override string ToString() {
            return "Resultado: "
                  + Result.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
