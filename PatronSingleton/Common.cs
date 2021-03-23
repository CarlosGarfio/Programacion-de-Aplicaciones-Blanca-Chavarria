using System;

namespace Ejercicios.PatronSingleton
{
    public sealed class Common
    {
        private static readonly Common _instance = new Common();

        private Common()
        {
        }

        public static Common Instance => _instance;

        public void SaySomething(string message) => Console.WriteLine(message);
    }
}