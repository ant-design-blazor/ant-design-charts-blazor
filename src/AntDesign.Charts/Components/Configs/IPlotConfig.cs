using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace AntDesign.Charts
{
    public interface IPlotConfig
    {
        [JsonIgnore]
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public string renderer { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public OneOf<string, object> theme { get; set; }//OneOf<LooseMap, string>   LooseMap: [key: string]: T;
        public bool? localRefresh { get; set; }
    }

}
