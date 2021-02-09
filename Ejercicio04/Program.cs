using System;
using System.Collections.Generic;

namespace Ejercicios.Ejercicio04
{
    class Program
    {
        static void Main1(string[] args)
        {
            var vueltas = 1;
            var alumnos = new List<Alumno>();

            do
            {
                var alumno = new Alumno();
                alumno.calificacion = new double[3];
                for (int i = 0; i < alumno.calificacion.Length; i++)
                    alumno.calificacion[i] = 0d;

                Console.WriteLine("Nombre del alumno:");
                alumno.nombre = Console.ReadLine();

                var calificacionesIngresadas = 0;
                double calificacion;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Ingresa la calificacion {0} del alumno {1}", calificacionesIngresadas + 1, alumno.nombre);
                    var str = Console.ReadLine();
                    if (!EsNumero(str))
                    {
                        Console.WriteLine("Error: Solo puedes ingresar numeros.");
                        Console.WriteLine("Preciona una tecla para reintentar...");
                        Console.ReadKey();
                        continue;
                    }

                    calificacion = Convert.ToDouble(str);

                    if (calificacion < 0d || calificacion > 10d)
                    {
                        Console.WriteLine("Error: El numero no puede ser mayor a {10} o menor a {0}.");
                        Console.WriteLine("Preciona una tecla para reintentar...");
                        Console.ReadKey();
                        continue;
                    }

                    alumno.calificacion[calificacionesIngresadas] = calificacion;

                    if (calificacionesIngresadas++ == 2)
                        break;

                }
                alumnos.Add(alumno);
            } while (vueltas++ != 5);


            Console.Clear();
            Console.WriteLine("---------- Lista de alumnos ----------");
            alumnos.ForEach(a =>
            {
                Console.WriteLine("Alumno: {0}", a.nombre);
                Console.WriteLine("Calificaciones:");
                var calificaciones = string.Empty;
                for (int i = 0; i < a.calificacion.Length; i++)
                {
                    calificaciones += a.calificacion[i].ToString();
                    if (i + 1 != a.calificacion.Length)
                        calificaciones += ",";
                }
                Console.WriteLine(calificaciones);
            });
        }

        static bool EsNumero(string str)
        {
            if (int.TryParse(str, out int i))
                return true;

            if (double.TryParse(str, out double d))
                return true;

            return false;
        }

        internal class Alumno
        {
            public string nombre { get; set; }
            public double[] calificacion { get; set; }
        }
    }
}