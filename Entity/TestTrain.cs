using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using ApexUtility.Entity;

namespace ApexUtility
{
    public class TestTrain
    {

        private FCADataSet _testdata = new FCADataSet();
        private FCADataSet _traindata = new FCADataSet();
        public DataStructure DS;
        private double _accuracy = new double();
        private Dictionary<Concept, Concept> _similarityvstestdata = new Dictionary<Concept, Concept>();

        public FCADataSet TestData
        {
            get
            {
                return _testdata;
            }
        }

        public FCADataSet TrainData
        {
            get
            {
                return _traindata;
            }
        }

        public string TestTrainName { get; set; }
        public double Accuracy
        {
            get
            {
                return _accuracy;
            }
        }

        AsgModel _FCAModel;
        public AsgModel FCAModel
        {
            get { return _FCAModel; }
        }

        public FCADataSet DataSet
        {
            get;
            set;
        }

        public Dictionary<Concept, Concept> SimilarityVsTestData { get { return _similarityvstestdata; } }


        /// <summary>
        /// percentage of spliting the data to Testdata and Traindata
        /// </summary>
        [DefaultValue(0)]
        public int PercentofTestData { get; set; }

        /// <summary>
        /// calculate the TestData and TrainData
        /// </summary>
        public void Create()
        {
            _traindata.Clear();
            if (PercentofTestData != 0)
            {
                int __numberOftestdata = (DataSet.Relations.Count * PercentofTestData / 100);
                List<int> __selectedNumbers = new List<int>();
                for (int i = 0; i < __numberOftestdata; i++)
                {
                    Random __randomnumber = new Random();
                    int __randomselectednumber = __randomnumber.Next(0, DataSet.Relations.Count - 1);
                    while (__selectedNumbers.Contains(__randomselectednumber))
                    {
                        __randomselectednumber = __randomnumber.Next(0, DataSet.Relations.Count - 1);
                    }
                    _testdata.AddRelation(DataSet.Relations[__randomselectednumber]);
                    __selectedNumbers.Add(__randomselectednumber);
                }
                for (int i = 0; i < DataSet.Relations.Count; i++)
                {
                    if (!__selectedNumbers.Contains(i))
                    {
                        _traindata.AddRelation(DataSet.Relations[i]);
                    }
                }
                _traindata.CreateReverseRelation();
                _traindata.SaveAsCXTFile(DS.Name, "Train" + PercentofTestData);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please fill the PersentageofTestData", "error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void CalculateAccuracy()
        {

            FCAModel.DataSet = _traindata;
            FCAModel.ASGFastFCA(_traindata.Extents);
            int __numberofcorrectsimilarity = 0;
            foreach (var item in _testdata.Relations)
            {
                Concept __similarconcept = FCAModel.Similarity(item.GetasConcept(true));
                Dictionary<string, int> Similarclass = new Dictionary<string, int>();
                foreach (var similarcases in __similarconcept.Extents)
                {
                    // get class of an extents
                    var classname = DataSet.GetClassOfCase(similarcases).Name;
                    if (Similarclass.ContainsKey(classname))
                    {
                        Similarclass[classname] += 1;
                    }
                    else
                    {
                        Similarclass.Add(classname, 1);
                    }
                }
                var maxclasscount = Similarclass.Max(s => s.Value);
                var similaritycalss = Similarclass.Where(s => s.Value == maxclasscount).First().Key;
                var realclass = _testdata.Intents.Where(intent => intent.IsClasslable == true).First().Name;
                if (String.Compare(similaritycalss,
                    realclass, true) == 0)
                {
                    __numberofcorrectsimilarity += 1;
                }
                _similarityvstestdata.Add(item.GetasConcept(), __similarconcept);
            }
            _accuracy = (TestData.Relations.Count / __numberofcorrectsimilarity) * 100;
        }

        public string CalculateAccuracyASGModel()
        {
            string LogCalculation = "";
            _FCAModel = new AsgModel();

            _FCAModel.DataSet = _traindata;
            _FCAModel.DS = DS;

            _FCAModel.GenerateConceptFromInclose("Train" + PercentofTestData.ToString());
            _FCAModel.GetConcepts(DSName: "Train" + PercentofTestData.ToString());
            _FCAModel.CalculateTheFrequencyOfObjectsInConcept();

            int CorrectAnswer = 0;
            foreach (var item in _testdata.Relations)
            {
                int __numberofcorrectsimilarity = 0;
                var ClassOfTestItem = item.Intents.Where(s => s.IsClasslable == true).FirstOrDefault().Name;

                Concept __similarconcept = _FCAModel.AsgSimilarity(item.GetasConcept(true));
                LogCalculation += _FCAModel.MoreCloserConcept + Environment.NewLine;
                LogCalculation += " Test Relarion => " + item.ToString() + Environment.NewLine;
                LogCalculation += " Class Test Relation => " + ClassOfTestItem + Environment.NewLine;
                LogCalculation += " Similar Concept => " + __similarconcept != null ? __similarconcept.ToString() : "No Case Found" + Environment.NewLine;

                if (__similarconcept.Extents != null)
                {
                    foreach (var similarcases in __similarconcept.Extents)
                    {
                        // get class of an extents
                        DataSet.DS = DS;
                        var classname = DataSet.GetClassOfCase(similarcases).Name;
                        LogCalculation += Environment.NewLine + " Class " + similarcases.Name + " => " + classname + Environment.NewLine;
                        if (ClassOfTestItem == classname)
                        {
                            __numberofcorrectsimilarity += 1;
                        }
                    }
                }
                if (__numberofcorrectsimilarity > 0)
                {
                    CorrectAnswer += 1;
                }
                LogCalculation += Environment.NewLine + "--------------------------------------------------------------" + Environment.NewLine;
            }
            _accuracy = Math.Round((double)((double)CorrectAnswer / (double)TestData.Relations.Count) * 100.0f, 2);
            return LogCalculation;
        }
    }
}
