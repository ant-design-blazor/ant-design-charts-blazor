using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BulletConfig : IBulletViewConfig, IPlotConfig
    { 
        [JsonPropertyName("data")]
        public BulletViewConfigData[] Data { get; set; }
        [JsonPropertyName("rangeMax")]
        public decimal? RangeMax { get; set; }
        [JsonPropertyName("measureSize")]
        public int? MeasureSize { get; set; }
        [JsonPropertyName("measureColors")]
        public string[] MeasureColors { get; set; }
        [JsonPropertyName("rangeSize")]
        public int? RangeSize { get; set; }
        [JsonPropertyName("rangeColors")]
        public string[] RangeColors { get; set; }
        [JsonPropertyName("markerSize")]
        public int? MarkerSize { get; set; }
        [JsonPropertyName("markerColors")]
        public string[] MarkerColors { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
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
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
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
        object IViewConfig.Data { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
    }

    public interface IBulletViewConfig : IViewConfig
    {
        [JsonPropertyName("data")]
        public BulletViewConfigData[] Data { get; set; }
        /// <summary>
        ///  进度条的色条范围区间的最大值 
        /// </summary>
        [JsonPropertyName("rangeMax")]
        public decimal? RangeMax { get; set; }
        /// <summary>
        ///  实际进度条大小设置 
        /// </summary>
        [JsonPropertyName("measureSize")]
        public int? MeasureSize { get; set; }
        [JsonPropertyName("measureColors")]
        public string[] MeasureColors { get; set; }
        /// <summary>
        ///  区间背景条大小设置。ratio number, relative to measureSize 
        /// </summary>
        [JsonPropertyName("rangeSize")]
        public int? RangeSize { get; set; }
        /// <summary>
        ///  进度条背景颜色 
        /// </summary>
        [JsonPropertyName("rangeColors")]
        public string[] RangeColors { get; set; }
        /// <summary>
        ///  目标值 marker 大小设置。ratio number, relative to measureSize 
        /// </summary>
        [JsonPropertyName("markerSize")]
        public int? MarkerSize { get; set; }
        /// <summary>
        ///  marker 的填充色 
        /// </summary>
        [JsonPropertyName("markerColors")]
        public string[] MarkerColors { get; set; }
    }

    public class BulletViewConfigData
    {
        /// <summary>
        ///  子弹图标题 
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        ///  进度值，array类型。支持阶段性的进度值（即堆叠） 
        /// </summary>
        [JsonPropertyName("measures")]
        public int[] Measures { get; set; }
        /// <summary>
        ///  进度条的色条范围区间，相对数值：[0, 1] 
        /// </summary>
        [JsonPropertyName("ranges")]
        public double[] Ranges { get; set; }
        /// <summary>
        ///  目标值，array类型。支持多目标设置 
        /// </summary>
        [JsonPropertyName("targets")]
        public int[] Targets { get; set; }

        [JsonPropertyName("markerStyle")]
        public BulletViewConfigMarkerStyle MarkerStyle { get; set; }
        /// <summary>
        ///  进度条刻度轴设置 
        /// </summary>
        [JsonPropertyName("axis")]
        public BulletAxis Axis { get; set; }
        [JsonPropertyName("stackField")]
        public string StackField { get; set; }
    }

    public class BulletViewConfigMarkerStyle
    {
        /// <summary>
        ///  marker 的宽度，default: 1 
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        ///  marker 的填充色, 若存在 markerColors, 优先取 markerColors 
        /// </summary>
        [JsonPropertyName("fill")]
        public string Fill { get; set; }
        /*   
         [k: string]: any;
         */
    }

    public interface IBulletAxis
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        /// 'before','after'
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickLine")]
        public BulletAxisTickLine TickLine { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }//(text: string, idx: number) => string
    }

    public interface IBulletAxisTickLine : ILineStyle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
    }

    public class BulletAxisTickLine : IBulletAxisTickLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
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
    }

    public class BulletAxis : IBulletAxis
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        /// 'before','after'
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        public static string PositionBefore = "before";
        public static string PositionAfter = "after";

        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickLine")]
        public BulletAxisTickLine TickLine { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
    }
}


