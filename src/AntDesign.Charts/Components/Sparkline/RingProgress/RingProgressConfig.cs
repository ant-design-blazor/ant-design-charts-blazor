using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    using IRingProgressViewConfig = IProgressViewConfig;
    public class RingProgressConfig : IRingProgressViewConfig, IPlotConfig
    {
        public GraphicStyle progressStyle { get; set; }
        public double? percent { get; set; }
        public int? size { get; set; }
        public MarkerConfig[] marker { get; set; }
        public int? barSize { get; set; }
        public GraphicStyle barStyle { get; set; }
        public string stackField { get; set; }
        public object indicator { get; set; }
        public object guideLine { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        GuideLineConfig[] IViewConfig.guideLine { get; set; }
    }
}
