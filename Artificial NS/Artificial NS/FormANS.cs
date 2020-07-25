using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANS
{
    public partial class FormANS : Form
    {
        public FormANS()
        {
            InitializeComponent();
            Icon = Properties.Resources.IconANS;
            Program.Shell = this;
            Program.UseShell = true;
        }

        private void ButtonImgRcg_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            FormImgRcg Dialog = new FormImgRcg();
            Dialog.Show();
            Dialog.Activate();
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}