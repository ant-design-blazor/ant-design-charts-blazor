using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IRangeBarLabelConfig
    {
        public bool? visible { get; set; }
        public string position { get; set; }//OneOf <'outer','inner'>
                                            //  formatter?: (...args: any[]) => string;
        public static string PositionOuter = "outer";
        public static string PositionInner = "inner";

        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public object style { get; set; }
        public object leftStyle { get; set; }
        public object rightStyle { get; set; }
        public bool? adjustColor { get; set; }
        public bool? adjustPosition { get; set; }
    }

    public class RangeBarLabelConfig : IRangeBarLabelConfig
    {
        public bool? visible { get;set; }
        public string position { get;set; }
        public int? offsetX { get;set; }
        public int? offsetY { get;set; }
        public object style { get;set; }
        public object leftStyle { get;set; }
        public object rightStyle { get;set; }
        public bool? adjustColor { get;set; }
        public bool? adjustPosition { get;set; }
    }
}
