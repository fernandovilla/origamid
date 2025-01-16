namespace AgendaBolo.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Windows.Forms.TextBoxTypeFormatInteger textBoxTypeFormatInteger1 = new Windows.Forms.TextBoxTypeFormatInteger();
            Windows.Forms.TextBoxTypeFormatInteger textBoxTypeFormatInteger2 = new Windows.Forms.TextBoxTypeFormatInteger();
            textBoxInteger1 = new Windows.Forms.TextBoxInteger();
            textBoxInteger2 = new Windows.Forms.TextBoxInteger();
            SuspendLayout();
            // 
            // textBoxInteger1
            // 
            textBoxInteger1.ForeColor = Color.FromArgb(64, 64, 64);
            textBoxInteger1.Format = textBoxTypeFormatInteger1;
            textBoxInteger1.Location = new Point(22, 25);
            textBoxInteger1.Name = "textBoxInteger1";
            textBoxInteger1.Size = new Size(100, 23);
            textBoxInteger1.TabIndex = 0;
            textBoxInteger1.Text = "1";
            textBoxInteger1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxInteger2
            // 
            textBoxInteger2.ForeColor = Color.FromArgb(64, 64, 64);
            textBoxInteger2.Format = textBoxTypeFormatInteger2;
            textBoxInteger2.Location = new Point(128, 25);
            textBoxInteger2.Name = "textBoxInteger2";
            textBoxInteger2.PlaceholderText = "Informe o ID";
            textBoxInteger2.Size = new Size(100, 23);
            textBoxInteger2.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 240, 244);
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxInteger2);
            Controls.Add(textBoxInteger1);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Windows.Forms.TextBoxInteger textBoxInteger1;
        private Windows.Forms.TextBoxInteger textBoxInteger2;
    }
}
