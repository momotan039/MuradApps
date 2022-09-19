using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuradApps
{
    internal static class Mytools
    {
        public static Shape shape = null;
        public static string lastShapeNameSelected;
        public static Object[] quturs = new object[] {
            6, 8,10, 12,
            14, 16,18, 20,
            22,25,28,32,
            50};
        public static double[] weightQuturByMeter ={
            0.229,0.407,0.636,0.915,
            1.25,1.63,2.06,2.54,
            3.07,3.97,4.97,6.5,
            15.68};
        public static bool ValidationInputs(ListView listView1, ComboBox comboBox1, TextBox numsTB, TextBox widthTB, TextBox heightTB, TextBox tailsTB)
        {
            if (lastShapeNameSelected == null)
            {
                MessageBox.Show("נא לבחור את הצורה !! ");
                listView1.Focus();
                return false;
            }
            if (comboBox1.SelectedItem == null || !int.TryParse(comboBox1.SelectedItem.ToString(), out int d))
            {
                MessageBox.Show("נא לבחור את הקוטר");
                comboBox1.Focus();
                return false;
            }
            if (!double.TryParse(numsTB.Text, out double a))
            {
                MessageBox.Show("נא לכניס מספר המוטות");
                numsTB.Focus();
                return false;
            }
            if (!double.TryParse(widthTB.Text, out double b))
            {
                MessageBox.Show("נא לכניס את הרוחב");
                widthTB.Focus();
                return false;
            }
            if (heightTB.Enabled == true && (!double.TryParse(heightTB.Text, out double c)))
            {
                MessageBox.Show("נא לכניס את הגובה");
                heightTB.Focus();
                return false;
            }

            if (tailsTB.Enabled == true && (!double.TryParse(tailsTB.Text, out double f)))
            {
                MessageBox.Show("נא לכניס רוחב חיצוני");
                tailsTB.Focus();
                return false;
            }
            return true;
        }
        public static void FillGridView(DataGridView dataGridView1, DateTimePicker dateTime, Label weightLabel, CheckBox monthChecker)
        {
            dataGridView1.Rows.Clear();
            IEnumerable<Order> orders;

            //get orders by selected month
            if (monthChecker.Checked)
                orders = DbContextHelper.Controller.Orders.ToList().Where(o => o.date.Month == dateTime.Value.Month);
            //get orders by selected full date
            else
                orders = DbContextHelper.Controller.Orders.ToList().Where(o => o.date.ToShortDateString() == dateTime.Value.ToShortDateString());

            int rows = 1;
            double totalWieght = 0;
            foreach (var order in orders)
            {
                var item = DbContextHelper.Controller.Items.FirstOrDefault(i => i.id == order.idItem);
                shape = GetShapeByItem(item);
                double wieght = CalculateWieght(shape.TotalLengthCm() / 100, order);
                dataGridView1.Rows.Add(
                 item.id,
                 rows++,
                 order.date.ToShortDateString(),
                 order.nums,
                 order.qutur,
                 shape.TotalLengthCm() / 100,
                 wieght,
                 shape.CustomizeImage()
                );
                totalWieght += wieght;
            }

            weightLabel.Text = +Math.Round(totalWieght, 2) + ":(kg)סכה\"ל משקל ב";
        }
        public static double CalculateWieght(double totalM, Order order)
        {
            double weight = 0;
            if (shape is CircularDoubleLine)
                weight = 0.222 * totalM * order.nums;
            else
            {
                double weightOfQutur = 0;
                for (int i = 0; i < quturs.Length; i++)
                {
                    if (Convert.ToInt16(quturs[i]) == order.qutur)
                    {
                        weightOfQutur = weightQuturByMeter[i];
                        break;
                    }
                }
                //weight = order.nums * 0.00616 * totalM * Math.Pow(order.qutur, 2);
                weight = order.nums * weightOfQutur * totalM ;

            }
            return Math.Round(weight, 2);
        }
        public static Shape GetShapeByItem(ItemSql item)
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
            lastShapeNameSelected = item.nameShape;
            if (lastShapeNameSelected == "Line")
                shape = new Line(width);
            else if (lastShapeNameSelected == "LightingStrike")
                shape = new LightingStrike(width, height);
            else if (lastShapeNameSelected == "DoubleLine")
                shape = new DoubleLine(width, height);
            else if (lastShapeNameSelected == "CircularDoubleLine")
                shape = new CircularDoubleLine(width, height);
            else if (lastShapeNameSelected == "Rectangle")
                shape = new Rectangle(width, height);
            else if (lastShapeNameSelected == "RectangleMissOne")
                shape = new RectangleMissOne(width, height);
            else if (lastShapeNameSelected == "RectangleMissOneWithTails")
                shape = new RectangleMissOneWithTails(width, height, tails);
            else if (lastShapeNameSelected == "CurvedRectangleMissOneWithTails")
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
        public static Shape CheckedWhichShapeInit(TextBox widthTB, TextBox tailsTB, TextBox heightTB)
        {
            double width = 0, height = 0, tails = 0;
            width = double.Parse(widthTB.Text);
            if (tailsTB.Text != "")
                tails = double.Parse(tailsTB.Text);
            if (heightTB.Text != "")
                height = double.Parse(heightTB.Text);

            if (lastShapeNameSelected == "Line")
                return new Line(width);
            else if (lastShapeNameSelected == "LightingStrike")
                return new LightingStrike(width, height);
            else if (lastShapeNameSelected == "DoubleLine")
                return new DoubleLine(width, height);
            else if (lastShapeNameSelected == "CircularDoubleLine")
                return new CircularDoubleLine(width, height);
            else if (lastShapeNameSelected == "Rectangle")
                return new Rectangle(width, height);
            else if (lastShapeNameSelected == "RectangleMissOne")
                return new RectangleMissOne(width, height);
            else if (lastShapeNameSelected == "RectangleMissOneWithTails")
                return new RectangleMissOneWithTails(width, height, tails);
            else
                return new CurvedRectangleMissOneWithTails(width, height, tails);
        }

        public static void ChangeBackgroundSelectedShape(ListView listView)
        {
            if (lastShapeNameSelected == null)
                return;
            //reset forground color for items
            foreach (ListViewItem item in listView.Items)
            {
                item.ForeColor = Color.White;
            }
            //change selected item forground
            listView.FindItemWithText(lastShapeNameSelected).ForeColor = Color.Red;
            //remove defult blue color from selected item
            listView.SelectedItems.Clear();
        }
    }
}
