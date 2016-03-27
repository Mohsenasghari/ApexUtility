namespace ApexUtility
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ToolBox = new System.Windows.Forms.ToolStrip();
            this.open_icon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Compile_Icon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ReadData_Icon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowFCA_Icon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TestTrain_Algorithm = new System.Windows.Forms.ToolStripButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataViewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.getCxt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DataProperties = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.DataViewer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.DataProperties.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(353, 170);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ToolBox
            // 
            this.ToolBox.AutoSize = false;
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_icon,
            this.toolStripSeparator1,
            this.Compile_Icon,
            this.toolStripSeparator2,
            this.ReadData_Icon,
            this.toolStripSeparator3,
            this.ShowFCA_Icon,
            this.toolStripSeparator5,
            this.TestTrain_Algorithm,
            this.toolStripSeparator7,
            this.toolStripButton1});
            this.ToolBox.Location = new System.Drawing.Point(0, 0);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(1123, 50);
            this.ToolBox.TabIndex = 1;
            this.ToolBox.Text = "toolStrip1";
            // 
            // open_icon
            // 
            this.open_icon.Image = global::ApexUtility.Properties.Resources._1456962569_document_open;
            this.open_icon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open_icon.Name = "open_icon";
            this.open_icon.Size = new System.Drawing.Size(40, 47);
            this.open_icon.Text = "Open";
            this.open_icon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.open_icon.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // Compile_Icon
            // 
            this.Compile_Icon.Image = global::ApexUtility.Properties.Resources._1456962696_resolutions_19;
            this.Compile_Icon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Compile_Icon.Name = "Compile_Icon";
            this.Compile_Icon.Size = new System.Drawing.Size(56, 47);
            this.Compile_Icon.Text = "Compile";
            this.Compile_Icon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Compile_Icon.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // ReadData_Icon
            // 
            this.ReadData_Icon.Image = global::ApexUtility.Properties.Resources._1456962638_document_save;
            this.ReadData_Icon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReadData_Icon.Name = "ReadData_Icon";
            this.ReadData_Icon.Size = new System.Drawing.Size(61, 47);
            this.ReadData_Icon.Text = "ReadData";
            this.ReadData_Icon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ReadData_Icon.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // ShowFCA_Icon
            // 
            this.ShowFCA_Icon.Image = global::ApexUtility.Properties.Resources._1456962709_resolutions_13;
            this.ShowFCA_Icon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowFCA_Icon.Name = "ShowFCA_Icon";
            this.ShowFCA_Icon.Size = new System.Drawing.Size(33, 47);
            this.ShowFCA_Icon.Text = "FCA";
            this.ShowFCA_Icon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ShowFCA_Icon.Click += new System.EventHandler(this.toolStripButton4_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 50);
            // 
            // TestTrain_Algorithm
            // 
            this.TestTrain_Algorithm.Image = global::ApexUtility.Properties.Resources._1456962679_resolutions_07;
            this.TestTrain_Algorithm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TestTrain_Algorithm.Name = "TestTrain_Algorithm";
            this.TestTrain_Algorithm.Size = new System.Drawing.Size(60, 47);
            this.TestTrain_Algorithm.Text = "TestTrain";
            this.TestTrain_Algorithm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TestTrain_Algorithm.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(356, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(567, 170);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 170);
            this.panel1.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 170);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(200, 220);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 330);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(203, 406);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 144);
            this.tabControl1.TabIndex = 8;
            // 
            // DataViewer
            // 
            this.DataViewer.Controls.Add(this.tabPage1);
            this.DataViewer.Controls.Add(this.tabPage2);
            this.DataViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataViewer.Location = new System.Drawing.Point(203, 220);
            this.DataViewer.Name = "DataViewer";
            this.DataViewer.SelectedIndex = 0;
            this.DataViewer.ShowToolTips = true;
            this.DataViewer.Size = new System.Drawing.Size(920, 183);
            this.DataViewer.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RealData";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(906, 151);
            this.dataGridView1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 157);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BooleanMatrix";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(906, 126);
            this.dataGridView2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getCxt,
            this.toolStripSeparator4,
            this.toolStripButton7,
            this.toolStripSeparator6,
            this.toolStripButton6});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(906, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // getCxt
            // 
            this.getCxt.Image = global::ApexUtility.Properties.Resources._1456962709_resolutions_13;
            this.getCxt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.getCxt.Name = "getCxt";
            this.getCxt.Size = new System.Drawing.Size(115, 22);
            this.getCxt.Text = "Generate Cxt File";
            this.getCxt.Click += new System.EventHandler(this.getCxt_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::ApexUtility.Properties.Resources._1456962620_network_workgroup;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(145, 22);
            this.toolStripButton7.Text = "Run Inclose Algorithm";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = global::ApexUtility.Properties.Resources._1456962598_document_open;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(141, 22);
            this.toolStripButton6.Text = "Open Folder Location";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(203, 403);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(920, 3);
            this.splitter3.TabIndex = 11;
            this.splitter3.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1456962569_document-open.png");
            this.imageList1.Images.SetKeyName(1, "1456962598_document-open.png");
            this.imageList1.Images.SetKeyName(2, "1456962620_network-workgroup.png");
            this.imageList1.Images.SetKeyName(3, "1456962638_document-save.png");
            this.imageList1.Images.SetKeyName(4, "1456962660_applications-internet.png");
            this.imageList1.Images.SetKeyName(5, "1456962679_resolutions-07.png");
            this.imageList1.Images.SetKeyName(6, "1456962696_resolutions-19.png");
            this.imageList1.Images.SetKeyName(7, "1456962709_resolutions-13.png");
            this.imageList1.Images.SetKeyName(8, "1456962775_database-gear.png");
            // 
            // DataProperties
            // 
            this.DataProperties.Controls.Add(this.tabPage3);
            this.DataProperties.Controls.Add(this.tabPage4);
            this.DataProperties.Dock = System.Windows.Forms.DockStyle.Left;
            this.DataProperties.Location = new System.Drawing.Point(0, 50);
            this.DataProperties.Name = "DataProperties";
            this.DataProperties.SelectedIndex = 0;
            this.DataProperties.Size = new System.Drawing.Size(200, 500);
            this.DataProperties.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(192, 474);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(186, 468);
            this.propertyGrid1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.propertyGrid2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(192, 474);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "BooleanData";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(186, 468);
            this.propertyGrid2.TabIndex = 4;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(96, 47);
            this.toolStripButton1.Text = "Show Results";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.DataViewer);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataProperties);
            this.Controls.Add(this.ToolBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ToolBox.ResumeLayout(false);
            this.ToolBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.DataViewer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.DataProperties.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip ToolBox;
        private System.Windows.Forms.ToolStripButton open_icon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Compile_Icon;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ReadData_Icon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl DataViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ShowFCA_Icon;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton getCxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton TestTrain_Algorithm;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.TabControl DataProperties;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

