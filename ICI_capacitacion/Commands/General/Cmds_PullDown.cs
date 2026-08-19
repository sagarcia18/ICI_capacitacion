using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form = System.Windows.Forms;

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
            TaskDialog.Show("Button 1 worked!", doc.Title);
            // Final return
            return Result.Succeeded;
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
