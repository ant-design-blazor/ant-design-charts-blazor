using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BubbleConfig : IBubbleViewConfig, IPlotConfig
    {
        public int[] pointSize { get; set; }
        public string sizeField { get; set; }
        public GraphicStyle pointStyle { get; set; }
        public string[] colorField { get; set; }
        public ValueTimeAxis xAxis { get; set; }
        public ValueTimeAxis yAxis { get; set; }
        public QuadrantConfig quadrant { get; set; }
        public TrendlineConfig trendline { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
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
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        object IScatterViewConfig.pointSize { get; set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }

    public interface IBubbleViewConfig : IScatterViewConfig
    {
        /// <summary>
        ///  气泡大小 
        /// </summary>
        public int[] pointSize { get; set; }//[number, number]
        /// <summary>
        ///  气泡大小字段 
        /// </summary>
        public string sizeField { get; set; }
    }
}
