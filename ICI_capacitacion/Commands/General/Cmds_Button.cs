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

            //Select a revision

            var revisionResult = doc.Ext_SelectRevision();

            if (revisionResult.Cancelled)
            {
                return Result.Cancelled;
            }
            var selectedRevision = revisionResult.Object as Revision;

            ICIFrm.Custom.Message(message: selectedRevision.Ext_ToRevisionKey());
            return Result.Succeeded;

            // Final return
        }
    }
}