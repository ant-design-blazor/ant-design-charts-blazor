using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class StackedAreaConfig : IStackedAreaLayerConfig, IPlotConfig
    {
        public string stackField { get; set; }
        public StackedAreaLabel label { get; set; }
        public GraphicStyle areaStyle { get; set; }
        public string seriesField { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }
        public ValueAxis yAxis { get; set; }
        public AreaViewConfigLine line { get; set; }
        public AreaViewConfigPoint point { get; set; }
        public bool? smooth { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public object parent { get; set; }
        public object canvas { get; set; }
        public bool? forceFit { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        AreaLabel IAreaViewConfig.label { get; set; }
        Label IViewConfig.label { get; set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }

    public interface IStackedAreaLayerConfig : IStackedAreaViewConfig, ILayerConfig { }
}
