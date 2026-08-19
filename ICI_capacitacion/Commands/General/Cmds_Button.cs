using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ICI_capacitacion.Extensions;
using Nice3point.Revit.Toolkit.External;

using ICIFrm = ICI_capacitacion.Forms;

//Associate with general commands
namespace ICI_capacitacion.Cmds_General
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

            //Show some forms

            ICIFrm.Custom.Message(message: "This is a simple message.");
            var yesNoResult = ICIFrm.Custom.Message(title: "Test", message: "This is a yes no message.", yesNo: true);

            if (yesNoResult.Cancelled)
            {
                return ICIFrm.Custom.Cancelled("The user cancelled the operation.");
            }

            ICIFrm.Custom.Error("The operation failed.");

            // Final return
            return ICIFrm.Custom.Completed("The operation completed successfully.");
        }
    }
}