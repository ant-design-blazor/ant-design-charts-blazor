using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BubbleConfig : IBubbleViewConfig, IPlotConfig
    {
        [JsonPropertyName("pointSize")]
        public int[] PointSize { get; set; }
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
        [JsonPropertyName("pointStyle")]
        public GraphicStyle PointStyle { get; set; }
        [JsonPropertyName("colorField")]
        public string[] ColorField { get; set; }
        [JsonPropertyName("xAxis")]
        public ValueTimeAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public ValueTimeAxis YAxis { get; set; }
        [JsonPropertyName("quadrant")]
        public QuadrantConfig Quadrant { get; set; }
        [JsonPropertyName("trendline")]
        public TrendlineConfig Trendline { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string YField { get; set; }
        [JsonPropertyName("color")]
        public string[] Color { get; set; }
        [JsonPropertyName("label")]
        public Label Label { get; set; }
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonPropertyName("animation")]
        public object Animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonPropertyName("responsiveTheme")]
        public object ResponsiveTheme { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("forceFit")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
        object IScatterViewConfig.PointSize { get; set; }
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
    }

    public interface IBubbleViewConfig : IScatterViewConfig
    {
        /// <summary>
        ///  气泡大小 
        /// </summary>
        [JsonPropertyName("pointSize")]
        public int[] PointSize { get; set; }//[number, number]
        /// <summary>
        ///  气泡大小字段 
        /// </summary>
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
    }
}


