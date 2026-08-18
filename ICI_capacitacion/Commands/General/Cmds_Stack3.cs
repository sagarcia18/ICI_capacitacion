using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

using Nice3point.Revit.Toolkit.External;

using ICIFrm = ICI_capacitacion.Forms;

//Associate with general commands
namespace ICI_capacitacion.Cmds_Stack3
{
    //Example command
    [Transaction(TransactionMode.Manual)]
    public class Cmd_Button : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Collect the document, the variable in the Interface gives us access to the uiApp
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Code logic here
            TaskDialog.Show("It works!", doc.Title);
            // Final return
            return Result.Succeeded;
        }
    }
}