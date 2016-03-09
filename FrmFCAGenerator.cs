using ApexUtility.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ApexUtility
{
    public partial class FrmFCAGenerator : Form
    {
        public FCADataSet FCAData = new FCADataSet();
        public DataStructure DS;
        FrmResult frmresult;
        AsgModel newmodel = new AsgModel();
        public FrmFCAGenerator()
        {
            InitializeComponent();
        }

        private void FCAGenerator_Load(object sender, EventArgs e)
        {

            newmodel.DataSet = FCAData;
            newmodel.DS = DS;
            newmodel.GenerateConceptFromInclose(DS.Name);
            newmodel.GetConcepts(DS.Name);
            newmodel.CalculateTheFrequencyOfObjectsInConcept();
            label4.Text = newmodel.Concepts.Count.ToString();


            treeView1.Nodes.Clear();
            TreeNode Current = new TreeNode();
            StringBuilder s = new StringBuilder();
            foreach (var item in newmodel.Concepts)
            {
                s.Append(item.ToString());
                treeView1.Nodes.Add(item.ToString());
            }
            richTextBox1.Text = newmodel.Log;
            dataGridView1.DataSource = newmodel.DataSet.Extents;
            dataGridView2.DataSource = newmodel.DataSet.Intents;
        }
    }
}
