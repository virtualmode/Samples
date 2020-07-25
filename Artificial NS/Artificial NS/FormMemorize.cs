using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANS
{
    public partial class FormMemorize : Form
    {
        public Byte Result; // Ответ юзера на диалоговое сообщение. 0 - отмена; 1 - перезаписать; 2 - переобучить.

        public FormMemorize()
        {
            InitializeComponent();
        }

        private void ButtonRewrite_Click(object sender, EventArgs e)
        {
            Result = 1;
            Hide();
        }

        private void ButtonReteach_Click(object sender, EventArgs e)
        {
            Result = 2;
            Hide();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Result = 0;
        }
    }
}