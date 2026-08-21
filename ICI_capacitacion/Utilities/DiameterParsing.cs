using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ICI_capacitacion.Utilities
{
    /// <summary>
    /// Parses nominal pipe/fitting diameters written in inches, in the "4"", "2.5"", "3/4"" or
    /// "1 1/2"" formats used both by Revit's calculated pipe size and by hanger family type names.
    /// </summary>
    public static class DiameterParsing
    {
        // Grabs the raw diameter token right before the inch mark, e.g. "4", "2.5", "3/4", "1 1/2".
        private static readonly Regex DiameterToken = new Regex(@"([\d\s/.]+)""", RegexOptions.Compiled);

        /// <summary>
        /// Finds and parses the first diameter token in the given text. Returns null if none is found.
        /// </summary>
        public static double? ParseFirst(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var match = DiameterToken.Match(text);
            if (!match.Success)
            {
                return null;
            }

            return ParseToken(match.Groups[1].Value);
        }

        /// <summary>
        /// Parses a token like "4", "2.5", "3/4" or "1 1/2" (whole part and fraction separated by
        /// a space) into a single inch value.
        /// </summary>
        private static double? ParseToken(string token)
        {
            var parts = token.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                return null;
            }

            double total = 0;
            foreach (var part in parts)
            {
                if (!TryParsePart(part, out double partValue))
                {
                    return null;
                }

                total += partValue;
            }

            return total;
        }

        private static bool TryParsePart(string part, out double value)
        {
            var fractionParts = part.Split('/');
            if (fractionParts.Length == 2)
            {
                if (double.TryParse(fractionParts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double numerator) &&
                    double.TryParse(fractionParts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double denominator) &&
                    denominator != 0)
                {
                    value = numerator / denominator;
                    return true;
                }

                value = 0;
                return false;
            }

            return double.TryParse(part, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }
    }
}
