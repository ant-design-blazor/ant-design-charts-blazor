using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public class DualAxesConfig : IDualAxesViewConfig, IPlotConfig
    {
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineConfigs")]
        public LineConfig[] LineConfigs { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Title Title { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Description Description { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string[] YField { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
        [JsonIgnore]
        public OneOf<bool?, Animation, object> Animation { get; set; }
        [JsonPropertyName("animation")]
        public object AnimationMapping => Animation.Value;
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

        string IViewConfig.YField { get; set; }
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
        Tooltip IViewConfig.Tooltip { get; set; }
        Legend IViewConfig.Legend { get; set; }
        Title IViewConfig.Title { get; set; }
        Description IViewConfig.Description { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }

        [JsonPropertyName("geometryOptions")]
        public object[] GeometryOptions { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        [JsonPropertyName("scrollbar")]
        public IScrollbar Scrollbar { get; set; }
        [JsonPropertyName("slider")]
        public ISlider Slider { get; set; }

    }

    public interface IDualAxesViewConfig : IComboViewConfig
    {
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }//OneOf <IValueAxis, ICatAxis, ITimeAxis>
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineConfigs")]
        public LineConfig[] LineConfigs { get; set; }
        [JsonPropertyName("scrollbar")]
        public IScrollbar Scrollbar { get; set; }
        [JsonPropertyName("slider")]
        public ISlider Slider { get; set; }
    }

    public interface IComboViewConfig : IViewConfig
    {
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Title Title { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Description Description { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }//DataItem[][]
        [JsonPropertyName("meta")]
        public object Meta { get; set; }//LooseMap<Meta>
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string[] YField { get; set; }
    }


}