using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class Label
    {
        public bool Visible { get; set; } 
        public string Position { get; set; }

        public int OffsetX { get; set; } = 6;
        public int OffsetY { get; set; } = 6;

        public bool AdjustColor { get; set; } = true;

        public bool AdjustPosition { get; set; } = false;


    }
}
