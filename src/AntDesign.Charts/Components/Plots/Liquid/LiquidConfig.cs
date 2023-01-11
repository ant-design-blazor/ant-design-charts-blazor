using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class LiquidConfig : ILiquidViewConfig, IPlotConfig
    {
        [JsonPropertyName("statistic")]
        public LiquidStatisticStyle Statistic { get; set; }
        [JsonPropertyName("liquidSize")]
        public int? LiquidSize { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use percent instead")]
        public decimal? Min { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use percent instead")]
        public decimal? Max { get; set; }
        [JsonPropertyName("percent")]
        public decimal? Percent { get; set; }
        [JsonPropertyName("liquidStyle")]
        public object LiquidStyle { get; set; }
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
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Shape { get; set; }
        [JsonPropertyName("shape")]
        public object ShapeMapping => Shape.Value;
        [JsonPropertyName("wave")]
        public LiquidWave Wave { get; set; }
        [JsonPropertyName("outline")]
        public LiquidOutline Outline { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Pattern { get; set; }
        [JsonPropertyName("pattern")]
        public object PatternMapping => Pattern.Value;
    }

    public interface ILiquidViewConfig : IViewConfig
    {
        [JsonPropertyName("statistic")]
        public LiquidStatisticStyle Statistic { get; set; }
        [JsonPropertyName("liquidSize")]
        public int? LiquidSize { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use percent instead")]
        public decimal? Min { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use percent instead")]
        public decimal? Max { get; set; }
        [JsonPropertyName("percent")]
        public decimal? Percent { get; set; }
        [JsonPropertyName("liquidStyle")]
        public object LiquidStyle { get; set; }//OneOf <LiquidStyle, ((...args: any[]) => LiquidStyle)>
        [JsonIgnore]
        public OneOf<string,object> Shape { get; set; }
        [JsonPropertyName("shape")]
        public object ShapeMapping => Shape.Value;
        [JsonPropertyName("wave")]
        public LiquidWave Wave { get; set; }
        [JsonPropertyName("outline")]
        public LiquidOutline Outline { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Pattern { get; set; }
        [JsonPropertyName("pattern")]
        public object PatternMapping => Pattern.Value;


    }

    public interface ILiquidStatisticStyle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }//(value) => string
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }//(...args: any) => string

    }

    public class LiquidStatisticStyle : ILiquidStatisticStyle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }
    }

    public class LiquidWave
    {
        [JsonPropertyName("count")]
        public int? Count { get; set; }
        [JsonPropertyName("length")]
        public int? Length { get; set; }
    }

    public class LiquidOutline
    {
        [JsonPropertyName("border")]
        public int? Border { get; set; }
        [JsonPropertyName("distance")]
        public int? Distance { get; set; }
        [JsonPropertyName("style")]
        public OutlineStyleCfg Style { get; set; }
    }

    public class OutlineStyleCfg
    {
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("strokeOpacity")]
        public double? StokeOpacity { get; set; }
    }
}


