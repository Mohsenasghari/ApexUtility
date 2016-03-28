using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ApexUtility
{
    public partial class FrmTestTrain : Form
    {
        public Entity.FCADataSet FCAData { get; set; }
        public Entity.DataStructure DataStructure { get; set; }
        public Dictionary<string, List<double>> RunAccuracy;
        public FrmTestTrain()
        {

            InitializeComponent();
            RunAccuracy = new Dictionary<string, List<double>>();
        }
        void ShowLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    showlogtextbox.Text = log + Environment.NewLine + showlogtextbox.Text;
                });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showlogtextbox.Text = "";
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            button1.Enabled = false;
                        });
                    }
                    int _start = Convert.ToInt32(start.Value);
                    int _end = Convert.ToInt32(end.Value);
                    int _interval = Convert.ToInt32(interval.Value);
                    if (Decrease.Checked)
                    {
                        _interval = _interval * -1;
                    }

                    FrmShowMultiResult smr = new FrmShowMultiResult();
                    List<TestTrain> ListTesttrain = new List<TestTrain>();
                    RunAccuracy.Clear();
                    for (int i = _start; i >= _end; i = i + _interval)
                    {
                        RunAccuracy.Add("Run" + i.ToString(), new List<double>());
                        for (int j = 0; j < NumberOfTry.Value; j++)
                        {
                            TestTrain tt = new TestTrain();
                            tt.PercentofTestData = i;
                            tt.DataSet = FCAData;
                            tt.DS = DataStructure;
                            tt.Create();
                            ShowLog("Training...." + (100 - i).ToString() + "%");
                            string _log = tt.CalculateAccuracyASGModel();
                            FrmResult frmresult = new FrmResult();
                            frmresult.TopLevel = false;
                            TabPage ResultTabpage = new TabPage((100 - i).ToString() + "% Training");
                            tt.TestTrainName = (100 - i).ToString() + "% TestData";
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
                            ShowLog("Calculated Accuracy.... Training" + (100 - i).ToString() + "%  Run:" + j + " => " + tt.Accuracy + "%");
                            RunAccuracy["Run" + i.ToString()].Add(tt.Accuracy);

                        }
                        ShowLog("------------------------------------------------------------------");
                        ShowLog("Average Accuracies" + i.ToString() + "% =>:" + RunAccuracy["Run" + i].Average() + "%");
                        ShowLog("------------------------------------------------------------------");

                    }

                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            button1.Enabled = true;
                        });
                    }

                    smr.RenderChart(ListTesttrain);
                    if (showResultOfEachIteration.Checked)
                    {
                        smr.ShowDialog();
                    }

                    TabControl charttabs = new TabControl();
                    ChartArea totalresultchartarea = new ChartArea();
                    Chart totalresult = new Chart();
                    totalresult.ChartAreas.Add(totalresultchartarea);
                    totalresult.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

                    ChartArea Avgchartarea = new ChartArea();
                    Chart AverageResult = new Chart();
                    AverageResult.ChartAreas.Add(Avgchartarea);
                    AverageResult.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

                    ChartArea VarianceChartArea = new ChartArea();
                    Chart VarianceResult = new Chart();
                    VarianceResult.ChartAreas.Add(VarianceChartArea);
                    VarianceResult.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

                    foreach (var item in RunAccuracy)
                    {
                        var series = totalresult.Series.Add(item.Key);
                        series.ChartType = SeriesChartType.Line;
                        foreach (var accuracies in item.Value)
                        {
                            series.Points.Add(accuracies);
                        }
                    }
                    totalresult.Dock = DockStyle.Fill;
                    TabPage accuracytab = new TabPage("Total Result");
                    accuracytab.Controls.Add(totalresult);
                    charttabs.TabPages.Add(accuracytab);


                    Panel averagepanel = new Panel();
                    var seriesaverage = AverageResult.Series.Add("AverageResults");
                    seriesaverage.ChartType = SeriesChartType.Line;
                    Entity.OutPut.Results.Add(DataStructure.Name + Entity.OutPut.IndexRun, new List<double>());
                    foreach (var item in RunAccuracy)
                    {
                        seriesaverage.Points.Add(item.Value.Average());
                        Entity.OutPut.Results[DataStructure.Name + Entity.OutPut.IndexRun].Add(item.Value.Average());
                    }
                    AverageResult.Dock = DockStyle.Top;
                    PropertyGrid _PropertyGrid = new System.Windows.Forms.PropertyGrid();
                    _PropertyGrid.SelectedObject = AverageResult;
                    _PropertyGrid.Dock = DockStyle.Fill;
                    averagepanel.Controls.Add(AverageResult);
                    averagepanel.Controls.Add(_PropertyGrid);
                    _PropertyGrid.BringToFront();
                    averagepanel.Dock = DockStyle.Fill;

                    TabPage AVGtab = new TabPage("Average Result");
                    AVGtab.Controls.Add(averagepanel);
                    charttabs.TabPages.Add(AVGtab);
                    Entity.OutPut.IndexRun++;


                    var seriesvarieance = VarianceResult.Series.Add("AverageResults");
                    seriesvarieance.ChartType = SeriesChartType.Line;
                    foreach (var item in RunAccuracy)
                    {
                        double avg = item.Value.Average();
                        double summofsquerindifference = item.Value.Select(val => (val - avg) * (val - avg)).Sum();
                        double standardvariance = Math.Sqrt(summofsquerindifference / item.Value.Count);
                        seriesvarieance.Points.Add(standardvariance);
                    }
                    Form showchartresults = new Form();
                    VarianceResult.Dock = DockStyle.Fill;
                    TabPage STVtab = new TabPage("Standard Varience Result");
                    STVtab.Controls.Add(VarianceResult);
                    charttabs.TabPages.Add(STVtab);

                    charttabs.Dock = DockStyle.Fill;
                    showchartresults.Controls.Add(charttabs);
                    showchartresults.ShowDialog();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            button1.Enabled = true;
                        });
                    }
                }
            });

        }
    }
}
