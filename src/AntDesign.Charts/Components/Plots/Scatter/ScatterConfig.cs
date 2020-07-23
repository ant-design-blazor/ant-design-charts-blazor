using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ScatterConfig : IScatterViewConfig, IPlotConfig
    {
        [JsonPropertyName("pointSize")]
        public object PointSize { get; set; }
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
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
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

    public interface IScatterViewConfig : IPointViewConfig
    {
        /// <summary>
        ///  散点大小 
        /// </summary>
        [JsonPropertyName("pointSize")]
        public object PointSize { get; set; }//OneOf<int?, object>
    }

    public interface IPointViewConfig : IViewConfig
    {
        /// <summary>
        ///  散点样式 
        /// </summary>
        [JsonPropertyName("pointStyle")]
        public GraphicStyle PointStyle { get; set; }//OneOf<GraphicStyle, ((...args: any) => GraphicStyle)>
        /// <summary>
        ///  颜色字段 
        /// </summary>
        [JsonPropertyName("colorField")]
        public string[] ColorField { get; set; }//OneOf<string, string[]>
        /// <summary>
        ///  x 轴配置 
        /// </summary>
        [JsonPropertyName("xAxis")]
        public ValueTimeAxis XAxis { get; set; }//OneOf<ITimeAxis, IValueAxis>
        /// <summary>
        ///  y 轴配置 
        /// </summary>
        [JsonPropertyName("yAxis")]
        public ValueTimeAxis YAxis { get; set; }//OneOf<ITimeAxis, IValueAxis>
        [JsonPropertyName("quadrant")]
        public QuadrantConfig Quadrant { get; set; }
        [JsonPropertyName("trendline")]
        public TrendlineConfig Trendline { get; set; }
    }

    public interface IQuadrantConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("xBaseline")]
        public int? XBaseline { get; set; }
        [JsonPropertyName("yBaseline")]
        public int? YBaseline { get; set; }
        [JsonPropertyName("regionStyle")]
        public object RegionStyle { get; set; }//OneOf<any[], object>
        [JsonPropertyName("lineStyle")]
        public object LineStyle { get; set; }
        [JsonPropertyName("label")]
        public ILabel Label { get; set; }
    }

    public class QuadrantConfig : IQuadrantConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("xBaseline")]
        public int? XBaseline { get; set; }
        [JsonPropertyName("yBaseline")]
        public int? YBaseline { get; set; }
        [JsonPropertyName("regionStyle")]
        public object RegionStyle { get; set; }
        [JsonPropertyName("lineStyle")]
        public object LineStyle { get; set; }
        [JsonPropertyName("label")]
        public ILabel Label { get; set; }
    }

    public interface ITrendlineConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
        [JsonPropertyName("showConfidence")]
        public bool? ShowConfidence { get; set; }
        [JsonPropertyName("confidenceStyle")]
        public object ConfidenceStyle { get; set; }
    }

    public class TrendlineConfig : ITrendlineConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
        [JsonPropertyName("showConfidence")]
        public bool? ShowConfidence { get; set; }
        [JsonPropertyName("confidenceStyle")]
        public object ConfidenceStyle { get; set; }
    }
}


