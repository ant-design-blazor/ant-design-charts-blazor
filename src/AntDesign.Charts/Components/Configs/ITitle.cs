using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{ 
   public interface ITitle
    {
        public bool? visible { get; set; }
        public string text { get; set; }
        public TextStyle style { get; set; }
        public string alignTo { get; set; }//OneOf<'left','right','middle'> 

    }

    public class Title : ITitle
    {
        public bool? visible { get;set; }
        public string text { get;set; }
        public TextStyle style { get;set; }
        public string alignTo { get;set; }
    }
}
