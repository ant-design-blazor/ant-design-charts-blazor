using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BubbleConfig : IBubbleViewConfig, IPlotConfig
    {
        [JsonIgnore]
        public OneOf<int?, int[], object> PointSize { get; set; }
        [JsonPropertyName("pointSize")]
        public object PointSizeMapping => PointSize.Value;
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
        [JsonPropertyName("pointStyle")]
        public GraphicStyle PointStyle { get; set; }
        [JsonIgnore]
        public OneOf<string, string[]> ColorField { get; set; }
        [JsonPropertyName("colorField")]
        public object ColorFieldMapping => ColorField.Value;
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
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonIgnore]
        public OneOf<bool?, Animation, object> Animation { get; set; }
        [JsonPropertyName("animation")]
        public object AnimationMapping => Animation.Value;
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonIgnore]
        public OneOf<string, object> ResponsiveTheme { get; set; }
        [JsonPropertyName("responsiveTheme")]
        public object ResponsiveThemeMapping => ResponsiveTheme.Value;
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
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
    }

    public interface IBubbleViewConfig : IScatterViewConfig
    {
        /// <summary>
        ///  气泡大小 
        /// </summary>
        [JsonPropertyName("pointSize")]
        public OneOf<int?, int[], object> PointSize { get; set; }
        /// <summary>
        ///  气泡大小字段 
        /// </summary>
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
    }
}


