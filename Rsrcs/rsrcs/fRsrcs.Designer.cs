namespace rsrcs
{
  partial class fRsrcs
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRsrcs));
      this.msRsrcs = new System.Windows.Forms.MenuStrip();
      this.msFile = new System.Windows.Forms.ToolStripMenuItem();
      this.msNew = new System.Windows.Forms.ToolStripMenuItem();
      this.msOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.msSave = new System.Windows.Forms.ToolStripMenuItem();
      this.msSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.msSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.msExit = new System.Windows.Forms.ToolStripMenuItem();
      this.tcRsrcs = new System.Windows.Forms.TabControl();
      this.tpSoldiers = new System.Windows.Forms.TabPage();
      this.dgvSoldiers = new System.Windows.Forms.DataGridView();
      this.cSLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cProfession = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cMoney = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tpTasks = new System.Windows.Forms.TabPage();
      this.dgvTasks = new System.Windows.Forms.DataGridView();
      this.cTLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cTGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tpRsrcs = new System.Windows.Forms.TabPage();
      this.lGroups = new System.Windows.Forms.Label();
      this.clbGroups = new System.Windows.Forms.CheckedListBox();
      this.bUpdate = new System.Windows.Forms.Button();
      this.gbPreview = new System.Windows.Forms.GroupBox();
      this.wbPreview = new System.Windows.Forms.WebBrowser();
      this.cbMoney = new System.Windows.Forms.CheckBox();
      this.lSeparator1 = new System.Windows.Forms.Label();
      this.dtpTo = new System.Windows.Forms.DateTimePicker();
      this.lOn = new System.Windows.Forms.Label();
      this.lTopic = new System.Windows.Forms.Label();
      this.tbTopic = new System.Windows.Forms.TextBox();
      this.dtpFrom = new System.Windows.Forms.DateTimePicker();
      this.tpHelp = new System.Windows.Forms.TabPage();
      this.pbAuthor = new System.Windows.Forms.PictureBox();
      this.tbLines = new System.Windows.Forms.TextBox();
      this.lRsrcs = new System.Windows.Forms.Label();
      this.lAuthor = new System.Windows.Forms.Label();
      this.cmsSoldiers = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.msSLink = new System.Windows.Forms.ToolStripMenuItem();
      this.msSReset = new System.Windows.Forms.ToolStripMenuItem();
      this.msSDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.msColor = new System.Windows.Forms.ToolStripMenuItem();
      this.msTDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.msRsrcs.SuspendLayout();
      this.tcRsrcs.SuspendLayout();
      this.tpSoldiers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSoldiers)).BeginInit();
      this.tpTasks.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
      this.tpRsrcs.SuspendLayout();
      this.gbPreview.SuspendLayout();
      this.tpHelp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).BeginInit();
      this.cmsSoldiers.SuspendLayout();
      this.cmsTasks.SuspendLayout();
      this.SuspendLayout();
      // 
      // msRsrcs
      // 
      this.msRsrcs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile});
      this.msRsrcs.Location = new System.Drawing.Point(0, 0);
      this.msRsrcs.Name = "msRsrcs";
      this.msRsrcs.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.msRsrcs.Size = new System.Drawing.Size(792, 24);
      this.msRsrcs.TabIndex = 0;
      // 
      // msFile
      // 
      this.msFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msNew,
            this.msOpen,
            this.msSave,
            this.msSaveAs,
            this.msSeparator1,
            this.msExit});
      this.msFile.Name = "msFile";
      this.msFile.Size = new System.Drawing.Size(55, 20);
      this.msFile.Text = "Рас&ход";
      // 
      // msNew
      // 
      this.msNew.Image = global::rsrcs.Properties.Resources.iNew;
      this.msNew.Name = "msNew";
      this.msNew.Size = new System.Drawing.Size(173, 22);
      this.msNew.Text = "Соз&дать";
      this.msNew.Click += new System.EventHandler(this.msNew_Click);
      // 
      // msOpen
      // 
      this.msOpen.Image = global::rsrcs.Properties.Resources.iOpen;
      this.msOpen.Name = "msOpen";
      this.msOpen.Size = new System.Drawing.Size(173, 22);
      this.msOpen.Text = "&Открыть";
      this.msOpen.Click += new System.EventHandler(this.msOpen_Click);
      // 
      // msSave
      // 
      this.msSave.Image = global::rsrcs.Properties.Resources.iSave;
      this.msSave.Name = "msSave";
      this.msSave.Size = new System.Drawing.Size(173, 22);
      this.msSave.Text = "Со&хранить";
      this.msSave.Click += new System.EventHandler(this.msSave_Click);
      // 
      // msSaveAs
      // 
      this.msSaveAs.Name = "msSaveAs";
      this.msSaveAs.Size = new System.Drawing.Size(173, 22);
      this.msSaveAs.Text = "&Сохранить как...";
      this.msSaveAs.Click += new System.EventHandler(this.msSaveAs_Click);
      // 
      // msSeparator1
      // 
      this.msSeparator1.Name = "msSeparator1";
      this.msSeparator1.Size = new System.Drawing.Size(170, 6);
      // 
      // msExit
      // 
      this.msExit.Name = "msExit";
      this.msExit.Size = new System.Drawing.Size(173, 22);
      this.msExit.Text = "Вы&ход";
      this.msExit.Click += new System.EventHandler(this.msExit_Click);
      // 
      // tcRsrcs
      // 
      this.tcRsrcs.Controls.Add(this.tpSoldiers);
      this.tcRsrcs.Controls.Add(this.tpTasks);
      this.tcRsrcs.Controls.Add(this.tpRsrcs);
      this.tcRsrcs.Controls.Add(this.tpHelp);
      this.tcRsrcs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcRsrcs.Location = new System.Drawing.Point(0, 24);
      this.tcRsrcs.Name = "tcRsrcs";
      this.tcRsrcs.SelectedIndex = 0;
      this.tcRsrcs.Size = new System.Drawing.Size(792, 542);
      this.tcRsrcs.TabIndex = 1;
      this.tcRsrcs.SelectedIndexChanged += new System.EventHandler(this.tcRsrcs_SelectedIndexChanged);
      // 
      // tpSoldiers
      // 
      this.tpSoldiers.Controls.Add(this.dgvSoldiers);
      this.tpSoldiers.Location = new System.Drawing.Point(4, 22);
      this.tpSoldiers.Name = "tpSoldiers";
      this.tpSoldiers.Padding = new System.Windows.Forms.Padding(5);
      this.tpSoldiers.Size = new System.Drawing.Size(784, 516);
      this.tpSoldiers.TabIndex = 0;
      this.tpSoldiers.Text = "Штат";
      this.tpSoldiers.UseVisualStyleBackColor = true;
      // 
      // dgvSoldiers
      // 
      this.dgvSoldiers.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvSoldiers.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvSoldiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvSoldiers.ColumnHeadersHeight = 48;
      this.dgvSoldiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvSoldiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSLine,
            this.cProfession,
            this.cGroup,
            this.cCategory,
            this.cFIO,
            this.cMoney,
            this.cDate,
            this.cTask});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvSoldiers.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgvSoldiers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvSoldiers.Location = new System.Drawing.Point(5, 5);
      this.dgvSoldiers.Name = "dgvSoldiers";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvSoldiers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dgvSoldiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvSoldiers.Size = new System.Drawing.Size(774, 506);
      this.dgvSoldiers.TabIndex = 0;
      this.dgvSoldiers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSoldiers_CellMouseClick);
      this.dgvSoldiers.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvSoldiers_SortCompare);
      this.dgvSoldiers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSoldiers_ColumnHeaderMouseClick);
      this.dgvSoldiers.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSoldiers_RowsAdded);
      this.dgvSoldiers.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSoldiers_RowsRemoved);
      // 
      // cSLine
      // 
      this.cSLine.HeaderText = "№";
      this.cSLine.MinimumWidth = 48;
      this.cSLine.Name = "cSLine";
      this.cSLine.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.cSLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      this.cSLine.Width = 48;
      // 
      // cProfession
      // 
      this.cProfession.HeaderText = "Должность";
      this.cProfession.MinimumWidth = 128;
      this.cProfession.Name = "cProfession";
      this.cProfession.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.cProfession.Width = 128;
      // 
      // cGroup
      // 
      this.cGroup.HeaderText = "Подразделение";
      this.cGroup.MinimumWidth = 196;
      this.cGroup.Name = "cGroup";
      this.cGroup.Width = 196;
      // 
      // cCategory
      // 
      this.cCategory.HeaderText = "Звание";
      this.cCategory.MinimumWidth = 70;
      this.cCategory.Name = "cCategory";
      this.cCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.cCategory.Width = 70;
      // 
      // cFIO
      // 
      this.cFIO.HeaderText = "Ф. И. О.";
      this.cFIO.MinimumWidth = 169;
      this.cFIO.Name = "cFIO";
      this.cFIO.Width = 169;
      // 
      // cMoney
      // 
      this.cMoney.HeaderText = "Контракт";
      this.cMoney.MinimumWidth = 81;
      this.cMoney.Name = "cMoney";
      this.cMoney.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.cMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.cMoney.Width = 81;
      // 
      // cDate
      // 
      this.cDate.HeaderText = "Заметка";
      this.cDate.MinimumWidth = 110;
      this.cDate.Name = "cDate";
      this.cDate.Width = 110;
      // 
      // cTask
      // 
      this.cTask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cTask.HeaderText = "Поставленная задача";
      this.cTask.Name = "cTask";
      this.cTask.ReadOnly = true;
      this.cTask.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // tpTasks
      // 
      this.tpTasks.Controls.Add(this.dgvTasks);
      this.tpTasks.Location = new System.Drawing.Point(4, 22);
      this.tpTasks.Name = "tpTasks";
      this.tpTasks.Padding = new System.Windows.Forms.Padding(5);
      this.tpTasks.Size = new System.Drawing.Size(784, 516);
      this.tpTasks.TabIndex = 1;
      this.tpTasks.Text = "Задачи";
      this.tpTasks.UseVisualStyleBackColor = true;
      // 
      // dgvTasks
      // 
      this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgvTasks.ColumnHeadersHeight = 48;
      this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTLine,
            this.cName,
            this.cTGroup});
      this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvTasks.Location = new System.Drawing.Point(5, 5);
      this.dgvTasks.Name = "dgvTasks";
      this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvTasks.Size = new System.Drawing.Size(774, 506);
      this.dgvTasks.TabIndex = 1;
      this.dgvTasks.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTasks_CellMouseClick);
      this.dgvTasks.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvTasks_SortCompare);
      this.dgvTasks.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTasks_ColumnHeaderMouseClick);
      this.dgvTasks.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTasks_RowsAdded);
      this.dgvTasks.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTasks_RowsRemoved);
      // 
      // cTLine
      // 
      this.cTLine.HeaderText = "№";
      this.cTLine.MinimumWidth = 48;
      this.cTLine.Name = "cTLine";
      this.cTLine.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.cTLine.Width = 48;
      // 
      // cName
      // 
      this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.cName.HeaderText = "Название";
      this.cName.Name = "cName";
      // 
      // cTGroup
      // 
      this.cTGroup.HeaderText = "Группа";
      this.cTGroup.MinimumWidth = 110;
      this.cTGroup.Name = "cTGroup";
      this.cTGroup.Width = 110;
      // 
      // tpRsrcs
      // 
      this.tpRsrcs.Controls.Add(this.lGroups);
      this.tpRsrcs.Controls.Add(this.clbGroups);
      this.tpRsrcs.Controls.Add(this.bUpdate);
      this.tpRsrcs.Controls.Add(this.gbPreview);
      this.tpRsrcs.Controls.Add(this.cbMoney);
      this.tpRsrcs.Controls.Add(this.lSeparator1);
      this.tpRsrcs.Controls.Add(this.dtpTo);
      this.tpRsrcs.Controls.Add(this.lOn);
      this.tpRsrcs.Controls.Add(this.lTopic);
      this.tpRsrcs.Controls.Add(this.tbTopic);
      this.tpRsrcs.Controls.Add(this.dtpFrom);
      this.tpRsrcs.Location = new System.Drawing.Point(4, 22);
      this.tpRsrcs.Name = "tpRsrcs";
      this.tpRsrcs.Padding = new System.Windows.Forms.Padding(5);
      this.tpRsrcs.Size = new System.Drawing.Size(784, 516);
      this.tpRsrcs.TabIndex = 2;
      this.tpRsrcs.Text = "Расход";
      this.tpRsrcs.UseVisualStyleBackColor = true;
      // 
      // lGroups
      // 
      this.lGroups.AutoSize = true;
      this.lGroups.Location = new System.Drawing.Point(5, 44);
      this.lGroups.Name = "lGroups";
      this.lGroups.Size = new System.Drawing.Size(90, 13);
      this.lGroups.TabIndex = 13;
      this.lGroups.Text = "Подразделения:";
      // 
      // clbGroups
      // 
      this.clbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.clbGroups.CheckOnClick = true;
      this.clbGroups.FormattingEnabled = true;
      this.clbGroups.Location = new System.Drawing.Point(101, 43);
      this.clbGroups.Name = "clbGroups";
      this.clbGroups.Size = new System.Drawing.Size(675, 49);
      this.clbGroups.TabIndex = 12;
      // 
      // bUpdate
      // 
      this.bUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.bUpdate.Image = global::rsrcs.Properties.Resources.iRefresh;
      this.bUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.bUpdate.Location = new System.Drawing.Point(643, 102);
      this.bUpdate.Name = "bUpdate";
      this.bUpdate.Size = new System.Drawing.Size(133, 24);
      this.bUpdate.TabIndex = 10;
      this.bUpdate.Text = "Обновить";
      this.bUpdate.UseVisualStyleBackColor = true;
      this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
      // 
      // gbPreview
      // 
      this.gbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gbPreview.Controls.Add(this.wbPreview);
      this.gbPreview.Location = new System.Drawing.Point(8, 130);
      this.gbPreview.Name = "gbPreview";
      this.gbPreview.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
      this.gbPreview.Size = new System.Drawing.Size(767, 378);
      this.gbPreview.TabIndex = 9;
      this.gbPreview.TabStop = false;
      this.gbPreview.Text = "Предварительный просмотр";
      // 
      // wbPreview
      // 
      this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wbPreview.Location = new System.Drawing.Point(3, 13);
      this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
      this.wbPreview.Name = "wbPreview";
      this.wbPreview.Size = new System.Drawing.Size(761, 362);
      this.wbPreview.TabIndex = 8;
      // 
      // cbMoney
      // 
      this.cbMoney.AutoSize = true;
      this.cbMoney.Location = new System.Drawing.Point(101, 102);
      this.cbMoney.Name = "cbMoney";
      this.cbMoney.Size = new System.Drawing.Size(150, 17);
      this.cbMoney.TabIndex = 7;
      this.cbMoney.Text = "С учётом контрактников";
      this.cbMoney.UseVisualStyleBackColor = true;
      this.cbMoney.CheckedChanged += new System.EventHandler(this.cbMoney_CheckedChanged);
      // 
      // lSeparator1
      // 
      this.lSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lSeparator1.AutoSize = true;
      this.lSeparator1.Location = new System.Drawing.Point(627, 16);
      this.lSeparator1.Name = "lSeparator1";
      this.lSeparator1.Size = new System.Drawing.Size(10, 13);
      this.lSeparator1.TabIndex = 5;
      this.lSeparator1.Text = "-";
      // 
      // dtpTo
      // 
      this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpTo.Enabled = false;
      this.dtpTo.Location = new System.Drawing.Point(643, 12);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new System.Drawing.Size(132, 20);
      this.dtpTo.TabIndex = 4;
      // 
      // lOn
      // 
      this.lOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lOn.AutoSize = true;
      this.lOn.Location = new System.Drawing.Point(464, 16);
      this.lOn.Name = "lOn";
      this.lOn.Size = new System.Drawing.Size(19, 13);
      this.lOn.TabIndex = 3;
      this.lOn.Text = "на";
      // 
      // lTopic
      // 
      this.lTopic.AutoSize = true;
      this.lTopic.Location = new System.Drawing.Point(5, 15);
      this.lTopic.Name = "lTopic";
      this.lTopic.Size = new System.Drawing.Size(64, 13);
      this.lTopic.TabIndex = 2;
      this.lTopic.Text = "Заголовок:";
      // 
      // tbTopic
      // 
      this.tbTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTopic.Location = new System.Drawing.Point(101, 12);
      this.tbTopic.Name = "tbTopic";
      this.tbTopic.Size = new System.Drawing.Size(357, 20);
      this.tbTopic.TabIndex = 1;
      // 
      // dtpFrom
      // 
      this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpFrom.Location = new System.Drawing.Point(489, 12);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new System.Drawing.Size(132, 20);
      this.dtpFrom.TabIndex = 0;
      this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
      // 
      // tpHelp
      // 
      this.tpHelp.Controls.Add(this.pbAuthor);
      this.tpHelp.Controls.Add(this.tbLines);
      this.tpHelp.Controls.Add(this.lRsrcs);
      this.tpHelp.Controls.Add(this.lAuthor);
      this.tpHelp.Location = new System.Drawing.Point(4, 22);
      this.tpHelp.Name = "tpHelp";
      this.tpHelp.Size = new System.Drawing.Size(784, 516);
      this.tpHelp.TabIndex = 3;
      this.tpHelp.Text = "Справка";
      this.tpHelp.UseVisualStyleBackColor = true;
      // 
      // pbAuthor
      // 
      this.pbAuthor.Image = global::rsrcs.Properties.Resources.iSoldier;
      this.pbAuthor.Location = new System.Drawing.Point(16, 18);
      this.pbAuthor.Name = "pbAuthor";
      this.pbAuthor.Size = new System.Drawing.Size(143, 196);
      this.pbAuthor.TabIndex = 2;
      this.pbAuthor.TabStop = false;
      // 
      // tbLines
      // 
      this.tbLines.Location = new System.Drawing.Point(15, 17);
      this.tbLines.Multiline = true;
      this.tbLines.Name = "tbLines";
      this.tbLines.ReadOnly = true;
      this.tbLines.Size = new System.Drawing.Size(145, 198);
      this.tbLines.TabIndex = 3;
      // 
      // lRsrcs
      // 
      this.lRsrcs.AutoSize = true;
      this.lRsrcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lRsrcs.Location = new System.Drawing.Point(165, 15);
      this.lRsrcs.Name = "lRsrcs";
      this.lRsrcs.Size = new System.Drawing.Size(389, 20);
      this.lRsrcs.TabIndex = 1;
      this.lRsrcs.Text = "Редактор расходов (версия от 24.06.2011 г.)";
      // 
      // lAuthor
      // 
      this.lAuthor.Location = new System.Drawing.Point(166, 40);
      this.lAuthor.Name = "lAuthor";
      this.lAuthor.Size = new System.Drawing.Size(370, 174);
      this.lAuthor.TabIndex = 0;
      this.lAuthor.Text = "Автор";
      // 
      // cmsSoldiers
      // 
      this.cmsSoldiers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msSLink,
            this.msSReset,
            this.msSDelete});
      this.cmsSoldiers.Name = "cmsSoldiers";
      this.cmsSoldiers.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.cmsSoldiers.Size = new System.Drawing.Size(152, 70);
      this.cmsSoldiers.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSoldiers_Opening);
      // 
      // msSLink
      // 
      this.msSLink.Name = "msSLink";
      this.msSLink.Size = new System.Drawing.Size(151, 22);
      this.msSLink.Text = "&Назначить...";
      // 
      // msSReset
      // 
      this.msSReset.Name = "msSReset";
      this.msSReset.Size = new System.Drawing.Size(151, 22);
      this.msSReset.Text = "&Снять";
      this.msSReset.Click += new System.EventHandler(this.msSReset_Click);
      // 
      // msSDelete
      // 
      this.msSDelete.Name = "msSDelete";
      this.msSDelete.Size = new System.Drawing.Size(151, 22);
      this.msSDelete.Text = "У&далить";
      this.msSDelete.Click += new System.EventHandler(this.msSDelete_Click);
      // 
      // cmsTasks
      // 
      this.cmsTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msColor,
            this.msTDelete});
      this.cmsTasks.Name = "contextMenuStrip2";
      this.cmsTasks.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.cmsTasks.Size = new System.Drawing.Size(130, 48);
      this.cmsTasks.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTasks_Opening);
      // 
      // msColor
      // 
      this.msColor.Name = "msColor";
      this.msColor.Size = new System.Drawing.Size(129, 22);
      this.msColor.Text = "Цвет";
      this.msColor.Click += new System.EventHandler(this.msColor_Click);
      // 
      // msTDelete
      // 
      this.msTDelete.Name = "msTDelete";
      this.msTDelete.Size = new System.Drawing.Size(129, 22);
      this.msTDelete.Text = "У&далить";
      this.msTDelete.Click += new System.EventHandler(this.msTDelete_Click);
      // 
      // fRsrcs
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 566);
      this.Controls.Add(this.tcRsrcs);
      this.Controls.Add(this.msRsrcs);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.msRsrcs;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "fRsrcs";
      this.Text = "Расход (версия 1.0)";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.fRsrcs_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fRsrcs_FormClosing);
      this.msRsrcs.ResumeLayout(false);
      this.msRsrcs.PerformLayout();
      this.tcRsrcs.ResumeLayout(false);
      this.tpSoldiers.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvSoldiers)).EndInit();
      this.tpTasks.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
      this.tpRsrcs.ResumeLayout(false);
      this.tpRsrcs.PerformLayout();
      this.gbPreview.ResumeLayout(false);
      this.tpHelp.ResumeLayout(false);
      this.tpHelp.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).EndInit();
      this.cmsSoldiers.ResumeLayout(false);
      this.cmsTasks.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip msRsrcs;
    private System.Windows.Forms.ToolStripMenuItem msFile;
    private System.Windows.Forms.ToolStripMenuItem msNew;
    private System.Windows.Forms.ToolStripMenuItem msOpen;
    private System.Windows.Forms.ToolStripMenuItem msSave;
    private System.Windows.Forms.ToolStripMenuItem msSaveAs;
    private System.Windows.Forms.ToolStripSeparator msSeparator1;
    private System.Windows.Forms.ToolStripMenuItem msExit;
    private System.Windows.Forms.TabControl tcRsrcs;
    private System.Windows.Forms.TabPage tpSoldiers;
    private System.Windows.Forms.TabPage tpTasks;
    private System.Windows.Forms.DataGridView dgvSoldiers;
    private System.Windows.Forms.DataGridView dgvTasks;
    private System.Windows.Forms.TabPage tpRsrcs;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.Label lOn;
    private System.Windows.Forms.Label lTopic;
    private System.Windows.Forms.TextBox tbTopic;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.Label lSeparator1;
    private System.Windows.Forms.CheckBox cbMoney;
    private System.Windows.Forms.WebBrowser wbPreview;
    private System.Windows.Forms.GroupBox gbPreview;
    private System.Windows.Forms.ContextMenuStrip cmsSoldiers;
    private System.Windows.Forms.ContextMenuStrip cmsTasks;
    private System.Windows.Forms.ToolStripMenuItem msColor;
    private System.Windows.Forms.ToolStripMenuItem msSLink;
    private System.Windows.Forms.ToolStripMenuItem msSReset;
    private System.Windows.Forms.ToolStripMenuItem msSDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn cTLine;
    private System.Windows.Forms.DataGridViewTextBoxColumn cName;
    private System.Windows.Forms.DataGridViewTextBoxColumn cTGroup;
    private System.Windows.Forms.ToolStripMenuItem msTDelete;
    private System.Windows.Forms.Button bUpdate;
    private System.Windows.Forms.DataGridViewTextBoxColumn cSLine;
    private System.Windows.Forms.DataGridViewTextBoxColumn cProfession;
    private System.Windows.Forms.DataGridViewTextBoxColumn cGroup;
    private System.Windows.Forms.DataGridViewTextBoxColumn cCategory;
    private System.Windows.Forms.DataGridViewTextBoxColumn cFIO;
    private System.Windows.Forms.DataGridViewCheckBoxColumn cMoney;
    private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn cTask;
    private System.Windows.Forms.CheckedListBox clbGroups;
    private System.Windows.Forms.Label lGroups;
    private System.Windows.Forms.TabPage tpHelp;
    private System.Windows.Forms.Label lAuthor;
    private System.Windows.Forms.Label lRsrcs;
    private System.Windows.Forms.PictureBox pbAuthor;
    private System.Windows.Forms.TextBox tbLines;
  }
}

