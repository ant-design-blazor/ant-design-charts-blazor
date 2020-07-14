using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{ 
   public  interface IStateConfig
    {
        //  condition: () => any | StateCondition;
        public GraphicStyle style { get; set; }
        public string[] related { get; set; }
    }

    public class StateConfig : IStateConfig
    {
        public GraphicStyle style { get;set;}
        public string[] related { get;set;}
    }
}
