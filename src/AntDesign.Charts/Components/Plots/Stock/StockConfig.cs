using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using AntDesign;

namespace AntDesign.Charts
{
    public class StockConfig : IStockViewConfig, IPlotConfig
    {
        [JsonPropertyName("total")]
        public StockViewConfigShowTotal ShowTotal { get; set; }
        [JsonPropertyName("leaderLine")]
        public StockViewConfigLeaderLine LeaderLine { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("stockStyle")]
        public GraphicStyle StockStyle { get; set; }
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
        public string[] YField { get; set; }
        string IViewConfig.YField { get => string.Join(",", YField); set { } }
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
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
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

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("labelMode")]
        public string LabelMode { get; set; }
        [JsonPropertyName("risingFill")]
        public string RisingFill { get; set; }
        [JsonPropertyName("fallingFill")]
        public string FallingFill { get; set; }
        [JsonPropertyName("columnWidthRatio")]
        public double ColumnWidthRatio { get; set; }
        [JsonPropertyName("slider")]
        public object Slider { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
    }
    public interface IStockViewConfig : IViewConfig
    {

        [JsonPropertyName("yField")]
        public new string[] YField { get; set; }
        [JsonPropertyName("labelMode")]
        public string LabelMode { get; set; }

        [JsonPropertyName("total")]
        public StockViewConfigShowTotal ShowTotal { get; set; }

        [JsonPropertyName("leaderLine")]
        public StockViewConfigLeaderLine LeaderLine { get; set; }
        /// <summary>
        /// 上涨色
        /// </summary>
        [JsonPropertyName("risingFill")]
        public string RisingFill { get; set; }
        /// <summary>
        /// 下跌色
        /// </summary>
        [JsonPropertyName("fallingFill")]
        public string FallingFill { get; set; }
        [JsonPropertyName("stockStyle")]
        public GraphicStyle StockStyle { get; set; }//OneOf <GraphicStyle, ((...args: any[]) => GraphicStyle)>
        /// <summary>
        /// 柱状图宽度占比
        /// 范围0-1
        /// </summary>
        [JsonPropertyName("columnWidthRatio")]
        public double ColumnWidthRatio { get; set; }

        [JsonPropertyName("slider")]
        public object Slider { get; set; }
    }

    public class StockViewConfigShowTotal
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
    }

    /// <summary>
    /// 差值label
    /// </summary>
    public class StockViewConfigDiffLabel
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("formatter")]
        public StockDiffLabelcfg Formatter { get; set; } //DiffLabelcfg['formatter']
    }

    public interface IStockDiffLabelcfg
    {
        [JsonPropertyName("view")]
        public object View { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        //public (text: string, item: object, idx: number) => string formatter { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class StockDiffLabelcfg : IStockDiffLabelcfg
    {
        [JsonPropertyName("view")]
        public object View { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class StockViewConfigLeaderLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }
}


