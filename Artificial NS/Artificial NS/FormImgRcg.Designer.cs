namespace ANS
{
    partial class FormImgRcg
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
            this.components = new System.ComponentModel.Container();
            this.ContainerImgRcg = new System.Windows.Forms.ToolStripContainer();
            this.PictureNeuronet = new System.Windows.Forms.PictureBox();
            this.LabelNeuronet = new System.Windows.Forms.Label();
            this.LabelImage = new System.Windows.Forms.Label();
            this.PictureImage = new System.Windows.Forms.PictureBox();
            this.ContextMenuImgRcg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextPenProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextClear = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.ToolStripImgRcg = new System.Windows.Forms.ToolStrip();
            this.ToolCreate = new System.Windows.Forms.ToolStripButton();
            this.ToolOpen = new System.Windows.Forms.ToolStripButton();
            this.ToolSave = new System.Windows.Forms.ToolStripButton();
            this.ToolClose = new System.Windows.Forms.ToolStripButton();
            this.ToolSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolName = new System.Windows.Forms.ToolStripLabel();
            this.ToolImage = new System.Windows.Forms.ToolStripComboBox();
            this.ToolAddImage = new System.Windows.Forms.ToolStripButton();
            this.ToolDeleteImage = new System.Windows.Forms.ToolStripButton();
            this.ToolSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolImgRcg = new System.Windows.Forms.ToolStripButton();
            this.TimerRefresher = new System.Windows.Forms.Timer(this.components);
            this.ContainerImgRcg.ContentPanel.SuspendLayout();
            this.ContainerImgRcg.TopToolStripPanel.SuspendLayout();
            this.ContainerImgRcg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureNeuronet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).BeginInit();
            this.ContextMenuImgRcg.SuspendLayout();
            this.ToolStripImgRcg.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContainerImgRcg
            // 
            // 
            // ContainerImgRcg.ContentPanel
            // 
            this.ContainerImgRcg.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ContainerImgRcg.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContainerImgRcg.ContentPanel.Controls.Add(this.PictureNeuronet);
            this.ContainerImgRcg.ContentPanel.Controls.Add(this.LabelNeuronet);
            this.ContainerImgRcg.ContentPanel.Controls.Add(this.LabelImage);
            this.ContainerImgRcg.ContentPanel.Controls.Add(this.PictureImage);
            this.ContainerImgRcg.ContentPanel.Controls.Add(this.LabelStatus);
            this.ContainerImgRcg.ContentPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ContainerImgRcg.ContentPanel.Size = new System.Drawing.Size(496, 279);
            this.ContainerImgRcg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerImgRcg.Location = new System.Drawing.Point(0, 0);
            this.ContainerImgRcg.Name = "ContainerImgRcg";
            this.ContainerImgRcg.Size = new System.Drawing.Size(496, 304);
            this.ContainerImgRcg.TabIndex = 1;
            this.ContainerImgRcg.Text = "toolStripContainer1";
            // 
            // ContainerImgRcg.TopToolStripPanel
            // 
            this.ContainerImgRcg.TopToolStripPanel.Controls.Add(this.ToolStripImgRcg);
            // 
            // PictureNeuronet
            // 
            this.PictureNeuronet.BackColor = System.Drawing.Color.Black;
            this.PictureNeuronet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureNeuronet.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureNeuronet.Location = new System.Drawing.Point(220, 27);
            this.PictureNeuronet.Name = "PictureNeuronet";
            this.PictureNeuronet.Size = new System.Drawing.Size(200, 200);
            this.PictureNeuronet.TabIndex = 4;
            this.PictureNeuronet.TabStop = false;
            this.PictureNeuronet.Visible = false;
            this.PictureNeuronet.Paint += new System.Windows.Forms.PaintEventHandler(this.NNStatus_Paint);
            // 
            // LabelNeuronet
            // 
            this.LabelNeuronet.AutoSize = true;
            this.LabelNeuronet.Location = new System.Drawing.Point(217, 10);
            this.LabelNeuronet.Name = "LabelNeuronet";
            this.LabelNeuronet.Size = new System.Drawing.Size(147, 13);
            this.LabelNeuronet.TabIndex = 3;
            this.LabelNeuronet.Text = "Состояние нейронной сети:";
            this.LabelNeuronet.Visible = false;
            // 
            // LabelImage
            // 
            this.LabelImage.AutoSize = true;
            this.LabelImage.Location = new System.Drawing.Point(11, 10);
            this.LabelImage.Name = "LabelImage";
            this.LabelImage.Size = new System.Drawing.Size(42, 13);
            this.LabelImage.TabIndex = 2;
            this.LabelImage.Text = "Образ:";
            this.LabelImage.Visible = false;
            // 
            // PictureImage
            // 
            this.PictureImage.BackColor = System.Drawing.Color.Black;
            this.PictureImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureImage.ContextMenuStrip = this.ContextMenuImgRcg;
            this.PictureImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureImage.Location = new System.Drawing.Point(14, 27);
            this.PictureImage.Name = "PictureImage";
            this.PictureImage.Size = new System.Drawing.Size(200, 200);
            this.PictureImage.TabIndex = 1;
            this.PictureImage.TabStop = false;
            this.PictureImage.Visible = false;
            this.PictureImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.PictureImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Image_MouseMove);
            this.PictureImage.Paint += new System.Windows.Forms.PaintEventHandler(this.Image_Paint);
            this.PictureImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            // 
            // ContextMenuImgRcg
            // 
            this.ContextMenuImgRcg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextPenProperties,
            this.ContextSeparator1,
            this.ContextClear});
            this.ContextMenuImgRcg.Name = "ContextMenuImgRcg";
            this.ContextMenuImgRcg.Size = new System.Drawing.Size(175, 54);
            // 
            // ContextPenProperties
            // 
            this.ContextPenProperties.Name = "ContextPenProperties";
            this.ContextPenProperties.Size = new System.Drawing.Size(174, 22);
            this.ContextPenProperties.Text = "Параметры кисти";
            this.ContextPenProperties.Click += new System.EventHandler(this.ContextPenProperties_Click);
            // 
            // ContextSeparator1
            // 
            this.ContextSeparator1.Name = "ContextSeparator1";
            this.ContextSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // ContextClear
            // 
            this.ContextClear.Name = "ContextClear";
            this.ContextClear.Size = new System.Drawing.Size(174, 22);
            this.ContextClear.Text = "Очистить";
            this.ContextClear.Click += new System.EventHandler(this.ContextClear_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(11, 230);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(155, 13);
            this.LabelStatus.TabIndex = 0;
            this.LabelStatus.Text = "Нейронная сеть отсутствует.";
            // 
            // ToolStripImgRcg
            // 
            this.ToolStripImgRcg.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStripImgRcg.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripImgRcg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolCreate,
            this.ToolOpen,
            this.ToolSave,
            this.ToolClose,
            this.ToolSeparator3,
            this.ToolRefresh,
            this.ToolSeparator1,
            this.ToolName,
            this.ToolImage,
            this.ToolAddImage,
            this.ToolDeleteImage,
            this.ToolSeparator2,
            this.ToolImgRcg});
            this.ToolStripImgRcg.Location = new System.Drawing.Point(3, 0);
            this.ToolStripImgRcg.Name = "ToolStripImgRcg";
            this.ToolStripImgRcg.Padding = new System.Windows.Forms.Padding(3, 0, 2, 0);
            this.ToolStripImgRcg.Size = new System.Drawing.Size(420, 25);
            this.ToolStripImgRcg.TabIndex = 0;
            // 
            // ToolCreate
            // 
            this.ToolCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolCreate.Image = global::ANS.Properties.Resources.ImageNew;
            this.ToolCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolCreate.Name = "ToolCreate";
            this.ToolCreate.Size = new System.Drawing.Size(23, 22);
            this.ToolCreate.Text = "Создать новую нейронную сеть";
            this.ToolCreate.Click += new System.EventHandler(this.ToolCreate_Click);
            // 
            // ToolOpen
            // 
            this.ToolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolOpen.Image = global::ANS.Properties.Resources.ImageOpen;
            this.ToolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolOpen.Name = "ToolOpen";
            this.ToolOpen.Size = new System.Drawing.Size(23, 22);
            this.ToolOpen.Text = "Открыть существующую нейронную сеть";
            this.ToolOpen.Click += new System.EventHandler(this.ToolOpen_Click);
            // 
            // ToolSave
            // 
            this.ToolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolSave.Enabled = false;
            this.ToolSave.Image = global::ANS.Properties.Resources.ImageSave;
            this.ToolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolSave.Name = "ToolSave";
            this.ToolSave.Size = new System.Drawing.Size(23, 22);
            this.ToolSave.Text = "Сохранить нейронную сеть как...";
            this.ToolSave.Click += new System.EventHandler(this.ToolSave_Click);
            // 
            // ToolClose
            // 
            this.ToolClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolClose.Enabled = false;
            this.ToolClose.Image = global::ANS.Properties.Resources.ImageClose;
            this.ToolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolClose.Name = "ToolClose";
            this.ToolClose.Size = new System.Drawing.Size(23, 22);
            this.ToolClose.Text = "Закрыть нейронную сеть";
            this.ToolClose.Click += new System.EventHandler(this.ToolClose_Click);
            // 
            // ToolSeparator3
            // 
            this.ToolSeparator3.Name = "ToolSeparator3";
            this.ToolSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolRefresh
            // 
            this.ToolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolRefresh.Enabled = false;
            this.ToolRefresh.Image = global::ANS.Properties.Resources.ImageRefresh;
            this.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolRefresh.Name = "ToolRefresh";
            this.ToolRefresh.Size = new System.Drawing.Size(23, 22);
            this.ToolRefresh.Text = "Обновить";
            this.ToolRefresh.Click += new System.EventHandler(this.ToolRefresh_Click);
            // 
            // ToolSeparator1
            // 
            this.ToolSeparator1.Name = "ToolSeparator1";
            this.ToolSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolName
            // 
            this.ToolName.Enabled = false;
            this.ToolName.Name = "ToolName";
            this.ToolName.Size = new System.Drawing.Size(88, 22);
            this.ToolName.Text = "Текущий образ:";
            // 
            // ToolImage
            // 
            this.ToolImage.Enabled = false;
            this.ToolImage.Name = "ToolImage";
            this.ToolImage.Size = new System.Drawing.Size(121, 25);
            this.ToolImage.Sorted = true;
            this.ToolImage.SelectedIndexChanged += new System.EventHandler(this.ToolImage_SelectedIndexChanged);
            // 
            // ToolAddImage
            // 
            this.ToolAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolAddImage.Enabled = false;
            this.ToolAddImage.Image = global::ANS.Properties.Resources.ImageAddImg;
            this.ToolAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolAddImage.Name = "ToolAddImage";
            this.ToolAddImage.Size = new System.Drawing.Size(23, 22);
            this.ToolAddImage.Text = "Сохранить образ (обучить)";
            this.ToolAddImage.Click += new System.EventHandler(this.ToolAddImage_Click);
            // 
            // ToolDeleteImage
            // 
            this.ToolDeleteImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolDeleteImage.Enabled = false;
            this.ToolDeleteImage.Image = global::ANS.Properties.Resources.ImageDelete;
            this.ToolDeleteImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolDeleteImage.Name = "ToolDeleteImage";
            this.ToolDeleteImage.Size = new System.Drawing.Size(23, 22);
            this.ToolDeleteImage.Text = "Удалить образ";
            this.ToolDeleteImage.Click += new System.EventHandler(this.ToolDeleteImage_Click);
            // 
            // ToolSeparator2
            // 
            this.ToolSeparator2.Name = "ToolSeparator2";
            this.ToolSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolImgRcg
            // 
            this.ToolImgRcg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolImgRcg.Enabled = false;
            this.ToolImgRcg.Image = global::ANS.Properties.Resources.ImageImgRcg;
            this.ToolImgRcg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolImgRcg.Name = "ToolImgRcg";
            this.ToolImgRcg.Size = new System.Drawing.Size(23, 22);
            this.ToolImgRcg.Text = "Распознать образ";
            this.ToolImgRcg.Click += new System.EventHandler(this.ToolImgRcg_Click);
            // 
            // TimerRefresher
            // 
            this.TimerRefresher.Interval = 1;
            this.TimerRefresher.Tick += new System.EventHandler(this.TimerRefresher_Tick);
            // 
            // FormImgRcg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 304);
            this.Controls.Add(this.ContainerImgRcg);
            this.Name = "FormImgRcg";
            this.Text = "Распознавание образов";
            this.Deactivate += new System.EventHandler(this.FormImgRcg_Deactivate);
            this.Resize += new System.EventHandler(this.FormImgRcg_Resize);
            this.Activated += new System.EventHandler(this.FormImgRcg_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormImgRcg_FormClosing);
            this.ContainerImgRcg.ContentPanel.ResumeLayout(false);
            this.ContainerImgRcg.ContentPanel.PerformLayout();
            this.ContainerImgRcg.TopToolStripPanel.ResumeLayout(false);
            this.ContainerImgRcg.TopToolStripPanel.PerformLayout();
            this.ContainerImgRcg.ResumeLayout(false);
            this.ContainerImgRcg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureNeuronet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).EndInit();
            this.ContextMenuImgRcg.ResumeLayout(false);
            this.ToolStripImgRcg.ResumeLayout(false);
            this.ToolStripImgRcg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer ContainerImgRcg;
        private System.Windows.Forms.ToolStrip ToolStripImgRcg;
        private System.Windows.Forms.ToolStripButton ToolCreate;
        private System.Windows.Forms.ToolStripButton ToolOpen;
        private System.Windows.Forms.ToolStripButton ToolSave;
        private System.Windows.Forms.ToolStripSeparator ToolSeparator1;
        private System.Windows.Forms.ToolStripComboBox ToolImage;
        private System.Windows.Forms.ToolStripButton ToolAddImage;
        private System.Windows.Forms.ToolStripButton ToolDeleteImage;
        private System.Windows.Forms.ToolStripSeparator ToolSeparator2;
        private System.Windows.Forms.ToolStripButton ToolImgRcg;
        private System.Windows.Forms.ToolStripLabel ToolName;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.ToolStripButton ToolClose;
        private System.Windows.Forms.PictureBox PictureImage;
        private System.Windows.Forms.Label LabelImage;
        private System.Windows.Forms.ContextMenuStrip ContextMenuImgRcg;
        private System.Windows.Forms.ToolStripMenuItem ContextPenProperties;
        private System.Windows.Forms.ToolStripSeparator ContextSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ContextClear;
        private System.Windows.Forms.Label LabelNeuronet;
        private System.Windows.Forms.PictureBox PictureNeuronet;
        private System.Windows.Forms.ToolStripSeparator ToolSeparator3;
        private System.Windows.Forms.ToolStripButton ToolRefresh;
        private System.Windows.Forms.Timer TimerRefresher;
    }
}