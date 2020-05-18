using System;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLogger log = new MyLogger();
            log.Info("CreateProgram");
            
            Greeting App = new Greeting();
            App.Hello();

            while (true)
            {
                Console.WriteLine("\nВыберете команду.");
                try
                {
                    App.Start();
                }
                catch (Exception e)
                {
                    log.Error("Error");
                    Console.WriteLine(e.Message);
                }
            }
 
        }
    }
}
