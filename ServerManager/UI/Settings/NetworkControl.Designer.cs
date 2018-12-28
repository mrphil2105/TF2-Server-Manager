namespace ServerManager.UI.Settings
{
    partial class NetworkControl
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
            this.chkPortMapping = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkPortMapping
            // 
            this.chkPortMapping.AutoSize = true;
            this.chkPortMapping.Location = new System.Drawing.Point(6, 6);
            this.chkPortMapping.Name = "chkPortMapping";
            this.chkPortMapping.Size = new System.Drawing.Size(325, 17);
            this.chkPortMapping.TabIndex = 0;
            this.chkPortMapping.Text = "Automatically create a port mapping before a server starts.";
            this.chkPortMapping.UseVisualStyleBackColor = true;
            // 
            // NetworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkPortMapping);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NetworkControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(350, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPortMapping;
    }
}
