﻿using MuradApps.Shapes_Opjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MuradApps.Forms
{
    public partial class SpinnerForm : Form
    {
        private bool noDataPassed=true;
        public SpinnerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quturSpinnerTB.Text == "")
            {
                MessageBox.Show("נא להכניס קוטר");
                return;
            }

            if (radiusSpinnerTB.Text == "")
            {
                MessageBox.Show("נא להכניס ראדיוס סביבות");
                return;
            }
            noDataPassed = false;

            Mytools.sl.qutur= double.Parse(quturSpinnerTB.Text);
            Mytools.sl.radius=double.Parse(radiusSpinnerTB.Text);
            Mytools.sl.nums=double.Parse(numsTb.Text);
            Close();
        }

        public bool FilledData()
        {
            return !noDataPassed;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
