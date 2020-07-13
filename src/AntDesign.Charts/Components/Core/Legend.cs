using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
   public class Legend
    {
        public bool Visible { get; set; }
        public string Position { get; set; }

        public long OffsetX { get; set; }
        public long OffsetY { get; set; }

        public Title Title { get; set; }

        

    }
}
