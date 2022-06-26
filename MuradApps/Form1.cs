using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
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
            Mytools.FillGridView(dataGridView1,dateTimePicker1,weightLabel);
        }
      
        private void AddBtn_Click(object sender, EventArgs e)
        {
            //check if not empty inputs zzz
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
            Mytools.FillGridView(dataGridView1, dateTimePicker1, weightLabel);
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
                Mytools.FillGridView(dataGridView1, dateTimePicker1, weightLabel);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           Mytools.FillGridView(dataGridView1,dateTimePicker1, weightLabel);
            dateTimePicker1.Visible = false;
            dateTimePicker1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            var sfd = new SaveFileDialog();
            sfd.Title = "תבחר תיקיה לשמור הדוח";
            sfd.Filter = "Excel File |*.xlsx";
            sfd.ShowDialog();
            if (sfd.FileName == "")
                return;
            
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            // name of the sheet
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            // Setting the properties
            workSheet.Row(1).Height = 30;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.Font.Size = 25;
            workSheet.Row(1).Style.VerticalAlignment= ExcelVerticalAlignment.Center;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                workSheet.Row(i+2).Height = 100;
                workSheet.Row(i+2).Style.Font.Size = 20;
                workSheet.Row(i+2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(i + 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            //add header text
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                workSheet.Cells[1,i].Value = dataGridView1.Columns[i].HeaderText;
            }
            //create New Folder to save temp pictures
            Directory.CreateDirectory("tempFolder");
            // add rows text
            for (int r = 0; r < dataGridView1.Rows.Count; r++)
            {
                for (int c = 0; c < dataGridView1.Columns.Count-1; c++)
                {
                    object val = dataGridView1.Rows[r].Cells[c + 1].Value;
                    if(val is Image)
                    {
                        //save image to current  folder
                        var img = dataGridView1.Rows[r].Cells[c+1].Value as Bitmap;
                        string path = "tempFolder/imgExcel"+r+".png";
                        try
                        {
                            img.Save(path);
                        }
                        catch (Exception)
                        {

                            //MessageBox.Show("התרחשה בעית בעת ביצוע נא לנסות שוה");
                            return;

                        }

                        var pic = workSheet.Drawings.AddPicture(r + 1 + "", path);
                        //customize image
                        pic.From.Column = c;
                        pic.From.Row = r+1;
                        pic.SetSize(162,135);

                       
                    }
                    else
                    {
                        workSheet.Cells[r + 2, c + 1].Value = val;
                    }
                }
            }
            //add weight to end last row in file excel
            int lastRow = dataGridView1.RowCount + 2;

            workSheet.Cells[lastRow,1,lastRow,10].Merge=true;
            workSheet.Row(lastRow).Style.Font.Bold=true;
            workSheet.Row(lastRow).Style.Font.Size=28;
            workSheet.Row(lastRow).Style.HorizontalAlignment= ExcelHorizontalAlignment.Center;
            workSheet.Cells[lastRow, 1].Value = weightLabel.Text;

            // set to auto fit for the content
            // of the range, so we are using
            // AutoFit() method here. 
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                workSheet.Column(i).AutoFit();
            }

            // file name with .xlsx extension 
            

            if (File.Exists(sfd.FileName))
                File.Delete(sfd.FileName);

            // Create excel file on physical disk 
            FileStream objFileStrm = File.Create(sfd.FileName);
            objFileStrm.Close();
            File.WriteAllBytes(sfd.FileName, excel.GetAsByteArray());

            try
            {
                Directory.Delete("tempFolder", true);
            }
            catch (Exception)
            {
                MessageBox.Show("הקובץ נשמר בהצלחה");

                return;
            }
            MessageBox.Show("הקובץ נשמר בהצלחה");
        }
    }
    
}
