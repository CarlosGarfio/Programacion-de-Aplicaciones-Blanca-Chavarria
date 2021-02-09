using System;

namespace Ejercicios.Ejercicio05
{
    class Program
    {
        static void Main1(string[] args)
        {
            var pantalla = new Pantalla("LG", "monster tv");

            pantalla.BajarVolumen();
            pantalla.BajarVolumen();
            pantalla.BajarVolumen();
            pantalla.BajarVolumen();
            pantalla.BajarVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();
            pantalla.SubirVolumen();

            pantalla.CambiarCanal(5);
            pantalla.CambiarCanal(10);
            pantalla.Apagar();

        }
    }
    class Pantalla
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public int canal { get; set; }
        protected int tamano { get; set; }
        public int volumen { get; set; }

        public Pantalla(string marca, string modelo)
        {
            this.canal = 1;
            this.volumen = 0;
            this.marca = marca;
            this.modelo = modelo;
            Encender();
        }

        private void Encender() => Console.WriteLine("La pantalla '{0}' esta encendida", this.modelo);
        public void Apagar() => Console.WriteLine("La pantalla '{0}' esta apagada", this.modelo);
        public void SubirVolumen()
        {
            if (this.volumen != 10)
                this.volumen++;
            ImprimirVolumen();
        }
        public void BajarVolumen()
        {
            if (this.volumen != 0)
                this.volumen--;
            ImprimirVolumen();
        }
        private void ImprimirVolumen()
        {
            if (this.volumen == 0)
            {
                Console.WriteLine("Mute");
                return;
            }

            Console.Write("Volumen ");
            for (int i = 0; i < 10; i++)
            {
                if (i < this.volumen)
                {
                    Console.Write("⌷");
                    continue;
                }

                Console.Write("-");
            }
            Console.Write("\n");
        }
        public void CambiarCanal(int canal)
        {
            if (canal < 1 || canal > 10)
                throw new ArgumentException("Fuera de rango. Rango esperado 1<->10", "canal");

            this.canal = canal;
            Console.WriteLine("Canal: {0}", this.canal);
        }
    }
}