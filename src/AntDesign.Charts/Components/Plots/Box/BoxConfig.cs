using OneOf;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BoxConfig : IBoxViewConfig, IPlotConfig
    {
        //From IPlotConfig
        [JsonPropertyName("forceFit")]
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
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        //[JsonPropertyName("label")]
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
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonIgnore]
        string IViewConfig.YField { get; set; }


        //IBoxViewConfig
        [JsonPropertyName("boxStyle")]
        public GraphicStyle BoxStyle { get; set; }
        [JsonPropertyName("groupField")]
        public string GroupField { get; set; }
        [JsonPropertyName("outliersField")]
        public string OutliersField { get; set; }
        [JsonPropertyName("outliersStyle")]
        public GraphicStyle OutliersStyle { get; set; }
        [JsonIgnore]
        public OneOf<string, string[]> YField { get; set; }
        [JsonPropertyName("yField")]
        public object YFieldMapping => YField.Value;
    }

    public interface IBoxViewConfig : IViewConfig
    {
        public GraphicStyle BoxStyle { get; set; }
        public string GroupField { get; set; }
        public string OutliersField { get; set; }
        public GraphicStyle OutliersStyle { get; set; }
        public OneOf<string, string[]> YField { get; set; }
    }

}