namespace MuradApps
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nums2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qutur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.display = new System.Windows.Forms.DataGridViewImageColumn();
            this.numsTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.widthTB = new System.Windows.Forms.TextBox();
            this.heightTB = new System.Windows.Forms.TextBox();
            this.tailsTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.nums2,
            this.qutur,
            this.length,
            this.weight,
            this.display});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 452);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView1.RowTemplate.Height = 150;
            this.dataGridView1.Size = new System.Drawing.Size(1239, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // index
            // 
            this.index.HeaderText = "ספר הפרט";
            this.index.MinimumWidth = 6;
            this.index.Name = "index";
            this.index.ReadOnly = true;
            // 
            // nums2
            // 
            this.nums2.HeaderText = "מספר מוטות";
            this.nums2.MinimumWidth = 6;
            this.nums2.Name = "nums2";
            this.nums2.ReadOnly = true;
            // 
            // qutur
            // 
            this.qutur.HeaderText = "קוטר";
            this.qutur.MinimumWidth = 6;
            this.qutur.Name = "qutur";
            this.qutur.ReadOnly = true;
            // 
            // length
            // 
            this.length.HeaderText = "אורך המוט ב (M)";
            this.length.MinimumWidth = 6;
            this.length.Name = "length";
            this.length.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.HeaderText = "משקל";
            this.weight.MinimumWidth = 6;
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // display
            // 
            this.display.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.display.HeaderText = "תואר הצורה";
            this.display.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.display.MinimumWidth = 6;
            this.display.Name = "display";
            this.display.ReadOnly = true;
            // 
            // numsTB
            // 
            this.numsTB.BackColor = System.Drawing.Color.White;
            this.numsTB.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numsTB.Location = new System.Drawing.Point(447, 262);
            this.numsTB.Name = "numsTB";
            this.numsTB.Size = new System.Drawing.Size(239, 58);
            this.numsTB.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(490, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "שמירה";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(689, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "מספר מוטות";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(689, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 53);
            this.label2.TabIndex = 4;
            this.label2.Text = "קוטר";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(447, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(239, 59);
            this.comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(689, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 53);
            this.label4.TabIndex = 7;
            this.label4.Text = "צורה";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 11;
            this.button2.Text = "בחירת צורה";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(252, 452);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(689, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 53);
            this.label3.TabIndex = 13;
            this.label3.Text = "רוחב";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(689, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 53);
            this.label5.TabIndex = 14;
            this.label5.Text = "רוחב חיצוני";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(689, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 53);
            this.label6.TabIndex = 13;
            this.label6.Text = "גובה";
            // 
            // widthTB
            // 
            this.widthTB.BackColor = System.Drawing.Color.White;
            this.widthTB.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.widthTB.Location = new System.Drawing.Point(452, 59);
            this.widthTB.Name = "widthTB";
            this.widthTB.Size = new System.Drawing.Size(239, 58);
            this.widthTB.TabIndex = 15;
            // 
            // heightTB
            // 
            this.heightTB.BackColor = System.Drawing.Color.White;
            this.heightTB.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.heightTB.Location = new System.Drawing.Point(452, 123);
            this.heightTB.Name = "heightTB";
            this.heightTB.Size = new System.Drawing.Size(239, 58);
            this.heightTB.TabIndex = 16;
            // 
            // tailsTB
            // 
            this.tailsTB.BackColor = System.Drawing.Color.White;
            this.tailsTB.Enabled = false;
            this.tailsTB.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tailsTB.Location = new System.Drawing.Point(452, 198);
            this.tailsTB.Name = "tailsTB";
            this.tailsTB.Size = new System.Drawing.Size(239, 58);
            this.tailsTB.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 852);
            this.Controls.Add(this.tailsTB);
            this.Controls.Add(this.heightTB);
            this.Controls.Add(this.widthTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numsTB);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox numsTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthTB;
        private System.Windows.Forms.TextBox heightTB;
        private System.Windows.Forms.TextBox tailsTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn nums2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qutur;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewImageColumn display;
    }
}
