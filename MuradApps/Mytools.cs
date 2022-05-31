using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuradApps
{
    internal static  class Mytools
    {
        public static Shape shape = null;
        public static string lastShapeSelected;
        public static bool ValidationInputs(ListView listView1, ComboBox comboBox1, TextBox numsTB, TextBox widthTB, TextBox heightTB, TextBox tailsTB)
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
                return false;
            }
            return true;
        }
        public static void FillGridView(DataGridView dataGridView1,DateTimePicker dateTime)
        {
            dataGridView1.Rows.Clear();
            var orders = DbContextHelper.Controller.Orders.ToList().Where(o=>o.date.Month==dateTime.Value.Month);
            int i = 1;
            foreach (var order in orders)
            {
                var item = DbContextHelper.Controller.Items.FirstOrDefault(i => i.id == order.idItem);
                shape = GetShapeByItem(item);
                dataGridView1.Rows.Add(
                 item.id, order.date.ToShortDateString(), i++,
                 order.nums,
                 order.qutur,
                 shape.TotalLengthCm() / 100,
                 CalculateWidth(shape.TotalLengthCm() / 100, order),
                 shape.CustomizeImage()
                );
            }
        }
        public static double CalculateWidth(double totalM, Order order)
        {
            double weight = 0;
            if (shape is CircularDoubleLine)
                weight = 0.222 * totalM * order.nums;
            else
                weight = order.nums * 0.00616 * totalM * Math.Pow(order.qutur, 2);
            return Math.Round(weight, 2);
        }

        public  static  Shape GetShapeByItem(ItemSql item)
        {
            if (item == null)
                return null;
            Shape shape = null;
            double width = 0, height = 0, tails = 0;
            if (item.tails != 0)
                tails = item.tails;
            if (item.height != 0)
                height = item.height;
            width = item.width;
            lastShapeSelected = item.nameShape;
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
        public static void InitListViewShapes(ListView listView1)
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
       public static  Shape CheckedWhichShapeInit(TextBox widthTB, TextBox tailsTB, TextBox heightTB)
        {
            Shape shape = null;
            double width = 0, height = 0, tails = 0;
            width = double.Parse(widthTB.Text);
            if (tailsTB.Text != "")
                tails = double.Parse(tailsTB.Text);
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

    }
}
