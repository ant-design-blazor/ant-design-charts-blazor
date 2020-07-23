using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ColumnLineConfig : IColumnLineViewConfig, IPlotConfig
    {
        [JsonPropertyName("xAxis")]
        public CatAxis XAxis { get; set; }
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineSeriesField")]
        public string LineSeriesField { get; set; }
        [JsonPropertyName("lineConfig")]
        public LineConfig LineConfig { get; set; }
        [JsonPropertyName("columnConfig")]
        public ColumnConfig ColumnConfig { get; set; }
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
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
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
        [JsonPropertyName("animation")]
        public object Animation { get; set; }
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
        string IViewConfig.YField { get; set; }
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
        Tooltip IViewConfig.Tooltip { get; set; }
        Legend IViewConfig.Legend { get; set; }
        Title IViewConfig.Title { get; set; }
        Description IViewConfig.Description { get; set; }
    }

    public interface IColumnLineViewConfig : IComboViewConfig
    {
        [JsonPropertyName("xAxis")]
        public CatAxis XAxis { get; set; }
        [JsonPropertyName("tooltip")]
        public object Tooltip { get; set; }
        [JsonPropertyName("lineSeriesField")]
        public string LineSeriesField { get; set; }
        [JsonPropertyName("lineConfig")]
        public LineConfig LineConfig { get; set; }
        [JsonPropertyName("columnConfig")]
        public ColumnConfig ColumnConfig { get; set; }
    }
}

