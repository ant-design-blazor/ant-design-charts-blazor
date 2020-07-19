using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class DonutConfig : IDonutViewConfig, IPlotConfig
    {
        public double? innerRadius { get; set; }
        public DonutViewConfigStatistic statistic { get; set; }
        public string angleField { get; set; }
        public string colorField { get; set; }
        public double? radius { get; set; }
        public GraphicStyle pieStyle { get; set; }
        public PieLabelConfig label { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
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
        Label IViewConfig.label { get; set; }
    }

    public interface IDonutViewConfig : IPieViewConfig
    {
        public double? innerRadius { get; set; }

        public DonutViewConfigStatistic statistic { get; set; }
    }

    public class DonutViewConfigStatistic
    {
        public bool? visible { get; set; }
        /// <summary>
        ///  指标卡 总计值 标签 
        /// </summary>
        public string totalLabel { get; set; }
        /// <summary>
        ///  触发显示的事件 
        /// </summary>
        public string triggerOn { get; set; }// 'mouseenter'
        /// <summary>
        ///  触发隐藏的事件 
        /// </summary>
        public string triggerOff { get; set; }//'mouseleave'
        public object content { get; set; }//OneOf<string, DonutStatisticContent>
        public string htmlContent { get; set; }//(...args: any) => string
    }
}
