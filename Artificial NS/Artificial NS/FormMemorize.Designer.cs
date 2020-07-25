namespace ANS
{
    partial class FormMemorize
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
            this.LabelText = new System.Windows.Forms.Label();
            this.ButtonRewrite = new System.Windows.Forms.Button();
            this.ButtonReteach = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GroupBoxReteach = new System.Windows.Forms.GroupBox();
            this.LabelMemoryFactor = new System.Windows.Forms.Label();
            this.TextMemoryFactor = new System.Windows.Forms.TextBox();
            this.GroupBoxReteach.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.Location = new System.Drawing.Point(12, 9);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(189, 56);
            this.LabelText.TabIndex = 0;
            this.LabelText.Text = "Образ с таким именем уже существует в базе. Выберите один из предложенных вариант" +
                "ов обучения:";
            // 
            // ButtonRewrite
            // 
            this.ButtonRewrite.Location = new System.Drawing.Point(15, 90);
            this.ButtonRewrite.Name = "ButtonRewrite";
            this.ButtonRewrite.Size = new System.Drawing.Size(180, 30);
            this.ButtonRewrite.TabIndex = 1;
            this.ButtonRewrite.Text = "Перезаписать";
            this.ButtonRewrite.UseVisualStyleBackColor = true;
            this.ButtonRewrite.Click += new System.EventHandler(this.ButtonRewrite_Click);
            // 
            // ButtonReteach
            // 
            this.ButtonReteach.Location = new System.Drawing.Point(6, 39);
            this.ButtonReteach.Name = "ButtonReteach";
            this.ButtonReteach.Size = new System.Drawing.Size(180, 30);
            this.ButtonReteach.TabIndex = 2;
            this.ButtonReteach.Text = "Переобучить";
            this.ButtonReteach.UseVisualStyleBackColor = true;
            this.ButtonReteach.Click += new System.EventHandler(this.ButtonReteach_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(15, 266);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(180, 30);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // GroupBoxReteach
            // 
            this.GroupBoxReteach.Controls.Add(this.LabelMemoryFactor);
            this.GroupBoxReteach.Controls.Add(this.TextMemoryFactor);
            this.GroupBoxReteach.Controls.Add(this.ButtonReteach);
            this.GroupBoxReteach.Location = new System.Drawing.Point(9, 126);
            this.GroupBoxReteach.Name = "GroupBoxReteach";
            this.GroupBoxReteach.Size = new System.Drawing.Size(192, 76);
            this.GroupBoxReteach.TabIndex = 4;
            this.GroupBoxReteach.TabStop = false;
            // 
            // LabelMemoryFactor
            // 
            this.LabelMemoryFactor.AutoSize = true;
            this.LabelMemoryFactor.Location = new System.Drawing.Point(6, 16);
            this.LabelMemoryFactor.Name = "LabelMemoryFactor";
            this.LabelMemoryFactor.Size = new System.Drawing.Size(120, 13);
            this.LabelMemoryFactor.TabIndex = 4;
            this.LabelMemoryFactor.Text = "Коэффициент памяти:";
            // 
            // TextMemoryFactor
            // 
            this.TextMemoryFactor.Location = new System.Drawing.Point(132, 13);
            this.TextMemoryFactor.Name = "TextMemoryFactor";
            this.TextMemoryFactor.Size = new System.Drawing.Size(54, 20);
            this.TextMemoryFactor.TabIndex = 3;
            this.TextMemoryFactor.Text = "0,6";
            this.TextMemoryFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormMemorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(210, 308);
            this.Controls.Add(this.GroupBoxReteach);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonRewrite);
            this.Controls.Add(this.LabelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMemorize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Варианты обучения";
            this.GroupBoxReteach.ResumeLayout(false);
            this.GroupBoxReteach.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Button ButtonRewrite;
        private System.Windows.Forms.Button ButtonReteach;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox GroupBoxReteach;
        private System.Windows.Forms.Label LabelMemoryFactor;
        public System.Windows.Forms.TextBox TextMemoryFactor;
    }
}