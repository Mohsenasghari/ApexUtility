using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexUtility.Entity
{
    public class OutPut
    {
        public static string TableOutPut { get; set; }
        public static Dictionary<string, List<double>> Results = new Dictionary<string, List<double>>();
        public static int IndexRun = 0;
    }
}
