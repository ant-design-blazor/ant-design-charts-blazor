using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{

    public class LineConfig : ILineViewConfig, IPlotConfig
    {
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("connectNulls")]
        public bool? ConnectNulls { get; set; }
        [JsonPropertyName("lineStyle")]
        public LineStyle LineStyle { get; set; }
        [JsonPropertyName("point")]
        public LineViewConfigPoint Point { get; set; }
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
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
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        /// <summary>
        /// bool?, Animation, object
        /// </summary>
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

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }

        /// <summary>
        /// 默认为 hv: 'hv','vh','vhv','hvh'
        /// </summary>
        [JsonPropertyName("stepType")]
        public string StepType { get; set; }
        public static string StepTypeHV = "hv";
        public static string StepTypeVH = "vh";
        public static string StepTypeVHV = "vhv";
        public static string StepTypeHVH = "hvh";
        [JsonPropertyName("isStack")]
        public bool? IsStack { get; set; }
    }

    public interface ILineViewConfig : IViewConfig
    {
        /// <summary>
        ///  分组字段 
        /// </summary>
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        /// <summary>
        ///  是否平滑 
        /// </summary>
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        /// <summary>
        ///  是否连接空数据 
        /// </summary>
        [JsonPropertyName("connectNulls")]
        public bool? ConnectNulls { get; set; }
        /// <summary>
        ///  折线extra图形样式 
        /// </summary>
        [JsonPropertyName("lineStyle")]
        public LineStyle LineStyle { get; set; }//OneOf <LineStyle, ((...args: any[]) => LineStyle)>
        /// <summary>
        /// 折线数据点图形样式
        /// </summary>
        [JsonPropertyName("point")]
        public LineViewConfigPoint Point { get; set; }
        /*
          markerPoints?: (Omit<MarkerPointCfg, 'view'> & {
            visible?: boolean;
          })[];
         */
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }//OneOf <IValueAxis, ICatAxis, ITimeAxis>
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        /*
            type LineInteraction =
              | IInteractions
              | { type: 'selected-tooltip' }
              | { type: 'slider'; cfg: ISliderInteractionConfig }
              | { type: 'scrollbar'; cfg?: IScrollbarInteractionConfig };
         */
    }

    /// <summary>
    /// 折线数据点图形样式
    /// </summary>
    public class LineViewConfigPoint
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("shape")]
        public string Shape { get; set; }//string | { fields?: []; callback: () => string };
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
    }

}


