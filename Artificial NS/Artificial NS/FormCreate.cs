using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANS
{
    public partial class FormCreate : Form
    {
        public Boolean Cancel;

        public FormCreate()
        {
            InitializeComponent();
            Cancel = true;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (ImageDimension.Value > PictureDimension.Value * PictureDimension.Value)
                MessageBox.Show("Нейронов не может быть больше чем длина стороны изображения в квадрате.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Cancel = false;
                Hide();
            }
        }
    }
}