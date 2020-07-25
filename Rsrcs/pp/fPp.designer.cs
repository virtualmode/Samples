namespace pp
{
	partial class fPp
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPp));
			this.msPp = new System.Windows.Forms.MenuStrip();
			this.mFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.mOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.mPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.mSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mSoldiers = new System.Windows.Forms.ToolStripMenuItem();
			this.mTasks = new System.Windows.Forms.ToolStripMenuItem();
			this.mWeapons = new System.Windows.Forms.ToolStripMenuItem();
			this.mMachines = new System.Windows.Forms.ToolStripMenuItem();
			this.mPaths = new System.Windows.Forms.ToolStripMenuItem();
			this.mReports = new System.Windows.Forms.ToolStripMenuItem();
			this.mHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsPp = new System.Windows.Forms.ToolStrip();
			this.tsbNew = new System.Windows.Forms.ToolStripButton();
			this.tsbOpen = new System.Windows.Forms.ToolStripButton();
			this.tssbSave = new System.Windows.Forms.ToolStripSplitButton();
			this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbPreview = new System.Windows.Forms.ToolStripButton();
			this.tsbSoldiers = new System.Windows.Forms.ToolStripButton();
			this.tsbTasks = new System.Windows.Forms.ToolStripButton();
			this.tsbWeapons = new System.Windows.Forms.ToolStripButton();
			this.tsbMachines = new System.Windows.Forms.ToolStripButton();
			this.tsbPaths = new System.Windows.Forms.ToolStripButton();
			this.tsbReport = new System.Windows.Forms.ToolStripButton();
			this.tsbHelp = new System.Windows.Forms.ToolStripButton();
			this.cmsPp = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.cbPosition = new System.Windows.Forms.ToolStripComboBox();
			this.mDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.pList = new System.Windows.Forms.Panel();
			this.scPp = new System.Windows.Forms.SplitContainer();
			this.wbReport = new System.Windows.Forms.WebBrowser();
			this.lvPp = new System.Windows.Forms.ListView();
			this.lvColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pgPp = new System.Windows.Forms.PropertyGrid();
			this.tsTools = new System.Windows.Forms.ToolStrip();
			this.lSearch = new System.Windows.Forms.ToolStripLabel();
			this.cbSearch = new System.Windows.Forms.ToolStripComboBox();
			this.cbHistory = new System.Windows.Forms.ToolStripComboBox();
			this.lHistory = new System.Windows.Forms.ToolStripLabel();
			this.pHelp = new System.Windows.Forms.Panel();
			this.tbHelp = new System.Windows.Forms.TextBox();
			this.pbAuthor = new System.Windows.Forms.PictureBox();
			this.lHelp = new System.Windows.Forms.Label();
			this.tSearch = new System.Windows.Forms.Timer(this.components);
			this.msPp.SuspendLayout();
			this.tsPp.SuspendLayout();
			this.cmsPp.SuspendLayout();
			this.pList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scPp)).BeginInit();
			this.scPp.Panel1.SuspendLayout();
			this.scPp.Panel2.SuspendLayout();
			this.scPp.SuspendLayout();
			this.tsTools.SuspendLayout();
			this.pHelp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).BeginInit();
			this.SuspendLayout();
			// 
			// msPp
			// 
			this.msPp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile});
			this.msPp.Location = new System.Drawing.Point(0, 0);
			this.msPp.Name = "msPp";
			this.msPp.Padding = new System.Windows.Forms.Padding(3, 3, 1, 4);
			this.msPp.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.msPp.Size = new System.Drawing.Size(792, 26);
			this.msPp.TabIndex = 0;
			this.msPp.Visible = false;
			// 
			// mFile
			// 
			this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCreate,
            this.mOpen,
            this.mSave,
            this.mSaveAs,
            this.mPreview,
            this.mSeparator1,
            this.mSoldiers,
            this.mTasks,
            this.mWeapons,
            this.mMachines,
            this.mPaths,
            this.mReports,
            this.mHelp,
            this.mSeparator3,
            this.mExit});
			this.mFile.Name = "mFile";
			this.mFile.Size = new System.Drawing.Size(55, 19);
			this.mFile.Text = "&Расход";
			// 
			// mCreate
			// 
			this.mCreate.Image = global::pp.Properties.Resources.iNew;
			this.mCreate.Name = "mCreate";
			this.mCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mCreate.Size = new System.Drawing.Size(202, 22);
			this.mCreate.Text = "Создать";
			this.mCreate.Click += new System.EventHandler(this.mCreate_Click);
			// 
			// mOpen
			// 
			this.mOpen.Image = global::pp.Properties.Resources.iOpen;
			this.mOpen.Name = "mOpen";
			this.mOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mOpen.Size = new System.Drawing.Size(202, 22);
			this.mOpen.Text = "Открыть";
			this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
			// 
			// mSave
			// 
			this.mSave.Image = global::pp.Properties.Resources.iSave;
			this.mSave.Name = "mSave";
			this.mSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mSave.Size = new System.Drawing.Size(202, 22);
			this.mSave.Text = "Сохранить";
			this.mSave.Click += new System.EventHandler(this.mSave_Click);
			// 
			// mSaveAs
			// 
			this.mSaveAs.Name = "mSaveAs";
			this.mSaveAs.Size = new System.Drawing.Size(202, 22);
			this.mSaveAs.Text = "Сохранить как...";
			this.mSaveAs.Click += new System.EventHandler(this.mSaveAs_Click);
			// 
			// mPreview
			// 
			this.mPreview.Name = "mPreview";
			this.mPreview.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.P)));
			this.mPreview.Size = new System.Drawing.Size(202, 22);
			this.mPreview.Text = "Просмотр";
			this.mPreview.Click += new System.EventHandler(this.tsbPreview_Click);
			// 
			// mSeparator1
			// 
			this.mSeparator1.Name = "mSeparator1";
			this.mSeparator1.Size = new System.Drawing.Size(199, 6);
			// 
			// mSoldiers
			// 
			this.mSoldiers.Name = "mSoldiers";
			this.mSoldiers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
			this.mSoldiers.Size = new System.Drawing.Size(202, 22);
			this.mSoldiers.Text = "Личный состав";
			this.mSoldiers.Click += new System.EventHandler(this.tsbSoldiers_Click);
			// 
			// mTasks
			// 
			this.mTasks.Name = "mTasks";
			this.mTasks.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
			this.mTasks.Size = new System.Drawing.Size(202, 22);
			this.mTasks.Text = "Задачи";
			this.mTasks.Click += new System.EventHandler(this.tsbTasks_Click);
			// 
			// mWeapons
			// 
			this.mWeapons.Name = "mWeapons";
			this.mWeapons.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
			this.mWeapons.Size = new System.Drawing.Size(202, 22);
			this.mWeapons.Text = "Оружие";
			this.mWeapons.Click += new System.EventHandler(this.tsbWeapons_Click);
			// 
			// mMachines
			// 
			this.mMachines.Name = "mMachines";
			this.mMachines.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
			this.mMachines.Size = new System.Drawing.Size(202, 22);
			this.mMachines.Text = "Техника";
			this.mMachines.Click += new System.EventHandler(this.tsbMachines_Click);
			// 
			// mPaths
			// 
			this.mPaths.Name = "mPaths";
			this.mPaths.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
			this.mPaths.Size = new System.Drawing.Size(202, 22);
			this.mPaths.Text = "Путевые листы";
			this.mPaths.Click += new System.EventHandler(this.tsbPath_Click);
			// 
			// mReports
			// 
			this.mReports.Name = "mReports";
			this.mReports.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
			this.mReports.Size = new System.Drawing.Size(202, 22);
			this.mReports.Text = "Отчёты";
			this.mReports.Click += new System.EventHandler(this.tsbReports_Click);
			// 
			// mHelp
			// 
			this.mHelp.Name = "mHelp";
			this.mHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
			this.mHelp.Size = new System.Drawing.Size(202, 22);
			this.mHelp.Text = "Справка";
			this.mHelp.Click += new System.EventHandler(this.tsbHelp_Click);
			// 
			// mSeparator3
			// 
			this.mSeparator3.Name = "mSeparator3";
			this.mSeparator3.Size = new System.Drawing.Size(199, 6);
			// 
			// mExit
			// 
			this.mExit.Name = "mExit";
			this.mExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.mExit.Size = new System.Drawing.Size(202, 22);
			this.mExit.Text = "Выход";
			this.mExit.Click += new System.EventHandler(this.mExit_Click);
			// 
			// tsPp
			// 
			this.tsPp.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsPp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tssbSave,
            this.tsbPreview,
            this.tsbSoldiers,
            this.tsbTasks,
            this.tsbWeapons,
            this.tsbMachines,
            this.tsbPaths,
            this.tsbReport,
            this.tsbHelp});
			this.tsPp.Location = new System.Drawing.Point(0, 0);
			this.tsPp.Name = "tsPp";
			this.tsPp.Padding = new System.Windows.Forms.Padding(5, 3, 5, 4);
			this.tsPp.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tsPp.Size = new System.Drawing.Size(792, 30);
			this.tsPp.TabIndex = 0;
			this.tsPp.TabStop = true;
			// 
			// tsbNew
			// 
			this.tsbNew.AutoToolTip = false;
			this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbNew.Image = global::pp.Properties.Resources.iNew;
			this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNew.Name = "tsbNew";
			this.tsbNew.Size = new System.Drawing.Size(23, 20);
			this.tsbNew.ToolTipText = "Создать новый расход (Ctrl+N).";
			this.tsbNew.Click += new System.EventHandler(this.mCreate_Click);
			// 
			// tsbOpen
			// 
			this.tsbOpen.AutoToolTip = false;
			this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOpen.Image = global::pp.Properties.Resources.iOpen;
			this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Size = new System.Drawing.Size(23, 20);
			this.tsbOpen.ToolTipText = "Открыть расход (Ctrl+O).";
			this.tsbOpen.Click += new System.EventHandler(this.mOpen_Click);
			// 
			// tssbSave
			// 
			this.tssbSave.AutoToolTip = false;
			this.tssbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tssbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSaveAs});
			this.tssbSave.Image = global::pp.Properties.Resources.iSave;
			this.tssbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssbSave.Name = "tssbSave";
			this.tssbSave.Size = new System.Drawing.Size(32, 20);
			this.tssbSave.ToolTipText = "Сохранить расход (Ctrl+S).";
			this.tssbSave.ButtonClick += new System.EventHandler(this.mSave_Click);
			// 
			// tsmSaveAs
			// 
			this.tsmSaveAs.Name = "tsmSaveAs";
			this.tsmSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.S)));
			this.tsmSaveAs.Size = new System.Drawing.Size(241, 22);
			this.tsmSaveAs.Text = "Сохранить как...";
			this.tsmSaveAs.Click += new System.EventHandler(this.mSaveAs_Click);
			// 
			// tsbPreview
			// 
			this.tsbPreview.AutoToolTip = false;
			this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPreview.Image = global::pp.Properties.Resources.iPreview;
			this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPreview.Name = "tsbPreview";
			this.tsbPreview.Size = new System.Drawing.Size(23, 20);
			this.tsbPreview.ToolTipText = "Предварительный просмотр отчёта (Ctrl+Shift+P).";
			this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
			// 
			// tsbSoldiers
			// 
			this.tsbSoldiers.Checked = true;
			this.tsbSoldiers.CheckOnClick = true;
			this.tsbSoldiers.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbSoldiers.Image = global::pp.Properties.Resources.iSoldiers;
			this.tsbSoldiers.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSoldiers.Name = "tsbSoldiers";
			this.tsbSoldiers.Size = new System.Drawing.Size(103, 20);
			this.tsbSoldiers.Text = "Личный состав";
			this.tsbSoldiers.ToolTipText = "Личный состав подразделения (Ctrl+1).";
			this.tsbSoldiers.Click += new System.EventHandler(this.tsbSoldiers_Click);
			// 
			// tsbTasks
			// 
			this.tsbTasks.AutoToolTip = false;
			this.tsbTasks.CheckOnClick = true;
			this.tsbTasks.Image = global::pp.Properties.Resources.iTasks;
			this.tsbTasks.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTasks.Name = "tsbTasks";
			this.tsbTasks.Size = new System.Drawing.Size(64, 20);
			this.tsbTasks.Text = "Задачи";
			this.tsbTasks.ToolTipText = "Задачи подразделения (Ctrl+2).";
			this.tsbTasks.Click += new System.EventHandler(this.tsbTasks_Click);
			// 
			// tsbWeapons
			// 
			this.tsbWeapons.AutoToolTip = false;
			this.tsbWeapons.CheckOnClick = true;
			this.tsbWeapons.Image = global::pp.Properties.Resources.iGun;
			this.tsbWeapons.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbWeapons.Name = "tsbWeapons";
			this.tsbWeapons.Size = new System.Drawing.Size(67, 20);
			this.tsbWeapons.Text = "Оружие";
			this.tsbWeapons.ToolTipText = "Вооружение подразделения (Ctrl+3).";
			this.tsbWeapons.Click += new System.EventHandler(this.tsbWeapons_Click);
			// 
			// tsbMachines
			// 
			this.tsbMachines.AutoToolTip = false;
			this.tsbMachines.CheckOnClick = true;
			this.tsbMachines.Image = global::pp.Properties.Resources.iTruck;
			this.tsbMachines.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbMachines.Name = "tsbMachines";
			this.tsbMachines.Size = new System.Drawing.Size(69, 20);
			this.tsbMachines.Text = "Техника";
			this.tsbMachines.ToolTipText = "Техника подразделения (Ctrl+4).";
			this.tsbMachines.Click += new System.EventHandler(this.tsbMachines_Click);
			// 
			// tsbPaths
			// 
			this.tsbPaths.AutoToolTip = false;
			this.tsbPaths.CheckOnClick = true;
			this.tsbPaths.Image = global::pp.Properties.Resources.iGsm;
			this.tsbPaths.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPaths.Name = "tsbPaths";
			this.tsbPaths.Size = new System.Drawing.Size(106, 20);
			this.tsbPaths.Text = "Путевые листы";
			this.tsbPaths.ToolTipText = "Путевые листы (Ctrl+5).";
			this.tsbPaths.Click += new System.EventHandler(this.tsbPath_Click);
			// 
			// tsbReport
			// 
			this.tsbReport.AutoToolTip = false;
			this.tsbReport.CheckOnClick = true;
			this.tsbReport.Image = global::pp.Properties.Resources.iReport;
			this.tsbReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbReport.Name = "tsbReport";
			this.tsbReport.Size = new System.Drawing.Size(67, 20);
			this.tsbReport.Text = "Отчёты";
			this.tsbReport.ToolTipText = "Формирование отчётов (Ctrl+6).";
			this.tsbReport.Click += new System.EventHandler(this.tsbReports_Click);
			// 
			// tsbHelp
			// 
			this.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbHelp.AutoToolTip = false;
			this.tsbHelp.Image = global::pp.Properties.Resources.iOptions;
			this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbHelp.Name = "tsbHelp";
			this.tsbHelp.Size = new System.Drawing.Size(70, 20);
			this.tsbHelp.Text = "Справка";
			this.tsbHelp.ToolTipText = "Справочная информация (Ctrl+0).";
			this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
			// 
			// cmsPp
			// 
			this.cmsPp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdd,
            this.cbPosition,
            this.mDelete,
            this.mSeparator2,
            this.mSelectAll});
			this.cmsPp.Name = "cmsPp";
			this.cmsPp.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.cmsPp.Size = new System.Drawing.Size(205, 101);
			this.cmsPp.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPp_Opening);
			// 
			// mAdd
			// 
			this.mAdd.Name = "mAdd";
			this.mAdd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.A)));
			this.mAdd.Size = new System.Drawing.Size(204, 22);
			this.mAdd.Text = "Добавить";
			this.mAdd.Click += new System.EventHandler(this.mAdd_Click);
			// 
			// cbPosition
			// 
			this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPosition.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbPosition.Name = "cbPosition";
			this.cbPosition.Size = new System.Drawing.Size(121, 21);
			this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
			// 
			// mDelete
			// 
			this.mDelete.Image = global::pp.Properties.Resources.iDelete;
			this.mDelete.Name = "mDelete";
			this.mDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.mDelete.Size = new System.Drawing.Size(204, 22);
			this.mDelete.Text = "Удалить";
			this.mDelete.Click += new System.EventHandler(this.mDelete_Click);
			// 
			// mSeparator2
			// 
			this.mSeparator2.Name = "mSeparator2";
			this.mSeparator2.Size = new System.Drawing.Size(201, 6);
			// 
			// mSelectAll
			// 
			this.mSelectAll.Name = "mSelectAll";
			this.mSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.mSelectAll.Size = new System.Drawing.Size(204, 22);
			this.mSelectAll.Text = "Выделить всё";
			this.mSelectAll.Click += new System.EventHandler(this.mSelectAll_Click);
			// 
			// pList
			// 
			this.pList.Controls.Add(this.scPp);
			this.pList.Controls.Add(this.tsTools);
			this.pList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pList.Location = new System.Drawing.Point(0, 30);
			this.pList.Name = "pList";
			this.pList.Size = new System.Drawing.Size(792, 536);
			this.pList.TabIndex = 8;
			// 
			// scPp
			// 
			this.scPp.BackColor = System.Drawing.SystemColors.Window;
			this.scPp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scPp.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.scPp.Location = new System.Drawing.Point(0, 28);
			this.scPp.Name = "scPp";
			// 
			// scPp.Panel1
			// 
			this.scPp.Panel1.Controls.Add(this.wbReport);
			this.scPp.Panel1.Controls.Add(this.lvPp);
			this.scPp.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 2, 5);
			// 
			// scPp.Panel2
			// 
			this.scPp.Panel2.Controls.Add(this.pgPp);
			this.scPp.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
			this.scPp.Size = new System.Drawing.Size(792, 508);
			this.scPp.SplitterDistance = 509;
			this.scPp.TabIndex = 3;
			this.scPp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scPp_SplitterMoved);
			// 
			// wbReport
			// 
			this.wbReport.AllowWebBrowserDrop = false;
			this.wbReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbReport.Location = new System.Drawing.Point(5, 5);
			this.wbReport.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbReport.Name = "wbReport";
			this.wbReport.Size = new System.Drawing.Size(502, 498);
			this.wbReport.TabIndex = 3;
			this.wbReport.Visible = false;
			// 
			// lvPp
			// 
			this.lvPp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvPp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvColumn});
			this.lvPp.ContextMenuStrip = this.cmsPp;
			this.lvPp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvPp.FullRowSelect = true;
			this.lvPp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvPp.HideSelection = false;
			this.lvPp.LabelWrap = false;
			this.lvPp.Location = new System.Drawing.Point(5, 5);
			this.lvPp.Name = "lvPp";
			this.lvPp.ShowGroups = false;
			this.lvPp.Size = new System.Drawing.Size(502, 498);
			this.lvPp.TabIndex = 2;
			this.lvPp.UseCompatibleStateImageBehavior = false;
			this.lvPp.View = System.Windows.Forms.View.Details;
			this.lvPp.SelectedIndexChanged += new System.EventHandler(this.lvPp_SelectedIndexChanged);
			// 
			// lvColumn
			// 
			this.lvColumn.Text = "Военнослужащие";
			this.lvColumn.Width = 64;
			// 
			// pgPp
			// 
			this.pgPp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgPp.Location = new System.Drawing.Point(0, 5);
			this.pgPp.Name = "pgPp";
			this.pgPp.PropertySort = System.Windows.Forms.PropertySort.NoSort;
			this.pgPp.Size = new System.Drawing.Size(274, 498);
			this.pgPp.TabIndex = 4;
			this.pgPp.ToolbarVisible = false;
			this.pgPp.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgPp_PropertyValueChanged);
			// 
			// tsTools
			// 
			this.tsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lSearch,
            this.cbSearch,
            this.cbHistory,
            this.lHistory});
			this.tsTools.Location = new System.Drawing.Point(0, 0);
			this.tsTools.Name = "tsTools";
			this.tsTools.Padding = new System.Windows.Forms.Padding(5, 3, 5, 4);
			this.tsTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tsTools.Size = new System.Drawing.Size(792, 28);
			this.tsTools.TabIndex = 1;
			this.tsTools.TabStop = true;
			// 
			// lSearch
			// 
			this.lSearch.BackColor = System.Drawing.Color.Transparent;
			this.lSearch.Name = "lSearch";
			this.lSearch.Size = new System.Drawing.Size(41, 18);
			this.lSearch.Text = "Поиск:";
			// 
			// cbSearch
			// 
			this.cbSearch.AutoSize = false;
			this.cbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbSearch.Name = "cbSearch";
			this.cbSearch.Size = new System.Drawing.Size(121, 21);
			this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
			this.cbSearch.TextChanged += new System.EventHandler(this.cbSearch_TextChanged);
			// 
			// cbHistory
			// 
			this.cbHistory.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cbHistory.AutoSize = false;
			this.cbHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbHistory.Name = "cbHistory";
			this.cbHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cbHistory.Size = new System.Drawing.Size(121, 21);
			this.cbHistory.SelectedIndexChanged += new System.EventHandler(this.cbHistory_SelectedIndexChanged);
			this.cbHistory.TextUpdate += new System.EventHandler(this.cbHistory_TextUpdate);
			this.cbHistory.Validating += new System.ComponentModel.CancelEventHandler(this.cbHistory_Validating);
			// 
			// lHistory
			// 
			this.lHistory.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lHistory.BackColor = System.Drawing.Color.Transparent;
			this.lHistory.Name = "lHistory";
			this.lHistory.Size = new System.Drawing.Size(53, 18);
			this.lHistory.Text = "История:";
			// 
			// pHelp
			// 
			this.pHelp.BackColor = System.Drawing.SystemColors.Window;
			this.pHelp.Controls.Add(this.tbHelp);
			this.pHelp.Controls.Add(this.pbAuthor);
			this.pHelp.Controls.Add(this.lHelp);
			this.pHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pHelp.Location = new System.Drawing.Point(0, 30);
			this.pHelp.Name = "pHelp";
			this.pHelp.Size = new System.Drawing.Size(792, 536);
			this.pHelp.TabIndex = 9;
			this.pHelp.Visible = false;
			// 
			// tbHelp
			// 
			this.tbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbHelp.BackColor = System.Drawing.SystemColors.Window;
			this.tbHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbHelp.Location = new System.Drawing.Point(160, 39);
			this.tbHelp.Multiline = true;
			this.tbHelp.Name = "tbHelp";
			this.tbHelp.ReadOnly = true;
			this.tbHelp.Size = new System.Drawing.Size(367, 165);
			this.tbHelp.TabIndex = 6;
			this.tbHelp.Text = resources.GetString("tbHelp.Text");
			// 
			// pbAuthor
			// 
			this.pbAuthor.BackColor = System.Drawing.SystemColors.Window;
			this.pbAuthor.Image = global::pp.Properties.Resources.iSoldier;
			this.pbAuthor.Location = new System.Drawing.Point(7, 8);
			this.pbAuthor.Name = "pbAuthor";
			this.pbAuthor.Size = new System.Drawing.Size(143, 196);
			this.pbAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbAuthor.TabIndex = 8;
			this.pbAuthor.TabStop = false;
			// 
			// lHelp
			// 
			this.lHelp.AutoSize = true;
			this.lHelp.BackColor = System.Drawing.SystemColors.Window;
			this.lHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lHelp.Location = new System.Drawing.Point(156, 8);
			this.lHelp.Name = "lHelp";
			this.lHelp.Size = new System.Drawing.Size(371, 20);
			this.lHelp.TabIndex = 5;
			this.lHelp.Text = "Редактор расходов (версия от 11.11.2011)";
			// 
			// tSearch
			// 
			this.tSearch.Interval = 1000;
			this.tSearch.Tick += new System.EventHandler(this.tSearch_Tick);
			// 
			// fPp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.pList);
			this.Controls.Add(this.pHelp);
			this.Controls.Add(this.tsPp);
			this.Controls.Add(this.msPp);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msPp;
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "fPp";
			this.Text = "Редактор расходов";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fPp_FormClosing);
			this.Load += new System.EventHandler(this.fPp_Load);
			this.Shown += new System.EventHandler(this.fPp_Shown);
			this.SizeChanged += new System.EventHandler(this.fPp_SizeChanged);
			this.msPp.ResumeLayout(false);
			this.msPp.PerformLayout();
			this.tsPp.ResumeLayout(false);
			this.tsPp.PerformLayout();
			this.cmsPp.ResumeLayout(false);
			this.pList.ResumeLayout(false);
			this.pList.PerformLayout();
			this.scPp.Panel1.ResumeLayout(false);
			this.scPp.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scPp)).EndInit();
			this.scPp.ResumeLayout(false);
			this.tsTools.ResumeLayout(false);
			this.tsTools.PerformLayout();
			this.pHelp.ResumeLayout(false);
			this.pHelp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPp;
        private System.Windows.Forms.ToolStripMenuItem mFile;
		private System.Windows.Forms.ToolStripMenuItem mCreate;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.ToolStripMenuItem mOpen;
        private System.Windows.Forms.ToolStripMenuItem mSave;
        private System.Windows.Forms.ToolStripMenuItem mSaveAs;
        private System.Windows.Forms.ToolStrip tsPp;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSplitButton tssbSave;
		private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
		private System.Windows.Forms.ToolStripButton tsbSoldiers;
		private System.Windows.Forms.ToolStripButton tsbTasks;
		private System.Windows.Forms.ToolStripButton tsbReport;
		private System.Windows.Forms.ToolStripButton tsbHelp;
		private System.Windows.Forms.ContextMenuStrip cmsPp;
		private System.Windows.Forms.ToolStripMenuItem mDelete;
		private System.Windows.Forms.ToolStripMenuItem mAdd;
		private System.Windows.Forms.ToolStripComboBox cbPosition;
		private System.Windows.Forms.ToolStripMenuItem mSelectAll;
		private System.Windows.Forms.ToolStripSeparator mSeparator2;
		private System.Windows.Forms.Panel pList;
		private System.Windows.Forms.SplitContainer scPp;
		private System.Windows.Forms.ListView lvPp;
		private System.Windows.Forms.ColumnHeader lvColumn;
		private System.Windows.Forms.PropertyGrid pgPp;
		private System.Windows.Forms.ToolStrip tsTools;
		private System.Windows.Forms.ToolStripLabel lSearch;
		private System.Windows.Forms.ToolStripComboBox cbSearch;
		private System.Windows.Forms.ToolStripComboBox cbHistory;
		private System.Windows.Forms.ToolStripLabel lHistory;
		private System.Windows.Forms.Panel pHelp;
		private System.Windows.Forms.TextBox tbHelp;
		private System.Windows.Forms.PictureBox pbAuthor;
		private System.Windows.Forms.Label lHelp;
		private System.Windows.Forms.Timer tSearch;
		private System.Windows.Forms.ToolStripButton tsbPaths;
		private System.Windows.Forms.ToolStripButton tsbMachines;
		private System.Windows.Forms.ToolStripButton tsbWeapons;
		private System.Windows.Forms.WebBrowser wbReport;
		private System.Windows.Forms.ToolStripButton tsbPreview;
		private System.Windows.Forms.ToolStripMenuItem mPreview;
		private System.Windows.Forms.ToolStripSeparator mSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mSoldiers;
		private System.Windows.Forms.ToolStripMenuItem mTasks;
		private System.Windows.Forms.ToolStripMenuItem mWeapons;
		private System.Windows.Forms.ToolStripMenuItem mMachines;
		private System.Windows.Forms.ToolStripMenuItem mPaths;
		private System.Windows.Forms.ToolStripMenuItem mReports;
		private System.Windows.Forms.ToolStripSeparator mSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mHelp;
    }
}

