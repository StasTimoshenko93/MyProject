using System;

namespace Project
{
    [Serializable]
    public class ValueClass
    {

        #region Константы
        private const double C1 = 0.14;
        private const double A = 0.63;
        private const double B = 0.3;
        private const int DensityLiq = 1000;
        private const int SecondPerHour = 3600;
        private const int SpeedInTube = 10;
        private const int SpeedInBoil = 2;
        private const int TInK = 273;
        #endregion

        #region Технология
        public int AirVolumeIn { get; }
        public int TempuratureIn { get; }
        public double GasLiqDensity { get; }
        public int SpeedInThroat { get; }
        public double DesnityAir { get; }
        public double AirVolumeOut { get; }
        public double TempuratureOut { get; }
        public double ResistWetThroat { get; }
        public double PressureInDryThroat { get; }
        public double PressureInWetThroat { get; }

        #endregion

        #region Габариты
        public string Material { get; }
        public double DiamThroat { get; }

        public double LengthThroat { get; }

        public double DiamTubeIn { get; }

        public double DiamConfandDiff { get; }

        public double LengthConf { get; }

        public double LengthDif { get; }

        public double DiamBoil { get; }

        public double LengthBoil { get; }

        #endregion

        public ValueClass(int air, int tempint, double gasliqden, int speedinthroat, double densityair)
        {
            AirVolumeIn = air;
            TempuratureIn = tempint;
            GasLiqDensity = gasliqden / 1000;
            SpeedInThroat = speedinthroat;
            DesnityAir = densityair;
            TempuratureOut = SetTempOut();
            AirVolumeOut = SetVolOut();
            ResistWetThroat = SetResistWetThroat();
            PressureInDryThroat = SetPInDryThroat();
            PressureInWetThroat = SetPinWetThroat();
            Material = SetMaterial();
            DiamThroat = SetDiamThroat();
            LengthThroat = SetLengthThroat();
            DiamTubeIn = SetDiamTubeIn();
            DiamConfandDiff = SetDiamConf();
            LengthConf = SetLengthConf();
            LengthDif = SetLengthDiff();
            DiamBoil = SetDiamBoil();
            LengthBoil = SetLengthBoil();
        }

        public static ValueClass inputValue()
        {
            int AirVolumeIn = CheckClass.ParseInt("Раcход воздуха на входе м3/ч.");
            int TempuratureIn = CheckClass.ParseInt("Температуру на входе в градусах цельсия.");
            double GasLiqDensity = CheckClass.ParseDouble("Плотность орошения л/м3");
            int SpeedinThroat = CheckClass.ParseInt("Скорость в горловине м/c");
            double DensityAir = CheckClass.ParseDouble("Плотность газа при нач. температуре кг/м3");
            return new ValueClass(AirVolumeIn, TempuratureIn, GasLiqDensity, SpeedinThroat, DensityAir);
        }

        #region Расчет Технологических параметров
        private double SetTempOut()
        {
            return (0.133 - (0.0041 * GasLiqDensity)) * TempuratureIn + 35;
        }

        private double SetVolOut()
        {
            return (AirVolumeIn * (TempuratureOut + TInK)) / (TempuratureIn + TInK);
        }

        private double SetPInDryThroat()
        {
            return (Math.Pow(SpeedInThroat, 2) * C1 * DesnityAir) / 2;
        }

        private double SetResistWetThroat()
        {
            return A * C1 * Math.Pow(GasLiqDensity, -B);
        }

        private double SetPinWetThroat()
        {
            return ((C1 * DesnityAir) + (ResistWetThroat * GasLiqDensity * DensityLiq) * Math.Pow(SpeedInThroat, 2)) / 2;
        }
        #endregion

        #region Расчет механических параметров.
        private double SetDiamThroat()
        {
            return 1.13 * Math.Sqrt(AirVolumeOut / (SpeedInThroat * SecondPerHour));
        }
        private double SetLengthThroat()
        {
            return 2 * SetDiamThroat();
        }
        private double SetDiamTubeIn()
        {
            return 1.13 * Math.Sqrt(AirVolumeIn / (SpeedInTube * SecondPerHour));
        }
        private double SetDiamConf()
        {
            return 3.8 * SetDiamThroat();
        }
        private double SetLengthConf()
        {
            return ((SetDiamConf() - SetDiamThroat()) / 2) / Math.Tan(15);
        }
        private double SetLengthDiff()
        {
            return ((SetDiamConf() - SetDiamThroat()) / 2) / Math.Tan(8);
        }
        private double SetDiamBoil()
        {
            return 1.13 * Math.Pow(AirVolumeOut / (SpeedInBoil * SecondPerHour), 0.5);
        }
        private double SetLengthBoil()
        {
            return 3 * SetDiamBoil();
        }
        private string SetMaterial()
        {
            if (TempuratureIn > 200 || TempuratureOut > 100)
            {
                return "Рекомендован полипропилен.";
            }
            else
            {
                return "Рекомендована нержавеющая сталь(AISI 304, AISI 316).";
            }
        }
        #endregion
    }
}
