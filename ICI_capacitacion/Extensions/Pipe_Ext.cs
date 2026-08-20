using System;
using System.Collections.Generic;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;

namespace ICI_capacitacion.Extensions
{
    public static class Pipe_Ext
    {
        #region Geometry

        /// <summary>
        /// Returns the pipe's location line. Pipes are always straight, Line-based elements in Revit.
        /// </summary>
        public static Line Ext_GetLocationLine(this Pipe pipe)
        {
            return (pipe.Location as LocationCurve)?.Curve as Line;
        }

        /// <summary>
        /// Returns the pipe's length, in internal (feet) units.
        /// </summary>
        public static double Ext_GetLength(this Pipe pipe)
        {
            return pipe.Ext_GetLocationLine().Length;
        }

        /// <summary>
        /// Returns the horizontal angle (radians, about Z) of the pipe's direction, measured from the X axis.
        /// Used to rotate a hanger instance so its cross-section plane matches the pipe run.
        /// </summary>
        public static double Ext_GetHorizontalAngle(this Pipe pipe)
        {
            var line = pipe.Ext_GetLocationLine();
            var direction = (line.GetEndPoint(1) - line.GetEndPoint(0)).Normalize();
            return Math.Atan2(direction.Y, direction.X);
        }

        #endregion

        #region Hanger distribution

        /// <summary>
        /// Computes the minimal, evenly-spaced set of hanger positions along the pipe, expressed as
        /// normalized fractions of the pipe length (0 = start, 1 = end).
        /// </summary>
        /// <param name="endOffsetFeet">Minimum distance from each pipe end to the nearest hanger.</param>
        /// <param name="spacingFeet">Maximum allowed distance between consecutive hangers.</param>
        public static List<double> Ext_GetHangerFractions(this Pipe pipe, double endOffsetFeet, double spacingFeet)
        {
            double length = pipe.Ext_GetLength();
            var fractions = new List<double>();

            if (length <= 2 * endOffsetFeet)
            {
                fractions.Add(0.5);
                return fractions;
            }

            double usableLength = length - 2 * endOffsetFeet;
            int segments = (int)Math.Ceiling(usableLength / spacingFeet);
            double actualSpacing = usableLength / segments;

            for (int i = 0; i <= segments; i++)
            {
                double position = endOffsetFeet + i * actualSpacing;
                fractions.Add(position / length);
            }

            return fractions;
        }

        #endregion

        #region Placement

        /// <summary>
        /// Places one instance of the given family symbol at each fraction along the pipe's length,
        /// rotated about Z to match the pipe's horizontal direction.
        /// </summary>
        public static List<FamilyInstance> Ext_PlaceHangers(this Pipe pipe, Document doc, FamilySymbol symbol,
            List<double> fractions, double angle)
        {
            if (!symbol.IsActive)
            {
                symbol.Activate();
            }

            var line = pipe.Ext_GetLocationLine();
            var level = pipe.ReferenceLevel;
            var instances = new List<FamilyInstance>();

            foreach (var fraction in fractions)
            {
                var point = line.Evaluate(fraction, true);
                var instance = doc.Create.NewFamilyInstance(point, symbol, level, StructuralType.NonStructural);

                var axis = Line.CreateBound(point, point + XYZ.BasisZ);
                ElementTransformUtils.RotateElement(doc, instance.Id, axis, angle);

                instances.Add(instance);
            }

            return instances;
        }

        #endregion
    }
}
