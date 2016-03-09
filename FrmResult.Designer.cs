namespace ApexUtility
{
    partial class FrmResult
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
            this.ResultProperties = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataSet = new System.Windows.Forms.PropertyGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FCAModel = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TestData = new System.Windows.Forms.PropertyGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.TrainData = new System.Windows.Forms.PropertyGrid();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultProperties
            // 
            this.ResultProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultProperties.Location = new System.Drawing.Point(3, 3);
            this.ResultProperties.Name = "ResultProperties";
            this.ResultProperties.Size = new System.Drawing.Size(410, 341);
            this.ResultProperties.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 373);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ResultProperties);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(416, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accuracy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataSet);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(416, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dataset";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataSet
            // 
            this.DataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataSet.Location = new System.Drawing.Point(3, 3);
            this.DataSet.Name = "DataSet";
            this.DataSet.Size = new System.Drawing.Size(410, 341);
            this.DataSet.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.FCAModel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(416, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FCAModel";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FCAModel
            // 
            this.FCAModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FCAModel.Location = new System.Drawing.Point(3, 3);
            this.FCAModel.Name = "FCAModel";
            this.FCAModel.Size = new System.Drawing.Size(410, 341);
            this.FCAModel.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.TestData);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(416, 347);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "TestData";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // TestData
            // 
            this.TestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestData.Location = new System.Drawing.Point(3, 3);
            this.TestData.Name = "TestData";
            this.TestData.Size = new System.Drawing.Size(410, 341);
            this.TestData.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.TrainData);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(416, 347);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "TrainDate";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // TrainData
            // 
            this.TrainData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrainData.Location = new System.Drawing.Point(3, 3);
            this.TrainData.Name = "TrainData";
            this.TrainData.Size = new System.Drawing.Size(410, 341);
            this.TrainData.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Log);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(416, 347);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Log";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Location = new System.Drawing.Point(3, 3);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(410, 341);
            this.Log.TabIndex = 0;
            this.Log.Text = "";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 373);
            this.Controls.Add(this.tabControl1);
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PropertyGrid ResultProperties;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.PropertyGrid DataSet;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.PropertyGrid FCAModel;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.PropertyGrid TestData;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.PropertyGrid TrainData;
        private System.Windows.Forms.TabPage tabPage6;
        public System.Windows.Forms.RichTextBox Log;

    }
}