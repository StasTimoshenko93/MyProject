using System;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting App = new Greeting();
            App.Hello();

            while (true)
            {
                Console.WriteLine("Выберете команду.");
                try
                {
                    App.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }           
        }
    }
}
