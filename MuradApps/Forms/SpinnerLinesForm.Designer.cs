﻿namespace MuradApps.Forms
{
    partial class SpinnerLinesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radiusSpinnerTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quturSpinnerTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(219, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spinner Lines";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Simple Indust Shaded", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(383, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 42);
            this.label4.TabIndex = 5;
            this.label4.Text = "סביבות r ";
            // 
            // radiusSpinnerTB
            // 
            this.radiusSpinnerTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.radiusSpinnerTB.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radiusSpinnerTB.ForeColor = System.Drawing.Color.White;
            this.radiusSpinnerTB.Location = new System.Drawing.Point(176, 122);
            this.radiusSpinnerTB.Name = "radiusSpinnerTB";
            this.radiusSpinnerTB.Size = new System.Drawing.Size(243, 40);
            this.radiusSpinnerTB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simple Indust Shaded", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(437, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "קוטר";
            // 
            // quturSpinnerTB
            // 
            this.quturSpinnerTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.quturSpinnerTB.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.quturSpinnerTB.ForeColor = System.Drawing.Color.White;
            this.quturSpinnerTB.Location = new System.Drawing.Point(176, 179);
            this.quturSpinnerTB.Name = "quturSpinnerTB";
            this.quturSpinnerTB.Size = new System.Drawing.Size(243, 40);
            this.quturSpinnerTB.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(235, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 60);
            this.button1.TabIndex = 8;
            this.button1.Text = "המשך";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpinnerLinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(629, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quturSpinnerTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radiusSpinnerTB);
            this.Controls.Add(this.label1);
            this.Name = "SpinnerLinesForm";
            this.Text = "Spinner Lines";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox radiusSpinnerTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quturSpinnerTB;
        private System.Windows.Forms.Button button1;
    }
}