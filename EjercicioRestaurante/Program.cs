using System;
using System.Collections.Generic;

namespace Ejercicios.EjercicioRestaurante
{
    class Program
    {
        static void Main1(string[] args)
        {

            var carrito = new List<IPlatillo>();

            // Platillo fuerte
            var opcionesPlatilloFuerte = new List<Opciones>
            {
                Opciones.Cuchillo,      // si
                Opciones.Tenedor,       // si
                //Opciones.Cuchara,     // no
                //Opciones.Azucar,      // no
                Opciones.Carne,         // puede
                Opciones.Sal,           // puede
                Opciones.Pollo          // puede
            };

            var platilloFuerte = CrearPlatillo.GenerarPlatillo(Platillos.PlatilloFuerte, opcionesPlatilloFuerte);
            carrito.Add(platilloFuerte);

            // Ensalada
            var opcionesEnsalada = new List<Opciones>
            {
                Opciones.Cuchillo,      // si
                Opciones.Tenedor,       // si
                //Opciones.Cuchara,     // no
                //Opciones.Carne,       // no
                //Opciones.Azucar,      // no
                Opciones.Sal,           // puede
                Opciones.Pollo          // puede
            };

            var ensalada = CrearPlatillo.GenerarPlatillo(Platillos.Ensalada, opcionesEnsalada);
            carrito.Add(ensalada);

            // Sopa
            var opcionesSopa = new List<Opciones>
            {
                Opciones.Cuchara,       // si
                //Opciones.Cuchillo,    // no
                //Opciones.Tenedor,     // no
                //Opciones.Carne,       // no
                //Opciones.Azucar,      // no
                Opciones.Sal,           // puede
                Opciones.Pollo          // puede
            };

            var sopa = CrearPlatillo.GenerarPlatillo(Platillos.Sopa, opcionesSopa);
            carrito.Add(sopa);

            // Postre
            var opcionesPostre = new List<Opciones>
            {
                Opciones.Cuchara,       // si
                Opciones.Tenedor,       // si
                Opciones.Azucar         // si
                //Opciones.Cuchillo,    // no
                //Opciones.Carne,       // no
                //Opciones.Sal,         // no
                //Opciones.Pollo        // no
            };

            var postre = CrearPlatillo.GenerarPlatillo(Platillos.Postre, opcionesPostre);
            carrito.Add(postre);

            // Bebida
            var opcionesBebida = new List<Opciones>
            {
                Opciones.Azucar         // si
                //Opciones.Cuchara,     // no
                //Opciones.Tenedor,     // no
                //Opciones.Cuchillo,    // no
                //Opciones.Carne,       // no
                //Opciones.Sal,         // no
                //Opciones.Pollo        // no
            };

            var bebida = CrearPlatillo.GenerarPlatillo(Platillos.Bebida, opcionesBebida);
            carrito.Add(bebida);

            carrito.ForEach(item => Console.WriteLine(item.GetPlatilloTipo()));

        }
    }
    enum Platillos
    {
        PlatilloFuerte = 1,
        Ensalada = 2,
        Sopa = 3,
        Postre = 4,
        Bebida = 5
    }
    enum Opciones
    {
        Pollo = 1,
        Sal = 2,
        Cuchara = 3,
        Tenedor = 4,
        Cuchillo = 5,
        Carne = 6,
        Azucar = 7
    }
    static class CrearPlatillo
    {
        public static IPlatillo GenerarPlatillo(Platillos tipo, List<Opciones> opciones)
        {
            IPlatillo platilloBase;
            platilloBase = tipo switch
            {
                Platillos.PlatilloFuerte => new PlatilloFuerte(),
                Platillos.Ensalada => new Ensalada(),
                Platillos.Sopa => new Sopa(),
                Platillos.Postre => new Postre(),
                Platillos.Bebida => new Bebida(),
                _ => null,
            };

            IPlatillo platillo = null;

            foreach (var opcion in opciones)
            {
                if (platillo != null)
                {
                    platillo = Generar(opcion, platillo);
                    continue;
                }

                switch (opcion)
                {
                    case Opciones.Pollo:
                        platillo = new PolloDecorator(platilloBase);
                        break;
                    case Opciones.Sal:
                        platillo = new SalDecorator(platilloBase);
                        break;
                    case Opciones.Cuchara:
                        platillo = new CucharaDecorator(platilloBase);
                        break;
                    case Opciones.Tenedor:
                        platillo = new TenedorDecorator(platilloBase);
                        break;
                    case Opciones.Cuchillo:
                        platillo = new CuchilloDecorator(platilloBase);
                        break;
                    case Opciones.Carne:
                        platillo = new CarneDecorator(platilloBase);
                        break;
                    case Opciones.Azucar:
                        platillo = new AzucarDecorator(platilloBase);
                        break;
                }
            }

            return platillo;
        }

        public static IPlatillo Generar(Opciones opciones, IPlatillo aDecorar)
        {
            aDecorar = opciones switch
            {
                Opciones.Pollo => new PolloDecorator(aDecorar),
                Opciones.Sal => new SalDecorator(aDecorar),
                Opciones.Cuchara => new CucharaDecorator(aDecorar),
                Opciones.Tenedor => new TenedorDecorator(aDecorar),
                Opciones.Cuchillo => new CuchilloDecorator(aDecorar),
                Opciones.Carne => new CarneDecorator(aDecorar),
                Opciones.Azucar => new AzucarDecorator(aDecorar),
                _ => null,
            };
            return aDecorar;
        }

    }

    #region Base interface

    interface IPlatillo
    {
        string GetPlatilloTipo();
    }

    #endregion

    #region Concrete implementation

    class PlatilloFuerte : IPlatillo
    {
        public string GetPlatilloTipo() => "Platillo fuerte";
    }
    class Ensalada : IPlatillo
    {
        public string GetPlatilloTipo() => "Ensalada";
    }
    class Sopa : IPlatillo
    {
        public string GetPlatilloTipo() => "Sopa";
    }
    class Postre : IPlatillo
    {
        public string GetPlatilloTipo() => "Postre";
    }
    class Bebida : IPlatillo
    {
        public string GetPlatilloTipo() => "Bebida";
    }

    #endregion

    #region Base decorator

    class PlatilloDecorator : IPlatillo
    {
        private IPlatillo platillo;

        public PlatilloDecorator(IPlatillo platillo)
        {
            this.platillo = platillo;
        }

        public virtual string GetPlatilloTipo() => platillo.GetPlatilloTipo();
    }

    #endregion

    #region Concrete decorators

    class PolloDecorator : PlatilloDecorator
    {
        public PolloDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con pollo";

            return tipo;
        }
    }
    class SalDecorator : PlatilloDecorator
    {
        public SalDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con sal";

            return tipo;
        }
    }
    class CucharaDecorator : PlatilloDecorator
    {
        public CucharaDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con cuchara";

            return tipo;
        }
    }
    class TenedorDecorator : PlatilloDecorator
    {
        public TenedorDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con tenedor";

            return tipo;
        }
    }
    class CuchilloDecorator : PlatilloDecorator
    {
        public CuchilloDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con cuchillo";

            return tipo;
        }
    }
    class CarneDecorator : PlatilloDecorator
    {
        public CarneDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con carne";

            return tipo;
        }
    }
    class AzucarDecorator : PlatilloDecorator
    {
        public AzucarDecorator(IPlatillo platillo) : base(platillo) { }

        public override string GetPlatilloTipo()
        {
            var tipo = base.GetPlatilloTipo();

            tipo += "\r\n con azucar";

            return tipo;
        }
    }

    #endregion
}