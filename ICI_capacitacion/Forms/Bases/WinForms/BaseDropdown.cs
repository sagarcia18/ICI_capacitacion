using Form = System.Windows.Forms.Form;
using ICIFil = ICI_capacitacion.Utilities.File_Utils;

namespace ICI_capacitacion.Forms.Base
{
    public partial class BaseDropdown : Form
    {
        //Form properties
        private List<string> Keys;
        private List<object> Values;
        private int DefaultIndex;
        public BaseDropdown(List<string> keys, List<object> values, string title, string message, int defaultIndex = -1)
        {
            InitializeComponent();
            ICIFil.SetFormatIcon(this);

            this.Text = title;
            this.labelMessage.Text = message;
            this.Keys = keys;
            this.Values = values;
            this.DefaultIndex = defaultIndex;
            this.DialogResult = DialogResult.Cancel;
            this.Tag = null;

            PopulateCombobox();

        }

        public void PopulateCombobox()
        {
            // Repopulate the ComboBox with the provided keys when necessary
            this.comboBox.Items.Clear();
            foreach (var key in this.Keys)
            {
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
                    this.comboBox.SelectedIndex = -1; // No selection{ }
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.comboBox.SelectedIndex >= 0 && this.comboBox.SelectedIndex < Values.Count)
            {
                var selectedValue = this.Values[this.comboBox.SelectedIndex];

                this.Tag = selectedValue;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
