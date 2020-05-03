using System;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Logger.InitLogger();
            Logger.Log.Info("Старт программы.");
            Logger.Log.Info(System.Reflection.Assembly.GetExecutingAssembly().GetName().FullName);
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
                    Logger.Log.Error(e.Message);
                    Console.WriteLine(e.Message);
                }
            }
 
        }
    }
}
