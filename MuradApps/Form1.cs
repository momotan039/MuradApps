using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuradApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var quturs = new object[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 25 };
            comboBox1.Items.AddRange(quturs);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (numsTB.Text == "" || comboBox1.SelectedItem == null)
            //{
            //    MessageBox.Show("נא למלא את כל השדוד");
            //    return;
            //}
            Line l = new Line(30);
            LightingStrike ls = new LightingStrike(20,30);
            DoubleLine dl = new DoubleLine(50,20);
            CircularDoubleLine cdl = new CircularDoubleLine(50,20);
            Rectangle r = new Rectangle(50, 20);
            RectangleMissOne rMO = new RectangleMissOne(50,20);
            RectangleMissOneWithTails rMOWT = new RectangleMissOneWithTails(50,20,10);
            CurvedRectangleMissOneWithTails CrMOWT = new CurvedRectangleMissOneWithTails(50,20,22);
            dataGridView1.Rows.Add(ItemList.index++,numsTB.Text,comboBox1.SelectedItem,lengthTB.Text, cdl.CustomizeImage());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            var x = sender as DataGridViewCell;
            if(x!=null)
            MessageBox.Show(x.Value.ToString());
        }
    }
}
