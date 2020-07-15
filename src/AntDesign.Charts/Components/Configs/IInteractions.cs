using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IInteractions
    {
        public string type { get; set; }
        public object cfg { get; set; }// [field: string]: any;
    }

    public class Interactions : IInteractions
    {
        public string type { get; set; }
        public object cfg { get; set; }
    }

}
