using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class TreemapConfig : ITreemapViewConfig, IPlotConfig
    {
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("maxLevel")]
        public int? MaxLevel { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("colors")]
        public string[] Colors { get; set; }
        [JsonPropertyName("rectStyle")]
        public GraphicStyle RectStyle { get; set; }
        [JsonPropertyName("label")]
        public TreemapLabelConfig Label { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
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
        OneOf<Label, object> IViewConfig.Label { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
    }

    public interface ITreemapViewConfig : IViewConfig
    {
        [JsonPropertyName("maxLevel")]
        public int? MaxLevel { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("colors")]
        public string[] Colors { get; set; }
        [JsonPropertyName("rectStyle")]
        public GraphicStyle RectStyle { get; set; }
        [JsonPropertyName("label")]
        public new TreemapLabelConfig Label { get; set; }
    }

    public interface ITreemapLabelConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }// (...args: any[]) => string
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
    }

    public class TreemapLabelConfig : ITreemapLabelConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
    }

}


