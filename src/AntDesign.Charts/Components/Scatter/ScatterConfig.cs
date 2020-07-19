using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ScatterConfig : IScatterViewConfig, IPlotConfig
    {
        public object pointSize { get; set; }
        public GraphicStyle pointStyle { get; set; }
        public string[] colorField { get; set; }
        public ValueTimeAxis xAxis { get; set; }
        public ValueTimeAxis yAxis { get; set; }
        public QuadrantConfig quadrant { get; set; }
        public TrendlineConfig trendline { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        public string theme { get; set; }
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
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }

    public interface IScatterViewConfig : IPointViewConfig
    {
        /// <summary>
        ///  散点大小 
        /// </summary>
        public object pointSize { get; set; }//OneOf<int?, object>
    }

    public interface IPointViewConfig : IViewConfig
    {
        /// <summary>
        ///  散点样式 
        /// </summary>
        public GraphicStyle pointStyle { get; set; }//OneOf<GraphicStyle, ((...args: any) => GraphicStyle)>
        /// <summary>
        ///  颜色字段 
        /// </summary>
        public string[] colorField { get; set; }//OneOf<string, string[]>
        /// <summary>
        ///  x 轴配置 
        /// </summary>
        public ValueTimeAxis xAxis { get; set; }//OneOf<ITimeAxis, IValueAxis>
        /// <summary>
        ///  y 轴配置 
        /// </summary>
        public ValueTimeAxis yAxis { get; set; }//OneOf<ITimeAxis, IValueAxis>
        public QuadrantConfig quadrant { get; set; }
        public TrendlineConfig trendline { get; set; }
    }

    public interface IQuadrantConfig
    {
        public bool? visible { get; set; }
        public int? xBaseline { get; set; }
        public int? yBaseline { get; set; }
        public object regionStyle { get; set; }//OneOf<any[], object>
        public object lineStyle { get; set; }
        public ILabel label { get; set; }
    }

    public class QuadrantConfig : IQuadrantConfig
    {
        public bool? visible { get; set; }
        public int? xBaseline { get; set; }
        public int? yBaseline { get; set; }
        public object regionStyle { get; set; }
        public object lineStyle { get; set; }
        public ILabel label { get; set; }
    }

    public interface ITrendlineConfig
    {
        public bool? visible { get; set; }
        public string type { get; set; }
        public object style { get; set; }
        public bool? showConfidence { get; set; }
        public object confidenceStyle { get; set; }
    }

    public class TrendlineConfig : ITrendlineConfig
    {
        public bool? visible { get; set; }
        public string type { get; set; }
        public object style { get; set; }
        public bool? showConfidence { get; set; }
        public object confidenceStyle { get; set; }
    }
}
