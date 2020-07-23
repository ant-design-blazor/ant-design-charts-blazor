using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class DensityHeatmapConfig : IDensityHeatmapViewConfig, IPlotConfig
    {
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("radius")]
        public int? Radius { get; set; }
        [JsonPropertyName("intensity")]
        public int? Intensity { get; set; }
        [JsonPropertyName("point")]
        public DensityHeatmapViewConfigPoint Point { get; set; }
        [JsonPropertyName("legend")]
        public HeatmapLegendConfig Legend { get; set; }
        [JsonPropertyName("background")]
        public HeatmapBackgroundConfig Background { get; set; }
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
        [JsonPropertyName("animation")]
        public object Animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
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
        Legend IViewConfig.Legend { get; set; }
    }

    public interface IDensityHeatmapViewConfig : IViewConfig
    {
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("radius")]
        public int? Radius { get; set; }
        [JsonPropertyName("intensity")]
        public int? Intensity { get; set; }
        [JsonPropertyName("point")]
        public DensityHeatmapViewConfigPoint Point { get; set; }
        [JsonPropertyName("legend")]
        public HeatmapLegendConfig Legend { get; set; }
        [JsonPropertyName("background")]
        public HeatmapBackgroundConfig Background { get; set; }

    }

    public class DensityHeatmapViewConfigPoint
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("shape")]
        public string Shape { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

    public interface IHeatmapLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        /// export type LegendPosition =
        ///  | 'left-top'  | 'left-center'  | 'left-bottom'  | 'right-top'  | 'right-center'  | 'right-bottom'  | 'top-left'  | 'top-center'  | 'top-right'  | 'bottom-left'  | 'bottom-center'  | 'bottom-right';
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("text")]
        public HeatmapLegendConfigText Text { get; set; }
        [JsonPropertyName("gridlineStyle")]
        public object GridlineStyle { get; set; }
        [JsonPropertyName("triggerOn")]
        public string TriggerOn { get; set; }
    }

    public interface HeatmapLegendConfigText
    {
        [JsonPropertyName("style")]
        public object Style { get; set; }
        //public () => string formatter { get; set; }
    }

    public class HeatmapLegendConfig : IHeatmapLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("text")]
        public HeatmapLegendConfigText Text { get; set; }
        [JsonPropertyName("gridlineStyle")]
        public object GridlineStyle { get; set; }
        [JsonPropertyName("triggerOn")]
        public string TriggerOn { get; set; }
    }

    public interface IHeatmapBackgroundConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public object Value { get; set; }
        [JsonPropertyName("src")]
        public string Src { get; set; }
        //public Function callback { get; set; }
    }

    public class HeatmapBackgroundConfig : IHeatmapBackgroundConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public object Value { get; set; }
        [JsonPropertyName("src")]
        public string Src { get; set; }
    }
}


