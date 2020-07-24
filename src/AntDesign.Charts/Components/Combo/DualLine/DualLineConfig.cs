using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class DualLineConfig : IDualLineViewConfig, IPlotConfig
    {
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineConfigs")]
        public LineConfig[] LineConfigs { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string[] YField { get; set; }
        [JsonPropertyName("yAxis")]
        public ComboYAxis YAxis { get; set; }
        [JsonPropertyName("legend")]
        public ComboLegendConfig Legend { get; set; }
        [JsonPropertyName("forceFit")]
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
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
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
    }

    public interface IDualLineViewConfig : IComboViewConfig
    {
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }//OneOf <IValueAxis, ICatAxis, ITimeAxis>
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineConfigs")]
        public LineConfig[] LineConfigs { get; set; }
    }

    public interface IComboViewConfig : IViewConfig
    {
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }//DataItem[][]
        [JsonPropertyName("meta")]
        public object Meta { get; set; }//LooseMap<Meta>
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string[] YField { get; set; }
        [JsonPropertyName("yAxis")]
        public ComboYAxis YAxis { get; set; }
        [JsonPropertyName("legend")]
        public ComboLegendConfig Legend { get; set; }
        /*
          events?: {
            [k: string]: ((...args: any[]) => any) | boolean;
          };
         */
    }

    public interface IComboYAxis
    {
        [JsonPropertyName("max")]
        public int? Max { get; set; }
        [JsonPropertyName("min")]
        public int? Min { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("leftConfig")]
        public ComboYAxisConfig LeftConfig { get; set; }
        [JsonPropertyName("rightConfig")]
        public ComboYAxisConfig RightConfig { get; set; }
    }

    public interface IComboYAxisConfig : IValueAxis
    {
        [JsonPropertyName("colorMapping")]
        public bool? ColorMapping { get; set; }
    }

    public class ComboYAxisConfig : IComboYAxisConfig
    {
        [JsonPropertyName("colorMapping")]
        public bool? ColorMapping { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("nice")]
        public bool? Nice { get; set; }
        [JsonPropertyName("min")]
        public double? Min { get; set; }
        [JsonPropertyName("max")]
        public double? Max { get; set; }
        [JsonPropertyName("minLimit")]
        public int? MinLimit { get; set; }
        [JsonPropertyName("maxLimit")]
        public int? MaxLimit { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickInterval")]
        public int? TickInterval { get; set; }
        [JsonPropertyName("exponent")]
        public int? Exponent { get; set; }
        public int? Base { get; set; }
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
        [JsonPropertyName("tickMethod")]
        public string TickMethod { get; set; }
        [JsonPropertyName("line")]
        public BaseAxisLine Line { get; set; }
        [JsonPropertyName("grid")]
        public BaseAxisGrid Grid { get; set; }
        [JsonPropertyName("label")]
        public BaseAxisLabel Label { get; set; }
        [JsonPropertyName("title")]
        public BaseAxisTitle Title { get; set; }
        [JsonPropertyName("tickLine")]
        public BaseAxisTickLine TickLine { get; set; }
    }

    public class ComboYAxis : IComboYAxis
    {
        [JsonPropertyName("max")]
        public int? Max { get; set; }
        [JsonPropertyName("min")]
        public int? Min { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("leftConfig")]
        public ComboYAxisConfig LeftConfig { get; set; }
        [JsonPropertyName("rightConfig")]
        public ComboYAxisConfig RightConfig { get; set; }
    }

    public interface IComboLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("marker")]
        public ComboLegendConfigMarker Marker { get; set; }
        [JsonPropertyName("text")]
        public ComboLegendConfigText Text { get; set; }
    }

    public class ComboLegendConfigMarker
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }

    }
    public class ComboLegendConfigText
    {
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        //public (value: string) => string formatter { get; set; }
    }

    public class ComboLegendConfig : IComboLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("marker")]
        public ComboLegendConfigMarker Marker { get; set; }
        [JsonPropertyName("text")]
        public ComboLegendConfigText Text { get; set; }
    }
}

