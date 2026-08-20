namespace ICI_capacitacion.Forms.Hanger
{
    public class HangerFormResult
    {
        public Family SelectedFamily { get; set; }
        public double EndOffsetFeet { get; set; }
        public double SpacingFeet { get; set; }
        public bool IsImperial { get; set; }

        public HangerFormResult(Family selectedFamily, double endOffsetFeet, double spacingFeet, bool isImperial)
        {
            SelectedFamily = selectedFamily;
            EndOffsetFeet = endOffsetFeet;
            SpacingFeet = spacingFeet;
            IsImperial = isImperial;
        }
    }
}
