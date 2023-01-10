using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ColumnConfig : IColumnViewConfig, IPlotConfig
    {
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("columnSize")]
        public int? ColumnSize { get; set; }
        [JsonPropertyName("columnStyle")]
        public GraphicStyle ColumnStyle { get; set; }
        [JsonPropertyName("xAxis")]
        public CatAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("conversionTag")]
        public ConversionTagOptions ConversionTag { get; set; }
        [JsonPropertyName("label")]
        public ColumnViewConfigLabel Label { get; set; }
        [JsonPropertyName("scrollbar")]
        public IScrollbar Scrollbar { get; set; }
        [JsonPropertyName("slider")]
        public ISlider Slider { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
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
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
        OneOf<Label, object> IViewConfig.Label { get ; set ; }

        [JsonPropertyName("isGroup")]
        public bool? IsGroup { get; set; }
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        [JsonPropertyName("isStack")]
        public bool? IsStack { get; set; }
        [JsonPropertyName("isRange")]
        public bool? IsRange { get; set; }
        [JsonPropertyName("isPercent")]
        public bool? IsPercent { get; set; }
    }

    public interface IColumnViewConfig : IViewConfig
    {
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        /// <summary>
        ///  百分比, 数值, 最小最大宽度
        /// </summary>
        [JsonPropertyName("columnSize")]
        public int? ColumnSize { get; set; }
        [JsonPropertyName("columnStyle")]
        public GraphicStyle ColumnStyle { get; set; }//OneOf <GraphicStyle, ((...args: any[]) => GraphicStyle)>
        [JsonPropertyName("xAxis")]
        public new CatAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public new ValueAxis YAxis { get; set; }
        [JsonPropertyName("conversionTag")]
        public ConversionTagOptions ConversionTag { get; set; }
        [JsonPropertyName("label")]
        public new ColumnViewConfigLabel Label { get; set; } //OneOf <IColumnLabel, IColumnAutoLabel>
        [JsonPropertyName("isStack")] 
        public bool? IsStack { get; set; }
        [JsonPropertyName("isRange")]
        public bool? IsRange { get; set; }
        [JsonPropertyName("isPercent")]
        public bool? IsPercent { get; set; }

    }

    public class ColumnViewConfigLabel : IColumnLabel, IColumnAutoLabel
    {
        /// <summary>
        /// string,'top','middle','bottom'
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        public static string PositionTop = "top";
        public static string PositionMiddle = "middle";
        public static string PositionBottom = "bottom";

        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("precision")]
        public int? Precision { get; set; }
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("field")]
        public string Field { get; set; }
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
        [JsonPropertyName("layout")]
        public LayoutType[] Layout { get; set; }
    }

    public interface IColumnLabel : ILabel
    {
        [JsonPropertyName("layout")]
        public LayoutType[] Layout { get; set; }
    }

    public class LayoutType
    {
        /// <summary>
        /// 'interval-adjust-position', 'interval-hide-overlap', 'adjust-color',
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public interface IColumnAutoLabel : ILabel
    {
        /// <summary>
        ///  column-auto 下暗色配置 
        /// </summary>
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        /// <summary>
        ///  column-auto 下亮色配置 
        /// </summary>
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
    }
}


