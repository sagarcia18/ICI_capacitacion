using Form = System.Windows.Forms.Form;
namespace ICI_capacitacion.Forms.Hanger
    
{
    partial class HangerSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rButtonImperial = new System.Windows.Forms.RadioButton();
            this.rButtonMetrica = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unidad2 = new System.Windows.Forms.Label();
            this.unidad = new System.Windows.Forms.Label();
            this.entreSoportes = new System.Windows.Forms.TextBox();
            this.aExtremos = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, -9);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(133, 123);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rButtonImperial);
            this.splitContainer1.Panel1.Controls.Add(this.rButtonMetrica);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.unidad2);
            this.splitContainer1.Panel2.Controls.Add(this.unidad);
            this.splitContainer1.Panel2.Controls.Add(this.entreSoportes);
            this.splitContainer1.Panel2.Controls.Add(this.aExtremos);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(548, 258);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // rButtonImperial
            // 
            this.rButtonImperial.AutoSize = true;
            this.rButtonImperial.Location = new System.Drawing.Point(20, 98);
            this.rButtonImperial.Margin = new System.Windows.Forms.Padding(4);
            this.rButtonImperial.Name = "rButtonImperial";
            this.rButtonImperial.Size = new System.Drawing.Size(76, 20);
            this.rButtonImperial.TabIndex = 1;
            this.rButtonImperial.Text = "Imperial";
            this.rButtonImperial.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rButtonImperial.UseVisualStyleBackColor = true;
            // 
            // rButtonMetrica
            // 
            this.rButtonMetrica.AutoSize = true;
            this.rButtonMetrica.Checked = true;
            this.rButtonMetrica.Location = new System.Drawing.Point(20, 63);
            this.rButtonMetrica.Margin = new System.Windows.Forms.Padding(4);
            this.rButtonMetrica.Name = "rButtonMetrica";
            this.rButtonMetrica.Size = new System.Drawing.Size(72, 20);
            this.rButtonMetrica.TabIndex = 0;
            this.rButtonMetrica.TabStop = true;
            this.rButtonMetrica.Text = "Métrica";
            this.rButtonMetrica.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(442, 36);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distanciamiento de los soportes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Distancia entre soportes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Distancia a los extremos";
            // 
            // unidad2
            // 
            this.unidad2.AutoSize = true;
            this.unidad2.Location = new System.Drawing.Point(396, 124);
            this.unidad2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unidad2.Name = "unidad2";
            this.unidad2.Size = new System.Drawing.Size(29, 16);
            this.unidad2.TabIndex = 4;
            this.unidad2.Text = "mm";
            // 
            // unidad
            // 
            this.unidad.AutoSize = true;
            this.unidad.Location = new System.Drawing.Point(396, 71);
            this.unidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unidad.Name = "unidad";
            this.unidad.Size = new System.Drawing.Size(29, 16);
            this.unidad.TabIndex = 3;
            this.unidad.Text = "mm";
            this.unidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // entreSoportes
            // 
            this.entreSoportes.Location = new System.Drawing.Point(231, 123);
            this.entreSoportes.Margin = new System.Windows.Forms.Padding(4);
            this.entreSoportes.Name = "entreSoportes";
            this.entreSoportes.Size = new System.Drawing.Size(132, 22);
            this.entreSoportes.TabIndex = 2;
            this.entreSoportes.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // aExtremos
            // 
            this.aExtremos.Location = new System.Drawing.Point(231, 66);
            this.aExtremos.Margin = new System.Windows.Forms.Padding(4);
            this.aExtremos.Name = "aExtremos";
            this.aExtremos.Size = new System.Drawing.Size(132, 22);
            this.aExtremos.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox.BackColor = System.Drawing.Color.White;
            this.comboBox.DropDownHeight = 200;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.ForeColor = System.Drawing.Color.Black;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.IntegralHeight = false;
            this.comboBox.ItemHeight = 16;
            this.comboBox.Location = new System.Drawing.Point(8, 154);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(430, 24);
            this.comboBox.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 505);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(933, 44);
            this.flowLayoutPanel3.TabIndex = 8;
            this.flowLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel3_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Elección de familia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.Location = new System.Drawing.Point(44, 16);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.MaximumSize = new System.Drawing.Size(267, 49);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(228, 39);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Poner soportes";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Location = new System.Drawing.Point(280, 16);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.MaximumSize = new System.Drawing.Size(267, 49);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(224, 39);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.42735F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.57265F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOk, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 185);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(40, 12, 40, 12);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 71);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // HangerSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(548, 256);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HangerSelection";
            this.Opacity = 0.9D;
            this.Text = "Hanger Selection";
            this.Load += new System.EventHandler(this.HangerSelection_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton rButtonImperial;
        private RadioButton rButtonMetrica;
        private Label label1;
        private TextBox entreSoportes;
        private TextBox aExtremos;
        private SplitContainer splitContainer1;
        private Label label5;
        private Label unidad2;
        private Label unidad;
        private ComboBox comboBox;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label2;
        private Button buttonOk;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}