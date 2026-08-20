using System.Linq;

namespace ICI_capacitacion.Extensions
{
    public static class Family_Ext
    {
        public static FamilySymbol Ext_FirstSymbol(this Family family, Document doc)
        {
            return family.GetFamilySymbolIds()
                .Select(id => doc.GetElement(id) as FamilySymbol)
                .FirstOrDefault(symbol => symbol != null);
        }
    }
}
