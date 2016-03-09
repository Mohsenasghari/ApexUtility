using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ApexUtility.Entity
{
    public class FCADataSet
    {
        private List<Extent> _Extents = new List<Extent>();
        private List<Intent> _Intents = new List<Intent>();
        private List<Relation> _Relations = new List<Relation>();
        private List<ReverseRelation> _ReverseRelation = new List<ReverseRelation>();
        public DataStructure DS { get; set; }
        private static string _opendfilename = "";
        /// <summary>
        /// List Of Object or Case
        /// </summary>
        public List<Extent> Extents
        {
            get { return _Extents; }

        }

        /// <summary>
        /// List Of Attribute
        /// </summary>
        public List<Intent> Intents
        {
            get { return _Intents; }
            set { _Intents = value; }
        }



        /// <summary>
        /// List OF Relation Between Case and Attribute
        /// </summary>
        public List<Relation> Relations
        {
            get { return _Relations; }
        }

        public static string OpendFileName { get { return _opendfilename; } }

        /// <summary>
        /// Create The Relation Data By Programming
        /// </summary>
        /// <param name="Case">Extent</param>
        /// <param name="Attributes">Intents in Relation</param>
        public void AddRelation(string Case, params AttributeStructure[] Attributes)
        {
            Relation NewRelation = new Relation();
            NewRelation.Intents = new List<Intent>();
            NewRelation.Extent = new Extent();
            if (_Extents.Where(C => C.Name.ToLower() == Case.ToLower()).Count() == 0)
            {
                Extent NewExtent = new Extent { Name = Case, Frequency = 0 };
                _Extents.Add(NewExtent);
                NewRelation.Extent = NewExtent;
            }
            for (int i = Attributes.Length - 1; i >= 0; i--)
            {
                if (_Intents.Where(I => String.Compare(I.Name.ToLower(), Attributes[i].Name.ToLower(), false) == 0).Count() == 0)
                {
                    Intent newIntent = new Intent { Name = Attributes[i].Name, Frequency = 0, IsClasslable = Attributes[i].IsClass };
                    _Intents.Add(newIntent);
                }
                NewRelation.Intents.Add(_Intents.Where(I => String.Compare(I.Name.ToLower(), Attributes[i].Name.ToLower(), false) == 0).First());
            }
            NewRelation.index = Relations.Count() + 1;
            _Relations.Add(NewRelation);
        }
        public void AddRelation(Relation item)
        {
            if (!_Extents.Contains(item.Extent))
            {
                _Extents.Add(item.Extent);
            }
            foreach (var __intent in item.Intents)
            {
                if (!_Intents.Contains(__intent))
                {
                    _Intents.Add(__intent);
                }
            }
            _Relations.Add(item);
        }

        public void CreateReverseRelation()
        {
            foreach (var item2 in this.Intents)
            {
                List<Extent> EP = new List<Extent>();
                foreach (var item in _Relations)
                {
                    if (item.Intents.Where(s => s.Name == item2.Name).Count() >= 1)
                    {
                        EP.Add(item.Extent);
                    }
                }
                ReverseRelation _rr = new ReverseRelation();
                _rr.Intent = item2;
                _rr.Extents.AddRange(EP);
                _ReverseRelation.Add(_rr);
            }

        }

        public void SaveAsCXTFile(string DsName, string filename = "")
        {
            DataTable dt = this.GetDataTable();
            StringBuilder ctxfile = new StringBuilder();
            ctxfile.AppendLine("B");
            ctxfile.AppendLine("");
            ctxfile.AppendLine(dt.Rows.Count.ToString());
            ctxfile.AppendLine((dt.Columns.Count - 1).ToString());
            ctxfile.AppendLine("");

            foreach (DataRow item in dt.Rows)
            {
                ctxfile.AppendLine(item[0].ToString());
            }
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                ctxfile.AppendLine(dt.Columns[i].ColumnName);
            }
            string row = "";
            foreach (DataRow item in dt.Rows)
            {
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    if (Convert.ToBoolean(item[i]))
                        row += "X";
                    else
                        row += ".";
                }
                ctxfile.AppendLine(row);
                row = "";
            }
            if (!Directory.Exists(Environment.SpecialFolder.MyDocuments + "/" + DsName))
            {
                Directory.CreateDirectory(Environment.SpecialFolder.MyDocuments + "/" + DsName);
            }
            using (StreamWriter sw = new StreamWriter(Environment.SpecialFolder.MyDocuments + "/" + DsName + "/" + (string.IsNullOrEmpty(filename) ? DsName : filename) + ".cxt"))
            {
                sw.Write(ctxfile.ToString());
            }
        }

        public DataTable GetDataTable()
        {
            if (_Relations.Count > 0)
            {
                DataTable DT = new DataTable();
                DT.Columns.Add("Cases", typeof(string));
                foreach (var item in _Intents)
                {
                    DT.Columns.Add(item.Name, typeof(Boolean));
                }
                foreach (var item in _Relations)
                {
                    DataRow NewRow = DT.NewRow();
                    NewRow[0] = item.Extent.Name;
                    int indexofintent = 1;
                    foreach (var item2 in _Intents)
                    {
                        if (item.Intents.Where(relate => relate.Name == item2.Name).Count() > 0)
                        {
                            NewRow[indexofintent] = true;
                        }
                        else
                        {
                            NewRow[indexofintent] = false;
                        }
                        indexofintent++;
                    }
                    DT.Rows.Add(NewRow);
                }
                return DT;
            }
            return null;
        }

        public void Clear()
        {
            _Relations.Clear();
            _Intents.Clear();
            _Extents.Clear();
        }

        public bool HasRelation(Extent Extent, Intent Intent)
        {
            return _Relations.Where(Ex => Ex.Extent.Name == Extent.Name).First().Intents.Contains(Intent);
        }

        /// <summary>
        /// if we do not have class lable null will be return
        /// </summary>
        /// <param name="Case"></param>
        /// <returns></returns>
        public Intent GetClassOfCase(Extent Case)
        {
            // Classlable has been changed during process that I could not find out what was happen
            // so I changed my GetClassof Case in order to make sure that even class lable is changed
            // but we get the right class lable here
            // The old version is commented in the end
            var listintents = GetIntents(Case);
            foreach (var item in listintents)
            {
                if (item.IsClasslable == true)
                {
                    string attrib = item.Name.Split('_')[0];
                    var _attrib = DS.Attributes.Where(s => s.Name == attrib).FirstOrDefault();
                    if (_attrib.IsClass == false)
                    {
                        item.IsClasslable = false;
                    }
                    else
                    {
                        return item;
                    }
                }
            }
            return null;
            // return listintents.Where(s => s.IsClasslable = true).FirstOrDefault();
        }
        public List<Intent> GetIntents(Extent Extent)
        {
            var intents = _Relations.Where(EX => EX.Extent.Name == Extent.Name).First().Intents;
            return intents;
        }

        public List<Intent> Extents_prim(List<Extent> Extents)
        {
            if (Extents.Count == 0)
            {
                return Intents;
            }
            List<Intent> EP = new List<Intent>();
            foreach (var item in Extents)
            {
                var intents = _Relations.Where(EX => EX.Extent.Name == item.Name).First().Intents;
                if (EP.Count == 0)
                {
                    EP = intents;
                }
                else
                {
                    EP = EP.Intersect(intents).ToList();
                    // There is no Intersect
                    if (EP.Count == 0)
                    {
                        return EP;
                    }
                }
            }
            return EP;
        }

        public List<Extent> Intents_Prim(List<Intent> Intents)
        {
            List<Extent> EP = new List<Extent>();
            if (Intents.Count == 0)
            {
                return Extents;
            }
            foreach (var item2 in Intents)
            {
                var extents = _ReverseRelation.Where(Int => Int.Intent.Name == item2.Name).First().Extents;
                if (EP.Count == 0)
                    EP = extents;
                else
                {
                    EP = EP.Intersect(extents).ToList();
                    // There is no Intersect
                    if (EP.Count == 0)
                    {
                        return EP;
                    }
                }
            }
            return EP;
        }

        public Dictionary<string, AsgCluster> GetDataAsCluster()
        {
            Dictionary<string, AsgCluster> Clusters = new Dictionary<string, AsgCluster>();
            foreach (var item in Relations)
            {
                var classes = item.Intents.Where(s => s.IsClasslable == true);
                if (classes.Count() > 0)
                {
                    var ItemCurrentClass = classes.FirstOrDefault().Name;
                    if (!Clusters.ContainsKey(ItemCurrentClass))
                    {
                        AsgCluster cluster = new AsgCluster();
                        cluster.Intents.AddRange(item.Intents);
                        cluster.Extents.Add(item.Extent);
                        cluster.Relations.Add(item);
                        Clusters.Add(ItemCurrentClass, cluster);
                    }
                    else
                    {
                        Clusters[ItemCurrentClass].Relations.Add(item);
                        Clusters[ItemCurrentClass].Intents.AddRange(item.Intents);
                        Clusters[ItemCurrentClass].Extents.Add(item.Extent);
                    }
                }
                else
                {
                    MessageBox.Show("Please define Class for you sample data");
                }
            }
            return Clusters;
        }


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

        public static bool IsSubset<A>(A[] Set, A[] toCheck)
        {
            return Set.Length == (toCheck.Union(Set)).Count();
        }


        public void CalculateInternalFrequency()
        {
            foreach (var item in Intents)
            {
                var selectedintent = _ReverseRelation.Where(s => s.Intent.Name == item.Name).FirstOrDefault();
                if (selectedintent != null)
                {
                    item.InternalFrequency = selectedintent.Extents.Count();
                }
                else
                {
                    item.InternalFrequency = 0;
                }

            }
            foreach (var item in Extents)
            {
                var selectedintents = _Relations.Where(s => s.Extent.Name == item.Name).FirstOrDefault();
                if (selectedintents != null)
                {
                    item.InternalFrequency = selectedintents.Intents.Count();
                }
                else
                {
                    item.InternalFrequency = 0;
                }

            }
        }
    }
}
