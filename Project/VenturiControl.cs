using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    class VenturiControl : Saver, IVenturiControl
    {

        private List<Venturi> Venturis { get; }
        public Venturi CurrentVenturi { get; }
        public bool IsNewVent { get; } = false;

        public VenturiControl()
        {
            Venturis = GetData();
        }

        public VenturiControl(string name)
        {

            Venturis = GetData();
            CurrentVenturi = Venturis.SingleOrDefault(v => v.Name == name);

            if (CurrentVenturi == null)
            {
                
                CurrentVenturi = new Venturi(name);
                Venturis.Add(CurrentVenturi);
                IsNewVent = true;
               
            }
            else
            {
                Console.WriteLine("Данный аппарат существует. Нажмите 2, чтобы посмотреть все существующие аппараты.");
            }
        }
        // Метод настрайвает данные в классе Venturi
        public async void SetNewVenturiData(DateTime birthday, ValueClass value)
        {
            CurrentVenturi.BirthayDate = birthday;
            CurrentVenturi.Value = value;
           await Task.Run(()=>Save());
        }

       
        // Метод показывает все аппараты.
        public void ShowAll()
        {
            int i = 1;
            foreach (var item in Venturis)
            {
                Console.WriteLine($"[{i++}] { item.Name}");
            }
        }

        // Метод показывает характеристики и расчет аппарата.
        public void ShowSingle ()
        {
            int index = CheckClass.ParseInt("Выберете Аппарат");
            var vent = Venturis[index-1];
            var ventIn = vent.Value;
            Console.WriteLine($"Имя: {vent.Name}");
            Console.WriteLine($"Дата создания: {vent.BirthayDate}");
            Console.WriteLine($"Параметры:\nРасход воздуха : {ventIn.AirVolumeIn}");
        }
        public void Delete()
        {
            int index = CheckClass.ParseInt("Выберете Аппарат для удаления.");
            var vent = Venturis[index - 1];
            if (vent != null)
            {
                Venturis.Remove(vent);
                Save();
            }
            else
            {
                Console.WriteLine("Данный аппарат не существует.");
            }
        }


        // Метод загрузки данных.
         public List<Venturi> GetData()
        {
            return Load<Venturi>() ?? new List<Venturi>();
        }
        // Метод Сохранения.
         public void Save()
        {
           Save(Venturis);
        }
    }
}
