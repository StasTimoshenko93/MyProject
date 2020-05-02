using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class GetSolidWorks
    {
        private static SldWorks SwApp;

        public GetSolidWorks()
        {

        }
        internal static SldWorks GetApplication()
        {
            if (SwApp == null)
            {
                SwApp = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application")) as SldWorks;
                SwApp.Visible = true;
                return SwApp;
            }
            return SwApp;
        }
    }
}
