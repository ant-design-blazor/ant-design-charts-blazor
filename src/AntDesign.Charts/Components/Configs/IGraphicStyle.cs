using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IGraphicStyle
    {
        public string fill { get; set; }
        public int? fillOpacity { get; set; }
        public string stroke { get; set; }
        public int? lineWidth { get; set; }
        public int[] lineDash { get; set; }
        public int? lineOpacity { get; set; }
        public int? opacity { get; set; }
        public string shadowColor { get; set; }
        public int? shadowBlur { get; set; }
        public int? shadowOffsetX { get; set; }
        public int? shadowOffsetY { get; set; }
        public string cursor { get; set; }
        //  [field: string]: any;
    }

    public class GraphicStyle : IGraphicStyle
    {
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
