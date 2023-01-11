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
        public double? StartAngle { get; set; }
        [JsonPropertyName("endAngle")]
        public double? EndAngle { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public decimal? Min { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public decimal? Max { get; set; }
        [JsonPropertyName("percent")]
        public decimal? Percent { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("innerRadius")]
        public double? InnerRadius { get; set; }
        [JsonIgnore]
        public OneOf<GaugeRange, double[]> Range { get; set; }
        [JsonPropertyName("range")]
        public object RangeMapping => Range.Value;
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public OneOf<string, string[], object> Color { get; set; }
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
        [JsonIgnore]
        [Obsolete("No longer supported, use Indicator instead")]
        public GaugePivot Pivot { get; set; }
        [JsonIgnore]
        public OneOf<GaugeIndicator, bool> Indicator { get; set; }
        [JsonPropertyName("indicator")]
        public object IndicatorMapping => Indicator.Value;
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
        [JsonIgnore]
        [Obsolete("No longer supported. Responsive is now built-in by default")]
        public bool? Responsive { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Title Title { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Description Description { get; set; }
        [JsonIgnore]
        [Obsolete("No Longer Supported, use annotation instead")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonIgnore]
        public OneOf<IAnnotation[], object[]> Annotation { get; set; }
        [JsonPropertyName("annotations")]
        public object AnnotationMapping => Annotation.Value;
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
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        [JsonPropertyName("gaugeStyle")]
        public GaugeStyle GaugeStyle { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

    }

    public interface IGaugeLayerConfig : GaugeViewConfig, ILayerConfig { }

    public interface GaugeViewConfig : IViewConfig
    {
        [JsonPropertyName("startAngle")]
        public double? StartAngle { get; set; }
        [JsonPropertyName("endAngle")]
        public double? EndAngle { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public decimal? Min { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public decimal? Max { get; set; }
        [JsonPropertyName("percent")]
        public decimal? Percent { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("innerRadius")]
        public double? InnerRadius { get; set; }
        [JsonIgnore]
        public OneOf<GaugeRange, double[]> Range { get; set; }
        [JsonPropertyName("range")]
        public object RangeMapping => Range.Value;
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
        [JsonIgnore]
        [Obsolete("No longer supported, use Indicator instead")]
        public GaugePivot Pivot { get; set; }
        [JsonIgnore]
        public OneOf<GaugeIndicator, bool> Indicator { get; set; }
        [JsonPropertyName("indicator")]
        public object IndicatorMapping => Indicator.Value;
        [JsonPropertyName("statistic")]
        public GaugeStatistic Statistic { get; set; }
        [JsonPropertyName("gaugeStyle")]
        public GaugeStyle GaugeStyle { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
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

    public class GaugeStyle : IGraphicStyle
    {
        [JsonPropertyName("fill")]
        public string Fill { get; set; }
        [JsonPropertyName("fillOpacity")]
        public decimal? FillOpacity { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
        [JsonPropertyName("shadowColor")]
        public string ShadowColor { get; set; }
        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }
        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }
        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("r")]
        public double? R { get; set; }
        [JsonPropertyName("lineCap")]
        public string LineCap { get; set; }
    }

    public interface IGaugeIndicator
    {
        [JsonPropertyName("pointer")]
        public GaugeIndicatorStyle Pointer { get; set; }
        
        [JsonPropertyName("pin")]
        public GaugeIndicatorStyle Pin { get; set; }
        
        [JsonPropertyName("shape")]
        public GaugeIndicatorStyle Shape { get; set; }
    }

    public class GaugeIndicator
    {
        [JsonPropertyName("pointer")]
        public GaugeIndicatorStyle Pointer { get; set; }

        [JsonPropertyName("pin")]
        public GaugeIndicatorStyle Pin { get; set; }

        [JsonPropertyName("shape")]
        public GaugeIndicatorStyle Shape { get; set; }
    }

    public class GaugeIndicatorStyle
    {
        [JsonIgnore]
        public OneOf<GaugeStyle, string, object> Style { get; set; }
        [JsonPropertyName("style")]
        public object StyleMapping => Style.Value;
    }

    public interface IGaugeStatistic
    {
        //might be obsolete
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
        //new statistics
        [JsonPropertyName("title")]
        public GaugeStatisticStyle Title { get; set; }
        [JsonPropertyName("content")]
        public GaugeStatisticStyle Content { get; set; }
    }

    public class GaugeStatistic : IGaugeStatistic
    {
        //might be obsolete
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
        //new statistics
        [JsonPropertyName("title")]
        public GaugeStatisticStyle Title { get; set; }
        [JsonPropertyName("content")]
        public GaugeStatisticStyle Content { get; set; }
    }

    public class GaugeStatisticStyle
    {
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("customHtml")]
        public object CustomHtml { get; set; }
        [JsonPropertyName("formatter")]
        public object Formatter { get; set; }
        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
    }

    public class GaugeRange
    {
        [JsonIgnore]
        public OneOf<double[], double> Ticks { get; set; }
        [JsonPropertyName("ticks")]
        public object TickMapping => Ticks.Value;
        [JsonIgnore]
        public OneOf<string[],string> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("width")]
        public int? Width { get; set; }
    }
}


