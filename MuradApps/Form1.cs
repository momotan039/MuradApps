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
        List<Item> items=new List<Item> ();
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
        private bool ValidationInputs()
        {
            if (lastShapeSelected == null)
            {
                MessageBox.Show("נא לבחור את הצורה !! ");
                listView1.Focus();
                return false;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("נא לבחור את הקוטר");
                comboBox1.Focus();
                return false;
            }
            if (numsTB.Text == "")
            {
                MessageBox.Show("נא לכניס מספר המוטות");
                numsTB.Focus();
                return false;
            }
            if (widthTB.Text == "")
            {
                MessageBox.Show("נא לכניס את הרוחב");
                widthTB.Focus();
                return false;
            }
            if (heightTB.Enabled == true && heightTB.Text == "")
            {
                MessageBox.Show("נא לכניס את הגובה");
                heightTB.Focus();
                return false;
            }
        
            if (tailsTB.Enabled == true && tailsTB.Text == "")
            {
                MessageBox.Show("נא לכניס רוחב חיצוני");
                tailsTB.Focus();
                return false ;
            }
            return true;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            //check if not empty inputs 
            if (!ValidationInputs())
                return;
            //get shape by selected image
            shape = CheckedWhichShapeInit();

            double totalM = shape.TotalLengthCm() / 100;
            var item = new ItemSql { 
            nums= int.Parse(numsTB.Text),
            totalm= totalM,
            qutur= int.Parse(comboBox1.SelectedItem+""),
            weight= CalculateWidth(totalM),
            nameShape=lastShapeSelected,
            };
            //add item to database
            DbContextHelper.Controller.Items.Add(item);
            //int idLastItem = DbContextHelper.Controller.Items.OrderBy(o=>o.id).LastOrDefault().id;
            item = DbContextHelper.Controller.Items.LastOrDefault();
            //add order to database
            DbContextHelper.Controller.Orders.Add(new Order
            {
                idItem = item.id,
            });
            DbContextHelper.Controller.SaveChanges();
            FillGridView();
        }

        private void FillGridView()
        {
            dataGridView1.Rows.Clear();
            var orders = DbContextHelper.Controller.Orders.ToList();
            int i = 1;
            foreach (var order in orders)
            {
                var item = DbContextHelper.Controller.Items.FirstOrDefault(i=>i.id==order.idItem);
                
                dataGridView1.Rows.Add(
                    item.id,i++,
                 item.nums,
                 item.qutur,
                 item.totalm, item.weight
                );
            }
            
        }

        private double CalculateWidth(double totalM)
        {
            double weight = 0;
            if (shape is CircularDoubleLine)
                weight = 0.222 * totalM * double.Parse(numsTB.Text);
            else
                weight = double.Parse(numsTB.Text) * 0.00616 * totalM * Math.Pow(double.Parse(comboBox1.SelectedItem.ToString()), 2);
       return Math.Round(weight,2);
        }
        private Shape CheckedWhichShapeInit()
        {
            Shape shape=null;
            double width = 0, height = 0, tails = 0 ;
            width = double.Parse(widthTB.Text);
            if(tailsTB.Text!="")
            tails= double.Parse(tailsTB.Text);
            if (heightTB.Text != "")
                height = double.Parse(heightTB.Text);
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
            if (lastShapeSelected != "Line")
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
           var r= dataGridView1.CurrentRow;
            if(r==null)
            {
                MessageBox.Show("נא לבחור שורה בכדי להמשיך");
                return;
            }
            var res = MessageBox.Show("האם ברצונך להמשיך","סים לב",MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
                return;
            else
            {
                int id=int.Parse(r.Cells[0].Value + "");
                var item = items.FirstOrDefault(i=>i.id==id);
                if (item == null)
                {
                    MessageBox.Show("this Item not found");
                }    

                    items.Remove(item);
                FillGridView();
            }
        }

        
    }
}
