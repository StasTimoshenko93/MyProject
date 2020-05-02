using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project
{
    class ModelSolid
    {
        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;
        bool status;
        string defaultPartTemplate;

        public void CreatePart()
        {
            string guild = Guid.NewGuid().ToString();
            string root = @"C:\\" + guild;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            else
            {
                throw new ArgumentException("Чертеж уже существует.");
            }

            swApp = GetSolidWorks.GetApplication();
        }
    }
}
