using System;

namespace Ejercicios.Ejercicio06
{
    class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Cual es el nombre del libro?");
            var titulo = Console.ReadLine();
            Console.WriteLine("Cuanto costara el libro?");
            var precio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cuantas paginas tiene el libro?");
            var paginas = Convert.ToInt32(Console.ReadLine());


            var libro = new Libro
            {
                titulo = titulo,
                precio = precio,
                paginasTotales = paginas
            };

            Console.WriteLine("---------- Especificaciones del libro ----------");
            Console.WriteLine("Titulo: {0}", libro.titulo);
            Console.WriteLine("Precio: ${0}", libro.precio.ToString("N"));
            Console.WriteLine("Paginas: {0}", libro.paginasTotales);

            libro.Lectura(0, 5);
            Console.WriteLine(libro.EstadoLectura());
            libro.Lectura(3, 1);
            Console.WriteLine(libro.EstadoLectura());
            libro.Lectura(1, 3);
            Console.WriteLine(libro.EstadoLectura());
            libro.Lectura(2, 3);
            Console.WriteLine(libro.EstadoLectura());
            libro.Lectura(5, 3);
            Console.WriteLine(libro.EstadoLectura());
            libro.Lectura(5, 10);
            Console.WriteLine(libro.EstadoLectura());

            //var cd = new CD();
            //cd.minutos = 60d;

            //Console.WriteLine(cd.GenTimeSpanFromMinutes());
        }
    }
    abstract class Publicacion
    {
        public string titulo { get; set; }
        public double precio { get; set; }
    }
    class Libro : Publicacion
    {
        public int paginasTotales { get; set; }
        private int ultimaPagina { get; set; }

        public Libro()
        {
            this.paginasTotales = 0;
            this.ultimaPagina = 0;
        }

        public int Lectura(int inicio, int paginasALeer)
        {
            if (inicio < 1)
                inicio = 1;

            this.ultimaPagina = inicio;

            for (int i = 0; i < paginasALeer; i++)
            {
                Console.WriteLine("Leyendo pagina {0}", this.ultimaPagina);

                if (this.ultimaPagina++ >= this.paginasTotales)
                    break;
            }

            return ultimaPagina;
        }

        public string EstadoLectura() => "Vas en la pagina " + (this.ultimaPagina >= this.paginasTotales ? this.paginasTotales : this.ultimaPagina) + " de " + this.paginasTotales;
    }
    class CD : Publicacion
    {
        public double minutos { get; set; }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromminutes?view=net-5.0
        /// 
        /// double minutos = 1      -> 1 minuto                 -> 00:01:00
        /// double minutos = 1.5    -> 1 minuto y 30 segundos   -> 00:01:30
        /// double minutos = 60     -> 1 hora                   -> 01:00:00
        /// double minutos = 60.5   -> 1 hora y 30 segundos     -> 01:00:30
        /// </summary>
        /// <param name="minutos"></param>
        /// <returns></returns>
        public string GenTimeSpanFromMinutes()
        {
            var interval = TimeSpan.FromMinutes(this.minutos);
            var timeInterval = interval.ToString();
            var pIndex = timeInterval.IndexOf(':');
            pIndex = timeInterval.IndexOf('.', pIndex);
            if (pIndex < 0) timeInterval += "        ";
            return timeInterval;
        }
    }
}