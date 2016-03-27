using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApexUtility
{
    public partial class FrmOutPut : Form
    {
        public FrmOutPut()
        {
            InitializeComponent();
        }

        private void OutPutConfig_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Entity.OutPut.Results;
            foreach (var item in Entity.OutPut.Results)
            {
                TabPage tt = new TabPage(item.Key);
                RichTextBox t = new RichTextBox();
                t.Dock = DockStyle.Fill;
                t.Text += item.Key + Environment.NewLine;
                t.Text += "------------------------" + Environment.NewLine;
                foreach (var results in item.Value)
                {
                    t.Text += Math.Round(results,2) + Environment.NewLine;
                }
                tt.Controls.Add(t);
                tabControl1.TabPages.Add(tt);
            }

        }
    }
}
