using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApexUtility.Entity
{
    public class FCADataStructure
    {

        public List<string> Intent = new List<string>();
        public List<string> Intents { get { return Intent; } }
        private List<string> Extent = new List<string>();
        public List<string> Extents { get { return Extent; } }
        private Dictionary<string, string[]> _Relations = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> Relations { get { return _Relations; } }
        public int persentOFTestData { get; set; }
        private Dictionary<string, string[]> _TestData = new Dictionary<string, string[]>();
        private Dictionary<string, string[]> _TrainData = new Dictionary<string, string[]>();



        public void AddRelation(string ExtentName, params string[] args)
        {
            if (!Extent.Contains(ExtentName.ToLower()))
            {
                Extent.Add(ExtentName.ToLower());
            }
            for (int i = args.Length - 1; i >= 0; i--)
            {
                if (!Intent.Contains(args[i].ToLower()))
                {
                    Intent.Add(args[i].ToLower());
                }
            }
            _Relations.Add(ExtentName.ToLower(), args);
        }
        public void SetTestTrain()
        {
            foreach (var item in _Relations.Take((_Relations.Count * persentOFTestData) / 100))
            {
                _TestData.Add(item.Key, item.Value);
            }
            foreach (var item in _Relations)
            {
                if (!_TestData.ContainsKey(item.Key))
                {
                    _TrainData.Add(item.Key, item.Value);
                }
            }
        }
        /// <summary>
        /// input :set of attribute
        /// output : set of common object
        /// </summary>
        /// <param name="Extents"></param>
        public List<string> BPrim(string[] intents)
        {
            List<string> selectedItem = new List<string>();
            bool isContains = true;
            foreach (var item in _Relations)
            {
                for (int i = 0; i < intents.Length; i++)
                {
                    if (!item.Value.Contains(intents[i]))
                    {
                        isContains = false;
                        break;
                    }
                    else
                    {
                        isContains = true;
                    }
                }
                if (isContains)
                {
                    selectedItem.Add(item.Key);
                }

            }
            //  var d = from Relation in _Relations where _Relations.Values.Contains(intents) select Relation;


            //foreach (var item in d)
            //{
            //    selectedItem.Add(item.Key);
            //}
            return selectedItem;
        }
        /// <summary>
        /// input :set of object
        /// output : set of common attributes
        /// </summary>
        /// <param name="Extents"></param>
        public List<string> APrim(string[] Extents)
        {
            var Setofintents = _Relations[Extents[0].ToLower()].ToList();
            for (int i = 1; i < Extents.Length - 1; i++)
            {
                Setofintents = Setofintents.Intersect(_Relations[Extents[i].ToLower()]).ToList();
            }
            return Setofintents;
        }
        public bool HasRelation(string Extent, string Intent)
        {
            return _Relations[Extent.ToLower()].Contains(Intent.ToLower());
        }
        public static bool IsSubset<A>(A[] Set, A[] toCheck)
        {
            return Set.Length == (toCheck.Union(Set)).Count();
        }
        public void Clear()
        {
            _Relations.Clear();
            Intents.Clear();
            Extent.Clear();
        }
        public static FCADataStructure OpenCXTFile()
        {
            int IndexOFLine = 1;
            int Number_of_Extent = 0;
            int Number_of_Intent = 0;
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                Dictionary<int, string> CTXFile = new Dictionary<int, string>();
                OFD.ShowDialog();
                FCADataStructure Data = new FCADataStructure();
                if (!string.IsNullOrEmpty(OFD.FileName))
                    using (StreamReader SR = new StreamReader(OFD.FileName))
                    {

                        while (!SR.EndOfStream)
                        {
                            string currentLine_data = SR.ReadLine();
                            CTXFile.Add(IndexOFLine, currentLine_data);
                            if (IndexOFLine == 3)
                                Number_of_Extent = int.Parse(currentLine_data);
                            else
                                if (IndexOFLine == 4)
                                    Number_of_Intent = int.Parse(currentLine_data);
                            IndexOFLine++;
                        }
                        SR.Close();
                    }
                if (CTXFile.Count > 0)
                {


                    for (int i = 1; i <= Number_of_Extent; i++)
                    {
                        List<string> intents = new List<string>();
                        for (int j = 0; j < Number_of_Intent; j++)
                        {
                            if (CTXFile[Number_of_Extent + Number_of_Intent + i + 5][j] == 'X')
                            {
                                intents.Add(CTXFile[Number_of_Extent + 6 + j]);
                            }
                        }
                        Data.AddRelation(CTXFile[5 + i], intents.ToArray());
                    }
                }
                return Data;
            }

        }
        public void SaveAsCXTFile(string DsName)
        {
            DataTable dt = this.GetDataTable();
            StringBuilder ctxfile = new StringBuilder();
            ctxfile.AppendLine("B");
            ctxfile.AppendLine("");
            ctxfile.AppendLine(dt.Rows.Count.ToString());
            ctxfile.AppendLine(dt.Columns.Count.ToString());
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
            using (StreamWriter sw = new StreamWriter(Environment.SpecialFolder.MyDocuments + "/" + DsName + "/" + DsName + ".cxt"))
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
                foreach (var item in Intent)
                {
                    DT.Columns.Add(item, typeof(Boolean));
                }
                foreach (var item in _Relations)
                {
                    DataRow NewRow = DT.NewRow();
                    NewRow[0] = item.Key;
                    int indexofintent = 1;
                    foreach (var item2 in Intent)
                    {
                        if (item.Value.Where(relate => relate.Contains(item2)).Count() > 0)
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
    }
}
