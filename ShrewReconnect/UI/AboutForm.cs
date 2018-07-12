using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace com.waldron.shrewReconnect
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            versionLabel.Text = "v " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
#if X86
            getLatestLink.Text = "https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest32.msi";
#endif
#if X64
            getLatestLink.Text = "https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest64.msi";
#endif
        }

        private void getLatestLink_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(getLatestLink.Text);
            Process.Start(sInfo);
        }

        private void moreInfoLink_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(moreInfoLink.Text);
            Process.Start(sInfo);
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Escape){
                 this.Close();
             }
        }
    }
}
