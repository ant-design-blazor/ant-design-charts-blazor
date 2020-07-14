using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ToolTip
    {
        public bool Visible { get; set; }
        public int Offset { get; set; }

        public string Fields { get; set; }

        public DomStyles DomStyles { get; set; }
    }
}
