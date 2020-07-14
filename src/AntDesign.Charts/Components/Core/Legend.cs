using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AntDesign.Charts
{
    public class Legend
    {
        public bool Visible { get; set; } = true;
        public string Position { get; set; } = "left";

        public long offsetX { get; set; } = 0;
        public long offsetY { get; set; } = 0;

        //public Title Title { get; set; }

        //public Marker Marker { get; set; }

        //public Text Text { get; set; }
    }
}
