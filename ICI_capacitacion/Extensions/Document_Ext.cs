using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View = Autodesk.Revit.DB.View;
using ICIFrm = ICI_capacitacion.Forms;
using System.Diagnostics;

namespace ICI_capacitacion.Extensions
{
    public static class Document_Ext
    {

        #region Collector constructors
        /// <summary>
        /// Collects elements from the document.
        /// </summary>
        /// <param name="doc">The document to collect elements from. (extended)</param>
        /// <returns>A filtered element collector.</returns>
        public static FilteredElementCollector Ext_Collector(this Document doc)
        {
            return new FilteredElementCollector(doc);
        }

        /// <summary>
        /// Collects elements from the document and a specific view.
        /// </summary>
        /// <param name="doc">The document to collect elements from.(extended) </param>
        /// <param name="view">The view to collect elements from.</param>
        /// <returns>A filtered element collector.</returns>
        public static FilteredElementCollector Ext_Collector(this Document doc, View view)
        {
            return new FilteredElementCollector(doc, view.Id);
        }

        #endregion

        #region Specific collectors

        /// <summary>
        /// Collects all sheets from the document, with options to sort and include/exclude placeholder sheets.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="sorted"></param>
        /// <param name="includePlaceholders"></param>
        /// <returns></returns>
        public static List<ViewSheet> Ext_GetSheets(this Document doc, bool sorted=true, bool includePlaceholders = false)
        {
            var sheets = doc.Ext_Collector()
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>()
                .ToList();

            // Filter out placeholder sheets if includePlaceholders is false
            if (!includePlaceholders)
            {
                sheets = sheets
                    .Where(s => !s.IsPlaceholder)
                    .ToList();
            }

            //Return elements, optionally sorted by sheet number
            if (sorted)
            {
                return sheets.OrderBy(s => s.SheetNumber).ToList();
            }
            else
            {
                return sheets;
            }
        }

        public static List<Revision> Ext_GetRevisions(this Document doc, bool sorted = true)
        {
            // Collect our revisions
            var revisions = doc.Ext_Collector()
                .OfClass(typeof(Revision))
                .Cast<Revision>()
                .ToList();


            //Return elements, optionally sorted by sheet number
            if (sorted)
            {
                return revisions.OrderBy(s => s.SequenceNumber).ToList()
                    .ToList();
            }
            else
            {
                return revisions;
            }
        }

        #endregion

        #region Revit collector based Forms

        public static ICIFrm.FormResult Ext_SelectRevision(this Document doc, string title = null, 
            string message = null, bool sorted = false)
        {

            // Default values 
            title ??= "Select a Revision";
            message ??= "Select a revision from the list below:";

            // Get Revisions

            var revisions = doc.Ext_GetRevisions(sorted);

            // Process into keys and values
            var revisionKeys = revisions
                .Select(r => r.Ext_ToRevisionKey())
                .ToList();
            var values = revisions
                .Cast<object>()
                .ToList();

            //Return the cform outcome
            return ICIFrm.Custom.SelectFromDropdown(revisionKeys, values, title, message);
        }

       

        public static ICIFrm.FormResult Ext_FamilyFromList(this Document doc, 
            List<string> familyNames, string title = null, string message = null)
        {

            // Default values 
            title ??= "Select a Family";
            message ??= $"Select a family from the list below:";
            List <string> typeKeys = new List<string>();
            List<object> values = new List<object>();
            // Get Family Types

            foreach (var familyName in familyNames)
            {
                Debug.WriteLine($"Family: {familyName}");

                try
                {
                    //var familie = new FilteredElementCollector(doc)
                    //    .OfClass(typeof(Family))
                    //    .Cast<Family>()
                    //    .Where(f => f.Name.Contains(familyName) || familyName.Contains(f.Name))
                    //    .Cast<object>()
                    //    .ToList();

                    var familie = new FilteredElementCollector(doc)
                        .OfClass(typeof(Family))
                        .Cast<Family>()
                        .Where(f =>
                            f.Name.Contains(familyName) ||
                            familyName.Contains(f.Name))
                        .ToList();

                    var familieObjects = new FilteredElementCollector(doc)
                        .OfClass(typeof(Family))
                        .Cast<Family>()
                        .Where(f =>
                            f.Name.Contains(familyName) ||
                            familyName.Contains(f.Name));


                    Debug.WriteLine($"Found {familie.Count} family/families.");
                    foreach (var fO in familieObjects) {

                        
                        typeKeys.Add(fO.Name);
                        Debug.WriteLine($"Family: {typeKeys[^1]}");
                        values.Add(fO);
                        Debug.WriteLine($"Family: {values[^1]}");
                    }
                }
                catch (Exception ex)
                {
                    ICIFrm.Custom.Message("Warning", $"An error occurred while collecting families: \n {ex.Message}");
                }
                // Process into keys and values
                
                
                
            }
            //Return the form outcome
            return ICIFrm.Custom.SelectFromDropdown(typeKeys, values, true, title, message);
        }
        #endregion
    }
}
