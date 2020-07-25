using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANS
{
    public partial class FormPenProperties : Form
    {
        public Boolean Cancel;

        public FormPenProperties()
        {
            InitializeComponent();
            Cancel = true;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Cancel = false;
            Hide();
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog Dialog = new ColorDialog();
            Dialog.Color = ButtonColor.BackColor;
            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                ButtonColor.BackColor = Dialog.Color;
            }
        }
    }
}