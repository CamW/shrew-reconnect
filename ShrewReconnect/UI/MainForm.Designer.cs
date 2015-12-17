namespace com.waldron.shrewReconnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.connectPanel = new System.Windows.Forms.Panel();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.siteConfigTextBox = new System.Windows.Forms.TextBox();
            this.siteConfigLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.showHideButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.connectPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Shrew Reconnect";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // connectPanel
            // 
            this.connectPanel.Controls.Add(this.checkBoxSave);
            this.connectPanel.Controls.Add(this.aboutButton);
            this.connectPanel.Controls.Add(this.ConnectButton);
            this.connectPanel.Controls.Add(this.passwordTextBox);
            this.connectPanel.Controls.Add(this.passwordLabel);
            this.connectPanel.Controls.Add(this.usernameTextBox);
            this.connectPanel.Controls.Add(this.usernameLabel);
            this.connectPanel.Controls.Add(this.siteConfigTextBox);
            this.connectPanel.Controls.Add(this.siteConfigLabel);
            this.connectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectPanel.Location = new System.Drawing.Point(0, 0);
            this.connectPanel.Name = "connectPanel";
            this.connectPanel.Size = new System.Drawing.Size(467, 195);
            this.connectPanel.TabIndex = 7;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Checked = true;
            this.checkBoxSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSave.Location = new System.Drawing.Point(98, 122);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(338, 17);
            this.checkBoxSave.TabIndex = 12;
            this.checkBoxSave.Text = "Encrypt and save credentials to local application data on connect.";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutButton.Location = new System.Drawing.Point(20, 160);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(57, 23);
            this.aboutButton.TabIndex = 4;
            this.aboutButton.TabStop = false;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.Location = new System.Drawing.Point(380, 160);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(98, 90);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(354, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(39, 93);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(98, 57);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(354, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(37, 60);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "Username";
            // 
            // siteConfigTextBox
            // 
            this.siteConfigTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siteConfigTextBox.Location = new System.Drawing.Point(98, 24);
            this.siteConfigTextBox.Name = "siteConfigTextBox";
            this.siteConfigTextBox.Size = new System.Drawing.Size(354, 20);
            this.siteConfigTextBox.TabIndex = 1;
            // 
            // siteConfigLabel
            // 
            this.siteConfigLabel.AutoSize = true;
            this.siteConfigLabel.Location = new System.Drawing.Point(9, 27);
            this.siteConfigLabel.Name = "siteConfigLabel";
            this.siteConfigLabel.Size = new System.Drawing.Size(83, 13);
            this.siteConfigLabel.TabIndex = 7;
            this.siteConfigLabel.Text = "Site Config Path";
            // 
            // statusPanel
            // 
            this.statusPanel.Controls.Add(this.showHideButton);
            this.statusPanel.Controls.Add(this.disconnectButton);
            this.statusPanel.Controls.Add(this.statusTextBox);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(467, 195);
            this.statusPanel.TabIndex = 8;
            this.statusPanel.Visible = false;
            // 
            // showHideButton
            // 
            this.showHideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showHideButton.Location = new System.Drawing.Point(264, 160);
            this.showHideButton.Name = "showHideButton";
            this.showHideButton.Size = new System.Drawing.Size(110, 23);
            this.showHideButton.TabIndex = 2;
            this.showHideButton.Text = "Show/Hide Shrew";
            this.showHideButton.UseVisualStyleBackColor = true;
            this.showHideButton.Click += new System.EventHandler(this.showHideButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectButton.Location = new System.Drawing.Point(380, 160);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTextBox.BackColor = System.Drawing.Color.White;
            this.statusTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextBox.Location = new System.Drawing.Point(12, 12);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(443, 142);
            this.statusTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 195);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.connectPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(948, 800);
            this.MinimumSize = new System.Drawing.Size(313, 168);
            this.Name = "MainForm";
            this.Text = "Shrew VPN Reconnect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.connectPanel.ResumeLayout(false);
            this.connectPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Panel connectPanel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox siteConfigTextBox;
        private System.Windows.Forms.Label siteConfigLabel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button showHideButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.CheckBox checkBoxSave;
    }
}

