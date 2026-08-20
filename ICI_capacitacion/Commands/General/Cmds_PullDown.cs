using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form = System.Windows.Forms;
using ICI_capacitacion.Extensions;
using ICIFrm = ICI_capacitacion.Forms;

namespace ICI_capacitacion.Cmds_PullDown

{
    //Example command
    [Transaction(TransactionMode.Manual)]
    public class Cmd_1Button: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Collect the document, the variable in the Interface gives us access to the uiApp
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;


            // Code logic here

            List<string> familieNames = ["Soporte sismorresistente", "Soporte de tipo pera"];

            var scriptResult = doc.Ext_FamilyFromList(familieNames);

            if (scriptResult.Cancelled)
            {
                return Result.Cancelled;
            }
            var hangerData = scriptResult.Object as ICIFrm.Hanger.HangerFormResult;

            var symbol = hangerData.SelectedFamily.Ext_FirstSymbol(doc);
            if (symbol is null)
            {
                ICIFrm.Custom.Error("La familia seleccionada no tiene tipos disponibles.");
                return Result.Failed;
            }

            var pipes = uiDoc.Ext_PickPipes();
            if (pipes.Count == 0)
            {
                return Result.Cancelled;
            }

            using (var tx = new Transaction(doc, "Colocar soportes de tubería"))
            {
                tx.Start();

                foreach (var pipe in pipes)
                {
                    var fractions = pipe.Ext_GetHangerFractions(hangerData.EndOffsetFeet, hangerData.SpacingFeet);
                    var angle = pipe.Ext_GetHorizontalAngle();
                    pipe.Ext_PlaceHangers(doc, symbol, fractions, angle);
                }

                tx.Commit();
            }

            return Result.Succeeded;

            // Final return
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Cmd_2Button : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Collect the document, the variable in the Interface gives us access to the uiApp
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Code logic here
            TaskDialog.Show("Button 2 worked!", doc.Title);
            // Final return
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Cmd_3Button : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Collect the document, the variable in the Interface gives us access to the uiApp
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Code logic here
            TaskDialog.Show("Button 3 worked!", doc.Title);
            // Final return
            return Result.Succeeded;
        }
    }
}
