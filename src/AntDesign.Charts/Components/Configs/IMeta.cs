using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IMeta
    {
        public string alias { get; set; }
        //  formatter?: (v: any) => string;
        public string[] values { get; set; }
        public int[] range { get; set; }
        public string type { get; set; }//OneOf <'linear','time','timeCat','cat','pow','log'>

        public static string TypeLinear = "linear";
        public static string TypeTime = "time";
        public static string TypeTimeCat = "timeCat";
        public static string TypeCat = "cat";
        public static string TypePow = "pow";
        public static string TypeLog = "log";
    }

    public class Meta : IMeta
    {
        public string alias { get; set; }
        public string[] values { get; set; }
        public int[] range { get; set; }
        public string type { get; set; }
    }
}
