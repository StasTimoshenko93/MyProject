using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    [Serializable]
    public class ValueClass
    {
        // Добавить автовалидацию.
       
        // Объемный расход воздуха на входе в аппарат.
        public int AirVolumeIn { get; set; }
        //  Объемный расход воздуха на выходе в аппарат.
        public int AirVolumeOut { get; set; }
        // Материал исполнения
        public int Material { get; set; }
        // Температура на входе
        public int TempuratureIn { get; set; }
        // Температура на выходе
        public int TempuratureOut { get; set; }
        
        
        public ValueClass( int air, int air2, int mat, int tempint, int tempout)
        {
          
            AirVolumeIn = air;
            AirVolumeOut = air2;
            Material = mat;
            TempuratureIn = tempint;
            TempuratureOut = tempout;
           
        }

        public static ValueClass inputValue()
        {
            int AirVolumeIn = CheckClass.ParseInt("температуру");
            int AirVolumeOut = CheckClass.ParseInt("влажность");
            int Materialn = CheckClass.ParseInt("расход воздуха");
            int TempuratureIn = CheckClass.ParseInt("скорость в горловине");
            int TempuratureOut = CheckClass.ParseInt("скорость в горловине");
            return new ValueClass(AirVolumeIn, AirVolumeOut, Materialn,  TempuratureIn, TempuratureOut);
        }   
    }
}
