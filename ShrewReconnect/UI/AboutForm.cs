using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace com.waldron.shrewReconnect
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            versionLabel.Text = "v " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
