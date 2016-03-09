using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ApexUtility
{
    public partial class BindingAttribute : UserControl
    {
        private Dictionary<double, int> _dictionaryofdatacolumn = new Dictionary<double, int>();
        public DataTable SelectedColumnData { get; set; }
        public string ColumnName { get; set; }
        public BindingAttribute()
        {
            InitializeComponent();
        }
        private void BindigAttribute_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                loadChartData();
            }
        }
        public void loadChartData()
        {
            chart1.Series.Add("seriesof" + ColumnName);
            chart1.ChartAreas.Add("Areaof" + ColumnName);
            chart1.Legends.Add("Legendof" + ColumnName);
            chart1.Series[0].ChartArea = "Areaof" + ColumnName;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            if (SelectedColumnData != null)
            {
                foreach (DataRow item2 in SelectedColumnData.Rows)
                {
                    double result;
                    if (Double.TryParse(item2[ColumnName].ToString(), out result))
                    {
                        _dictionaryofdatacolumn.Add(Convert.ToDouble(item2[ColumnName]), Convert.ToInt32(item2["Count" + ColumnName]));
                        chart1.Series[0].Points.AddXY(Convert.ToDouble(item2[ColumnName]), Convert.ToDouble(item2["Count" + ColumnName]));
                    }
                }
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int __lenghtofeachbound = _dictionaryofdatacolumn.Values.Max();
            var __sorteddata = from data in _dictionaryofdatacolumn orderby data.Key ascending select data;
            int __index = 0;
            List<BindingData<double>> __listofbounds = new List<BindingData<double>>();

            IEnumerator<KeyValuePair<double, int>> __enumeratorlist = __sorteddata.GetEnumerator();
            bool __movenext = __enumeratorlist.MoveNext();
            int __countofdata = 0;
            int __Remainindex = 0;
            int __currentindexofbounds = -1;
            while (_dictionaryofdatacolumn.Count - 1 != __countofdata)
            {
                if (__index == 0)
                {
                    //__currentindexofbounds = -1;
                    BindingData<double> NewBound = new BindingData<double>();
                    NewBound.ContentOfBind = new Dictionary<double, int>();
                    // NewBound.ContentOfBind.Add(__enumeratorlist.Current.Key, __enumeratorlist.Current.Value);
                    __listofbounds.Add(NewBound);
                    __currentindexofbounds++;
                    __listofbounds[__currentindexofbounds].Start = __enumeratorlist.Current.Key;
                }
                if (!__movenext)
                {
                    __index += __Remainindex;
                    __listofbounds[__currentindexofbounds].ContentOfBind.Add(__enumeratorlist.Current.Key, __Remainindex);
                }
                else
                {
                    __index += __enumeratorlist.Current.Value;
                    __listofbounds[__currentindexofbounds].ContentOfBind.Add(__enumeratorlist.Current.Key, __enumeratorlist.Current.Value);
                }
                if (__index <= __lenghtofeachbound)
                {
                    __movenext = __enumeratorlist.MoveNext();
                    __countofdata++;
                }
                else
                {
                    __Remainindex = __index - __lenghtofeachbound;
                    int __counttocomplete = __enumeratorlist.Current.Value - __Remainindex;
                    __index = __lenghtofeachbound;
                    __movenext = false;
                    __listofbounds[__currentindexofbounds].ContentOfBind.Remove(__enumeratorlist.Current.Key);
                    __listofbounds[__currentindexofbounds].ContentOfBind.Add(__enumeratorlist.Current.Key, __counttocomplete);
                }
                if (__index == __lenghtofeachbound || _dictionaryofdatacolumn.Count - 1 == __countofdata)
                {
                    __listofbounds[__currentindexofbounds].End = __enumeratorlist.Current.Key;
                    __listofbounds[__currentindexofbounds].Count = __index;
                    __index = 0;
                }
            }
        }
        public class BindingData<T>
        {
            public T Start { get; set; }
            public T End { get; set; }
            public Dictionary<T, int> ContentOfBind { get; set; }
            public int Count { get; set; }
            public double GetAverage()
            {
                double __average = 0;
                foreach (var item in ContentOfBind)
                {
                    __average += Convert.ToDouble(item.Key) * item.Value;
                }
                return Math.Round((__average / Count));
            }
        }
    }
}
