using ApexUtility.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApexUtility
{
    public class Core
    {
        Dictionary<int, Concept> _Generated_Concepts = new Dictionary<int, Concept>();
        Dictionary<int, Concept> _Main_Generated_Concepts = new Dictionary<int, Concept>();
        Dictionary<Concept, double> _result = new Dictionary<Concept, double>();
        Dictionary<string, Extent> _ListofExtents = new Dictionary<string, Extent>();
        Dictionary<string, Intent> _ListofIntents = new Dictionary<string, Intent>();

        int _ConceptIndex = 0;

        public static string Log;

        public Dictionary<int, Concept> Generated_Concepts { get { return _Generated_Concepts; } }
        public Dictionary<int, Concept> Main_Generated_Concepts { get { return _Main_Generated_Concepts; } }
        public Dictionary<string, Extent> ListOFExtents { get { return _ListofExtents; } }
        public Dictionary<string, Intent> ListOFIntents { get { return _ListofIntents; } }
        public Dictionary<Concept, double> SimilarityResult { get { return _result; } }



        public static bool UnorderedEqual<T>(ICollection<T> a, ICollection<T> b)
        {
            // 1
            // Require that the counts are equal
            if (a.Count != b.Count)
            {
                return false;
            }
            // 2
            // Initialize new Dictionary of the type
            Dictionary<T, int> d = new Dictionary<T, int>();
            // 3
            // Add each key's frequency from collection A to the Dictionary
            foreach (T item in a)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    d[item] = c + 1;
                }
                else
                {
                    d.Add(item, 1);
                }
            }
            // 4
            // Add each key's frequency from collection B to the Dictionary
            // Return early if we detect a mismatch
            foreach (T item in b)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    if (c == 0)
                    {
                        return false;
                    }
                    else
                    {
                        d[item] = c - 1;
                    }
                }
                else
                {
                    // Not in dictionary
                    return false;
                }
            }
            // 5
            // Verify that all frequencies are zero
            foreach (int v in d.Values)
            {
                if (v != 0)
                {
                    return false;
                }
            }
            // 6
            // We know the collections are equal
            return true;
        }


        public void GenrateConcepts(FCADataSet Data, int R, int ConceptIndex)
        {
            _ConceptIndex = ConceptIndex;
            List<Intent> BR = new List<Intent>();
            List<Extent> AR = new List<Extent>();
            AR[0] = Data.Extents[0];
            BR[0] = Data.APrim(Data.Extents.ToArray()).ToArray();

            Concept FirstConcept = new Concept { Extents = AR[0].ToList<string>(), Intents = BR[0].ToList<string>(), R = 0, index = _ConceptIndex };
            _Generated_Concepts.Add(_ConceptIndex, FirstConcept);
            if (FirstConcept.Extents.Count > 0 && FirstConcept.Intents.Count > 0)
            {
                _Main_Generated_Concepts.Add(_ConceptIndex, FirstConcept);
            }
            GenrateConcepts(Data, BR, AR, R, _ConceptIndex);
            CalculateTheFrequencyOfObjectsInConcept(Data);
        }
        void GenrateConcepts(FCADataSet Data, string[][] BR, string[][] AR, int R, int C)
        {

            for (int i = Data.Intents.Count - 1; i >= 0; i--)
            {
                string[] Selected_intent = { Data.Intents[i] };
                //we saw the intent in last iteration
                if (BR[R].Contains(Data.Intents[i]))
                {
                    continue;
                }
                else
                {

                    // made the list of extent that has relation with this intent
                    AR[R + 1] = AR[R].Intersect(Data.BPrim(Selected_intent)).ToArray<string>();

                    //check if other intent support the list of extent that this intent has relationship with them

                    for (int j = 0; j <= i - 1; j++)
                    {
                        string[] j_intent = { Data.Intents[j] };
                        //if supported then go to next intent
                        if (BR[R].Contains(Data.Intents[j]))
                        {
                            continue;
                        }
                        if (FCADataStructure.IsSubset<string>(Data.BPrim(j_intent).ToArray(), AR[R + 1]))
                        {
                            goto P;
                        }
                    }

                    // there is no intent that support the extent that made by this intent
                    // so we made an list of extent
                    BR[R + 1] = BR[R].Union(Selected_intent.ToList<string>()).ToArray<string>();

                    //see if there is another list of intetn has same relation with this intent add it to list
                    for (int j = i + 1; j < Data.Intents.Count; j++)
                    {
                        string[] j_intent = { Data.Intents[j] };
                        if (BR[R + 1].Contains(Data.Intents[j]))
                        {
                            continue;
                        }
                        else if (FCADataSet.IsSubset<string>(Data.BPrim(j_intent).ToArray(), AR[R + 1]))
                        {
                            BR[R + 1] = BR[R + 1].Union(j_intent.ToList<string>()).ToArray<string>();
                        }
                    }
                    Concept generated_Concept = new Concept { Extents = AR[R + 1].ToList<string>(), Intents = BR[R + 1].ToList<string>(), R = R + 1, index = _ConceptIndex + 1 };
                    _ConceptIndex++;
                    Generated_Concepts.Add(_ConceptIndex, generated_Concept);

                    if (!_Main_Generated_Concepts.Values.Contains(generated_Concept) && generated_Concept.Intents.Count > 0 && generated_Concept.Extents.Count > 0)
                    {
                        _Main_Generated_Concepts.Add(_ConceptIndex, generated_Concept);
                    }


                    GenrateConcepts(Data, BR, AR, R + 1, _ConceptIndex);
                P: continue;
                }


            }
        }


        void CalculateTheFrequencyOfObjectsInConcept(FCADataSet Data)
        {
            foreach (var item in Data.Extents)
            {
                foreach (var item2 in _Main_Generated_Concepts)
                {
                    if (item2.Value.Extents.Count > 0 && item2.Value.Intents.Count > 0)
                    {
                        if (item2.Value.Extents.Contains(item))
                        {
                            if (!_ListofExtents.ContainsKey(item))
                            {
                                Extent NewExtent = new Extent() { Name = item, Frequency = 1 };
                                _ListofExtents.Add(item, NewExtent);
                            }
                            else
                            {
                                _ListofExtents[item].Frequency += 1;
                            }
                        }
                    }
                }
            }
            foreach (var item in Data.Intents)
            {
                foreach (var item2 in _Main_Generated_Concepts)
                {

                    if (item2.Value.Intents.Contains(item))
                    {
                        if (!_ListofIntents.ContainsKey(item))
                        {
                            Intent NewIntent = new Intent() { Name = item, Frequency = 1 };
                            _ListofIntents.Add(item, NewIntent);
                        }
                        else
                        {
                            _ListofIntents[item].Frequency += 1;
                        }
                    }
                }
            }

        }
        public void Similatiry(Concept NewCase)
        {

            double iIN = 0;
            double N = _Main_Generated_Concepts.Count;
            int MaxcountIntesect = 0;
            foreach (var item in Main_Generated_Concepts)
            {
                int currentCount = item.Value.Intents.Intersect(NewCase.Intents).Count();
                if (currentCount > MaxcountIntesect)
                {
                    NewCase.Extents = item.Value.Extents;
                    MaxcountIntesect = currentCount;
                }
            }
            foreach (var item in NewCase.Intents)
            {
                double Frequencyofintent = 0;
                if (_ListofIntents.Where(intent => intent.Key == item).Count() > 0)
                {
                    Frequencyofintent = _ListofIntents.Where(intent => intent.Key == item).First().Value.Frequency;
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
                if (_ListofExtents.Where(extent => extent.Key == item).Count() > 0)
                {
                    Frequencyofextent = _ListofExtents.Where(extent => extent.Key == item).First().Value.Frequency;
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


            foreach (var item in Main_Generated_Concepts)
            {
                Similarity1(item.Value, NewCase, kEN, iIN, N);
            }
        }
        public double Similarity1(Concept CP, Concept CN, double kEN, double iIN, double N)
        {
            //Total Number of Concept
            //CP.OutputString = OutputStringFCA.NormalFormat;
            Log += String.Format("\n Similarity by ==> {0} {1} \n", CP.index, CP.ToString());
            Log += "-------------------------------------------------------------------------------" + "\n";
            List<string> SET_V = CN.Extents.Intersect(CP.Extents).ToList<string>();
            List<string> SET_U = CN.Intents.Intersect(CP.Intents).ToList<string>();
            ////List<string> SET_Uion_U = CN.Intents.Union(CP.Intents).ToList<string>();

            double u = 0;
            foreach (var item in SET_U)
            {
                double Frequencyofintent = 0;
                if (_ListofIntents.Where(intent => intent.Key == item).Count() > 0)
                {
                    Frequencyofintent = _ListofIntents.Where(intent => intent.Key == item).First().Value.Frequency;
                    u += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
                }
                else
                {
                    u += 0;
                }

            }
            //Log += Case.Format("sigma(log(N/faU)^2) = {0} \t", u);
            Log += String.Format("{0} |\t", Math.Round(u, 3));

            ////double union_u = 0;
            ////foreach (var item in SET_Uion_U)
            ////{
            ////    double Frequencyofintent = 0;
            ////    if (_ListofIntents.Where(intent => intent.Key == item).Count() > 0)
            ////    {
            ////        Frequencyofintent = _ListofIntents.Where(intent => intent.Key == item).First().Value.Frequency;
            ////        union_u += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
            ////    }
            ////    else
            ////    {
            ////        union_u += 0;
            ////    }

            ////}
            ////Log += Case.Format("Union sigma(log(N/faU)^2) = {0}\n", union_u);

            double v = 0;
            foreach (var item in SET_V)
            {
                double Frequencyofextent = 0;
                if (_ListofExtents.Where(extent => extent.Key == item).Count() > 0)
                {
                    Frequencyofextent = _ListofExtents.Where(extent => extent.Key == item).First().Value.Frequency;
                    v += Math.Pow(Math.Log10((N / Frequencyofextent)), 2);
                }
                else
                {
                    v += 0;
                }

            }
            //Log += Case.Format("sigma(log(N/fcV)^2) = {0} \t", v);
            Log += String.Format(" {0} |\t", Math.Round(v, 3));


            double jIP = 0;
            foreach (var item in CP.Intents)
            {
                double Frequencyofintent = 0;
                if (_ListofIntents.Where(intent => intent.Key == item).Count() > 0)
                {
                    Frequencyofintent = _ListofIntents.Where(intent => intent.Key == item).First().Value.Frequency;
                    jIP += Math.Pow(Math.Log10((N / Frequencyofintent)), 2);
                }
                else
                {
                    jIP += 0;
                }
            }
            //Log += Case.Format("jIP = {0} \t", jIP);
            Log += String.Format("{0} |\t", Math.Round(jIP, 3));




            double kEP = 0;
            foreach (var item in CP.Extents)
            {
                double Frequencyofextent = 0;
                if (_ListofExtents.Where(extent => extent.Key == item).Count() > 0)
                {
                    Frequencyofextent = _ListofExtents.Where(extent => extent.Key == item).First().Value.Frequency;
                    kEP += Math.Pow(Math.Log10((N / Frequencyofextent)), 2);
                }
                else
                {
                    kEP += 0;
                }
            }
            //Log += Case.Format("kEP = {0} \t", kEP);
            Log += String.Format("{0} |\t", Math.Round(kEP, 3));

            double result = ((u / (Math.Sqrt(iIN * jIP))) + (v / (Math.Sqrt(kEN * kEP)))) / 2;
            //double result = (u / (Math.Sqrt(iIN * jIP)));
            //double result = (u / union_u);
            //Log += "\n" + "--------------------------------------------------------------------" + "\n";
            //Log += Case.Format("result = {0}\n", result);
            Log += String.Format("{0} |\n", Math.Round(result, 3));
            _result.Add(CP, result);
            Log += "--------------------------------------------------------------------";
            return result;

        }
    }
}
