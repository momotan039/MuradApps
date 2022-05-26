using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
           var quturs = new object[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 25 };
            comboBox1.Items.AddRange(quturs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(numsTB.Text == "" || comboBox1.SelectedItem== null)
            {
                MessageBox.Show("נא למלא את כל השדוד");
                return;
            }
            dataGridView1.Rows.Add(ItemList.index++,numsTB.Text,comboBox1.SelectedItem,lengthTB.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       
    }
}
