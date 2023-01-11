using OneOf;
using System;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ViolinConfig : IViolinViewConfig, IPlotConfig
    {
        //From IPlotConfig
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }


        //From IViewConfig
        [JsonIgnore]
        public OneOf<bool?, Animation, object> Animation { get; set; }
        [JsonPropertyName("animation")]
        public object AnimationMapping => Animation.Value;
        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
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
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
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
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string YField { get; set; }


        //IViolinViewConfig
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        /// <summary>
        /// 'smooth'|'hollow'|'hollow-smooth'
        /// </summary>
        [JsonPropertyName("shape")]
        public string Shape { get; set; }
        [JsonPropertyName("violinStyle")]
        public GraphicStyle ViolinStyle { get; set; }
    }

    public interface IViolinViewConfig : IViewConfig
    {
        public string SeriesField { get; set; }
        public string Shape { get; set; }//'smooth'|'hollow'|'hollow-smooth'
        public GraphicStyle ViolinStyle { get; set; }
    }

}