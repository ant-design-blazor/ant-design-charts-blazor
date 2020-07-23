using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{

    public class LineConfig : ILineViewConfig, IPlotConfig
    {
        public string seriesField { get; set; }
        public bool? smooth { get; set; }
        public bool? connectNulls { get; set; }
        public LineStyle lineStyle { get; set; }
        public LineViewConfigPoint point { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }
        public ValueAxis yAxis { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }//ILooseMap<Meta>
        public string padding { get; set; }//int ,string
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        /// <summary>
        ///OneOf<Animation, bool?> 
        /// </summary>
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
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
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }

    public interface ILineViewConfig : IViewConfig
    {
        /// <summary>
        ///  分组字段 
        /// </summary>
        public string seriesField { get; set; }
        /// <summary>
        ///  是否平滑 
        /// </summary>
        public bool? smooth { get; set; }
        /// <summary>
        ///  是否连接空数据 
        /// </summary>
        public bool? connectNulls { get; set; }
        /// <summary>
        ///  折线extra图形样式 
        /// </summary>
        public LineStyle lineStyle { get; set; }//OneOf<LineStyle, ((...args: any[]) => LineStyle)>
        /// <summary>
        /// 折线数据点图形样式
        /// </summary>
        public LineViewConfigPoint point { get; set; }
        /*
          markerPoints?: (Omit<MarkerPointCfg, 'view'> & {
            visible?: boolean;
          })[];
         */
        public ValueCatTimeAxis xAxis { get; set; }//OneOf<IValueAxis, ICatAxis, ITimeAxis>
        public ValueAxis yAxis { get; set; }
        public Interaction[] interactions { get; set; }
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
        public bool? visible { get; set; }
        public string shape { get; set; }//string | { fields?: []; callback: () => string };
        public int? size { get; set; }
        public string color { get; set; }
        public GraphicStyle style { get; set; }
    }

}
