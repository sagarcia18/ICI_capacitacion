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

            // Collec all walls
            var walls = new FilteredElementCollector(doc)
                .OfClass(typeof(Wall))
                .WhereElementIsNotElementType()
                .ToElements();



            TaskDialog.Show(doc.Title, $"We have {walls.Count} walls in the model.");

            //Construct a filter
            var parameterId = new ElementId(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
            var provider = new ParameterValueProvider(parameterId);
            var rule = new FilterNumericLess();
            var passesRule = new FilterDoubleRule(provider, rule, 12, 0.0);
            var paramFilter = new ElementParameterFilter(passesRule);

            //Collect all walls lower than 12 feet
            var wallsFiltered = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .WherePasses(paramFilter)
                .ToElements();

            TaskDialog.Show(doc.Title, $"We have {wallsFiltered.Count} small walls in the model.");

            var sheets = doc.Ext_GetSheets();
            var revisions = doc.Ext_GetRevisions();
            TaskDialog.Show(doc.Title, $"We have {sheets.Count} sheets and {revisions.Count} revisions in the model.");
           
            // Final return
            return Result.Succeeded;
        }
    }
}