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
        public event EventHandler<NewVentEventArgs> CreateEvent;
        public event EventHandler<NewVentEventArgs> CalculateEvent;
        public event EventHandler<NewVentEventArgs> SaveEvent;

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
                CreateEvent?.Invoke(this, new NewVentEventArgs($"Аппарат создан {CurrentVenturi.Name}"));
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
            CalculateEvent?.Invoke(this, new NewVentEventArgs($"Аппарат расcчитан"));
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
            int index = CheckClass.ParseInt("Аппарат");
            var vent = Venturis[index-1];
            var ventIn = vent.Value;
            Console.WriteLine($"Имя: {vent.Name}");
            Console.WriteLine($"Дата создания: {vent.BirthayDate}");
            Console.WriteLine($"Параметры:\n\nРасход воздуха, м3/ч. на входе: {ventIn.AirVolumeIn}. На выходе: {ventIn.AirVolumeOut}");
            Console.WriteLine($"Температура газа, град.цельс. на входе: {ventIn.TempuratureIn}. На выходе: {ventIn.TempuratureOut}");
            Console.WriteLine($"Плотность орошения, м3/м3.: {ventIn.GasLiqDensity}");
            Console.WriteLine($"Скорость в сопле, м/с.: {ventIn.SpeedInThroat}");
            Console.WriteLine($"Перепад давления при орошении, Па.: {ventIn.PressureInWetThroat}");
            Console.WriteLine("\n\n");
            Console.WriteLine($"Материал изготовления: {ventIn.Material}");
            Console.WriteLine($"Диаметр входного газохода, мм: {ventIn.DiamTubeIn}");
            Console.WriteLine($"Диаметр сопла, мм: {ventIn.DiamThroat}");
            Console.WriteLine($"Длина сопла, мм: {ventIn.LengthThroat}");
            Console.WriteLine($"Диаметр конффузора и диффузора, мм: {ventIn.DiamConfandDiff}");
            Console.WriteLine($"Длина конффузора, мм: {ventIn.LengthConf}");
            Console.WriteLine($"Длина диффузора, мм: {ventIn.LengthDif}");
            Console.WriteLine($"Диаметр  каплиуловителя, мм: {ventIn.DiamBoil}");
            Console.WriteLine($"Длина каплиуловителя, мм: {ventIn.LengthBoil}");
        }
        public void Delete()
        {
            int index = CheckClass.ParseInt("Аппарат для удаления.");
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
         public  void Save()
        {
           SaveEvent?.Invoke(this, new NewVentEventArgs("Аппарат сохранен"));
           Save(Venturis);
        }
    }
}
