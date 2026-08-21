using System;
using System.Linq;
using ICI_capacitacion.Utilities;

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

        /// <summary>
        /// Parses the type's nominal diameter (in inches) from its name. Accepts a whole/decimal
        /// number (4", 2.5"), a bare fraction (3/4"), or a mixed number (1 1/2"). Returns null if
        /// the name doesn't contain any of these.
        /// </summary>
        public static double? Ext_ParseDiameter(this FamilySymbol symbol)
        {
            return DiameterParsing.ParseFirst(symbol.Name);
        }

        /// <summary>
        /// Finds the family type whose name-encoded diameter (see Ext_ParseDiameter) best matches
        /// the given pipe diameter (inches): an exact match if available, otherwise the closest type
        /// with a diameter greater than the pipe's, otherwise the largest type available.
        /// Returns null if no type in the family has a parseable diameter.
        /// </summary>
        public static FamilySymbol Ext_SymbolByDiameter(this Family family, Document doc, double diameterInches)
        {
            var symbols = family.GetFamilySymbolIds()
                .Select(id => doc.GetElement(id) as FamilySymbol)
                .Where(symbol => symbol != null)
                .Select(symbol => (Symbol: symbol, Diameter: symbol.Ext_ParseDiameter()))
                .Where(entry => entry.Diameter.HasValue)
                .Select(entry => (entry.Symbol, Diameter: entry.Diameter.Value))
                .ToList();

            if (symbols.Count == 0)
            {
                return null;
            }

            var exact = symbols.FirstOrDefault(entry => Math.Abs(entry.Diameter - diameterInches) < 0.001);
            if (exact.Symbol != null)
            {
                return exact.Symbol;
            }

            var closestGreater = symbols
                .Where(entry => entry.Diameter > diameterInches)
                .OrderBy(entry => entry.Diameter)
                .FirstOrDefault();
            if (closestGreater.Symbol != null)
            {
                return closestGreater.Symbol;
            }

            // No type covers the pipe's diameter: fall back to the largest one available.
            return symbols.OrderByDescending(entry => entry.Diameter).First().Symbol;
        }
    }
}
