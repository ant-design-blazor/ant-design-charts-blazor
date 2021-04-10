using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class PieConfig : IPieViewConfig, IPlotConfig
    {
        [JsonPropertyName("angleField")]
        public string AngleField { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("pieStyle")]
        public GraphicStyle PieStyle { get; set; }
        [JsonPropertyName("label")]
        public PieLabelConfig Label { get; set; }
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
        OneOf<Label, object> IViewConfig.Label { get; set; }


        [JsonPropertyName("innerRadius")]
        public double? InnerRadius { get; set; }
        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
    }

    public interface IPieViewConfig : IViewConfig
    {
        [JsonPropertyName("angleField")]
        public string AngleField { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("pieStyle")]
        public GraphicStyle PieStyle { get; set; }//OneOf <GraphicStyle, ((...args: any[]) => GraphicStyle)>
        [JsonPropertyName("label")]
        public PieLabelConfig Label { get; set; }
    }

    public interface IPieLabelConfig : ILabel
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public object Formatter { get; set; }//OneOf <(text: string, int?, undefined,null, item: any, idx: number, ...extras: any[]) => string>
        /// <summary>
        ///  whether 
        /// </summary>
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        /// <summary>
        ///  allow label overlap 
        /// </summary>
        [JsonPropertyName("allowOverlap")]
        public bool? AllowOverlap { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("labelHeight")]
        public int? LabelHeight { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("line")]
        public PieLabelConfigLine Line { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public interface PieLabelConfigLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
    }

    public class PieLabelConfig : IPieLabelConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public object Formatter { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        [JsonPropertyName("allowOverlap")]
        public bool? AllowOverlap { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("labelHeight")]
        public int? LabelHeight { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("line")]
        public PieLabelConfigLine Line { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("precision")]
        public int? Precision { get; set; }
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("field")]
        public string Field { get; set; }
    }

}


