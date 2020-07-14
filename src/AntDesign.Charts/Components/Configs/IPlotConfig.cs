using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IPlotConfig
    {
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public string renderer { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public string theme { get; set; }//OneOf<LooseMap, string>   LooseMap: [key: string]: T;
        public bool? localRefresh { get; set; }
    }

}
