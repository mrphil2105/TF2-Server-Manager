namespace ServerManager.UI.Settings
{
    partial class GeneralControl
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
            this.lblDirectory = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowseDirectory = new System.Windows.Forms.Button();
            this.chkHideConsole = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(6, 3);
            this.lblDirectory.MaximumSize = new System.Drawing.Size(338, 0);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(334, 39);
            this.lblDirectory.TabIndex = 3;
            this.lblDirectory.Text = "Determines where the directory for the servers will be placed. If you want to mov" +
    "e the servers to a new directory, you will need to move them manually before cha" +
    "nging this.";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(6, 45);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(297, 22);
            this.txtDirectory.TabIndex = 0;
            this.txtDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // btnBrowseDirectory
            // 
            this.btnBrowseDirectory.Location = new System.Drawing.Point(309, 45);
            this.btnBrowseDirectory.Name = "btnBrowseDirectory";
            this.btnBrowseDirectory.Size = new System.Drawing.Size(35, 22);
            this.btnBrowseDirectory.TabIndex = 1;
            this.btnBrowseDirectory.Text = "...";
            this.btnBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDirectory.Click += new System.EventHandler(this.OnClick);
            // 
            // chkHideConsole
            // 
            this.chkHideConsole.AutoSize = true;
            this.chkHideConsole.Location = new System.Drawing.Point(6, 79);
            this.chkHideConsole.Name = "chkHideConsole";
            this.chkHideConsole.Size = new System.Drawing.Size(316, 17);
            this.chkHideConsole.TabIndex = 2;
            this.chkHideConsole.Text = "Automatically hide the console of a server when it starts.";
            this.chkHideConsole.UseVisualStyleBackColor = true;
            // 
            // GeneralControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkHideConsole);
            this.Controls.Add(this.btnBrowseDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.lblDirectory);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GeneralControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(350, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowseDirectory;
        private System.Windows.Forms.CheckBox chkHideConsole;
    }
}
