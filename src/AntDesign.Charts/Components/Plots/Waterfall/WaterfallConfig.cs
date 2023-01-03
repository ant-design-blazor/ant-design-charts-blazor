using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class WaterfallConfig : IWaterfallViewConfig, IPlotConfig
    {
        [JsonPropertyName("showTotal")]
        public WaterfallViewConfigShowTotal ShowTotal { get; set; }
        [JsonPropertyName("diffLabel")]
        public WaterfallViewConfigDiffLabel DiffLabel { get; set; }
        [JsonPropertyName("leaderLine")]
        public WaterfallViewConfigLeaderLine LeaderLine { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("waterfallStyle")]
        public GraphicStyle WaterfallStyle { get; set; }
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
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
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

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
    }

    public interface IWaterfallViewConfig : IViewConfig
    {
        [JsonPropertyName("showTotal")]
        public WaterfallViewConfigShowTotal ShowTotal { get; set; }
        /// <summary>
        /// 差值label
        /// </summary>
        [JsonPropertyName("diffLabel")]
        public WaterfallViewConfigDiffLabel DiffLabel { get; set; }
        [JsonPropertyName("leaderLine")]
        public WaterfallViewConfigLeaderLine LeaderLine { get; set; }
        /// <summary>
        ///   color?:
        ///    | string
        ///    | { rising: string; falling: string; total?: string  }
        ///    | ((type: string, value: number | null, values: number | number[], index: number) => string);
        /// </summary>
        [JsonPropertyName("color")]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("waterfallStyle")]
        public GraphicStyle WaterfallStyle { get; set; }//OneOf <GraphicStyle, ((...args: any[]) => GraphicStyle)>
    }

    public class WaterfallViewConfigShowTotal
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }

    }

    /// <summary>
    /// 差值label
    /// </summary>
    public class WaterfallViewConfigDiffLabel
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("formatter")]
        public DiffLabelcfg Formatter { get; set; } //DiffLabelcfg['formatter']
    }

    public interface IDiffLabelcfg
    {
        [JsonPropertyName("view")]
        public object View { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        //public (text: string, item: object, idx: number) => string formatter { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class DiffLabelcfg : IDiffLabelcfg
    {
        [JsonPropertyName("view")]
        public object View { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class WaterfallViewConfigLeaderLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }
}

