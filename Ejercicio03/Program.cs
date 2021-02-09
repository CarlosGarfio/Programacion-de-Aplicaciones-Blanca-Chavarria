using System;

namespace Ejercicios.Ejercicio03
{
    class Program
    {
        static void Main1(string[] args)
        {

            var empleado = new Empleado();

            Console.WriteLine("Nombre del empleado:");
            empleado.nombre = Console.ReadLine();


            int antiguedad;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Antiguedad del empleado (Años):");

                var str = Console.ReadLine();
                if (!EsNumero(str))
                {
                    Console.WriteLine("Error: Solo puedes ingresar numeros.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                antiguedad = Convert.ToInt32(str);

                if (antiguedad < 0)
                {
                    Console.WriteLine("Error: La antiguedad no puede menor a {0}.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                break;
            }
            empleado.antiguedad = antiguedad;

            double salario;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Salario del empleado:");

                var str = Console.ReadLine();
                if (!EsNumero(str))
                {
                    Console.WriteLine("Error: Solo puedes ingresar numeros.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                salario = Convert.ToDouble(str);

                if (salario < 0d)
                {
                    Console.WriteLine("Error: La antiguedad no puede menor a {0}.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                break;
            }
            empleado.salario = salario;

            int hijos;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Numero de hijos del empleado:");

                var str = Console.ReadLine();
                if (!EsNumero(str))
                {
                    Console.WriteLine("Error: Solo puedes ingresar numeros.");
                    Console.WriteLine("Preciona una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                hijos = Convert.ToInt32(str);

                break;
            }
            empleado.cantidadHijos = hijos;

            Console.Clear();

            double bono = 1d;

            if (empleado.antiguedad > 8 && empleado.cantidadHijos > 3)
            {
                bono = 1.15d;
                Console.WriteLine("El empleado {0} tiene un bono del 15%", empleado.nombre);
            }
            else if (empleado.antiguedad < 8 && empleado.cantidadHijos >= 3)
            {
                bono = 1.10d;
                Console.WriteLine("El empleado {0} tiene un bono del 10%", empleado.nombre);
            }
            else if (empleado.antiguedad > 8 && empleado.cantidadHijos < 3)
            {
                bono = 1.05d;
                Console.WriteLine("El empleado {0} tiene un bono del 5%", empleado.nombre);
            }
            else
                Console.WriteLine("El empleado {0} no cuenta con bono", empleado.nombre);

            Console.WriteLine("Salario del empleado {0}: {1}", empleado.nombre, empleado.salario * bono);
        }

        static bool EsNumero(string str)
        {
            if (int.TryParse(str, out int i))
                return true;

            if (double.TryParse(str, out double d))
                return true;

            return false;
        }

        internal class Empleado
        {
            public string nombre { get; set; }
            public int antiguedad { get; set; }
            public double salario { get; set; }
            public int cantidadHijos { get; set; }
        }
    }
}