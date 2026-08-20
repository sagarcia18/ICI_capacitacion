using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI_capacitacion.Extensions
{
    public static class Revision_Ext
    {
        public static string Ext_ToRevisionKey(this Revision revision, bool includeId = false)
        {
            if (revision is null)
            {
                return "Revision cannot be null.";
            }
            if (includeId)
            {
                return $"{revision.SequenceNumber}: {revision.RevisionDate} - {revision.Description} [{revision.Id.ToString()}]";
            }
            else
            {
                return $"{revision.SequenceNumber}: {revision.RevisionDate} - {revision.Description}";
            }
        }
    }
}
