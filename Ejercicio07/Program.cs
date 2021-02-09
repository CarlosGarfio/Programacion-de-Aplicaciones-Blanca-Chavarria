using System;

namespace Ejercicios.Ejercicio07
{
    class Program
    {
        static void Main1(string[] args)
        {
            var miAuto = new Auto(5, "ABC7500", "GMC", 2023, 1_000_000, Tipos.Lujo.ToString());

            var columnas = new string[] { "No. Serie", "Marca", "Año", "Precio", "Pasajeros", "Tipo" };
            var auto = new string[] { miAuto.noSerie.ToString(), miAuto.marca.ToString(), miAuto.anno.ToString(), "$" + miAuto.precio.ToString("N"), miAuto.cantidadPasajeros.ToString(), miAuto.tipo.ToString() };

            Console.Clear();
            Tabla.PrintLine();
            Tabla.PrintRow(columnas);
            Tabla.PrintLine();
            Tabla.PrintRow(auto);
            Tabla.PrintLine();

            var miCamioneta = new Vagoneta(50, 8, 2, "XBFG430", "NISSAN", 2079, 500_000, Tipos.Camioneta.ToString());

            columnas = new string[] { "No. Serie", "Marca", "Año", "Precio", "Carga", "Ejes", "Rodadas", "Tipo" };
            auto = new string[] { miCamioneta.noSerie.ToString(), miCamioneta.marca.ToString(), miCamioneta.anno.ToString(), "$" + miCamioneta.precio.ToString("N"), miCamioneta.cargaKGS.ToString() + "Kgs", miCamioneta.ejes.ToString(), miCamioneta.rodadas.ToString(), miCamioneta.tipo.ToString() };

            Tabla.PrintLine();
            Tabla.PrintRow(columnas);
            Tabla.PrintLine();
            Tabla.PrintRow(auto);
            Tabla.PrintLine();
        }
    }
    abstract class Vehiculo
    {
        public string noSerie { get; set; }
        public string marca { get; set; }
        public int anno { get; set; }
        public double precio { get; set; }
        public string tipo { get; set; }

        protected Vehiculo(string noSerie, string marca, int anno, double precio, string tipo)
        {
            this.noSerie = noSerie;
            this.marca = marca;
            this.anno = anno;
            this.precio = precio;
            this.tipo = tipo;
        }
    }

    class Auto : Vehiculo
    {
        public int cantidadPasajeros { get; set; }

        public Auto(int cantidadPasajeros, string noSerie, string marca, int anno, double precio, string tipo) :
            base(noSerie, marca, anno, precio, tipo)
        {
            this.cantidadPasajeros = cantidadPasajeros;
        }


    }
    class Vagoneta : Vehiculo
    {
        public double cargaKGS { get; set; }
        public int ejes { get; set; }
        public int rodadas { get; set; }

        public Vagoneta(double cargaKGS, int ejes, int rodadas, string noSerie, string marca, int anno, double precio, string tipo) :
            base(noSerie, marca, anno, precio, tipo)
        {
            this.cargaKGS = cargaKGS;
            this.ejes = ejes;
            this.rodadas = rodadas;
        }
    }

    enum Tipos
    {
        Compacto,
        Lujo,
        Camioneta,
        Vagoneta
    }

    static class Tabla
    {
        private static int tableWidth = 100;
        public static void PrintLine() => Console.WriteLine(new string('-', tableWidth));
        public static void PrintRow(params string[] columns)
        {
            var width = (tableWidth - columns.Length) / columns.Length;
            var row = "|";

            foreach (string column in columns)
                row += AlignCentre(column, width) + "|";

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
                return new string(' ', width);
            else
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}