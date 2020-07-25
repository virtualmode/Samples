namespace ANS
{
    partial class FormPenProperties
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
            this.LabelColor = new System.Windows.Forms.Label();
            this.LabelSize = new System.Windows.Forms.Label();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.NumberSize = new System.Windows.Forms.NumericUpDown();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ComboType = new System.Windows.Forms.ComboBox();
            this.LabelType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSize)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelColor
            // 
            this.LabelColor.AutoSize = true;
            this.LabelColor.Location = new System.Drawing.Point(8, 16);
            this.LabelColor.Name = "LabelColor";
            this.LabelColor.Size = new System.Drawing.Size(35, 13);
            this.LabelColor.TabIndex = 2;
            this.LabelColor.Text = "Цвет:";
            // 
            // LabelSize
            // 
            this.LabelSize.AutoSize = true;
            this.LabelSize.Location = new System.Drawing.Point(8, 40);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(49, 13);
            this.LabelSize.TabIndex = 3;
            this.LabelSize.Text = "Размер:";
            // 
            // ButtonColor
            // 
            this.ButtonColor.BackColor = System.Drawing.Color.White;
            this.ButtonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonColor.Location = new System.Drawing.Point(119, 12);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(120, 20);
            this.ButtonColor.TabIndex = 0;
            this.ButtonColor.UseVisualStyleBackColor = false;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // NumberSize
            // 
            this.NumberSize.Location = new System.Drawing.Point(119, 38);
            this.NumberSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumberSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberSize.Name = "NumberSize";
            this.NumberSize.Size = new System.Drawing.Size(120, 20);
            this.NumberSize.TabIndex = 1;
            this.NumberSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(164, 119);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Location = new System.Drawing.Point(83, 119);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(75, 23);
            this.ButtonCreate.TabIndex = 12;
            this.ButtonCreate.Text = "Ок";
            this.ButtonCreate.UseVisualStyleBackColor = true;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ComboType
            // 
            this.ComboType.FormattingEnabled = true;
            this.ComboType.Items.AddRange(new object[] {
            "Кисть",
            "Распылитель"});
            this.ComboType.Location = new System.Drawing.Point(118, 64);
            this.ComboType.Name = "ComboType";
            this.ComboType.Size = new System.Drawing.Size(121, 21);
            this.ComboType.TabIndex = 14;
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(8, 67);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(29, 13);
            this.LabelType.TabIndex = 15;
            this.LabelType.Text = "Тип:";
            // 
            // FormPenProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(251, 153);
            this.Controls.Add(this.LabelType);
            this.Controls.Add(this.ComboType);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.NumberSize);
            this.Controls.Add(this.ButtonColor);
            this.Controls.Add(this.LabelSize);
            this.Controls.Add(this.LabelColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPenProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Параметры кисти";
            ((System.ComponentModel.ISupportInitialize)(this.NumberSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelColor;
        private System.Windows.Forms.Label LabelSize;
        public System.Windows.Forms.Button ButtonCancel;
        public System.Windows.Forms.Button ButtonCreate;
        public System.Windows.Forms.Button ButtonColor;
        public System.Windows.Forms.NumericUpDown NumberSize;
        private System.Windows.Forms.Label LabelType;
        public System.Windows.Forms.ComboBox ComboType;
    }
}