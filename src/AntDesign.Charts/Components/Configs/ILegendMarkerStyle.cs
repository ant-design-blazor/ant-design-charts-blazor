using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
  public   interface ILegendMarkerStyle: IGraphicStyle
    {
        public int? r { get; set; }
    }

    public class LegendMarkerStyle : ILegendMarkerStyle
    {
        public int? r { get;set; }
        public string fill { get;set; }
        public int? fillOpacity { get;set; }
        public string stroke { get;set; }
        public int? lineWidth { get;set; }
        public int[] lineDash { get;set; }
        public int? lineOpacity { get;set; }
        public int? opacity { get;set; }
        public string shadowColor { get;set; }
        public int? shadowBlur { get;set; }
        public int? shadowOffsetX { get;set; }
        public int? shadowOffsetY { get;set; }
        public string cursor { get;set; }
    }
}
