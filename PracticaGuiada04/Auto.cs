using System;

namespace Ejercicios.PracticaGuiada04
{
    class Auto
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        protected double velocidad;

        public Auto()
        {
            this.marca = string.Empty;
            this.modelo = string.Empty;
            this.color = string.Empty;
            this.velocidad = 0d;
        }
        public Auto(string marca, string modelo, string color)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.color = color;
            this.velocidad = 0d;
        }

        public string Encender() => "Encendido";
        public string Apagar() => "Apagado";
        public void Acelerar(double velocidad) => this.velocidad += velocidad;
        public void Desacelerar(double velocidad) => this.velocidad -= velocidad;
        public void Frenar() => this.velocidad = 0d;
        public double Velocidad() => this.velocidad;
        public void ImprimirVelocidad() => Console.WriteLine("La velocidad es: {0}km/h", this.velocidad);
    }
}
