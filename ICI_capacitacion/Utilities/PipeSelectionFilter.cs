using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;

namespace ICI_capacitacion.Utilities
{
    public class PipeSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Pipe;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
