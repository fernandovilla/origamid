namespace AgendaBolo.UI.Views.Ingredientes
{
    partial class BuscaIngrediente
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
            Windows.Forms.TextBoxFormatInteger textBoxFormatInteger1 = new Windows.Forms.TextBoxFormatInteger();
            Windows.Forms.TextBoxFormatDecimal textBoxFormatDecimal1 = new Windows.Forms.TextBoxFormatDecimal();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            textBoxFlatInteger1 = new Windows.Forms.TextBoxFlatInteger();
            textBoxFlat1 = new Windows.Forms.TextBoxFlat();
            textBox1 = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.35484F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.6451645F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 131F));
            tableLayoutPanel1.Size = new Size(1006, 721);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxFlatInteger1);
            panel1.Controls.Add(textBoxFlat1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1000, 108);
            panel1.TabIndex = 0;
            // 
            // textBoxFlatInteger1
            // 
            textBoxFormatInteger1.Emptiness = Windows.Forms.Emptiness.Zero;
            textBoxFlatInteger1.Format = textBoxFormatInteger1;
            textBoxFlatInteger1.Location = new Point(736, 56);
            textBoxFlatInteger1.Name = "textBoxFlatInteger1";
            textBoxFlatInteger1.Size = new Size(125, 27);
            textBoxFlatInteger1.TabIndex = 3;
            textBoxFlatInteger1.Text = "0";
            textBoxFlatInteger1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxFlat1
            // 
            textBoxFormatDecimal1.Emptiness = Windows.Forms.Emptiness.Zero;
            textBoxFormatDecimal1.TrailingZeros = 2;
            textBoxFlat1.Format = textBoxFormatDecimal1;
            textBoxFlat1.Location = new Point(736, 23);
            textBoxFlat1.Name = "textBoxFlat1";
            textBoxFlat1.Size = new Size(125, 27);
            textBoxFlat1.TabIndex = 2;
            textBoxFlat1.Text = "0,00";
            textBoxFlat1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.FromArgb(54, 79, 120);
            textBox1.Location = new Point(23, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(679, 30);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(54, 79, 120);
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // BuscaIngrediente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 236, 242);
            ClientSize = new Size(1006, 721);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.FromArgb(54, 79, 120);
            Name = "BuscaIngrediente";
            Text = "BuscaIngrediente";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        private Windows.Forms.TextBoxFlat textBoxFlat1;
        private Windows.Forms.TextBoxFlatInteger textBoxFlatInteger1;
    }
}