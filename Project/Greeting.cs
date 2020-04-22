using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Greeting
    {
        public void Hello()
        {
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine("Добрый день Вас приветствует программа для автоматического подбора аппарата ТСА.");
            Console.WriteLine("Программа включает: ");
            Console.WriteLine("Расчет Технологических параметров; ");
            Console.WriteLine("Расчет  Механических  параметров; ");
            Console.WriteLine("Авто-генерация 3d модели в SolidWorks по полученным данным;");
            Console.WriteLine("Сохранение расчетов в базу данных;\n\n");
            Console.WriteLine("Команды управления:");
            Console.WriteLine("1 - Создание нового аппарата");
            Console.WriteLine("2 - Показ существующих");
            Console.WriteLine("3 - Выход из приложения\n");
            Console.WriteLine("Начало работы.");
        }

        public void Start()
        {
            string pushButton = Console.ReadLine();

            switch (pushButton)
            {
                case "1":
                    
                    Console.WriteLine("Введите имя аппарата. Например - ТСА-10.");

                    var name = Console.ReadLine();
                    VenturiControl venturiconroler = new VenturiControl(name);
                    if (venturiconroler.IsNewVent)
                    {
                       
                        var birthday = DateTime.Now;
                        var inputvalue = ValueClass.inputValue();
                        venturiconroler.SetNewVenturiData(birthday, inputvalue);
                    }
                    break;
                case "2":
                    VenturiControl vc = new VenturiControl();
                    Console.WriteLine("Вы выбрали показ существующих аппаратов: ");
                    vc.ShowAll();
                    Console.WriteLine("Выберите действие: 1 - Показ. 2 - Удаление.");
                    string button = Console.ReadLine();
                    switch (button)
                    {
                        case "1":
                            vc.ShowSingle();
                            break;
                        case "2":
                            vc.Delete();
                            break;
                        default:
                            Console.WriteLine("Ошибка. Вводимое значение не соответствует ни одной из команд управления");
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("Вы выбрали выход из приложения.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ошибка. Вводимое значение не соответствует ни одной из команд управления");
                    break;
            }
        }
    }
}
