using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class GaugeConfig : IGaugeLayerConfig, IPlotConfig
    {
        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }
        [JsonPropertyName("endAngle")]
        public int? EndAngle { get; set; }
        [JsonPropertyName("min")]
        public decimal? Min { get; set; }
        [JsonPropertyName("max")]
        public decimal? Max { get; set; }
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
        [JsonPropertyName("range")]
        public double[] Range { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("rangeSize")]
        public int? RangeSize { get; set; }
        [JsonPropertyName("rangeStyle")]
        public GraphicStyle RangeStyle { get; set; }
        [JsonPropertyName("rangeBackgroundStyle")]
        public GraphicStyle RangeBackgroundStyle { get; set; }
        [JsonPropertyName("format")]
        public string Format { get; set; }
        [JsonPropertyName("axis")]
        public GaugeAxis Axis { get; set; }
        [JsonPropertyName("pivot")]
        public GaugePivot Pivot { get; set; }
        [JsonPropertyName("statistic")]
        public GaugeStatistic Statistic { get; set; }
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
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
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
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("x")]
        public int? X { get; set; }
        [JsonPropertyName("y")]
        public int? Y { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("parent")]
        public object Parent { get; set; }
        [JsonPropertyName("canvas")]
        public object Canvas { get; set; }
        [JsonPropertyName("forceFit")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }

        [JsonPropertyName("appendPadding")]
        public int AppendPadding { get; set; }
    }

    public interface IGaugeLayerConfig : GaugeViewConfig, ILayerConfig { }

    public interface GaugeViewConfig : IViewConfig
    {
        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }
        [JsonPropertyName("endAngle")]
        public int? EndAngle { get; set; }
        [JsonPropertyName("min")]
        public decimal? Min { get; set; }
        [JsonPropertyName("max")]
        public decimal? Max { get; set; }
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
        [JsonPropertyName("range")]
        public double[] Range { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("rangeSize")]
        public int? RangeSize { get; set; }
        [JsonPropertyName("rangeStyle")]
        public GraphicStyle RangeStyle { get; set; }
        [JsonPropertyName("rangeBackgroundStyle")]
        public GraphicStyle RangeBackgroundStyle { get; set; }
        [JsonPropertyName("format")]
        public string Format { get; set; }//(...args: any[]) => string
        [JsonPropertyName("axis")]
        public GaugeAxis Axis { get; set; }
        [JsonPropertyName("pivot")]
        public GaugePivot Pivot { get; set; }
        [JsonPropertyName("statistic")]
        public GaugeStatistic Statistic { get; set; }

    }

    public interface IGaugeAxis
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickLine")]
        public GaugeAxisTickLine TickLine { get; set; }
        [JsonPropertyName("label")]
        public GaugeAxisLabel Label { get; set; }

    }

    public class GaugeAxisTickLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("length")]
        public int? Length { get; set; }
        [JsonPropertyName("thickness")]
        public int? Thickness { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }

    public class GaugeAxisLabel
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }//() => string
    }

    public class GaugeAxis : IGaugeAxis
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickLine")]
        public GaugeAxisTickLine TickLine { get; set; }
        [JsonPropertyName("label")]
        public GaugeAxisLabel Label { get; set; }
    }

    public interface IGaugePivot
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("thickness")]
        public int? Thickness { get; set; }
        [JsonPropertyName("pointer")]
        public GaugePivotPointer Pointer { get; set; }
        [JsonPropertyName("pin")]
        public GaugePivotPin Pin { get; set; }
        [JsonPropertyName("base")]
        public GaugePivotBase Base { get; set; }

    }

    public class GaugePivotPointer
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

    public class GaugePivotPin
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

    public class GaugePivotBase
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

    public class GaugePivot : IGaugePivot
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("thickness")]
        public int? Thickness { get; set; }
        [JsonPropertyName("pointer")]
        public GaugePivotPointer Pointer { get; set; }
        [JsonPropertyName("pin")]
        public GaugePivotPin Pin { get; set; }
        public GaugePivotBase Base { get; set; }
    }

    public interface IGaugeStatistic
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string[] Position { get; set; }// [string, string]
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }

    public class GaugeStatistic : IGaugeStatistic
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string[] Position { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}


