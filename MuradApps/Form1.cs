﻿using System;
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

        //200 15 500 10  662k
        List<Item> items=new List<Item> ();
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var quturs = new object[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 25 };
            comboBox1.Items.AddRange(quturs);

            Mytools.InitListViewShapes(listView1);
            Mytools.FillGridView(dataGridView1,dateTimePicker1);
        }
      
        private void AddBtn_Click(object sender, EventArgs e)
        {
            //check if not empty inputs 
            if (!Mytools.ValidationInputs(listView1,comboBox1,numsTB,widthTB,heightTB,tailsTB))
                return;
            //get shape by selected image
            Mytools.shape = Mytools.CheckedWhichShapeInit(widthTB,tailsTB,heightTB);

            double totalM = Mytools.shape.TotalLengthCm() / 100;
            double tails=0, height=0;
            if (Mytools.shape is RectangleMissOneWithTails)
                tails= (Mytools.shape as RectangleMissOneWithTails).tails;
            if (Mytools.shape is DoubleLine)
                height = (Mytools.shape as DoubleLine).height;
            else if (Mytools.shape is LightingStrike)
                height = (Mytools.shape as LightingStrike).curvedHeight;

            var item = new ItemSql { 
            width = Mytools.shape.width,
            tails=tails,
            height=height,
            nameShape =Mytools.lastShapeSelected,
            };
            //add item to database
            DbContextHelper.Controller.Items.Add(item);
            DbContextHelper.Controller.SaveChanges();
           //int idLastItem = DbContextHelper.Controller.Items.OrderBy(o=>o.id).LastOrDefault().id;
           item = DbContextHelper.Controller.Items.OrderByDescending(i=>i.id).FirstOrDefault();
            //add order to database
            DbContextHelper.Controller.Orders.Add(new Order
            {   date=dateTimePicker1.Value,
                idItem = item.id,
                nums= int.Parse(numsTB.Text),
                qutur=int.Parse(comboBox1.SelectedItem + "")
            });
            DbContextHelper.Controller.SaveChanges();
            Mytools.FillGridView(dataGridView1, dateTimePicker1);
        }

        

        
        
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
        }



        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Mytools.lastShapeSelected = listView1.SelectedItems[0].SubItems[0].Text;

            if (Mytools.lastShapeSelected == "RectangleMissOneWithTails" || Mytools.lastShapeSelected == "CurvedRectangleMissOneWithTails")
                tailsTB.Enabled = true;
            else
                tailsTB.Enabled = false;
            if (Mytools.lastShapeSelected != "Line")
                heightTB.Enabled = true;
            else
                heightTB.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var r = dataGridView1.CurrentRow;
            if(r!=null)
            MessageBox.Show(r.Index + "");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           var rows= dataGridView1.SelectedRows;
            if(rows.Count == 0)
            {
                MessageBox.Show("נא לבחור שורה בכדי להמשיך");
                return;
            }
            var res = MessageBox.Show("האם ברצונך להמשיך","סים לב",MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
                return;
            else
            {
                foreach (DataGridViewRow r in rows)
                {
                    int id = int.Parse(r.Cells[0].Value + "");
                    var order = DbContextHelper.Controller.Orders.FirstOrDefault(o => o.id == id);
                    var item = DbContextHelper.Controller.Items.FirstOrDefault(i => i.id == order.idItem);
                    if (item != null)
                    {
                        DbContextHelper.Controller.Items.Remove(item);
                        DbContextHelper.Controller.Orders.Remove(order);
                        DbContextHelper.Controller.SaveChanges();
                    }
                }
                MessageBox.Show("הפעולה פוצעה בהצלחה");
                Mytools.FillGridView(dataGridView1, dateTimePicker1);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           Mytools.FillGridView(dataGridView1,dateTimePicker1);
            dateTimePicker1.Visible = false;
            dateTimePicker1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
