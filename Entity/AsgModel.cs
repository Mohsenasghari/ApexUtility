using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace ApexUtility.Entity
{
    public class AsgModel
    {
        #region Variable
        public string MoreCloserConcept = "";
        public string Log;
        public FCADataSet DataSet { get; set; }
        public DataStructure DS;
        public List<Concept> Concepts { get; set; }
        Dictionary<Concept, double> _result = new Dictionary<Concept, double>();
        StringBuilder ConceptBuilder;
        #endregion


        public AsgModel()
        {
            Concepts = new List<Concept>();
            ConceptBuilder = new StringBuilder();
        }


        #region FastConceptGenerator
        public bool ConceptTest(List<ApexUtility.Intent> Intents, string concept)
        {
            if (Intents.Count == 0)
            {
                if (!ConceptIsTestedExtent(concept))
                {
                    List<Intent> Aprim = DataSet.Extents_prim(DataSet.Extents);
                    List<Extent> Azegond = DataSet.Intents_Prim(Aprim);
                    if (ISConcept(DataSet.Extents, Azegond))
                    {
                        Concept NewConcept = new Concept() { Intents = Aprim, Extents = DataSet.Extents };
                        Concepts.Add(NewConcept);
                        ConceptBuilder.AppendLine(NewConcept.ToString());
                        return true;
                    }
                }
            }
            else if (Intents.Count() >= 1)
            {
                if (!ConceptIsTestedIntent(concept))
                {
                    List<Extent> Bprim = DataSet.Intents_Prim(Intents);
                    List<Intent> Bzegond = DataSet.Extents_prim(Bprim);
                    if (ISConcept(Intents, Bzegond))
                    {
                        Concept NewConcept = new Concept() { Intents = Intents, Extents = Bprim };
                        Concepts.Add(NewConcept);
                        ConceptBuilder.AppendLine(NewConcept.ToString());
                        return true;
                    }
                    else
                    {
                        if (!ConceptIsTestedIntent(Bzegond, null))
                        {
                            ConceptTest(Bzegond, "");
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            return true;
        }

        bool ConceptIsTestedIntent(string concept)
        {
            string _CurrentExtent = concept;
            string ExpressionMatchExtents = "(\\s+)?Int:(\\s+)?\\{(\\s+)?" + (string.IsNullOrEmpty(_CurrentExtent) ? "" : _CurrentExtent.Remove(_CurrentExtent.Length - 1, 1)) + "(\\s+)?\\}(\\s+)?";
            return Regex.IsMatch(ConceptBuilder.ToString(), ExpressionMatchExtents);
        }
        bool ConceptIsTestedIntent(List<Intent> newsubset, string concept)
        {
            string _CurrentExtent = concept;
            if (concept == null)
            {
                foreach (var Intent in newsubset)
                {
                    _CurrentExtent += string.Format("{0},", Intent.Name);
                }
            }

            string ExpressionMatchExtents = "(\\s+)?Int:(\\s+)?\\{(\\s+)?" + (string.IsNullOrEmpty(_CurrentExtent) ? "" : _CurrentExtent.Remove(_CurrentExtent.Length - 1, 1)) + "(\\s+)?\\}(\\s+)?";
            return Regex.IsMatch(ConceptBuilder.ToString(), ExpressionMatchExtents);
        }
        bool ConceptIsTestedExtent(string concept)
        {
            string _CurrentExtent = concept;
            string ExpressionMatchExtents = "(\\s+)?Ex:(\\s+)?\\{(\\s+)?" + (string.IsNullOrEmpty(_CurrentExtent) ? "" : _CurrentExtent.Remove(_CurrentExtent.Length - 1, 1)) + "(\\s+)?\\}(\\s+)?";
            return Regex.IsMatch(ConceptBuilder.ToString(), ExpressionMatchExtents);
        }
        bool ConceptIsTestedExtent(List<Extent> newsubset, string concept)
        {
            string _CurrentExtent = concept;
            if (concept == null)
            {
                foreach (var Intent in newsubset)
                {
                    _CurrentExtent += string.Format("{0},", Intent.Name);
                }
            }
            string ExpressionMatchExtents = "(\\s+)?Ex:(\\s+)?\\{(\\s+)?" + (string.IsNullOrEmpty(_CurrentExtent) ? "" : _CurrentExtent.Remove(_CurrentExtent.Length - 1, 1)) + "(\\s+)?\\}(\\s+)?";
            return Regex.IsMatch(ConceptBuilder.ToString(), ExpressionMatchExtents);
        }
        List<List<Intent>> ListSubset = new List<List<Intent>>();
        public List<List<Intent>> FastConceptGenerator(List<ApexUtility.Intent> Intents, int s, string subsetstring)
        {

            if (s == DataSet.Intents.Count)
            {
                return null;
            }

            if (Intents == null)
            {
                // consider non set

                if (!ConceptIsTestedIntent(subsetstring))
                {
                    //ListSubset.Add(new List<Intent> { DataSet.Intents[s] });
                    //subsetstring += DataSet.Intents[s].Name + ",";
                    if (ConceptTest(new List<Intent> { DataSet.Intents[s] }, subsetstring))
                    {
                        int indexsubset = s + 1;
                        FastConceptGenerator(new List<Intent> { DataSet.Intents[s] }, indexsubset, DataSet.Intents[s].Name + ",");
                    }
                }
                if (s < (DataSet.Intents.Count - 2))
                    FastConceptGenerator(null, ++s, DataSet.Intents[++s].Name + ",");
                else
                    return null;
            }
            else
            {
                for (int i = s; i < DataSet.Intents.Count; i++)
                {
                    List<Intent> newsubset = new List<Intent>();
                    newsubset.AddRange(Intents);
                    subsetstring += DataSet.Intents[i].Name + ",";
                    newsubset.Add(DataSet.Intents[i]);
                    if (!ConceptIsTestedIntent(subsetstring))
                    {
                        if (ConceptTest(newsubset, subsetstring))
                        {
                            FastConceptGenerator(newsubset, ++i, subsetstring);
                        }
                        else
                        {
                            continue;
                        }
                        //ListSubset.Add(newsubset);
                    }
                }
            }
            return ListSubset;
        }

        public bool ISConcept(List<Intent> A, List<Intent> B)
        {
            return A.SequenceEqual(B);
        }
        public bool ISConcept(List<Extent> A, List<Extent> B)
        {
            return A.SequenceEqual(B);
        }
        #endregion


        #region GetConceptFromInclose
        public void GenerateConceptFromInclose(string DSName)
        {
            try
            {
                string exelocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                exelocation = Path.GetDirectoryName(exelocation);
                if (File.Exists(exelocation + "\\concept_" + DSName + ".txt"))
                {
                    File.Delete(exelocation + "\\concept_" + DSName + ".txt");
                }

                Process calculateinclose = new Process();
                calculateinclose.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                calculateinclose.StartInfo.FileName = exelocation + "\\Inclose.exe";
                calculateinclose.StartInfo.Arguments = exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DSName + ".cxt";
                calculateinclose.Start();
                calculateinclose.WaitForExit();
                if (File.Exists(exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DSName + ".txt"))
                {
                    File.Delete(exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DSName + ".txt");
                }
                File.Move(exelocation + "\\concept_" + DSName + ".txt", exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DSName + ".txt");
                File.Delete(exelocation + "\\concept_" + DSName + ".txt");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw ex;
            }

        }
        public void GetConcepts(string DSName = "")
        {
            string exelocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            exelocation = Path.GetDirectoryName(exelocation);
            var filelocation = exelocation + "\\" + "MyDocuments" + "\\" + DS.Name + "\\" + DSName + ".txt";
            if (File.Exists(filelocation))
            {
                StreamReader sr = new StreamReader(filelocation);
                string _Concept = sr.ReadLine();
                while (!string.IsNullOrEmpty(_Concept))
                {
                    string[] ExtentsIntents = _Concept.Split(new string[] { "->" }, StringSplitOptions.None);
                    string[] intents = ExtentsIntents[0].Replace("{", "").Replace("}", "").Split(',');
                    string[] extents = ExtentsIntents[1].Replace("{", "").Replace("}", "").Split(',');
                    if (extents.Length > 1 && intents.Length > 1)
                    {
                        Concept c = new ApexUtility.Concept();
                        for (int i = 0; i < intents.Length - 1; i++)
                        {
                            var intent = DataSet.Intents.Where(s => s.Name == intents[i]).FirstOrDefault();
                            if (intent != null)
                            {
                                c.Intents.Add(intent);
                            }

                        }
                        for (int i = 0; i < extents.Length - 1; i++)
                        {
                            var extent = DataSet.Extents.Where(s => s.Name == extents[i]).FirstOrDefault();
                            if (extent != null)
                            {
                                c.Extents.Add(extent);
                            }

                        }
                        Concepts.Add(c);
                    }

                    _Concept = sr.ReadLine();
                }
                sr.Close();
                sr.Dispose();
            }
        }
        #endregion

        #region FCAGenerator

        public void ASGFastFCA(List<ApexUtility.Extent> originalArray)
        {
            List<List<ApexUtility.Extent>> subsets = new List<List<ApexUtility.Extent>>();
            for (int i = 0; i < originalArray.Count; i++)
            {
                int subsetCount = subsets.Count;
                List<Extent> firstsubset = new List<Extent> { originalArray[i] };

                subsets.Add(firstsubset);
                List<Intent> Aprim = DataSet.Extents_prim(firstsubset);
                List<Extent> Azegond = DataSet.Intents_Prim(Aprim);

                if (ISConcept(firstsubset, Azegond))
                {
                    Concept NewConcept = new Concept() { Intents = Aprim, Extents = firstsubset };
                    Concepts.Add(NewConcept);
                    ConceptBuilder.AppendLine(NewConcept.ToString());
                }

                for (int j = 0; j < subsetCount; j++)
                {
                    Extent[] newSubset = new Extent[subsets[j].Count + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    List<Extent> currentset = new List<Extent>();
                    for (int k = 0; k < newSubset.Length; k++)
                    {
                        currentset.Add(newSubset[k]);
                    }
                    List<Intent> Aprim2 = DataSet.Extents_prim(currentset);
                    List<Extent> Azegond2 = DataSet.Intents_Prim(Aprim2);

                    if (ISConcept(currentset, Azegond2))
                    {
                        Concept NewConcept = new Concept() { Intents = Aprim, Extents = firstsubset };
                        Concepts.Add(NewConcept);
                        ConceptBuilder.AppendLine(NewConcept.ToString());
                    }
                    subsets.Add(currentset);
                }
            }
            CalculateTheFrequencyOfObjectsInConcept();
        }


        public void CalculateTheFrequencyOfObjectsInConcept()
        {
            var clusters = DataSet.GetDataAsCluster();

            foreach (var item in DataSet.Extents)
            {
                foreach (var item2 in Concepts)
                {
                    if (item2.Extents.Contains(item))
                    {
                        item.Frequency += 1;
                    }
                }
            }
            foreach (var item in DataSet.Intents)
            {
                item.EachClusterWeight.Clear();
                foreach (var cluster in clusters)
                {
                    var weightincluster = cluster.Value.WeightOFIntents(item);
                    item.ClusterWeight += weightincluster;
                    item.EachClusterWeight.Add(item.Name + "_" + cluster.Key, Math.Round(weightincluster, 2));
                }
                foreach (var item2 in Concepts)
                {
                    if (item2.Intents.Contains(item))
                    {
                        item.Frequency += 1;
                    }
                }
            }
        }


        #endregion

        #region AsgSimilarity
        public Concept AsgSimilarity(Concept NC)
        {
            //Log = "";
            Concept MoreSimilarConcept = new Concept();
            double similarityMeasure = 0;
            int indexconcept = 1;

            foreach (var item in Concepts)
            {
                Log += "C" + indexconcept.ToString() + Environment.NewLine;
                var currentsimilarity = AsgSimilarity_OCNC_New(item, NC);
                Log += "........ similarity Measured : " + Math.Round(currentsimilarity, 2).ToString();
                if (currentsimilarity > similarityMeasure)
                {
                    MoreCloserConcept = item.ToString() + " => with Similarity Measure :" + currentsimilarity + Environment.NewLine;
                    similarityMeasure = currentsimilarity;
                    MoreSimilarConcept = item;
                }
                Log += Environment.NewLine;
                //Log = "";
                indexconcept++;
            }
            return MoreSimilarConcept;
        }
        public double AsgSimilarity_OCNC_New(Concept OC, Concept NC)
        {
            try
            {
                _result.Clear();
                double N = Concepts.Count;
                var IntersectOC_NC = OC.Intents.Intersect(NC.Intents);
                double Part1 = 0, Part2 = 0, Part3 = 0;
                if (IntersectOC_NC != null && IntersectOC_NC.Count() > 0)
                {

                    foreach (var item in IntersectOC_NC)
                    {
                        var intentinconcept = Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2);
                        foreach (var cluster in item.EachClusterWeight)
                        {
                            if (intentinconcept != 0 && cluster.Value != 0)
                            {
                                Part1 += Math.Pow(Math.Log10((intentinconcept * cluster.Value)), 2);
                            }
                        }

                    }
                }


                Log += ".........." + (Part1 == 0 ? "0.00" : Math.Round(Part1, 2).ToString());
                if (NC.Intents != null && NC.Intents.Count > 0)
                {
                    foreach (var item in NC.Intents)
                    {
                        if (item.IsClasslable == false)
                        {
                            //Part2 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2) * item.ClusterWeight);
                            Part2 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2));
                        }
                    }
                }

                Log += ".........." + (Part2 == 0 ? "0.00" : Math.Round(Part2, 2).ToString());
                if (OC.Intents != null && OC.Intents.Count() > 0)
                {
                    foreach (var item in OC.Intents)
                    {
                        if (item.IsClasslable == false)
                        {
                            //Part3 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2) * item.ClusterWeight);
                            Part3 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2));
                        }
                    }
                }

                Log += ".........." + (Part3 == 0 ? "0.00" : Math.Round(Part3, 2).ToString());
                if (Part2 == 0 || Part3 == 0)
                {
                    return Part1;
                }
                return Part1 / Math.Pow(Part2 * Part3, 0.5);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return 0;
            }


        }
        public double AsgSimilarity_OCNC(Concept OC, Concept NC)
        {
            try
            {
                _result.Clear();
                double N = Concepts.Count;
                var IntersectOC_NC = OC.Intents.Intersect(NC.Intents);
                double Part1 = 0, Part2 = 0, Part3 = 0;
                if (IntersectOC_NC != null && IntersectOC_NC.Count() > 0)
                {
                    foreach (var item in IntersectOC_NC)
                    {
                        Part1 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2) * item.ClusterWeight);
                    }
                }


                Log += ".........." + (Part1 == 0 ? "0.00" : Math.Round(Part1, 2).ToString());
                if (NC.Intents != null && NC.Intents.Count > 0)
                {
                    foreach (var item in NC.Intents)
                    {
                        if (item.IsClasslable == false)
                        {
                            //Part2 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2) * item.ClusterWeight);
                            Part2 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2));
                        }
                    }
                }

                Log += ".........." + (Part2 == 0 ? "0.00" : Math.Round(Part2, 2).ToString());
                if (OC.Intents != null && OC.Intents.Count() > 0)
                {
                    foreach (var item in OC.Intents)
                    {
                        if (item.IsClasslable == false)
                        {
                            //Part3 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2) * item.ClusterWeight);
                            Part3 += (Math.Pow(Math.Log10(item.Frequency != 0 ? N / item.Frequency : 1), 2));
                        }
                    }
                }

                Log += ".........." + (Part3 == 0 ? "0.00" : Math.Round(Part3, 2).ToString());
                if (Part2 == 0 || Part3 == 0)
                {
                    return Part1;
                }
                return Part1 / Math.Pow(Part2 * Part3, 0.5);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return 0;
            }


        }
        #endregion


        #region Similarity
        public Concept Similarity(Concept NewCase)
        {
            _result.Clear();
            double iIN = 0;
            double N = Concepts.Count;
            int MaxcountIntesect = 0;
            // Calculate EN From CP
            foreach (var item in Concepts)
            {
                int currentCount = item.Intents.Intersect(NewCase.Intents).Count();
                if (currentCount > MaxcountIntesect)
                {
                    NewCase.Extents = item.Extents;
                    MaxcountIntesect = currentCount;
                }
            }
            foreach (var item in NewCase.Intents)
            {
                double Frequencyofintent = 0;
                if (DataSet.Intents.Contains(item))
                {
                    Frequencyofintent = DataSet.Intents.Where(intent => intent == item).First().Frequency;
                    iIN += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
                }
                else
                {
                    iIN += 0;
                }
            }
            Log += String.Format("iIN = {0}\n", iIN);

            double kEN = 0;
            foreach (var item in NewCase.Extents)
            {
                double Frequencyofextent = 0;
                if (DataSet.Extents.Contains(item))
                {
                    Frequencyofextent = DataSet.Extents.Where(extent => extent == item).First().Frequency;
                    kEN += Math.Pow(Math.Log10((N / Frequencyofextent)), 2);
                }
                else
                {
                    kEN += 0;
                }

            }
            Log += String.Format("kEN = {0}\n", kEN);
            Log += String.Format("NEW CASE :{0}\n", NewCase);
            Log += "---------------------------------------------------------" + "\n";


            foreach (var item in Concepts)
            {
                _Similarity(item, NewCase, kEN, iIN, N);
            }
            return _result.Where(res => res.Value == _result.Values.Max()).First().Key;
        }
        private double _Similarity(Concept CP, Concept CN, double kEN, double iIN, double N)
        {
            //Total Number of Concept
            //CP.OutputString = OutputStringFCA.NormalFormat;
            Log += String.Format("\n Similarity by ==> {0} {1} \n", CP.index, CP.ToString());
            Log += "-------------------------------------------------------------------------------" + "\n";
            List<Extent> SET_V = CN.Extents.Intersect(CP.Extents).ToList();
            List<Intent> SET_U = CN.Intents.Intersect(CP.Intents).ToList();

            double u = 0;
            foreach (var item in SET_U)
            {
                double Frequencyofintent = 0;
                if (DataSet.Intents.Contains(item))
                {
                    Frequencyofintent = DataSet.Intents.Where(intent => intent == item).First().Frequency;
                    u += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
                }
                else
                {
                    u += 0;
                }

            }
            Log += String.Format("{0} |\t", Math.Round(u, 3));

            double v = 0;
            foreach (var item in SET_V)
            {
                double Frequencyofextent = 0;
                if (DataSet.Extents.Contains(item))
                {
                    Frequencyofextent = DataSet.Extents.Where(extent => extent == item).First().Frequency;
                    v += Math.Pow(Math.Log10((N / Frequencyofextent)), 2);
                }
                else
                {
                    v += 0;
                }

            }

            Log += String.Format(" {0} |\t", Math.Round(v, 3));


            double jIP = 0;
            foreach (var item in CP.Intents)
            {
                double Frequencyofintent = 0;
                if (DataSet.Intents.Contains(item))
                {
                    Frequencyofintent = DataSet.Intents.Where(intent => intent == item).First().Frequency;
                    jIP += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
                }
                else
                {
                    jIP += 0;
                }
            }

            Log += String.Format("{0} |\t", Math.Round(jIP, 3));




            double kEP = 0;
            foreach (var item in CP.Extents)
            {
                double Frequencyofextent = 0;
                if (DataSet.Extents.Contains(item))
                {
                    Frequencyofextent = DataSet.Extents.Where(extent => extent == item).First().Frequency;
                    kEP += Math.Pow(Math.Log10((N / Frequencyofextent)), 2);
                }
                else
                {
                    kEP += 0;
                }
            }

            Log += String.Format("{0} |\t", Math.Round(kEP, 3));

            double result = ((u / (Math.Sqrt(iIN * jIP))) + (v / (Math.Sqrt(kEN * kEP)))) / 2;

            Log += String.Format("{0} |\n", Math.Round(result, 3));
            _result.Add(CP, result);
            Log += "--------------------------------------------------------------------";
            return result;

        }
        #endregion
    }
}
