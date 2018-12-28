namespace ServerManager.UI
{
    partial class ServerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblOptions = new System.Windows.Forms.TableLayoutPanel();
            this.grpGeneralSettings = new System.Windows.Forms.GroupBox();
            this.btnApplyGeneralSettings = new System.Windows.Forms.Button();
            this.lblSlots = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.numSlots = new System.Windows.Forms.NumericUpDown();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.txtMap = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tblActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnRunUpdater = new System.Windows.Forms.Button();
            this.btnHideShowConsole = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tblOptions.SuspendLayout();
            this.grpGeneralSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpActions.SuspendLayout();
            this.tblActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOptions
            // 
            this.tblOptions.ColumnCount = 2;
            this.tblOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblOptions.Controls.Add(this.grpGeneralSettings, 0, 0);
            this.tblOptions.Controls.Add(this.grpActions, 1, 0);
            this.tblOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblOptions.Location = new System.Drawing.Point(3, 3);
            this.tblOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tblOptions.Name = "tblOptions";
            this.tblOptions.RowCount = 1;
            this.tblOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOptions.Size = new System.Drawing.Size(394, 224);
            this.tblOptions.TabIndex = 0;
            // 
            // grpGeneralSettings
            // 
            this.grpGeneralSettings.Controls.Add(this.btnApplyGeneralSettings);
            this.grpGeneralSettings.Controls.Add(this.lblSlots);
            this.grpGeneralSettings.Controls.Add(this.txtName);
            this.grpGeneralSettings.Controls.Add(this.lblName);
            this.grpGeneralSettings.Controls.Add(this.numSlots);
            this.grpGeneralSettings.Controls.Add(this.txtFolder);
            this.grpGeneralSettings.Controls.Add(this.lblFolder);
            this.grpGeneralSettings.Controls.Add(this.lblMap);
            this.grpGeneralSettings.Controls.Add(this.txtMap);
            this.grpGeneralSettings.Controls.Add(this.txtAddress);
            this.grpGeneralSettings.Controls.Add(this.lblAddress);
            this.grpGeneralSettings.Controls.Add(this.lblPort);
            this.grpGeneralSettings.Controls.Add(this.numPort);
            this.grpGeneralSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneralSettings.Location = new System.Drawing.Point(3, 3);
            this.grpGeneralSettings.Name = "grpGeneralSettings";
            this.grpGeneralSettings.Size = new System.Drawing.Size(250, 218);
            this.grpGeneralSettings.TabIndex = 1;
            this.grpGeneralSettings.TabStop = false;
            this.grpGeneralSettings.Text = "General Settings";
            // 
            // btnApplyGeneralSettings
            // 
            this.btnApplyGeneralSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyGeneralSettings.Enabled = false;
            this.btnApplyGeneralSettings.Location = new System.Drawing.Point(169, 189);
            this.btnApplyGeneralSettings.Name = "btnApplyGeneralSettings";
            this.btnApplyGeneralSettings.Size = new System.Drawing.Size(75, 23);
            this.btnApplyGeneralSettings.TabIndex = 6;
            this.btnApplyGeneralSettings.Text = "A&pply";
            this.btnApplyGeneralSettings.UseVisualStyleBackColor = true;
            this.btnApplyGeneralSettings.Click += new System.EventHandler(this.OnClick);
            // 
            // lblSlots
            // 
            this.lblSlots.AutoSize = true;
            this.lblSlots.Location = new System.Drawing.Point(6, 163);
            this.lblSlots.Name = "lblSlots";
            this.lblSlots.Size = new System.Drawing.Size(38, 13);
            this.lblSlots.TabIndex = 12;
            this.lblSlots.Text = "Slots :";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(66, 21);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 22);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name :";
            // 
            // numSlots
            // 
            this.numSlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSlots.Location = new System.Drawing.Point(66, 161);
            this.numSlots.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numSlots.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSlots.Name = "numSlots";
            this.numSlots.Size = new System.Drawing.Size(178, 22);
            this.numSlots.TabIndex = 5;
            this.numSlots.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSlots.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.numSlots.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(66, 49);
            this.txtFolder.MaxLength = 100;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(178, 22);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.txtFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(6, 52);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(46, 13);
            this.lblFolder.TabIndex = 8;
            this.lblFolder.Text = "Folder :";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(6, 136);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(36, 13);
            this.lblMap.TabIndex = 11;
            this.lblMap.Text = "Map :";
            // 
            // txtMap
            // 
            this.txtMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMap.Location = new System.Drawing.Point(66, 133);
            this.txtMap.MaxLength = 100;
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(178, 22);
            this.txtMap.TabIndex = 4;
            this.txtMap.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.txtMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(66, 77);
            this.txtAddress.MaxLength = 15;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(178, 22);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 80);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(54, 13);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address :";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 107);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 13);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port :";
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.Location = new System.Drawing.Point(66, 105);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(178, 22);
            this.numPort.TabIndex = 3;
            this.numPort.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.numPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.lblStatus);
            this.grpActions.Controls.Add(this.tblActions);
            this.grpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActions.Location = new System.Drawing.Point(259, 3);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(132, 218);
            this.grpActions.TabIndex = 0;
            this.grpActions.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(6, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "-";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblActions
            // 
            this.tblActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblActions.ColumnCount = 1;
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActions.Controls.Add(this.btnRunUpdater, 0, 0);
            this.tblActions.Controls.Add(this.btnHideShowConsole, 0, 4);
            this.tblActions.Controls.Add(this.btnConnect, 0, 3);
            this.tblActions.Controls.Add(this.btnStart, 0, 1);
            this.tblActions.Controls.Add(this.btnStop, 0, 2);
            this.tblActions.Location = new System.Drawing.Point(3, 35);
            this.tblActions.Margin = new System.Windows.Forms.Padding(0);
            this.tblActions.Name = "tblActions";
            this.tblActions.RowCount = 5;
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblActions.Size = new System.Drawing.Size(126, 180);
            this.tblActions.TabIndex = 0;
            // 
            // btnRunUpdater
            // 
            this.btnRunUpdater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRunUpdater.Enabled = false;
            this.btnRunUpdater.Location = new System.Drawing.Point(3, 3);
            this.btnRunUpdater.Name = "btnRunUpdater";
            this.btnRunUpdater.Size = new System.Drawing.Size(120, 30);
            this.btnRunUpdater.TabIndex = 4;
            this.btnRunUpdater.Text = "Run &Updater";
            this.btnRunUpdater.UseVisualStyleBackColor = true;
            this.btnRunUpdater.Click += new System.EventHandler(this.OnClick);
            // 
            // btnHideShowConsole
            // 
            this.btnHideShowConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHideShowConsole.Enabled = false;
            this.btnHideShowConsole.Location = new System.Drawing.Point(3, 147);
            this.btnHideShowConsole.Name = "btnHideShowConsole";
            this.btnHideShowConsole.Size = new System.Drawing.Size(120, 30);
            this.btnHideShowConsole.TabIndex = 3;
            this.btnHideShowConsole.Text = "-";
            this.btnHideShowConsole.UseVisualStyleBackColor = true;
            this.btnHideShowConsole.Click += new System.EventHandler(this.OnClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(3, 111);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.OnClick);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(3, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnClick);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(3, 75);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.OnClick);
            // 
            // ServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServerControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(400, 230);
            this.tblOptions.ResumeLayout(false);
            this.grpGeneralSettings.ResumeLayout(false);
            this.grpGeneralSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.tblActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblOptions;
        private System.Windows.Forms.GroupBox grpGeneralSettings;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnApplyGeneralSettings;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRunUpdater;
        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblSlots;
        private System.Windows.Forms.NumericUpDown numSlots;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel tblActions;
        private System.Windows.Forms.Button btnHideShowConsole;
    }
}
