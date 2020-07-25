namespace ANS
{
    partial class FormCreate
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonCreate = new System.Windows.Forms.Button();
            this.ImageDimension = new System.Windows.Forms.NumericUpDown();
            this.LabelLayers = new System.Windows.Forms.Label();
            this.PictureDimension = new System.Windows.Forms.NumericUpDown();
            this.LabelLinks = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.LabelText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDimension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDimension)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(315, 184);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonCreate
            // 
            this.ButtonCreate.Location = new System.Drawing.Point(234, 184);
            this.ButtonCreate.Name = "ButtonCreate";
            this.ButtonCreate.Size = new System.Drawing.Size(75, 23);
            this.ButtonCreate.TabIndex = 10;
            this.ButtonCreate.Text = "Создать";
            this.ButtonCreate.UseVisualStyleBackColor = true;
            this.ButtonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // ImageDimension
            // 
            this.ImageDimension.Location = new System.Drawing.Point(223, 131);
            this.ImageDimension.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ImageDimension.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ImageDimension.Name = "ImageDimension";
            this.ImageDimension.Size = new System.Drawing.Size(167, 20);
            this.ImageDimension.TabIndex = 8;
            this.ImageDimension.Value = new decimal(new int[] {
            196,
            0,
            0,
            0});
            // 
            // LabelLayers
            // 
            this.LabelLayers.Location = new System.Drawing.Point(12, 133);
            this.LabelLayers.Name = "LabelLayers";
            this.LabelLayers.Size = new System.Drawing.Size(205, 15);
            this.LabelLayers.TabIndex = 12;
            this.LabelLayers.Text = "Количество нейронов в нижнем слое:";
            // 
            // PictureDimension
            // 
            this.PictureDimension.Location = new System.Drawing.Point(223, 105);
            this.PictureDimension.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.PictureDimension.Minimum = new decimal(new int[] {
            121,
            0,
            0,
            0});
            this.PictureDimension.Name = "PictureDimension";
            this.PictureDimension.Size = new System.Drawing.Size(167, 20);
            this.PictureDimension.TabIndex = 6;
            this.PictureDimension.Value = new decimal(new int[] {
            196,
            0,
            0,
            0});
            // 
            // LabelLinks
            // 
            this.LabelLinks.Location = new System.Drawing.Point(12, 107);
            this.LabelLinks.Name = "LabelLinks";
            this.LabelLinks.Size = new System.Drawing.Size(205, 15);
            this.LabelLinks.TabIndex = 9;
            this.LabelLinks.Text = "Ширина (высота) изображения:";
            // 
            // LabelName
            // 
            this.LabelName.Location = new System.Drawing.Point(12, 82);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(205, 15);
            this.LabelName.TabIndex = 7;
            this.LabelName.Text = "Имя (необязательно):";
            // 
            // TextName
            // 
            this.TextName.Location = new System.Drawing.Point(223, 79);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(167, 20);
            this.TextName.TabIndex = 5;
            this.TextName.Text = "Lambda";
            // 
            // LabelText
            // 
            this.LabelText.Location = new System.Drawing.Point(12, 9);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(383, 45);
            this.LabelText.TabIndex = 13;
            this.LabelText.Text = "Заполните все необходимые поля для создания новой нейронной сети. Рекомендуется, " +
                "чтобы корень из количества нейронов в нижнем слое был целым и делил длину сторон" +
                "ы изображения нацело.";
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(407, 219);
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonCreate);
            this.Controls.Add(this.ImageDimension);
            this.Controls.Add(this.LabelLayers);
            this.Controls.Add(this.PictureDimension);
            this.Controls.Add(this.LabelLinks);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.TextName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание нейронной сети";
            ((System.ComponentModel.ISupportInitialize)(this.ImageDimension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDimension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ButtonCancel;
        public System.Windows.Forms.Button ButtonCreate;
        public System.Windows.Forms.NumericUpDown ImageDimension;
        private System.Windows.Forms.Label LabelLayers;
        public System.Windows.Forms.NumericUpDown PictureDimension;
        private System.Windows.Forms.Label LabelLinks;
        private System.Windows.Forms.Label LabelName;
        public System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.Label LabelText;
    }
}