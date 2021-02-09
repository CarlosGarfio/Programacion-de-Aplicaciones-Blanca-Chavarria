using System;
namespace Ejercicios.PracticaGuiada04
{
    class Program
    {
        static void Main1(string[] args)
        {
            var auto = new Auto("Dodge", "Charger 97", "Naranga");

            Console.WriteLine("La informacion del auto es:");
            Console.WriteLine("Marca: {0}", auto.marca);
            Console.WriteLine("Modelo: {0}", auto.modelo);
            Console.WriteLine("Color: {0}", auto.color);

            auto.Encender();
            Console.WriteLine("El auto esta encendido");

            auto.Acelerar(50d);
            auto.ImprimirVelocidad();
            auto.Desacelerar(30d);
            auto.ImprimirVelocidad();
            auto.Frenar();

            auto.Apagar();
            Console.WriteLine("El auto esta apagado");

        }
    }
}