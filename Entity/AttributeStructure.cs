using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace ApexUtility.Entity
{
    public class AttributeStructure
    {


        protected ValueType _AttribValuyeType;

        public string Name { get; set; }
        public int Priority { get; set; }
        public AttributeType TypeOfAttribute { get; set; }
        public string Description { get; set; }
        public ValueType AttribValuyeType { get { return _AttribValuyeType; } }
        public bool IsCase { get; set; }
        public bool IsClass { get; set; }
        public bool Refuse { get; set; }

    }
    public class ContinuesAttribute<T> : AttributeStructure
    {
        public ContinuesAttribute()
        {
            _AttribValuyeType = ValueType.Continues;
        }
        public T Start { get; set; }
        public T End { get; set; }
    }
    public class DiscreteAttribute<T> : AttributeStructure
    {
        public DiscreteAttribute()
        {
            _AttribValuyeType = ValueType.Discrete;
            PossibleValue = new List<T>();
        }
        public List<T> PossibleValue { get; set; }
    }

    public enum AttributeType
    {
        Int = 1,
        Float = 2,
        String = 3,
        Boolean = 4
    }
    public enum ValueType
    {
        Continues = 1,
        Discrete = 2
    }

}
