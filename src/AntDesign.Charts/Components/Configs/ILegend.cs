using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILegend
    {
        public bool? visible { get; set; }
        /// <summary>
        ///  位置 
        /// </summary>
        public string position { get; set; }//  | 'left-top'  | 'left-center'  | 'left-bottom'  | 'right-top'  | 'right-center'  | 'right-bottom'  | 'top-left'  | 'top-center'  | 'top-right'  | 'bottom-left'  | 'bottom-center'  | 'bottom-right'
        /// <summary>
        ///  翻页 
        /// </summary>
        public bool? flipPage { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public bool? clickable { get; set; }
        public LegendTitle title { get; set; }
        public LegendMarker marker { get; set; }
        public LegendText text { get; set; }


    }

    public class LegendTitle
    {
        public bool? visible { get; set; }
        public string text { get; set; }
        public TextStyle style { get; set; }
    }

    public class LegendMarker
    {
        public string symbol { get; set; }
        public LegendMarkerStyle style { get; set; }
    }

    public class LegendText
    {
        public TextStyle style { get; set; }
        //formatter?: (text: string, cfg: any) => string;
    }

    public class Legend : ILegend
    {
        public bool? visible {get;set;}
        public string position {get;set;}
        public bool? flipPage {get;set;}
        public int? offsetX {get;set;}
        public int? offsetY {get;set;}
        public bool? clickable {get;set;}
        public LegendTitle title {get;set;}
        public LegendMarker marker {get;set;}
        public LegendText text {get;set;}
    }
}
