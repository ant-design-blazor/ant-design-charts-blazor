using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ScatterConfig : IScatterViewConfig, IPlotConfig
    {
        [JsonIgnore]
        public OneOf<int?, int[], object> PointSize { get; set; }
        [JsonPropertyName("pointSize")]
        public object PointSizeMapping => PointSize.Value;
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

        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
    }

    public interface IScatterViewConfig : IPointViewConfig
    {
        /// <summary>
        ///  散点大小 
        /// </summary>
        [JsonPropertyName("pointSize")]
        public OneOf<int?, int[], object> PointSize { get; set; }
    }

    public interface IPointViewConfig : IViewConfig
    {
        /// <summary>
        ///  散点样式 
        /// </summary>
        [JsonPropertyName("pointStyle")]
        public GraphicStyle PointStyle { get; set; }//OneOf <GraphicStyle, ((...args: any) => GraphicStyle)>
        /// <summary>
        ///  颜色字段 
        /// </summary>
        [JsonPropertyName("colorField")]
        public OneOf<string, string[]> ColorField { get; set; }
        /// <summary>
        ///  x 轴配置 
        /// </summary>
        [JsonPropertyName("xAxis")]
        public ValueTimeAxis XAxis { get; set; }//OneOf <ITimeAxis, IValueAxis>
        /// <summary>
        ///  y 轴配置 
        /// </summary>
        [JsonPropertyName("yAxis")]
        public ValueTimeAxis YAxis { get; set; }//OneOf <ITimeAxis, IValueAxis>
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
        public OneOf<object, object[]> RegionStyle { get; set; }
        [JsonPropertyName("lineStyle")]
        public object LineStyle { get; set; }
        [JsonPropertyName("label")]
        public OneOf<Label, object> Label { get; set; }
    }

    public class QuadrantConfig : IQuadrantConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("xBaseline")]
        public int? XBaseline { get; set; }
        [JsonPropertyName("yBaseline")]
        public int? YBaseline { get; set; }
        [JsonIgnore]
        public OneOf<object, object[]> RegionStyle { get; set; }
        [JsonPropertyName("regionStyle")]
        public object RegionStyleMapping => RegionStyle.Value;
        [JsonPropertyName("lineStyle")]
        public object LineStyle { get; set; }
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
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


