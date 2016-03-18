namespace ApexUtility
{
    partial class FrmTestTrain
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
            this.button1 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.NumericUpDown();
            this.interval = new System.Windows.Forms.NumericUpDown();
            this.end = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.showlogtextbox = new System.Windows.Forms.RichTextBox();
            this.Decrease = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumberOfTry = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showResultOfEachIteration = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTry)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(61, 26);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(47, 20);
            this.start.TabIndex = 2;
            this.start.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(61, 52);
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(47, 20);
            this.interval.TabIndex = 3;
            this.interval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(203, 26);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(40, 20);
            this.end.TabIndex = 4;
            this.end.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "InterVal";
            // 
            // showlogtextbox
            // 
            this.showlogtextbox.Location = new System.Drawing.Point(12, 142);
            this.showlogtextbox.Name = "showlogtextbox";
            this.showlogtextbox.Size = new System.Drawing.Size(328, 150);
            this.showlogtextbox.TabIndex = 6;
            this.showlogtextbox.Text = "";
            // 
            // Decrease
            // 
            this.Decrease.AutoSize = true;
            this.Decrease.Checked = true;
            this.Decrease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Decrease.Location = new System.Drawing.Point(133, 55);
            this.Decrease.Name = "Decrease";
            this.Decrease.Size = new System.Drawing.Size(72, 17);
            this.Decrease.TabIndex = 7;
            this.Decrease.Text = "Decrease";
            this.Decrease.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showResultOfEachIteration);
            this.groupBox1.Controls.Add(this.NumberOfTry);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.Decrease);
            this.groupBox1.Controls.Add(this.interval);
            this.groupBox1.Controls.Add(this.end);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Data Seting";
            // 
            // NumberOfTry
            // 
            this.NumberOfTry.Location = new System.Drawing.Point(61, 91);
            this.NumberOfTry.Name = "NumberOfTry";
            this.NumberOfTry.Size = new System.Drawing.Size(47, 20);
            this.NumberOfTry.TabIndex = 12;
            this.NumberOfTry.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Number Of Try";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // showResultOfEachIteration
            // 
            this.showResultOfEachIteration.AutoSize = true;
            this.showResultOfEachIteration.Location = new System.Drawing.Point(153, 94);
            this.showResultOfEachIteration.Name = "showResultOfEachIteration";
            this.showResultOfEachIteration.Size = new System.Drawing.Size(169, 17);
            this.showResultOfEachIteration.TabIndex = 13;
            this.showResultOfEachIteration.Text = "Show Result Of Each Iteration";
            this.showResultOfEachIteration.UseVisualStyleBackColor = true;
            // 
            // FrmTestTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 337);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showlogtextbox);
            this.Controls.Add(this.button1);
            this.Name = "FrmTestTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestTrain";
            ((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfTry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown start;
        private System.Windows.Forms.NumericUpDown interval;
        private System.Windows.Forms.NumericUpDown end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox showlogtextbox;
        private System.Windows.Forms.CheckBox Decrease;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumberOfTry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox showResultOfEachIteration;
    }
}