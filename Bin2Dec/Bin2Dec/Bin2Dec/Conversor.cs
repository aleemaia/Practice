using System;

namespace Bin2Dec {
    class Conversor {
        public int Result { get; set; } = 0;
        public Conversor() {
        }

        public int ToDecimal(string binary) { 
        for (int i = 0; i < binary.Length; i++) {
                Result += int.Parse(binary.Substring(i, 1)) * (int)Math.Pow(2, binary.Length - (i + 1));
            }
            return Result;
        }
            // Apenas com 8 digitos
            /*
            public int ToDecimal(string binary) {
                Result = 128 * int.Parse(binary.ToCharArray(0, 1))
                    + 64 * int.Parse(binary.ToCharArray(1, 1))
                    + 32 * int.Parse(binary.ToCharArray(2, 1))
                    + 16 * int.Parse(binary.ToCharArray(3, 1))
                    + 8 * int.Parse(binary.ToCharArray(4, 1))
                    + 4 * int.Parse(binary.ToCharArray(5, 1))
                    + 2 * int.Parse(binary.ToCharArray(6, 1))
                    + 1 * int.Parse(binary.ToCharArray(7, 1));
                return Result;
            } */
        }
}
