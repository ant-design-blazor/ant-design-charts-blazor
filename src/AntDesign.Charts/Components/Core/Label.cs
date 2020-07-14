using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class Label
    {
        public bool Visible { get; set; } = false;
        public string Position { get; set; } = "top";

        public object Style { get; set; }

        public string Type { get; set; } = "inner";

        //public int OffsetX { get; set; } = 6;
        //public int OffsetY { get; set; } = 6;

        //public bool adjustColor { get; set; } = true;

        //public bool adjustPosition { get; set; } = false;


    }
}
