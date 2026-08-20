using Autodesk.Revit.DB.Visual;
using System;
using System.Windows.Media.Animation;
using Form = System.Windows.Forms.Form;
using ICIFil = ICI_capacitacion.Utilities.File_Utils;
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
            if (this.comboBox.SelectedIndex >= 0 && this.comboBox.SelectedIndex < Values.Count)
            {
                var selectedValue = this.Values[this.comboBox.SelectedIndex];

                this.Tag = selectedValue;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
