namespace com.waldron.shrewReconnect
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.productNameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moreInfoLink = new System.Windows.Forms.Label();
            this.getLatestLink = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productNameLabel
            // 
            this.productNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameLabel.Location = new System.Drawing.Point(172, 9);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(172, 20);
            this.productNameLabel.TabIndex = 0;
            this.productNameLabel.Text = "Shrew VPN Reconnect";
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(490, 156);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(53, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "v X.X.X.X";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Get Latest:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "More Information:";
            // 
            // moreInfoLink
            // 
            this.moreInfoLink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.moreInfoLink.AutoSize = true;
            this.moreInfoLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moreInfoLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoLink.ForeColor = System.Drawing.Color.Blue;
            this.moreInfoLink.Location = new System.Drawing.Point(140, 91);
            this.moreInfoLink.Name = "moreInfoLink";
            this.moreInfoLink.Size = new System.Drawing.Size(212, 13);
            this.moreInfoLink.TabIndex = 4;
            this.moreInfoLink.Text = "https://github.com/camw/shrew-reconnect";
            this.moreInfoLink.Click += new System.EventHandler(this.moreInfoLink_Click);
            // 
            // getLatestLink
            // 
            this.getLatestLink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.getLatestLink.AutoSize = true;
            this.getLatestLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getLatestLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getLatestLink.ForeColor = System.Drawing.Color.Blue;
            this.getLatestLink.Location = new System.Drawing.Point(140, 65);
            this.getLatestLink.Name = "getLatestLink";
            this.getLatestLink.Size = new System.Drawing.Size(367, 13);
            this.getLatestLink.TabIndex = 5;
            this.getLatestLink.Text = "http://www.waldron.co.za/downloads/installers/ShrewReconnectLatest.msi";
            this.getLatestLink.Click += new System.EventHandler(this.getLatestLink_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 178);
            this.Controls.Add(this.getLatestLink);
            this.Controls.Add(this.moreInfoLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.productNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label moreInfoLink;
        private System.Windows.Forms.Label getLatestLink;
    }
}