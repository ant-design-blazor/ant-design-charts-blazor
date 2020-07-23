using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class RadarConfig : IRadarViewConfig, IPlotConfig
    {
        public string angleField { get; set; }
        public string radiusField { get; set; }
        public string seriesField { get; set; }
        public bool? smooth { get; set; }
        public RadarViewConfigLine line { get; set; }
        public RadarViewConfigPoint point { get; set; }
        public RadarViewConfigArea area { get; set; }
        public CatAxis angleAxis { get; set; }
        public ValueAxis radiusAxis { get; set; }
        public int? radius { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
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
    }

    public interface IRadarViewConfig : IViewConfig
    {
        /// <summary>
        ///  角度字段 
        /// </summary>
        public string angleField { get; set; }
        /// <summary>
        ///  径向字段 
        /// </summary>
        public string radiusField { get; set; }
        /// <summary>
        ///  分组字段 
        /// </summary>
        public string seriesField { get; set; }
        /// <summary>
        ///  是否平滑 
        /// </summary>
        public bool? smooth { get; set; }
        /// <summary>
        /// 折线图形样式
        /// </summary>
        public RadarViewConfigLine line { get; set; }
        /// <summary>
        /// 数据点图形样式
        /// </summary>
        public RadarViewConfigPoint point { get; set; }
        /// <summary>
        /// area图形样式
        /// </summary>
        public RadarViewConfigArea area { get; set; }
        /// <summary>
        ///  角度轴配置 
        /// </summary>
        public CatAxis angleAxis { get; set; }
        /// <summary>
        ///  径向轴配置 
        /// </summary>
        public ValueAxis radiusAxis { get; set; }
        /// <summary>
        ///  雷达图半径 
        /// </summary>
        public int? radius { get; set; }
    }

    public class RadarViewConfigLine
    {
        public bool? visible { get; set; }
        public int? size { get; set; }
        public string color { get; set; }
        public LineStyle style { get; set; }//OneOf<LineStyle, ((...args: any[]) => LineStyle)>
    }

    public class RadarViewConfigPoint
    {
        public bool? visible { get; set; }
        public string shape { get; set; }
        public int? size { get; set; }
        public string color { get; set; }
        public GraphicStyle style { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
    }

    public class RadarViewConfigArea
    {
        public bool? visible { get; set; }
        public GraphicStyle style { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>

    }
}
