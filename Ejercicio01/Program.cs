using System;

namespace Ejercicios.Ejercicio01
{
    class Program
    {
        static void Main1(string[] args)
        {
            var numerosOriginal = string.Empty;
            var numerosAlreves = string.Empty;
            var index = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingresa un numero:");
                int n;

                try
                {
                    n = Convert.ToInt32(Console.ReadLine());

                    if (n < 0 || n > 9)
                    {
                        Console.WriteLine("Error: El numero no puede ser mayor a {10} o menor a {0}.");
                        Console.WriteLine("Preciona una tecla para reintentar...");
                        Console.ReadKey();
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Solo puedes ingresar numeros.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                numerosAlreves = n.ToString() + numerosAlreves;
                numerosOriginal += n.ToString();

                if (index++ == 2)
                    break;
            }

            Console.Clear();
            Console.WriteLine("Entrada original: {0}\nEntrada alreves: {1}", numerosOriginal, numerosAlreves);
        }
    }
}