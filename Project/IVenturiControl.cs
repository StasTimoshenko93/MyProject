using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    interface IVenturiControl
    {
        List<Venturi> GetData();
        void Save();
        void Delete();
        void SetNewVenturiData(DateTime birthday, ValueClass value);
        void ShowAll();
        void ShowSingle();
    }
}
