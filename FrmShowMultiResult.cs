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
    public partial class FrmShowMultiResult : Form
    {
        public FrmShowMultiResult()
        {
            InitializeComponent();
        }
        public void RenderChart(List<TestTrain> ListTestTrain)
        {

            List<double> accuracy = new List<double>();
            List<string> NameOfTestTrasin = new List<string>();
            foreach (var item in ListTestTrain)
            {
                accuracy.Add(item.Accuracy);
                NameOfTestTrasin.Add(item.TestTrainName);
            }
            chart1.Titles.Add("Accuracy Chart");
            var series = chart1.Series.Add("Acuuracy");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            foreach (var item in accuracy)
            {
                series.Points.Add(item);
            }


        }
    }
}
