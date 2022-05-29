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

        //200 15 500 10  662k
        static string lastShapeSelected;
        static Shape shape=null;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var quturs = new object[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 25 };
            comboBox1.Items.AddRange(quturs);
            InitListViewShapes();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lastShapeSelected == null)
            {
                MessageBox.Show("נא לבחור את הצורה !! ");
                return;
            }

            if (numsTB.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("נא למלא את כל השדודת");
                return;
            }
            shape = CheckedWhichShapeInit();
            double totalM = shape.Total() / 100;
            double weight = 0;
            if (shape is CircularDoubleLine)
                weight = 0.222 * totalM * double.Parse(numsTB.Text);
            else
                weight = double.Parse(numsTB.Text) * 0.00616 * totalM * Math.Pow(double.Parse(comboBox1.SelectedItem.ToString()), 2);

            dataGridView1.Rows.Add(ItemList.index++,numsTB.Text,comboBox1.SelectedItem, totalM,weight, shape.CustomizeImage());
            lastShapeSelected = null;
            numsTB.Text = "";
            comboBox1.SelectedItem = null;
        }
        private Shape CheckedWhichShapeInit()
        {
            Shape shape=null;
            double width = 0, height = 0, tails = 0 ;
            width = double.Parse(widthTB.Text);
            height= double.Parse(heightTB.Text);
            if(tailsTB.Text!="")
            tails= double.Parse(tailsTB.Text);
            if (lastShapeSelected == "Line")
                shape = new Line(width);
            else if (lastShapeSelected == "LightingStrike")
                shape = new LightingStrike(width, height);
            else if (lastShapeSelected == "DoubleLine")
                shape = new DoubleLine(width, height);
            else if (lastShapeSelected == "CircularDoubleLine")
                shape = new CircularDoubleLine(width, height);
            else if (lastShapeSelected == "Rectangle")
                shape = new Rectangle(width, height);
            else if (lastShapeSelected == "RectangleMissOne")
                shape = new RectangleMissOne(width, height);
            else if (lastShapeSelected == "RectangleMissOneWithTails")
                shape = new RectangleMissOneWithTails(width, height, tails);
            else if (lastShapeSelected == "CurvedRectangleMissOneWithTails")
                shape = new CurvedRectangleMissOneWithTails(width, height, tails);

            return shape;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
        }

        private void InitListViewShapes()
        {
            listView1.View = View.LargeIcon;
            string[] paths = Directory.GetFiles(@"../../../images/");
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(100, 100);
            foreach (string path in paths)
            {
                imgs.Images.Add(Image.FromFile(path));
            }

            listView1.LargeImageList = imgs;
            listView1.Items.Add("CircularDoubleLine", 0);
            listView1.Items.Add("CurvedRectangleMissOneWithTails", 1);
            listView1.Items.Add("DoubleLine", 2);
            listView1.Items.Add("LightingStrike", 3);
            listView1.Items.Add("Line", 4);
            listView1.Items.Add("Rectangle", 5);
            listView1.Items.Add("RectangleMissOne", 6);
            listView1.Items.Add("RectangleMissOneWithTails", 7);
        }



        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            lastShapeSelected = listView1.SelectedItems[0].SubItems[0].Text;

            if (lastShapeSelected == "RectangleMissOneWithTails" || lastShapeSelected== "CurvedRectangleMissOneWithTails")
                tailsTB.Enabled = true;
            else
                tailsTB.Enabled = false;    

            listView1.SelectedItems.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
