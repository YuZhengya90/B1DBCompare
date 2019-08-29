namespace ResultCompareUI
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mDGVCompareList = new System.Windows.Forms.DataGridView();
            this.mLB1 = new System.Windows.Forms.Label();
            this.mTBLeftKey = new System.Windows.Forms.TextBox();
            this.mTBRightKey = new System.Windows.Forms.TextBox();
            this.mLB2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mCBBO = new System.Windows.Forms.ComboBox();
            this.mBtnBrz = new System.Windows.Forms.Button();
            this.mTBIgnorePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mBtnCompare = new System.Windows.Forms.Button();
            this.mCheckBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.mLBLog = new System.Windows.Forms.ListBox();
            this.mProgBar = new System.Windows.Forms.ProgressBar();
            this.mLine1 = new System.Windows.Forms.TextBox();
            this.mLine2 = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FILEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkingDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanWorkingDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDGVCompareListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IgnoreColumnTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.mLBCompareList = new System.Windows.Forms.Label();
            this.mDGVIgnoreListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeColumnTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.mBtnAdvance = new System.Windows.Forms.Button();
            this.mPBLogo = new System.Windows.Forms.PictureBox();
            this.mLBLogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearLogTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.mLVSubTable = new System.Windows.Forms.ListView();
            this.mRBShowCompare = new System.Windows.Forms.RadioButton();
            this.mRBShowIgnore = new System.Windows.Forms.RadioButton();
            this.mDGVCompareHeaderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyTablesDiffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mDGVCompareList)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.mDGVCompareListMenu.SuspendLayout();
            this.mDGVIgnoreListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPBLogo)).BeginInit();
            this.mLBLogMenu.SuspendLayout();
            this.mDGVCompareHeaderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDGVCompareList
            // 
            this.mDGVCompareList.AllowUserToDeleteRows = false;
            this.mDGVCompareList.AllowUserToOrderColumns = true;
            this.mDGVCompareList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.mDGVCompareList.BackgroundColor = System.Drawing.Color.Honeydew;
            this.mDGVCompareList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mDGVCompareList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mDGVCompareList.DefaultCellStyle = dataGridViewCellStyle5;
            this.mDGVCompareList.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.mDGVCompareList.Location = new System.Drawing.Point(186, 123);
            this.mDGVCompareList.Name = "mDGVCompareList";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mDGVCompareList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.mDGVCompareList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mDGVCompareList.Size = new System.Drawing.Size(811, 439);
            this.mDGVCompareList.TabIndex = 1000;
            this.mDGVCompareList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mDGVCompareList_CellMouseUp);
            // 
            // mLB1
            // 
            this.mLB1.Location = new System.Drawing.Point(297, 39);
            this.mLB1.Name = "mLB1";
            this.mLB1.Size = new System.Drawing.Size(68, 13);
            this.mLB1.TabIndex = 1000;
            this.mLB1.Text = "Object Key 1";
            this.mLB1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mTBLeftKey
            // 
            this.mTBLeftKey.Location = new System.Drawing.Point(369, 36);
            this.mTBLeftKey.Name = "mTBLeftKey";
            this.mTBLeftKey.Size = new System.Drawing.Size(57, 20);
            this.mTBLeftKey.TabIndex = 40;
            this.mTBLeftKey.Enter += new System.EventHandler(this.mTBLeftKey_Enter);
            // 
            // mTBRightKey
            // 
            this.mTBRightKey.Location = new System.Drawing.Point(504, 36);
            this.mTBRightKey.Name = "mTBRightKey";
            this.mTBRightKey.Size = new System.Drawing.Size(57, 20);
            this.mTBRightKey.TabIndex = 50;
            this.mTBRightKey.Enter += new System.EventHandler(this.mTBRightKey_Enter);
            // 
            // mLB2
            // 
            this.mLB2.Location = new System.Drawing.Point(432, 39);
            this.mLB2.Name = "mLB2";
            this.mLB2.Size = new System.Drawing.Size(68, 13);
            this.mLB2.TabIndex = 1000;
            this.mLB2.Text = "Object Key 2";
            this.mLB2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1000;
            this.label5.Text = "Business Object";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mCBBO
            // 
            this.mCBBO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCBBO.FormattingEnabled = true;
            this.mCBBO.Location = new System.Drawing.Point(101, 35);
            this.mCBBO.Name = "mCBBO";
            this.mCBBO.Size = new System.Drawing.Size(190, 21);
            this.mCBBO.TabIndex = 10;
            this.mCBBO.SelectedIndexChanged += new System.EventHandler(this.mComBoxBO_SelectedIndexChanged);
            // 
            // mBtnBrz
            // 
            this.mBtnBrz.Location = new System.Drawing.Point(567, 61);
            this.mBtnBrz.Name = "mBtnBrz";
            this.mBtnBrz.Size = new System.Drawing.Size(92, 22);
            this.mBtnBrz.TabIndex = 90;
            this.mBtnBrz.Text = "Browse";
            this.mBtnBrz.UseVisualStyleBackColor = true;
            this.mBtnBrz.Click += new System.EventHandler(this.mButtonBrz_Click);
            // 
            // mTBIgnorePath
            // 
            this.mTBIgnorePath.Location = new System.Drawing.Point(51, 61);
            this.mTBIgnorePath.Name = "mTBIgnorePath";
            this.mTBIgnorePath.Size = new System.Drawing.Size(510, 20);
            this.mTBIgnorePath.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 1000;
            this.label6.Text = "Ignore";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mBtnCompare
            // 
            this.mBtnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mBtnCompare.Location = new System.Drawing.Point(663, 36);
            this.mBtnCompare.Name = "mBtnCompare";
            this.mBtnCompare.Size = new System.Drawing.Size(101, 47);
            this.mBtnCompare.TabIndex = 60;
            this.mBtnCompare.Text = "Compare >>>";
            this.mBtnCompare.UseVisualStyleBackColor = true;
            this.mBtnCompare.Click += new System.EventHandler(this.mButtonCompare_Click);
            // 
            // mCheckBoxSelectAll
            // 
            this.mCheckBoxSelectAll.AutoSize = true;
            this.mCheckBoxSelectAll.Location = new System.Drawing.Point(11, 106);
            this.mCheckBoxSelectAll.Name = "mCheckBoxSelectAll";
            this.mCheckBoxSelectAll.Size = new System.Drawing.Size(37, 17);
            this.mCheckBoxSelectAll.TabIndex = 20;
            this.mCheckBoxSelectAll.Text = "All";
            this.mCheckBoxSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mCheckBoxSelectAll.UseVisualStyleBackColor = true;
            this.mCheckBoxSelectAll.CheckedChanged += new System.EventHandler(this.mCheckBoxSelectAll_CheckedChanged);
            // 
            // mLBLog
            // 
            this.mLBLog.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mLBLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLBLog.ForeColor = System.Drawing.Color.Red;
            this.mLBLog.FormattingEnabled = true;
            this.mLBLog.HorizontalScrollbar = true;
            this.mLBLog.ItemHeight = 16;
            this.mLBLog.Location = new System.Drawing.Point(9, 590);
            this.mLBLog.Name = "mLBLog";
            this.mLBLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.mLBLog.Size = new System.Drawing.Size(987, 132);
            this.mLBLog.TabIndex = 1100;
            this.mLBLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mLBLog_MouseUp);
            // 
            // mProgBar
            // 
            this.mProgBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.mProgBar.Location = new System.Drawing.Point(877, 571);
            this.mProgBar.Name = "mProgBar";
            this.mProgBar.Size = new System.Drawing.Size(119, 10);
            this.mProgBar.Step = 1;
            this.mProgBar.TabIndex = 1000;
            this.mProgBar.UseWaitCursor = true;
            this.mProgBar.Visible = false;
            // 
            // mLine1
            // 
            this.mLine1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mLine1.Location = new System.Drawing.Point(3, 91);
            this.mLine1.Multiline = true;
            this.mLine1.Name = "mLine1";
            this.mLine1.Size = new System.Drawing.Size(1000, 1);
            this.mLine1.TabIndex = 1000;
            // 
            // mLine2
            // 
            this.mLine2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mLine2.Location = new System.Drawing.Point(4, 576);
            this.mLine2.Multiline = true;
            this.mLine2.Name = "mLine2";
            this.mLine2.Size = new System.Drawing.Size(1000, 1);
            this.mLine2.TabIndex = 1000;
            // 
            // MenuStrip
            // 
            this.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FILEToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1008, 24);
            this.MenuStrip.TabIndex = 1000;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FILEToolStripMenuItem1
            // 
            this.FILEToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWorkingDirToolStripMenuItem,
            this.cleanWorkingDirToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.screenCaptureToolStripMenuItem,
            this.captureToClipboardToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.FILEToolStripMenuItem1.Name = "FILEToolStripMenuItem1";
            this.FILEToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.FILEToolStripMenuItem1.Text = "File";
            // 
            // openWorkingDirToolStripMenuItem
            // 
            this.openWorkingDirToolStripMenuItem.Name = "openWorkingDirToolStripMenuItem";
            this.openWorkingDirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openWorkingDirToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.openWorkingDirToolStripMenuItem.Text = "Open Working Dir";
            this.openWorkingDirToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirToolStripMenuItem_Click);
            // 
            // cleanWorkingDirToolStripMenuItem
            // 
            this.cleanWorkingDirToolStripMenuItem.Name = "cleanWorkingDirToolStripMenuItem";
            this.cleanWorkingDirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.cleanWorkingDirToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.cleanWorkingDirToolStripMenuItem.Text = "Clean Working Dir";
            this.cleanWorkingDirToolStripMenuItem.Click += new System.EventHandler(this.cleanWorkingDirToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // screenCaptureToolStripMenuItem
            // 
            this.screenCaptureToolStripMenuItem.Name = "screenCaptureToolStripMenuItem";
            this.screenCaptureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.screenCaptureToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.screenCaptureToolStripMenuItem.Text = "Capture Screen As";
            this.screenCaptureToolStripMenuItem.Click += new System.EventHandler(this.screenCaptureToolStripMenuItem_Click);
            // 
            // captureToClipboardToolStripMenuItem
            // 
            this.captureToClipboardToolStripMenuItem.Name = "captureToClipboardToolStripMenuItem";
            this.captureToClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.captureToClipboardToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.captureToClipboardToolStripMenuItem.Text = "Capture Screen to Clipboard";
            this.captureToClipboardToolStripMenuItem.Click += new System.EventHandler(this.captureToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // readmeToolStripMenuItem
            // 
            this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
            this.readmeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.readmeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.readmeToolStripMenuItem.Text = "Read Me";
            this.readmeToolStripMenuItem.Click += new System.EventHandler(this.readmeToolStripMenuItem_Click);
            // 
            // mDGVCompareListMenu
            // 
            this.mDGVCompareListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellToolStripMenuItem,
            this.IgnoreColumnTSM});
            this.mDGVCompareListMenu.Name = "CompareListCMS";
            this.mDGVCompareListMenu.Size = new System.Drawing.Size(175, 48);
            // 
            // copyCellToolStripMenuItem
            // 
            this.copyCellToolStripMenuItem.Name = "copyCellToolStripMenuItem";
            this.copyCellToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.copyCellToolStripMenuItem.Text = "Copy Cell";
            this.copyCellToolStripMenuItem.Click += new System.EventHandler(this.copyCellToolStripMenuItem_Click);
            // 
            // IgnoreColumnTSM
            // 
            this.IgnoreColumnTSM.Name = "IgnoreColumnTSM";
            this.IgnoreColumnTSM.Size = new System.Drawing.Size(174, 22);
            this.IgnoreColumnTSM.Text = "Ignore this column";
            this.IgnoreColumnTSM.Click += new System.EventHandler(this.IgnoreColumnTSM_Click);
            // 
            // mLBCompareList
            // 
            this.mLBCompareList.AutoSize = true;
            this.mLBCompareList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLBCompareList.Location = new System.Drawing.Point(192, 101);
            this.mLBCompareList.Name = "mLBCompareList";
            this.mLBCompareList.Size = new System.Drawing.Size(110, 16);
            this.mLBCompareList.TabIndex = 1000;
            this.mLBCompareList.Text = "Compare Tables";
            this.mLBCompareList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mLBCompareList.Visible = false;
            // 
            // mDGVIgnoreListMenu
            // 
            this.mDGVIgnoreListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeColumnTSM});
            this.mDGVIgnoreListMenu.Name = "CompareListCMS";
            this.mDGVIgnoreListMenu.Size = new System.Drawing.Size(180, 26);
            // 
            // removeColumnTSM
            // 
            this.removeColumnTSM.Name = "removeColumnTSM";
            this.removeColumnTSM.Size = new System.Drawing.Size(179, 22);
            this.removeColumnTSM.Text = "Restore this column";
            this.removeColumnTSM.Click += new System.EventHandler(this.removeColumnTSM_Click);
            // 
            // mBtnAdvance
            // 
            this.mBtnAdvance.Location = new System.Drawing.Point(567, 36);
            this.mBtnAdvance.Name = "mBtnAdvance";
            this.mBtnAdvance.Size = new System.Drawing.Size(92, 22);
            this.mBtnAdvance.TabIndex = 80;
            this.mBtnAdvance.Text = "Advance";
            this.mBtnAdvance.UseVisualStyleBackColor = true;
            this.mBtnAdvance.Click += new System.EventHandler(this.mBtnAdvance_Click);
            // 
            // mPBLogo
            // 
            this.mPBLogo.Image = ((System.Drawing.Image)(resources.GetObject("mPBLogo.Image")));
            this.mPBLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("mPBLogo.InitialImage")));
            this.mPBLogo.Location = new System.Drawing.Point(771, 38);
            this.mPBLogo.Name = "mPBLogo";
            this.mPBLogo.Size = new System.Drawing.Size(225, 46);
            this.mPBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mPBLogo.TabIndex = 1004;
            this.mPBLogo.TabStop = false;
            this.mPBLogo.Click += new System.EventHandler(this.mPBLogo_Click);
            // 
            // mLBLogMenu
            // 
            this.mLBLogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.ClearLogTSM});
            this.mLBLogMenu.Name = "CompareListCMS";
            this.mLBLogMenu.Size = new System.Drawing.Size(119, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // ClearLogTSM
            // 
            this.ClearLogTSM.Name = "ClearLogTSM";
            this.ClearLogTSM.Size = new System.Drawing.Size(118, 22);
            this.ClearLogTSM.Text = "Clear All";
            this.ClearLogTSM.Click += new System.EventHandler(this.ClearLogTSM_Click);
            // 
            // mLVSubTable
            // 
            this.mLVSubTable.BackColor = System.Drawing.SystemColors.Info;
            this.mLVSubTable.CheckBoxes = true;
            this.mLVSubTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.mLVSubTable.Location = new System.Drawing.Point(9, 123);
            this.mLVSubTable.Name = "mLVSubTable";
            this.mLVSubTable.Size = new System.Drawing.Size(168, 439);
            this.mLVSubTable.TabIndex = 30;
            this.mLVSubTable.UseCompatibleStateImageBehavior = false;
            this.mLVSubTable.View = System.Windows.Forms.View.List;
            // 
            // mRBShowCompare
            // 
            this.mRBShowCompare.AutoSize = true;
            this.mRBShowCompare.Checked = true;
            this.mRBShowCompare.Location = new System.Drawing.Point(819, 100);
            this.mRBShowCompare.Name = "mRBShowCompare";
            this.mRBShowCompare.Size = new System.Drawing.Size(86, 17);
            this.mRBShowCompare.TabIndex = 100;
            this.mRBShowCompare.TabStop = true;
            this.mRBShowCompare.Text = "Compare List";
            this.mRBShowCompare.UseVisualStyleBackColor = true;
            this.mRBShowCompare.Click += new System.EventHandler(this.mRBShowCompare_Clicked);
            // 
            // mRBShowIgnore
            // 
            this.mRBShowIgnore.AutoSize = true;
            this.mRBShowIgnore.Location = new System.Drawing.Point(910, 100);
            this.mRBShowIgnore.Name = "mRBShowIgnore";
            this.mRBShowIgnore.Size = new System.Drawing.Size(74, 17);
            this.mRBShowIgnore.TabIndex = 101;
            this.mRBShowIgnore.TabStop = true;
            this.mRBShowIgnore.Text = "Ignore List";
            this.mRBShowIgnore.UseVisualStyleBackColor = true;
            this.mRBShowIgnore.Click += new System.EventHandler(this.mRBShowIgnore_Clicked);
            // 
            // mDGVCompareHeaderMenu
            // 
            this.mDGVCompareHeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTablesDiffsToolStripMenuItem});
            this.mDGVCompareHeaderMenu.Name = "mDGVCompareHeaderMenu";
            this.mDGVCompareHeaderMenu.Size = new System.Drawing.Size(161, 26);
            // 
            // copyTablesDiffsToolStripMenuItem
            // 
            this.copyTablesDiffsToolStripMenuItem.Name = "copyTablesDiffsToolStripMenuItem";
            this.copyTablesDiffsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyTablesDiffsToolStripMenuItem.Text = "Copy Table Diffs";
            this.copyTablesDiffsToolStripMenuItem.Click += new System.EventHandler(this.copyTablesDiffsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mRBShowIgnore);
            this.Controls.Add(this.mRBShowCompare);
            this.Controls.Add(this.mLVSubTable);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.mPBLogo);
            this.Controls.Add(this.mBtnAdvance);
            this.Controls.Add(this.mLBCompareList);
            this.Controls.Add(this.mProgBar);
            this.Controls.Add(this.mLBLog);
            this.Controls.Add(this.mBtnCompare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mTBIgnorePath);
            this.Controls.Add(this.mBtnBrz);
            this.Controls.Add(this.mCBBO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mLB2);
            this.Controls.Add(this.mTBRightKey);
            this.Controls.Add(this.mTBLeftKey);
            this.Controls.Add(this.mLB1);
            this.Controls.Add(this.mDGVCompareList);
            this.Controls.Add(this.mLine2);
            this.Controls.Add(this.mLine1);
            this.Controls.Add(this.mCheckBoxSelectAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.Text = "SAP Business One Table Compare";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mDGVCompareList)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.mDGVCompareListMenu.ResumeLayout(false);
            this.mDGVIgnoreListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPBLogo)).EndInit();
            this.mLBLogMenu.ResumeLayout(false);
            this.mDGVCompareHeaderMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mDGVCompareList;
        private System.Windows.Forms.Label mLB1;
        private System.Windows.Forms.TextBox mTBLeftKey;
        private System.Windows.Forms.TextBox mTBRightKey;
        private System.Windows.Forms.Label mLB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mCBBO;
        private System.Windows.Forms.Button mBtnBrz;
        private System.Windows.Forms.TextBox mTBIgnorePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button mBtnCompare;
        private System.Windows.Forms.CheckBox mCheckBoxSelectAll;
        private System.Windows.Forms.ListBox mLBLog;
        private System.Windows.Forms.ProgressBar mProgBar;
        private System.Windows.Forms.TextBox mLine1;
        private System.Windows.Forms.TextBox mLine2;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FILEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mDGVCompareListMenu;
        private System.Windows.Forms.ToolStripMenuItem IgnoreColumnTSM;
        private System.Windows.Forms.Label mLBCompareList;
        private System.Windows.Forms.ContextMenuStrip mDGVIgnoreListMenu;
        private System.Windows.Forms.ToolStripMenuItem removeColumnTSM;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.Button mBtnAdvance;
        private System.Windows.Forms.PictureBox mPBLogo;
        private System.Windows.Forms.ContextMenuStrip mLBLogMenu;
        private System.Windows.Forms.ToolStripMenuItem ClearLogTSM;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanWorkingDirToolStripMenuItem;
        private System.Windows.Forms.ListView mLVSubTable;
        private System.Windows.Forms.RadioButton mRBShowCompare;
        private System.Windows.Forms.RadioButton mRBShowIgnore;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToClipboardToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mDGVCompareHeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem copyTablesDiffsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

