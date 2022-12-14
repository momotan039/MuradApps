using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MuradApps.Forms
{
    public partial class PopUpImageForm : Form
    {

        public PopUpImageForm()
        {
        }

        public PopUpImageForm(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }
    }
}
