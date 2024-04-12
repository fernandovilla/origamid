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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new Windows.Forms.Group();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            group1 = new Windows.Forms.Group();
            group3 = new Windows.Forms.Group();
            dataGridView1 = new DataGridView();
            group2 = new Windows.Forms.Group();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            group1.SuspendLayout();
            group3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(group1, 0, 1);
            tableLayoutPanel1.Controls.Add(group2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.0793648F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.92063F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.Size = new Size(1008, 729);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(5, 5);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(998, 85);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(709, 35);
            button1.Name = "button1";
            button1.Size = new Size(97, 26);
            button1.TabIndex = 6;
            button1.Text = "Pesquisar [F3]";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.WindowFrame;
            textBox1.Location = new Point(16, 35);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(687, 26);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 2;
            label1.Text = "Código, Nome ou EAN";
            // 
            // group1
            // 
            group1.BackColor = SystemColors.Control;
            group1.Controls.Add(group3);
            group1.Dock = DockStyle.Fill;
            group1.Location = new Point(5, 100);
            group1.Margin = new Padding(5);
            group1.Name = "group1";
            group1.Size = new Size(998, 525);
            group1.TabIndex = 4;
            group1.TabStop = false;
            // 
            // group3
            // 
            group3.Controls.Add(dataGridView1);
            group3.Dock = DockStyle.Fill;
            group3.Location = new Point(1, 1);
            group3.Name = "group3";
            group3.Padding = new Padding(0);
            group3.Size = new Size(996, 523);
            group3.TabIndex = 0;
            group3.Text = "group3";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(996, 523);
            dataGridView1.TabIndex = 0;
            // 
            // group2
            // 
            group2.BackColor = SystemColors.Control;
            group2.Dock = DockStyle.Fill;
            group2.Location = new Point(5, 635);
            group2.Margin = new Padding(5);
            group2.Name = "group2";
            group2.Size = new Size(998, 89);
            group2.TabIndex = 5;
            group2.Text = "group2";
            // 
            // BuscaIngrediente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1008, 729);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BuscaIngrediente";
            Text = "BuscaIngrediente";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            group1.ResumeLayout(false);
            group3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private AgendaBolo.UI.Windows.Forms.Group groupBox1;
        private TextBox textBox1;
        private Label label1;
        private Windows.Forms.Group group1;
        private Button button1;
        private Windows.Forms.Group group2;
        private Windows.Forms.Group group3;
        private DataGridView dataGridView1;
    }
}