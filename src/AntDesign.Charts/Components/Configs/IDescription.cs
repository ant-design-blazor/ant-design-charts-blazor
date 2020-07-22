using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
  public   interface IDescription
    {
        public bool? visible { get; set; }
        public string text { get; set; }
        public TextStyle style { get; set; }
        public string  alignTo { get; set; }//OneOf <'left','right','middle'>

        public static string AlignToLeft = "left";
        public static string AlignToMiddle = "middle";
        public static string AlignToRight = "right";

    }

    public class Description : IDescription
    {
        public bool? visible { get;set;}
        public string text { get;set;}
        public TextStyle style { get;set;}
        public string alignTo { get;set;}
    }
}
