using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class DensityHeatmapConfig : IDensityHeatmapViewConfig, IPlotConfig
    {
        public string colorField { get; set; }
        public int? radius { get; set; }
        public int? intensity { get; set; }
        public DensityHeatmapViewConfigPoint point { get; set; }
        public HeatmapLegendConfig legend { get; set; }
        public HeatmapBackgroundConfig background { get; set; }
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
        Legend IViewConfig.legend { get; set; }
    }

    public interface IDensityHeatmapViewConfig : IViewConfig
    {
        public string colorField { get; set; }
        public int? radius { get; set; }
        public int? intensity { get; set; }
        public DensityHeatmapViewConfigPoint point { get; set; }
        public HeatmapLegendConfig legend { get; set; }
        public HeatmapBackgroundConfig background { get; set; }

    }

    public class DensityHeatmapViewConfigPoint
    {
        public bool? visible { get; set; }
        public string shape { get; set; }
        public int? size { get; set; }
        public string color { get; set; }
        public GraphicStyle style { get; set; }
    }

    public interface IHeatmapLegendConfig
    {
        public bool? visible { get; set; }
        /// <summary>
        /// export type LegendPosition =
        ///  | 'left-top'  | 'left-center'  | 'left-bottom'  | 'right-top'  | 'right-center'  | 'right-bottom'  | 'top-left'  | 'top-center'  | 'top-right'  | 'bottom-left'  | 'bottom-center'  | 'bottom-right';
        /// </summary>
        public string position { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public HeatmapLegendConfigText text { get; set; }
        public object gridlineStyle { get; set; }
        public string triggerOn { get; set; }
    }

    public interface HeatmapLegendConfigText
    {
        public object style { get; set; }
        //public () => string formatter { get; set; }
    }

    public class HeatmapLegendConfig : IHeatmapLegendConfig
    {
        public bool? visible { get; set; }
        public string position { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public HeatmapLegendConfigText text { get; set; }
        public object gridlineStyle { get; set; }
        public string triggerOn { get; set; }
    }

    public interface IHeatmapBackgroundConfig
    {
        public bool? visible { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string src { get; set; }
        //public Function callback { get; set; }
    }

    public class HeatmapBackgroundConfig : IHeatmapBackgroundConfig
    {
        public bool? visible { get; set; }
        public string type { get; set; }
        public object value { get; set; }
        public string src { get; set; }
    }
}
