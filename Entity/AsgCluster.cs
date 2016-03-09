using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ApexUtility.Entity
{
    public class AsgCluster
    {


        public string Name { get; set; }
        public List<Intent> Intents { get; set; }
        public List<Extent> Extents { get; set; }
        public List<Relation> Relations { get; set; }

        public int CountIntents { get { return Intents.Distinct().Count(); } }
        public int CountExtents { get { return Extents.Count(); } }

        public double WeightOFIntents(Intent i)
        {
            var frequencyofintentincluster = Intents.Where(s => s.Name == i.Name).Count();
            return (double)frequencyofintentincluster / (double)CountIntents;
        }

        public AsgCluster()
        {
            Intents = new List<Intent>();
            Extents = new List<Extent>();
            Relations = new List<Relation>();
        }
    }
}
