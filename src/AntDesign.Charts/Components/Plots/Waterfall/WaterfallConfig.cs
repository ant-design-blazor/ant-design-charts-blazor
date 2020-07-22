using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class WaterfallConfig : IWaterfallViewConfig, IPlotConfig
    {
        public WaterfallViewConfigShowTotal showTotal { get; set; }
        public WaterfallViewConfigDiffLabel diffLabel { get; set; }
        public WaterfallViewConfigLeaderLine leaderLine { get; set; }
        public object color { get; set; }
        public GraphicStyle waterfallStyle { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        string[] IViewConfig.color { get; set; }
    }

    public interface IWaterfallViewConfig : IViewConfig
    {
        public WaterfallViewConfigShowTotal showTotal { get; set; }
        /// <summary>
        /// 差值label
        /// </summary>
        public WaterfallViewConfigDiffLabel diffLabel { get; set; }
        public WaterfallViewConfigLeaderLine leaderLine { get; set; }
        /// <summary>
        ///   color?:
        ///    | string
        ///    | { rising: string; falling: string; total?: string  }
        ///    | ((type: string, value: number | null, values: number | number[], index: number) => string);
        /// </summary>
        public object color { get; set; }
        public GraphicStyle waterfallStyle { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
    }

    public class WaterfallViewConfigShowTotal
    {
        public bool? visible { get; set; }
        public string label { get; set; }

    }

    /// <summary>
    /// 差值label
    /// </summary>
    public class WaterfallViewConfigDiffLabel
    {
        public bool? visible { get; set; }
        public TextStyle style { get; set; }
        public DiffLabelcfg formatter { get; set; } //DiffLabelcfg['formatter'] 
    }

    public interface IDiffLabelcfg
    {
        public object view { get; set; }
        public string[] fields { get; set; }
        //public (text: string, item: object, idx: number) => string formatter { get; set; }
        public TextStyle style { get; set; }
    }

    public class DiffLabelcfg : IDiffLabelcfg
    {
        public object view { get; set; }
        public string[] fields { get; set; }
        public TextStyle style { get; set; }
    }

    public class WaterfallViewConfigLeaderLine
    {
        public bool? visible { get; set; }
        public LineStyle style { get; set; }
    }
}