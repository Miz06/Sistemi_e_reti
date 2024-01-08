using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversioneSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        { //Alessandro Mizzon 4E
            string i;
            int DP, DP2;

            Console.WriteLine("Inserire un indirizzo:");
            i = Console.ReadLine();

            string[] iS = i.Split('.');
            int[] dp = new int[iS.Length];

            for (int j = 0; j < iS.Length; j++)
            {
                dp[j] = Convert.ToInt32(iS[j]);
            }

            //Metodo converti in booleano
            bool[] bin = Convert_dp_to_boolean(dp);

            for (int j = 0; j < 32; j++)
            {
                Console.WriteLine($"{bin[j]} ");
            }

            Console.WriteLine();

            //Metodo converti in binario
            int[] binario = new int[32];
            binario = Convert_dp_to_binario(bin);

            for (int j = 0; j < 32; j++)
            {
                Console.Write($"{binario[j]} ");
            }

            Console.WriteLine();

            //Metodo converti in decimale puntato da booleano
            DP = Convert_binario_todecimale_puntato(bin);
            Console.WriteLine(DP);

            //Metodo converti in decimale puntato da intero
            DP2 = Convert_dp_to_intero(dp);
            Console.WriteLine(DP2);
            Console.ReadLine();
        }

        static bool[] Convert_dp_to_boolean(int[] dp)
        {
            bool[] Bin = new bool[32];
            int indice = 31;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Bin[indice] = Convert.ToBoolean(dp[i] % 2);
                    dp[i] = dp[i] / 2;
                    indice--;
                }
            }

            return Bin;
        }

        static int[] Convert_dp_to_binario(bool[] dp)
        {
            int[] binario = new int[32];

            for (int i = 0; i < 32; i++)
            {
                binario[i] = Convert.ToInt32(dp[i]);
            }

            return binario;
        }

        static int Convert_binario_todecimale_puntato(bool[] array)
        {
            int DP = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i])
                {
                    DP += Convert.ToInt32(Math.Pow(2, 31 - i));
                }
            }

            return DP;
        }

        static int Convert_dp_to_intero(int[] dp)
        {
            int D = 0;

            for (int i = 0; i < dp.Length; i++)
            {
                D += Convert.ToInt32(Math.Pow(256, 3 - i) * dp[i]);
            }

            return D;
        }
    }
}