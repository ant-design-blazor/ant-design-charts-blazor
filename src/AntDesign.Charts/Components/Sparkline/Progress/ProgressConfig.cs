using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ProgressConfig : IProgressViewConfig, IPlotConfig
    {
        [JsonPropertyName("progressStyle")]
        public GraphicStyle ProgressStyle { get; set; }
        [JsonPropertyName("percent")]
        public double? Percent { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("marker")]
        public MarkerConfig[] Marker { get; set; }
        [JsonPropertyName("barSize")]
        public int? BarSize { get; set; }
        [JsonPropertyName("barStyle")]
        public GraphicStyle BarStyle { get; set; }
        [JsonPropertyName("stackField")]
        public string StackField { get; set; }
        [JsonPropertyName("indicator")]
        public object Indicator { get; set; }
        [JsonPropertyName("guideLine")]
        public object GuideLine { get; set; }
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
        [JsonPropertyName("color")]
        public string[] Color { get; set; }
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonPropertyName("label")]
        public Label Label { get; set; }
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonPropertyName("animation")]
        public object Animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => Theme.Value;
        [JsonPropertyName("responsiveTheme")]
        public object ResponsiveTheme { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
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
        GuideLineConfig[] IViewConfig.GuideLine { get; set; }
    }

    public interface IProgressViewConfig : ITinyViewConfig
    {
        [JsonPropertyName("progressStyle")]
        public GraphicStyle ProgressStyle { get; set; }
        [JsonPropertyName("percent")]
        public double? Percent { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("marker")]
        public MarkerConfig[] Marker { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("barSize")]
        public int? BarSize { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("barStyle")]
        public GraphicStyle BarStyle { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("stackField")]
        public string StackField { get; set; }
    }

    public interface ITinyViewConfig : IViewConfig
    {
        [JsonPropertyName("indicator")]
        public object Indicator { get; set; }
        [JsonPropertyName("guideLine")]
        public object GuideLine { get; set; }//FIXME:
    }

    public interface IMarkerConfig
    {
        [JsonPropertyName("view")]
        public object View { get; set; }//View
        [JsonPropertyName("canvas")]
        public object Canvas { get; set; }//Canvas
        [JsonPropertyName("progressSize")]
        public int? ProgressSize { get; set; }
        [JsonPropertyName("value")]
        public int? Value { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
    }

    public class MarkerConfig : IMarkerConfig
    {
        [JsonPropertyName("view")]
        public object View { get; set; }
        [JsonPropertyName("canvas")]
        public object Canvas { get; set; }
        [JsonPropertyName("progressSize")]
        public int? ProgressSize { get; set; }
        [JsonPropertyName("value")]
        public int? Value { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
    }
}

