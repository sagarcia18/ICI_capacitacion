using System.Collections.Generic;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ICI_capacitacion.Utilities;

namespace ICI_capacitacion.Extensions
{
    public static class UIDocument_Ext
    {
        /// <summary>
        /// Prompts the user to select one or more pipes, restricting the pick to the Pipe category.
        /// Returns an empty list if the user cancels the selection.
        /// </summary>
        public static List<Pipe> Ext_PickPipes(this UIDocument uiDoc, string prompt = null)
        {
            prompt ??= "Seleccione las tuberías para colocar soportes";

            IList<Reference> references;
            try
            {
                references = uiDoc.Selection.PickObjects(ObjectType.Element, new PipeSelectionFilter(), prompt);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return new List<Pipe>();
            }

            var pipes = new List<Pipe>();
            foreach (var reference in references)
            {
                if (uiDoc.Document.GetElement(reference.ElementId) is Pipe pipe)
                {
                    pipes.Add(pipe);
                }
            }

            return pipes;
        }
    }
}
