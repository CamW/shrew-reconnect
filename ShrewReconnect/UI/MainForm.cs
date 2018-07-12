using com.waldron.shrewReconnect.Shrew;
using com.waldron.shrewReconnect.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.waldron.shrewReconnect
{
    public partial class MainForm : Form
    {
        ShrewConnection connection = null;

        public MainForm()
        {
            InitializeComponent();
        }

        override
        protected void OnLoad(EventArgs e)
        {
            ShrewNotifier.OperationLogged += notifications_OperationLogged;
            ShrewNotifier.ConnectionStatusChanged += notifications_ConnectionStatusChanged;
            UpdateChecker.UpdateAvailable += updates_UpdateAvailable;
            ShrewCredentials credentials = null;
            try
            {
                credentials = ShrewConfiguration.LoadCredentials();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to load saved credentials! " + exc.Message, "Error Loading Credentials!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (credentials != null)
            {
                this.usernameTextBox.Text = credentials.username;
                this.passwordTextBox.Text = credentials.password;
                this.siteConfigTextBox.Text = credentials.siteConfigPath;
                this.checkboxConnectOnStart.Checked = credentials.connectOnStart;
                this.checkBoxVerifyByDomain.Checked = credentials.verifyConnectionByDomain;
                this.checkBoxSave.Checked = true;
                if (this.checkboxConnectOnStart.Checked)
                {
                    connect();
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                this.checkBoxSave.Checked = false;
            }
        }

        private void updates_UpdateAvailable(object o, UpdateAvailableArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                showMainForm();
                DialogResult dr = MessageBox.Show(this, String.Format("Version v{0} is available for download. Would you like to update?", e.Version),
                    "Shrew VPN Reconnect - Update Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateChecker.InitLatestDownload();
                }
            }));
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void connect()
        {
            if (String.IsNullOrWhiteSpace(this.usernameTextBox.Text)
                || String.IsNullOrWhiteSpace(this.passwordTextBox.Text)
                || String.IsNullOrWhiteSpace(this.siteConfigTextBox.Text))
            {
                MessageBox.Show("Site Config Path, Username and Password fields must all be completed before you will be able to connect to your VPN.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            statusTextBox.Text = "";
            connectPanel.Visible = false;
            statusPanel.Visible = true;

            ShrewCredentials credentials = new ShrewCredentials();
            credentials.username = this.usernameTextBox.Text;
            credentials.password = this.passwordTextBox.Text;
            credentials.siteConfigPath = this.siteConfigTextBox.Text;
            credentials.connectOnStart = this.checkboxConnectOnStart.Checked;
            credentials.verifyConnectionByDomain = checkBoxVerifyByDomain.Checked;
            connection = new ShrewConnection(credentials);
            if (checkBoxSave.Checked)
            {
                try
                {
                    ShrewConfiguration.SaveCredentials(credentials);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Unable to save credentials! " + exc.Message, "Error Saving Credentials!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ShrewConfiguration.DeleteCredentials();
            }
            connection.Connect();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            this.destroyConnection();
            connectPanel.Visible = true;
            statusPanel.Visible = false;
            statusTextBox.Text = "";
            ShrewNotifier.ResetLog();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.connection != null)
            {
                this.destroyConnection();
            }
            TrayIcon.Visible = false;
        }

        private void notifications_ConnectionStatusChanged(object o, ShrewConnectionStatusArgs e)
        {
            this.Invoke((MethodInvoker)(() => {
                switch (e.status)
                {
                    case ShrewConnectionStatus.Connected:
                        this.TrayIcon.Icon = Properties.Resources.green;
                        this.Icon = Properties.Resources.green;
                        break;
                    case ShrewConnectionStatus.Disconnected:
                        this.TrayIcon.Icon = Properties.Resources.red;
                        this.Icon = Properties.Resources.red;
                        break;
                    case ShrewConnectionStatus.Pending:
                        this.TrayIcon.Icon = Properties.Resources.yellow;
                        this.Icon = Properties.Resources.yellow;
                        break;
                }
                Application.DoEvents();
            }));
        }

        private void notifications_OperationLogged(object o, OperationLogArgs e)
        {
            this.Invoke((MethodInvoker)(() => {
                Color textColor = Color.DarkOrange;
                switch (e.Status)
                {
                    case ShrewConnectionStatus.Connected:
                        textColor = Color.DarkGreen;
                        break;
                    case ShrewConnectionStatus.Pending:
                        textColor = Color.Black;
                        break;
                    case ShrewConnectionStatus.Disconnected:
                        textColor = Color.DarkRed;
                        break;
                }
                this.appendText(e.Message, textColor); 
            }));
        }

        private void showMainForm()
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            showMainForm();
        }

        private void showHideButton_Click(object sender, EventArgs e)
        {
            this.connection.ToggleShrewVisible();
        }

        private void appendText(string text, Color color)
        {
            /*box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;*/

            statusTextBox.AppendText(text);
        }

        private void destroyConnection()
        {
            this.connection.Shutdown();
            this.connection = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateChecker.CheckForUpdate();
        }

        private void checkBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            checkboxConnectOnStart.Enabled = checkBoxSave.Checked;
            if (!checkBoxSave.Checked)
            {
                checkboxConnectOnStart.Checked = false;
            }
        }
    }
}