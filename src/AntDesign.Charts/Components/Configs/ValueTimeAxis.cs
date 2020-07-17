using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ValueTimeAxis : IValueAxis, ITimeAxis
    {
        public string type { get;set; }
        public bool? nice { get;set; }
        public double? min { get;set; }
        public double? max { get;set; }
        public int? minLimit { get;set; }
        public int? maxLimit { get;set; }
        public int? tickCount { get;set; }
        public int? tickInterval { get;set; }
        public int? exponent { get;set; }
        public int? @base { get;set; }
        public bool visible { get;set; }
        public string tickMethod { get;set; }
        public BaseAxisLine line { get;set; }
        public BaseAxisGrid grid { get;set; }
        public BaseAxisLabel label { get;set; }
        public BaseAxisTitle title { get;set; }
        public BaseAxisTickLine tickLine { get;set; }
        public string mask { get;set; }
        string ITimeAxis.tickInterval { get;set; }
    }
}
