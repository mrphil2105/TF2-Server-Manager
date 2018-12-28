namespace ServerManager.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickBrowseFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClickExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabServers = new System.Windows.Forms.TabControl();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolLinkCopyPublicEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClickBrowseFiles,
            this.menuSeparator1,
            this.menuClickExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuClickBrowseFiles
            // 
            this.menuClickBrowseFiles.Name = "menuClickBrowseFiles";
            this.menuClickBrowseFiles.Size = new System.Drawing.Size(180, 22);
            this.menuClickBrowseFiles.Text = "&Browse Files...";
            this.menuClickBrowseFiles.Click += new System.EventHandler(this.OnClick);
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuClickExit
            // 
            this.menuClickExit.Name = "menuClickExit";
            this.menuClickExit.Size = new System.Drawing.Size(180, 22);
            this.menuClickExit.Text = "&Exit";
            this.menuClickExit.Click += new System.EventHandler(this.OnClick);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClickSettings,
            this.menuClickAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "H&elp";
            // 
            // menuClickSettings
            // 
            this.menuClickSettings.Name = "menuClickSettings";
            this.menuClickSettings.Size = new System.Drawing.Size(125, 22);
            this.menuClickSettings.Text = "&Settings...";
            this.menuClickSettings.Click += new System.EventHandler(this.OnClick);
            // 
            // menuClickAbout
            // 
            this.menuClickAbout.Name = "menuClickAbout";
            this.menuClickAbout.Size = new System.Drawing.Size(125, 22);
            this.menuClickAbout.Text = "&About...";
            this.menuClickAbout.Click += new System.EventHandler(this.OnClick);
            // 
            // tabServers
            // 
            this.tabServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabServers.Location = new System.Drawing.Point(0, 86);
            this.tabServers.Name = "tabServers";
            this.tabServers.SelectedIndex = 0;
            this.tabServers.Size = new System.Drawing.Size(484, 255);
            this.tabServers.TabIndex = 0;
            this.tabServers.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnRight);
            this.pnlActions.Controls.Add(this.btnLeft);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 24);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(3);
            this.pnlActions.Size = new System.Drawing.Size(484, 62);
            this.pnlActions.TabIndex = 1;
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Image = global::ServerManager.Properties.Resources.Right;
            this.btnRight.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRight.Location = new System.Drawing.Point(192, 6);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(56, 50);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "&Right";
            this.btnRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.OnClick);
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Image = global::ServerManager.Properties.Resources.Left;
            this.btnLeft.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLeft.Location = new System.Drawing.Point(130, 6);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(56, 50);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "&Left";
            this.btnLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.OnClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::ServerManager.Properties.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(68, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.OnClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::ServerManager.Properties.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(6, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 50);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.OnClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLinkCopyPublicEndPoint});
            this.statusStrip.Location = new System.Drawing.Point(0, 341);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolLinkCopyPublicEndPoint
            // 
            this.toolLinkCopyPublicEndPoint.Enabled = false;
            this.toolLinkCopyPublicEndPoint.IsLink = true;
            this.toolLinkCopyPublicEndPoint.Name = "toolLinkCopyPublicEndPoint";
            this.toolLinkCopyPublicEndPoint.Size = new System.Drawing.Size(144, 17);
            this.toolLinkCopyPublicEndPoint.Text = "Copy Public Server IP:Port";
            this.toolLinkCopyPublicEndPoint.Click += new System.EventHandler(this.OnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 363);
            this.Controls.Add(this.tabServers);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 402);
            this.Name = "MainForm";
            this.Text = "TF2 Server Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuClickSettings;
        private System.Windows.Forms.ToolStripMenuItem menuClickAbout;
        private System.Windows.Forms.TabControl tabServers;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem menuClickBrowseFiles;
        private System.Windows.Forms.ToolStripSeparator menuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuClickExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolLinkCopyPublicEndPoint;
    }
}

