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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscaIngrediente));
            ingredienteBuscaBindingSource = new BindingSource(components);
            group1 = new Windows.Forms.Group();
            group3 = new Windows.Forms.Group();
            gridIngredientes = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantidadeEstoqueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            colFill = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            groupBox1 = new Windows.Forms.Group();
            btnPesquisa = new Button();
            txtPesquisa = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            btnNovo = new Windows.Forms.ButtonFlat();
            btnEditar = new Windows.Forms.ButtonFlat();
            btnExcluir = new Windows.Forms.ButtonFlat();
            label2 = new Label();
            group2 = new Windows.Forms.Group();
            lblRodape = new Label();
            ((System.ComponentModel.ISupportInitialize)ingredienteBuscaBindingSource).BeginInit();
            group1.SuspendLayout();
            group3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridIngredientes).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            group2.SuspendLayout();
            SuspendLayout();
            // 
            // ingredienteBuscaBindingSource
            // 
            ingredienteBuscaBindingSource.DataSource = typeof(Domain.Model.Ingredientes.IngredienteBusca);
            // 
            // group1
            // 
            group1.BackColor = SystemColors.Control;
            group1.Controls.Add(group3);
            group1.Dock = DockStyle.Fill;
            group1.Location = new Point(6, 112);
            group1.Margin = new Padding(6, 8, 6, 8);
            group1.Name = "group1";
            group1.Padding = new Padding(1, 2, 1, 2);
            group1.Size = new Size(837, 453);
            group1.TabIndex = 4;
            group1.TabStop = false;
            // 
            // group3
            // 
            group3.Controls.Add(gridIngredientes);
            group3.Dock = DockStyle.Fill;
            group3.Location = new Point(1, 2);
            group3.Margin = new Padding(3, 5, 3, 5);
            group3.Name = "group3";
            group3.Padding = new Padding(0);
            group3.Size = new Size(835, 449);
            group3.TabIndex = 0;
            group3.Text = "group3";
            // 
            // gridIngredientes
            // 
            gridIngredientes.AllowUserToAddRows = false;
            gridIngredientes.AllowUserToDeleteRows = false;
            gridIngredientes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.BackColor = SystemColors.ButtonFace;
            gridIngredientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            gridIngredientes.AutoGenerateColumns = false;
            gridIngredientes.BackgroundColor = Color.White;
            gridIngredientes.BorderStyle = BorderStyle.None;
            gridIngredientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(61, 163, 156);
            dataGridViewCellStyle9.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(68, 182, 174);
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            gridIngredientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            gridIngredientes.ColumnHeadersHeight = 24;
            gridIngredientes.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, quantidadeEstoqueDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, colFill });
            gridIngredientes.DataSource = ingredienteBuscaBindingSource;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            gridIngredientes.DefaultCellStyle = dataGridViewCellStyle13;
            gridIngredientes.Dock = DockStyle.Fill;
            gridIngredientes.EnableHeadersVisualStyles = false;
            gridIngredientes.Location = new Point(0, 0);
            gridIngredientes.Margin = new Padding(3, 5, 3, 5);
            gridIngredientes.MultiSelect = false;
            gridIngredientes.Name = "gridIngredientes";
            gridIngredientes.ReadOnly = true;
            gridIngredientes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.GrayText;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            gridIngredientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            gridIngredientes.RowHeadersWidth = 30;
            gridIngredientes.RowTemplate.Height = 25;
            gridIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridIngredientes.Size = new Size(835, 449);
            gridIngredientes.StandardTab = true;
            gridIngredientes.TabIndex = 0;
            gridIngredientes.RowEnter += gridIngredientes_RowEnter;
            gridIngredientes.Enter += gridIngredientes_Enter;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 80;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nomeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 400;
            // 
            // quantidadeEstoqueDataGridViewTextBoxColumn
            // 
            quantidadeEstoqueDataGridViewTextBoxColumn.DataPropertyName = "QuantidadeEstoque";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            quantidadeEstoqueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            quantidadeEstoqueDataGridViewTextBoxColumn.HeaderText = "Estoque";
            quantidadeEstoqueDataGridViewTextBoxColumn.Name = "quantidadeEstoqueDataGridViewTextBoxColumn";
            quantidadeEstoqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colFill
            // 
            colFill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFill.HeaderText = "";
            colFill.Name = "colFill";
            colFill.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(group1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(group2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 5, 3, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 104F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(849, 606);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 98);
            panel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(btnPesquisa);
            groupBox1.Controls.Add(txtPesquisa);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 37);
            groupBox1.Margin = new Padding(6, 8, 6, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1, 2, 1, 2);
            groupBox1.Size = new Size(843, 61);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnPesquisa
            // 
            btnPesquisa.FlatAppearance.BorderColor = Color.LightGray;
            btnPesquisa.FlatAppearance.BorderSize = 0;
            btnPesquisa.FlatStyle = FlatStyle.Flat;
            btnPesquisa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnPesquisa.ForeColor = Color.FromArgb(56, 56, 56);
            btnPesquisa.Image = (Image)resources.GetObject("btnPesquisa.Image");
            btnPesquisa.Location = new Point(720, 23);
            btnPesquisa.Margin = new Padding(3, 5, 3, 5);
            btnPesquisa.Name = "btnPesquisa";
            btnPesquisa.Size = new Size(120, 30);
            btnPesquisa.TabIndex = 6;
            btnPesquisa.Text = "Pesquisar [F3]";
            btnPesquisa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPesquisa.UseVisualStyleBackColor = false;
            btnPesquisa.Click += btnPesquisa_Click;
            // 
            // txtPesquisa
            // 
            txtPesquisa.CharacterCasing = CharacterCasing.Upper;
            txtPesquisa.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPesquisa.ForeColor = Color.FromArgb(64, 64, 64);
            txtPesquisa.Location = new Point(9, 26);
            txtPesquisa.Margin = new Padding(3, 0, 3, 0);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(705, 27);
            txtPesquisa.TabIndex = 0;
            txtPesquisa.KeyDown += txtPesquisa_KeyDown;
            txtPesquisa.KeyPress += txtPesquisa_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 7);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(225, 16);
            label1.TabIndex = 2;
            label1.Text = "Pesquisa (nome, ean ou código):";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(843, 37);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnNovo);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(btnExcluir);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(518, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(325, 37);
            panel3.TabIndex = 1;
            // 
            // btnNovo
            // 
            btnNovo.Dock = DockStyle.Right;
            btnNovo.FlatAppearance.BorderColor = Color.LightGray;
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNovo.Image = (Image)resources.GetObject("btnNovo.Image");
            btnNovo.Location = new Point(113, 0);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(69, 37);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "&Novo";
            btnNovo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Dock = DockStyle.Right;
            btnEditar.Enabled = false;
            btnEditar.FlatAppearance.BorderColor = Color.LightGray;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.Location = new Point(182, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(70, 37);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "&Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Dock = DockStyle.Right;
            btnExcluir.Enabled = false;
            btnExcluir.FlatAppearance.BorderColor = Color.LightGray;
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluir.Image = (Image)resources.GetObject("btnExcluir.Image");
            btnExcluir.Location = new Point(252, 0);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(73, 37);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "E&xcluir";
            btnExcluir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(293, 37);
            label2.TabIndex = 0;
            label2.Text = "Cadastro de Ingredientes";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // group2
            // 
            group2.Controls.Add(lblRodape);
            group2.Dock = DockStyle.Fill;
            group2.Location = new Point(3, 576);
            group2.Name = "group2";
            group2.Size = new Size(843, 27);
            group2.TabIndex = 10;
            group2.Text = "group2";
            // 
            // lblRodape
            // 
            lblRodape.Dock = DockStyle.Left;
            lblRodape.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRodape.Location = new Point(1, 1);
            lblRodape.Name = "lblRodape";
            lblRodape.Size = new Size(518, 25);
            lblRodape.TabIndex = 0;
            lblRodape.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BuscaIngrediente
            // 
            AutoScaleDimensions = new SizeF(8F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(849, 606);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3);
            Name = "BuscaIngrediente";
            Text = "BuscaIngrediente";
            Activated += BuscaIngrediente_Activated;
            ((System.ComponentModel.ISupportInitialize)ingredienteBuscaBindingSource).EndInit();
            group1.ResumeLayout(false);
            group3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridIngredientes).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            group2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource ingredienteBuscaBindingSource;
        private Windows.Forms.Group group1;
        private Windows.Forms.Group group3;
        private DataGridView gridIngredientes;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantidadeEstoqueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colFill;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Windows.Forms.Group groupBox1;
        private Button btnPesquisa;
        private TextBox txtPesquisa;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Windows.Forms.Group group2;
        private Label lblRodape;
        private Windows.Forms.ButtonFlat btnNovo;
        private Windows.Forms.ButtonFlat btnEditar;
        private Windows.Forms.ButtonFlat btnExcluir;
    }
}