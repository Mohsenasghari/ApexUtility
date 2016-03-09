using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ApexUtility.Entity
{
    public class DataStructure
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long TrainingInstances { get; set; }
        public long TestInstances { get; set; }
        public long NumberofAttributes { get; set; }
        public long NumberofClass { get; set; }
        public string AttributeSeperator { get; set; }
        public string CaseSeperator { get; set; }
        public string MissingAttributeValues { get; set; }

        public List<AttributeStructure> Attributes { get; set; }
    }
}
