using System;

namespace Ejercicios.PracticaGuiada03
{
    class Program
    {
        static void Main1(string[] args)
        {
            var index = 0;

            var numeros = new double[3];

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingresa el numero {0}", index + 1);

                var str = Console.ReadLine();
                if (!EsNumero(str))
                {
                    Console.WriteLine("Error: Solo puedes ingresar numeros.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                numeros[index] = Convert.ToDouble(str);

                if (index++ == 2)
                    break;
            }

            Console.Clear();

            Array.Sort(numeros);

            if (numeros[0] == numeros[1] && numeros[0] == numeros[2])
            {
                Console.WriteLine("Los tres numeros son iguales");
                return;
            }


            Console.WriteLine("El menor es: {0}", numeros[0]);
            Console.WriteLine("El mediano es: {0}", numeros[1]);
            Console.WriteLine("El mayor es: {0}", numeros[2]);
        }

        static bool EsNumero(string str)
        {
            if (int.TryParse(str, out int i))
                return true;

            if (double.TryParse(str, out double d))
                return true;

            return false;
        }
    }
}