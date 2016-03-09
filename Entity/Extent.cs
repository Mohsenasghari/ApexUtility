using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApexUtility
{
    public class Extent
    {
        //For sorting Intent
        public int InternalFrequency { get; set; }

        private int _Frequency;

        public int Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Extent EqualTo = obj as Extent;
            if (EqualTo == null)
                return false;
            else if (EqualTo.Name == Name)
                return true;
            return false;
        }


    }
}
