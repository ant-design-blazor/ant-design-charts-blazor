using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IGuideLineConfig
    {
        public string type { get; set; }
        public object[] start { get; set; }//any[]
        public object[] end { get; set; }//any[]
        public LineStyle lineStyle { get; set; }
        public GuideLineConfigText text { get; set; }
    }

    public class GuideLineConfigText
    {
        public string position { get; set; }//OneOf<'start','center','end'>
        public string content { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public TextStyle style { get; set; }
    }

    public class GuideLineConfig : IGuideLineConfig
    {
        public string type {get;set;}
        public object[] start {get;set;}
        public object[] end {get;set;}
        public LineStyle lineStyle {get;set;}
        public GuideLineConfigText text {get;set;}
    }

}
