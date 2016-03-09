using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
 

namespace ApexUtility
{
    public static class Common
    {
        public static string ExtractValue(string Source, string pattern, string CustomPatternExtractValue = "", string removepattern = "")
        {
            return Regex.Replace(Regex.Match(Regex.Match(Source, pattern).Value.Trim(),
                 CustomPatternExtractValue == "" ?
                 Properties.Resources.ExtractValue :
                 CustomPatternExtractValue).Value, removepattern == "" ? Properties.Resources.RemoveBrace : removepattern, "");
        }
    }
}
