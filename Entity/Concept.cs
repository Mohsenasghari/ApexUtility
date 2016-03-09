using ApexUtility.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApexUtility
{
    public class Concept
    {
        public Concept()
        {
            Intents = new List<Intent>();
            Extents = new List<Extent>();
        }
        //object
        public int R { get; set; }
        public int index { get; set; }
        public List<Intent> Intents { get; set; }
        public List<Extent> Extents { get; set; }
        public string ExpressionMatchExtents { get; set; }
        public string ExpressionMatchIntents { get; set; }
        public override string ToString()
        {
            string _Extent = "";
            string _Intent = "";
            if (Extents != null)
            {
                foreach (var Extent in Extents)
                {
                    _Extent += string.Format("{0},", Extent.Name);
                }
            }
            if (Intents != null)
            {
                foreach (var Intent in Intents)
                {
                    _Intent += string.Format("{0},", Intent.Name);
                }
            }
            return "Ex:{" + (string.IsNullOrEmpty(_Extent) ? "" : _Extent.Remove(_Extent.Length - 1, 1)) + "}=>Int:{" + (string.IsNullOrEmpty(_Intent) ? "" : _Intent.Remove(_Intent.Length - 1, 1)) + "};";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Concept input = obj as Concept;
            if (input == null)
                return false;
            if (FCADataSet.UnorderedEqual(Intents, input.Intents) || FCADataSet.UnorderedEqual(Extents, input.Extents))
            {
                return true;
            }
            return false;
        }
    }
}