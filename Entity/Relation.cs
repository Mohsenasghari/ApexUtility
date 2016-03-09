using System;
using System.Collections.Generic;

namespace ApexUtility.Entity
{
    public class Relation
    {

        public Extent Extent
        {
            get;
            set;
        }

        public List<Intent> Intents
        {
            get;
            set;
        }

        public int index
        {
            get;
            set;
        }
        public override string ToString()
        {
            string _Intents = "";
            foreach (var item in Intents)
            {
                _Intents += item.Name + ",";
            }
            return string.Format("Case : {0} == > Attributes : {1}", Extent.Name, _Intents);
        }

        public Concept GetasConcept()
        {
            Concept __conceptofrelation = new Concept();
            __conceptofrelation.Extents = new List<Extent>();
            __conceptofrelation.Intents = new List<Intent>();
            __conceptofrelation.Extents.Add(Extent);
            //__conceptofrelation.OutputString = OutputStringFCA.NormalFormat;
            foreach (var item in Intents)
            {
                __conceptofrelation.Intents.Add(item);
            }
            return __conceptofrelation;
        }
        /// <summary>
        /// Send true if you want use a relation as new case for calculate the similarity
        /// </summary>
        public Concept GetasConcept(bool issimilarity)
        {
            Concept __conceptofrelation = new Concept();
            __conceptofrelation.Extents = new List<Extent>();
            __conceptofrelation.Intents = new List<Intent>();
            foreach (var item in Intents)
            {
                if (!item.IsClasslable)
                {
                    __conceptofrelation.Intents.Add(item);
                }
            }
            return __conceptofrelation;
        }
    }
    public class ReverseRelation
    {
        public ReverseRelation()
        {
            Intent = new Intent();
            Extents = new List<Extent>();
        }
        public Intent Intent { get; set; }
        public List<Extent> Extents { get; set; }
    }
}
