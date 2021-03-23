namespace Ejercicios.PatronSingleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            var msg = "Probando mi singleton";
            Common.Instance.SaySomething(msg);
        }
    }
}