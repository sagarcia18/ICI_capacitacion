using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI_capacitacion.Extensions
{
    public static class Document_Ext
    {
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
    }
}
