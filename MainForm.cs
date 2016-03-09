using ApexUtility.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Windows.Forms;

namespace ApexUtility
{
    public partial class MainForm : Form
    {
        FCADataSet FCAData = new FCADataSet();
        DataStructure DS = new DataStructure();
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string compile = Regex.Replace(richTextBox1.Text, Properties.Resources.Comment, "");
                DS.Name = Common.ExtractValue(compile, Properties.Resources.Name);
                DS.Title = Common.ExtractValue(compile, Properties.Resources.Title);
                DS.TrainingInstances = Convert.ToInt64(Common.ExtractValue(compile, Properties.Resources.TrainingInstances));
                DS.TestInstances = Convert.ToInt64(Common.ExtractValue(compile, Properties.Resources.TestInstances));
                DS.NumberofAttributes = Convert.ToInt64(Common.ExtractValue(compile, Properties.Resources.NumberofAttributes));
                DS.NumberofClass = Convert.ToInt64(Common.ExtractValue(compile, Properties.Resources.NumberofClass));
                DS.AttributeSeperator = Common.ExtractValue(compile, Properties.Resources.AttributeSeperator);
                DS.CaseSeperator = Common.ExtractValue(compile, Properties.Resources.CaseSeperator);
                DS.MissingAttributeValues = Common.ExtractValue(compile, Properties.Resources.MissingAttributeValues);
                var attributes = Regex.Matches(compile, Properties.Resources.Attributes);
                DS.Attributes = new List<AttributeStructure>();
                if (attributes.Count > 0)
                {

                    foreach (var item in attributes)
                    {


                        string type = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractTypeOfAttribute, Properties.Resources.ExtractTypeOfAttribute, Properties.Resources.RemoveSlash);
                        AttributeType attribtype;
                        string ValueAttribute = "";
                        switch (type.ToLower())
                        {
                            case "boolean":
                                attribtype = AttributeType.Boolean;
                                DiscreteAttribute<int> boolvalues = new DiscreteAttribute<int>()
                                {
                                    Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                    Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                    Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                    TypeOfAttribute = attribtype
                                };
                                boolvalues.PossibleValue.Add(0);
                                boolvalues.PossibleValue.Add(1);

                                addvalue(boolvalues, item.ToString());
                                break;
                            case "int":
                                attribtype = AttributeType.Int;
                                ValueAttribute = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractValueAttribute, Properties.Resources.ExtractValueAttribute, Properties.Resources.RemoveBracet);
                                if (ValueAttribute.Contains("->"))
                                {
                                    ContinuesAttribute<int> values = new ContinuesAttribute<int>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split(new string[] { "->" }, StringSplitOptions.None);
                                    values.Start = Convert.ToInt32(startendvalues[0]);
                                    values.End = Convert.ToInt32(startendvalues[1]);
                                    addvalue(values, item.ToString());
                                }
                                else
                                {
                                    DiscreteAttribute<int> values = new DiscreteAttribute<int>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split('-');
                                    foreach (var item2 in startendvalues)
                                    {
                                        values.PossibleValue.Add(Convert.ToInt32(item2));
                                    }

                                    addvalue(values, item.ToString());
                                }

                                break;
                            case "float":
                                attribtype = AttributeType.Float;
                                ValueAttribute = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractValueAttribute, Properties.Resources.ExtractValueAttribute, Properties.Resources.RemoveBracet);
                                if (ValueAttribute.Contains("->"))
                                {
                                    ContinuesAttribute<float> values = new ContinuesAttribute<float>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split(new string[] { "->" }, StringSplitOptions.None);
                                    values.Start = Convert.ToSingle(startendvalues[0]);
                                    values.End = Convert.ToSingle(startendvalues[1]);

                                    addvalue(values, item.ToString());
                                }
                                else
                                {
                                    DiscreteAttribute<float> values = new DiscreteAttribute<float>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split('-');
                                    foreach (var item2 in startendvalues)
                                    {
                                        values.PossibleValue.Add(Convert.ToSingle(item2));
                                    }


                                    addvalue(values, item.ToString());
                                }
                                break;
                            case "string":
                                attribtype = AttributeType.String;
                                ValueAttribute = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractValueAttribute, Properties.Resources.ExtractValueAttribute, Properties.Resources.RemoveBracet);
                                if (ValueAttribute.Contains("->"))
                                {
                                    ContinuesAttribute<string> values = new ContinuesAttribute<string>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split(new string[] { "->" }, StringSplitOptions.None);
                                    values.Start = startendvalues[0];
                                    values.End = startendvalues[1];


                                    addvalue(values, item.ToString());
                                }
                                else
                                {
                                    DiscreteAttribute<string> values = new DiscreteAttribute<string>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split('-');
                                    foreach (var item2 in startendvalues)
                                    {
                                        values.PossibleValue.Add(item2);
                                    }


                                    addvalue(values, item.ToString());
                                }
                                break;
                            default:
                                attribtype = AttributeType.String;
                                ValueAttribute = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractValueAttribute, Properties.Resources.ExtractValueAttribute, Properties.Resources.RemoveBracet);
                                if (ValueAttribute.Contains("->"))
                                {
                                    ContinuesAttribute<string> values = new ContinuesAttribute<string>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split(new string[] { "->" }, StringSplitOptions.None);
                                    values.Start = startendvalues[0];
                                    values.End = startendvalues[1];


                                    addvalue(values, item.ToString());
                                }
                                else
                                {
                                    DiscreteAttribute<string> values = new DiscreteAttribute<string>()
                                    {
                                        Name = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractNameAttribute, Properties.Resources.ExtractNameAttribute, Properties.Resources.RemoveQutation),
                                        Priority = Convert.ToInt32(Common.ExtractValue(item.ToString(), Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.ExtractPriorityOfAttribute, Properties.Resources.RemoveParantesis)),
                                        Description = Common.ExtractValue(item.ToString(), Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.ExtractDescriptionAttribute, Properties.Resources.RemoveBrace),
                                        TypeOfAttribute = attribtype
                                    };
                                    string[] startendvalues = ValueAttribute.Split('-');
                                    foreach (var item2 in startendvalues)
                                    {
                                        values.PossibleValue.Add(item2);
                                    }


                                    addvalue(values, item.ToString());
                                }
                                break;
                        }
                    }
                }
                propertyGrid1.SelectedObject = DS;
                if (!Directory.Exists(Environment.SpecialFolder.MyDocuments + "/" + DS.Name))
                {
                    Directory.CreateDirectory(Environment.SpecialFolder.MyDocuments + "/" + DS.Name);
                }
                using (StreamWriter sw = new StreamWriter(Environment.SpecialFolder.MyDocuments + "/" + DS.Name + "/" + DS.Name + ".mcode"))
                {
                    sw.Write(richTextBox1.Text);
                }
                using (StreamWriter sw = new StreamWriter(Environment.SpecialFolder.MyDocuments + "/" + DS.Name + "/" + DS.Name + ".mdat"))
                {
                    sw.Write(richTextBox2.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addvalue(AttributeStructure values, string item)
        {

            if (Regex.IsMatch(item, "class"))
            {
                values.IsClass = true;
            }

            if (Regex.IsMatch(item, "refuse"))
            {
                values.Refuse = true;
            }
            if (Regex.IsMatch(item, "case"))
            {
                values.IsCase = true;
            }
            DS.Attributes.Add(values);
        }

        //Read Data
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();

            try
            {
                DataTable dt = new DataTable();
                FCAData.Clear();

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                int countrepeatedcase = 1;

                List<AttributeStructure> orderedlist = DS.Attributes.OrderBy(s => s.Priority).ToList();
                int indexcase = orderedlist.FirstOrDefault(s => s.IsCase == true).Priority;
                foreach (var item in orderedlist)
                {
                    dataGridView1.Columns.Add(item.Name, item.Name);
                    dt.Columns.Add(new DataColumn() { ColumnName = item.Name });
                }
                StringReader sr = new StringReader(richTextBox2.Text);
                if (DS.CaseSeperator == "EOL")
                {
                    string record = sr.ReadLine();
                    int recordindex = 1;
                    while (!string.IsNullOrEmpty(record))
                    {
                        string[] attributes = record.Split(new string[] { DS.AttributeSeperator }, StringSplitOptions.None);
                        if (attributes.Length < DS.Attributes.Count)
                        {
                            List<string> _attributes = new List<string>();
                            _attributes.Add("case" + recordindex.ToString());
                            recordindex++;
                            _attributes.AddRange(attributes);
                            attributes = _attributes.ToArray();
                        }

                        dataGridView1.Rows.Add(attributes);




                        dt.Rows.Add(attributes);
                        List<AttributeStructure> fcaattribute = new List<AttributeStructure>();
                        int index = 1;
                        foreach (var item in attributes)
                        {
                            if (index != indexcase)
                            {
                                if (orderedlist[index - 1].TypeOfAttribute == AttributeType.Boolean)
                                {
                                    // if the case has this value because it is boolean attribute
                                    if (item == "1")
                                    {
                                        if (orderedlist[index - 1].Refuse != true)
                                        {
                                            fcaattribute.Add(orderedlist[index - 1]);
                                        }

                                    }
                                }
                                else
                                {
                                    if (orderedlist[index - 1].Refuse != true)
                                    {
                                        fcaattribute.Add(new AttributeStructure()
                                        {
                                            Name = orderedlist[index - 1].Name + "_" + item,
                                            IsClass = orderedlist[index - 1].IsClass
                                        });
                                    }
                                }
                            }
                            index++;
                        }
                        if (FCAData.Extents.Contains(new Extent() { Name = attributes[indexcase - 1] }))
                        {
                            MessageBox.Show("There is a repeated case name " + attributes[indexcase - 1] + " in the line of " + indexcase);
                            FCAData.AddRelation(attributes[indexcase - 1] + countrepeatedcase.ToString(), fcaattribute.ToArray());
                            countrepeatedcase++;
                        }
                        else
                        {
                            FCAData.AddRelation(attributes[indexcase - 1], fcaattribute.ToArray());
                        }
                        record = sr.ReadLine();
                    }

                }
                else
                {
                    string record = sr.ReadToEnd();
                    string[] cases = record.Split(new string[] { DS.CaseSeperator }, StringSplitOptions.None);
                    foreach (var item in cases)
                    {
                        string[] attributes = item.Split(new string[] { DS.AttributeSeperator }, StringSplitOptions.None);
                        dataGridView1.Rows.Add(attributes);
                        dt.Rows.Add(attributes);
                        List<AttributeStructure> fcaattribute = new List<AttributeStructure>();
                        int index = 1;
                        foreach (var item2 in attributes)
                        {
                            if (index != indexcase)
                            {
                                fcaattribute.Add(new AttributeStructure()
                                {
                                    Name = orderedlist[index - 1].Name + "_" + item,
                                    IsClass = orderedlist[index - 1].IsClass
                                });

                            }
                            index++;
                        }
                        if (FCAData.Extents.Contains(new Extent() { Name = attributes[indexcase - 1] }))
                        {
                            MessageBox.Show("There is a repeated case name " + attributes[indexcase - 1] + " in the line of " + indexcase);
                            FCAData.AddRelation(attributes[indexcase - 1] + countrepeatedcase.ToString(), fcaattribute.ToArray());
                            countrepeatedcase++;
                        }
                        else
                        {
                            FCAData.AddRelation(attributes[indexcase - 1], fcaattribute.ToArray());
                        }
                    }
                }
                foreach (DataColumn item in dt.Columns)
                {
                    ApexUtility.BindingAttribute NewBindigAttribute = new BindingAttribute();
                    NewBindigAttribute.ColumnName = item.ColumnName;
                    IEnumerable<string> columnsToGroupBy = new[] { item.ColumnName };
                    string columnToAggregate = item.ColumnName;

                    var selectedvale = dt.AsEnumerable().GroupBy(r => new NTuple<object>(from column in columnsToGroupBy select r[column])).Select(group =>
                        new
                        {
                            Metric = group.Key,
                            Count = group.Count()
                        });
                    DataTable FeedOfChart = new DataTable();
                    FeedOfChart.Columns.Add(item.ColumnName);
                    FeedOfChart.Columns.Add("Count" + item.ColumnName);
                    // the test routine
                    foreach (var line in selectedvale)
                    {
                        FeedOfChart.Rows.Add(line.Metric.Values[0], line.Count);
                    }
                    NewBindigAttribute.SelectedColumnData = FeedOfChart;
                    NewBindigAttribute.Dock = DockStyle.Fill;
                    TabPage tt = new TabPage();
                    tt.Name = item.ColumnName;
                    tt.Text = item.ColumnName;
                    tt.ToolTipText = item.ColumnName;
                    NewBindigAttribute.loadChartData();
                    tt.Controls.Add(NewBindigAttribute);
                    tabControl1.TabPages.Add(tt);
                }
                FCAData.CreateReverseRelation();
                FCAData.CalculateInternalFrequency();
                dataGridView2.DataSource = FCAData.GetDataTable();
                propertyGrid2.SelectedObject = FCAData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class NTuple<T> : IEquatable<NTuple<T>>, IComparable
        {
            public NTuple(IEnumerable<T> values)
            {
                Values = values.ToArray();
            }

            public readonly T[] Values;

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj == null)
                    return false;
                return Equals(obj as NTuple<T>);
            }

            public bool Equals(NTuple<T> other)
            {
                if (ReferenceEquals(this, other))
                    return true;
                if (other == null)
                    return false;
                var length = Values.Length;
                if (length != other.Values.Length)
                    return false;
                for (var i = 0; i < length; ++i)
                    if (!Equals(Values[i], other.Values[i]))
                        return false;
                return true;
            }

            public override int GetHashCode()
            {
                var hc = 17;
                foreach (var value in Values)
                    hc = hc * 37 + (!ReferenceEquals(value, null) ? value.GetHashCode() : 0);
                return hc;
            }

            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // panel1.Visible = false;
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog opd = new OpenFileDialog();
                opd.Filter = "*|*.mdat";
                if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamReader r = new StreamReader(opd.FileName))
                    {
                        richTextBox2.Text = r.ReadToEnd();
                    }
                }
                opd.Filter = "*|*.mcode";
                if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamReader r = new StreamReader(opd.FileName))
                    {
                        richTextBox1.Text = r.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {

            try
            {
                FrmFCAGenerator frmgenerator = new FrmFCAGenerator();
                frmgenerator.DS = DS;
                frmgenerator.FCAData = FCAData;
                frmgenerator.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getCxt_Click(object sender, EventArgs e)
        {
            try
            {
                FCAData.SaveAsCXTFile(DS.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmTestTrain frmtestterain = new FrmTestTrain();
            frmtestterain.FCAData = FCAData;
            frmtestterain.DataStructure = DS;
            frmtestterain.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.SpecialFolder.MyDocuments + "/" + DS.Name))
            {
                string exelocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                exelocation = Path.GetDirectoryName(exelocation);
                Process.Start("explorer.exe", exelocation + "\\" + "MyDocuments" + "\\" + DS.Name);
            }
            else
            {
                MessageBox.Show("Folder dose not existed please compile your code to create this folder.");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string exelocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            exelocation = Path.GetDirectoryName(exelocation);
            Process.Start(exelocation + "\\Inclose.exe", exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DS.Name + ".cxt");
            if (File.Exists(exelocation + "\\concepts.txt"))
            {
                if (File.Exists(exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + "concepts.txt"))
                {
                    File.Delete(exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + "concepts.txt");
                }
                File.Move(exelocation + "\\concepts.txt", exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + "concepts.txt");
                File.Delete(exelocation + "\\concepts.txt");
            }
        }
    }
}
