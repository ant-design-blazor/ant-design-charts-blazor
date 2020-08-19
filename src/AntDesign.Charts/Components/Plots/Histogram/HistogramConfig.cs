using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class HistogramConfig : IHistogramViewConfig, IPlotConfig
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
        [JsonPropertyName("binField")]
        public string BinField { get; set; }
        [JsonPropertyName("binWidth")]
        public int? BinWidth { get; set; }
        [JsonPropertyName("binNumber")]
        public int? BinNumber { get; set; }
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }
OneOf<Label, object> IViewConfig.Label { get ; set ; }
    }

    public interface IHistogramViewConfig : IColumnViewConfig
    {
        [JsonPropertyName("binField")]
        public string BinField { get; set; }
        [JsonPropertyName("binWidth")]
        public int? BinWidth { get; set; }
        [JsonPropertyName("binNumber")]
        public int? BinNumber { get; set; }
    }
}


