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
    public partial class FrmTestTrain : Form
    {
        public Entity.FCADataSet FCAData { get; set; }
        public Entity.DataStructure DataStructure { get; set; }
        public FrmTestTrain()
        {
            InitializeComponent();
        }
        void ShowLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    showlogtextbox.Text += log + Environment.NewLine;
                });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    for (int j = 0; j < NumberOfTry.Value; j++)
                    {
                        int _start = Convert.ToInt32(start.Value);
                        int _end = Convert.ToInt32(end.Value);
                        int _interval = Convert.ToInt32(interval.Value);
                        if (Decrease.Checked)
                        {
                            _interval = _interval * -1;
                        }

                        FrmShowMultiResult smr = new FrmShowMultiResult();
                        List<TestTrain> ListTesttrain = new List<TestTrain>();
                        for (int i = _start; i >= _end; i = i + _interval)
                        {
                            TestTrain tt = new TestTrain();
                            tt.PercentofTestData = i;
                            tt.DataSet = FCAData;
                            tt.DS = DataStructure;
                            ShowLog("start Create Test Data .... " + i.ToString() + "%");
                            tt.Create();
                            ShowLog("Start Calculate Accuracy...." + i.ToString() + "%");
                            string _log = tt.CalculateAccuracyASGModel();
                            FrmResult frmresult = new FrmResult();
                            frmresult.TopLevel = false;
                            TabPage ResultTabpage = new TabPage(i.ToString() + "% TestData");
                            tt.TestTrainName = i.ToString() + "% TestData";
                            smr.tabControl1.TabPages.Add(ResultTabpage);
                            ResultTabpage.Controls.Add(frmresult);
                            frmresult.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            frmresult.Dock = DockStyle.Fill;
                            frmresult.ResultProperties.SelectedObject = tt;
                            frmresult.DataSet.SelectedObject = FCAData;
                            frmresult.FCAModel.SelectedObject = tt.FCAModel;
                            frmresult.TrainData.SelectedObject = tt.TrainData;
                            frmresult.TestData.SelectedObject = tt.TestData;
                            frmresult.Log.Text = _log;
                            frmresult.Show();
                            ListTesttrain.Add(tt);
                            ShowLog("-----------------------------------------");
                        }
                        smr.RenderChart(ListTesttrain);
                        smr.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            });

        }
    }
}
