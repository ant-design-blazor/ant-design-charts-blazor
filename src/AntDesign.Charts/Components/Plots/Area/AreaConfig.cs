using OneOf;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class AreaConfig : IAreaViewConfig, IPlotConfig
    {
        [JsonPropertyName("areaStyle")]
        public GraphicStyle AreaStyle { get; set; }
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("line")]
        public AreaViewConfigLine Line { get; set; }
        [JsonPropertyName("point")]
        public AreaViewConfigPoint Point { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("label")]
        public AreaLabel Label { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }//ILooseMap<Meta>
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
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
        OneOf<Label, object> IViewConfig.Label { get; set; }
    }

    public interface IAreaViewConfig : IViewConfig
    {
        [JsonPropertyName("areaStyle")]
        public GraphicStyle AreaStyle { get; set; }//OneOf <GraphicStyle, ((...args: any) => GraphicStyle)>
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }//OneOf <ICatAxis, ITimeAxis, IValueAxis>
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("line")]
        public AreaViewConfigLine Line { get; set; }
        [JsonPropertyName("point")]
        public AreaViewConfigPoint Point { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        /// <summary>
        /// export type AreaInteraction =
        ///  | { type: 'slider'; cfg: ISliderInteractionConfig }
        ///  | { type: 'scrollbar'; cfg?: IScrollbarInteractionConfig };
        /// </summary>
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }

        [JsonPropertyName("label")]
        public AreaLabel Label { get; set; }

    }

    public class AreaViewConfigLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }

    public class AreaViewConfigPoint
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("shape")]
        public string Shape { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

    public interface IAreaLabel : IAreaPointLabel, IAreaPointAutoLabel, ILabel
    {
    }

    public interface IAreaPointLabel : ILabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }//'area-point'
    }

    public interface IAreaPointAutoLabel : ILabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }//'area-point-auto'
        /// <summary>
        ///  area-point-auto 暗色配置 
        /// </summary>
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        /// <summary>
        ///  area-point-auto 亮色配置 
        /// </summary>
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
    }

    public class AreaLabel : IAreaLabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("precision")]
        public int? Precision { get; set; }
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("field")]
        public string Field { get; set; }
    }

}


