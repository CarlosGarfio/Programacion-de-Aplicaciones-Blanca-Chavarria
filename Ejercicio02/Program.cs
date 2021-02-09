using System;
using System.Collections.Generic;

namespace Ejercicios.Ejercicio02
{
    class Program
    {
        static void Main1(string[] args)
        {
            var orden = new List<Product>();
            while (true)
            {
                Console.Clear();
                int entrada;
                Console.WriteLine("---------------- Menu ----------------");
                /*  
                 *  Hamburguesas  sencilla          $35.50*
                 *  Hamburguesa doble               $55.50*
                 *  Hamburguesa hawaiana            $50.00
                 *  Papas Francesas con queso       $25.00
                 *  Papas Francesas sin queso       $20.00
                 *  Refresco                        $12.50  
                 */

                Console.WriteLine("1). Hamburguesas  sencilla          $35.50");
                Console.WriteLine("2). Hamburguesa doble               $55.50");
                Console.WriteLine("3). Hamburguesa hawaiana            $50.00");
                Console.WriteLine("4). Papas Francesas con queso       $25.00");
                Console.WriteLine("5). Papas Francesas sin queso       $20.00");
                Console.WriteLine("6). Refresco                        $12.50");
                Console.WriteLine("\nIngresa el numero del pedido:");

                try
                {
                    entrada = Convert.ToInt32(Console.ReadLine());

                    if (entrada < 1 || entrada > 7)
                    {
                        Console.WriteLine("Error: El numero no puede ser mayor a {6} o menor a {1}.");
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

                var product = GenerateProduct(entrada);

                int index = orden.FindIndex(delegate (Product p) { return p.nombre.Equals(product.nombre, StringComparison.Ordinal); });

                if (index != -1)
                {
                    orden[index].cantidad++;
                }
                else
                {
                    orden.Add(product);
                }


                var _continue = false;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Deseas agregar mas productos? s/N");


                    var resp = Console.ReadLine();

                    if (resp.Equals(string.Empty) || resp.ToLower().Equals("n"))
                        break;

                    if (resp.ToLower().Equals("s"))
                    {
                        _continue = true;
                        break;
                    }
                }

                if (_continue)
                    continue;

                break;
            }

            Console.WriteLine("---------------- Tu orden ----------------");
            var totalAPagar = 0d;
            orden.ForEach(p =>
            {
                var total = p.cantidad * p.precio;
                totalAPagar += total;
                Console.WriteLine("{0} ${1} x {2} = {3}", p.nombre, p.precio.ToString("N"), p.cantidad, total);
            });
            Console.WriteLine("Total a pagar: ${0}", totalAPagar.ToString("N"));



        }

        static Product GenerateProduct(int product) =>
        product switch
        {
            1 => new Product { nombre = "Hamburguesas  sencilla", precio = 35.50d, cantidad = 1 },
            2 => new Product { nombre = "Hamburguesa doble", precio = 55.50d, cantidad = 1 },
            3 => new Product { nombre = "Hamburguesa hawaiana", precio = 50.50d, cantidad = 1 },
            4 => new Product { nombre = "Papas Francesas con queso", precio = 25d, cantidad = 1 },
            5 => new Product { nombre = "Papas Francesas sin queso", precio = 20d, cantidad = 1 },
            6 => new Product { nombre = "Refresco", precio = 15.50d, cantidad = 1 },
            _ => null,
        };


        internal class Product
        {
            public string nombre { get; set; }
            public double precio { get; set; }
            public int cantidad { get; set; }
        }
    }
}