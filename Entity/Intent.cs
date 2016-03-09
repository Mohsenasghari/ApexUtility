using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ApexUtility
{
    public class Intent
    {

        public Intent()
        {
            EachClusterWeight = new Dictionary<string, double>();
        }

        //For sorting Intent
        public int InternalFrequency { get; set; }

        private int _Frequency;

        public int Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        double _ClusterWeight = 0;
        public double ClusterWeight { get { return _ClusterWeight; } set { _ClusterWeight = Math.Round(value, 3); } }
        public Dictionary<string, double> EachClusterWeight { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        [DefaultValue(false)]
        public bool IsClasslable
        {
            get;
            set;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Intent EqualTo = obj as Intent;
            if (EqualTo == null)
                return false;
            else if (EqualTo.Name == Name)
                return true;
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
