using Autodesk.Revit.DB.Visual;
using System;
using System.Windows.Media.Animation;
using Form = System.Windows.Forms.Form;
using ICIFil = ICI_capacitacion.Utilities.File_Utils;
using ICIFrm = ICI_capacitacion.Forms;
using Color = System.Drawing.Color;
using baseFrm = ICI_capacitacion.Forms.Base;
using ICI_capacitacion.Forms.Base;
using System.Diagnostics;
using Autodesk.Revit.UI;

namespace ICI_capacitacion.Forms.Hanger
{
    public partial class HangerSelection : Form
    {
        private List<string> Keys;
        private List<object> Values;
        private int DefaultIndex;
        public HangerSelection(List<string> keys, List<object> values, string title, string message, int defaultIndex = -1)
        {
            InitializeComponent();
            ICIFil.SetFormatIcon(this);

            this.Text = title;
            this.Keys = keys;
            this.Values = values;
            this.DefaultIndex = defaultIndex;
            this.DialogResult = DialogResult.Cancel;
            this.Tag = null;

            PopulateCombobox();

            rButtonMetrica.CheckedChanged += RadioButtonUnit_CheckedChanged;
            rButtonImperial.CheckedChanged += RadioButtonUnit_CheckedChanged;
            UpdateUnitLabels();
        }

        private void RadioButtonUnit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUnitLabels();
        }

        private void UpdateUnitLabels()
        {
            string unit = rButtonImperial.Checked ? "ft" : "m";
            unidad.Text = unit;
            unidad2.Text = unit;
        }

        private void PopulateCombobox()
        {
            // Repopulate the ComboBox with the provided keys when necessary
            this.comboBox.Items.Clear();
            foreach (var key in this.Keys)
            {
                comboBox.DrawItem += comboBox_DrawItem;
                this.comboBox.Items.Add(key);
            }
            if (DefaultIndex >= 0 && DefaultIndex < Keys.Count)
            {
                this.comboBox.SelectedIndex = DefaultIndex;
            }
            else
            {
                try
                {
                    this.comboBox.SelectedIndex = 0; // Default to the first item if no valid default index is provided
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Handle the case where the ComboBox is empty
                    this.comboBox.SelectedIndex = -1; // No selection
                }
            }
        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            string text = comboBox.Items[e.Index].ToString();

            // e.ForeColor can come back as Color.Empty (fully transparent) when WinForms
            // draws the closed/edit portion of an owner-drawn ComboBox, so fall back to
            // the control's own colors instead of trusting it blindly.
            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? SystemColors.HighlightText
                : comboBox.ForeColor;

            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    text,
                    e.Font,
                    brush,
                    e.Bounds);
            }

            e.DrawFocusRectangle();
        }
        private void HangerSelection_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (!TryParseDistance(aExtremos.Text, out double endOffset))
            {
                ICIFrm.Custom.Error("La distancia a los extremos debe ser un número mayor a 0 y menor a 99.");
                return;
            }

            if (!TryParseDistance(entreSoportes.Text, out double spacing))
            {
                ICIFrm.Custom.Error("La distancia entre soportes debe ser un número mayor a 0 y menor a 99.");
                return;
            }

            if (this.comboBox.SelectedIndex >= 0 && this.comboBox.SelectedIndex < Values.Count)
            {
                var selectedFamily = this.Values[this.comboBox.SelectedIndex] as Family;

                bool isImperial = rButtonImperial.Checked;
                var unit = isImperial ? UnitTypeId.Feet : UnitTypeId.Meters;
                double endOffsetFeet = UnitUtils.ConvertToInternalUnits(endOffset, unit);
                double spacingFeet = UnitUtils.ConvertToInternalUnits(spacing, unit);

                this.Tag = new HangerFormResult(selectedFamily, endOffsetFeet, spacingFeet, isImperial);
                this.DialogResult = DialogResult.OK;
            }
        }

        private static bool TryParseDistance(string text, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (!double.TryParse(text, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out value))
                return false;

            return value > 0 && value < 99;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
