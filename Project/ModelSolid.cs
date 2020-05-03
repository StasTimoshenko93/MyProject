using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project
{
    class ModelSolid
    {
        
        public string PartName { get; set; } = "Partname";
        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;
        bool status;
        string defaultPartTemplate;
        public ModelSolid(Venturi obj)
        {
            
        }
        public void CreatePart()
        {
            string guild = Guid.NewGuid().ToString();
            string root = @"C:\Users\timos\source\Project\Solution\Project\VenturiPart\" + guild;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            else
            {
                throw new ArgumentException("Чертеж уже существует.");
            }

            swApp = GetSolidWorks.GetApplication();

            defaultPartTemplate = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);
            swApp.NewDocument(defaultPartTemplate, 0, 0, 0);
            swModel = (ModelDoc2)swApp.ActiveDoc;

            swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.CreateCenterLine(0.000000, 0.000000, 0.000000, -0.173611, 0.000000, 0.000000);
            swModel.SketchManager.CreateLine(0.000000, -0.026016, 0.000000, -0.039342, -0.026016, 0.000000);
            swModel.SketchManager.CreateLine(-0.039342, -0.026016, 0.000000, -0.075130, -0.007488, 0.000000);
            swModel.SketchManager.CreateLine(-0.075130, -0.007488, 0.000000, -0.092897, -0.007488, 0.000000);
            swModel.SketchManager.CreateLine(-0.092897, -0.007488, 0.000000, -0.173611, -0.026016, 0.000000);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Point8", "SKETCHPOINT", -0.17361079172679997, -0.026016237064323086, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point2", "SKETCHPOINT", -0.17361079172679997, 0, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICALPOINTS2D");
            swModel.Extension.SelectByID2("Point4", "SKETCHPOINT", 0, -0.026016237064323086, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point1", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICALPOINTS2D");
            swModel.Extension.SelectByID2("Point4", "SKETCHPOINT", 0, -0.026016237064323086, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point1", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swModel.ClearSelection2(true);
            swModel.FeatureManager.FeatureRevolve2(true, true, true, false, false, false, 0, 0, 6.2831853071796004, 0, false, false, 0.01, 0.01, 0, 0.005, 0.01, true, true, true);
            swModel.ISelectionManager.EnableContourSelection = false;
            swModel.ViewZoomtofit2();
            swModel.ForceRebuild3(true);
            swModel.SaveAs("1.SPLDRT");
            swApp = null;
        }
    }
}
