using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class AreaConfig : IAreaViewConfig, IPlotConfig
    {
        public GraphicStyle areaStyle { get; set; }
        public string seriesField { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }
        public ValueAxis yAxis { get; set; }
        public AreaViewConfigLine line { get; set; }
        public AreaViewConfigPoint point { get; set; }
        public bool? smooth { get; set; }
        public Interaction[] interactions { get; set; }
        public AreaLabel label { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object  meta { get; set; }//ILooseMap<Meta>
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        public string theme { get; set; }
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
        Label IViewConfig.label { get; set; }
    }

    public interface IAreaViewConfig : IViewConfig
    {
        public GraphicStyle areaStyle { get; set; }//OneOf<GraphicStyle, ((...args: any) => GraphicStyle)>
        public string seriesField { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }//OneOf<ICatAxis, ITimeAxis, IValueAxis>
        public ValueAxis yAxis { get; set; }
        public AreaViewConfigLine line { get; set; }
        public AreaViewConfigPoint point { get; set; }
        public bool? smooth { get; set; }
        /// <summary>
        /// export type AreaInteraction =
        ///  | { type: 'slider'; cfg: ISliderInteractionConfig }
        ///  | { type: 'scrollbar'; cfg?: IScrollbarInteractionConfig };
        /// </summary>
        public Interaction[] interactions { get; set; }

        public AreaLabel label { get; set; }

    }

    public class AreaViewConfigLine
    {
        public bool? visible { get; set; }
        public string color { get; set; }
        public int? size { get; set; }
        public LineStyle style { get; set; }
    }

    public class AreaViewConfigPoint
    {
        public bool? visible { get; set; }
        public string color { get; set; }
        public int? size { get; set; }
        public string shape { get; set; }
        public GraphicStyle style { get; set; }
    }

    public interface IAreaLabel : IAreaPointLabel, IAreaPointAutoLabel, ILabel
    {
    }

    public interface IAreaPointLabel : ILabel
    {
        public string type { get; set; }//'area-point'
    }

    public interface IAreaPointAutoLabel : ILabel
    {
        public string type { get; set; }//'area-point-auto'
        /// <summary>
        ///  area-point-auto 暗色配置 
        /// </summary>
        public TextStyle darkStyle { get; set; }
        /// <summary>
        ///  area-point-auto 亮色配置 
        /// </summary>
        public TextStyle lightStyle { get; set; }
    }

    public class AreaLabel : IAreaLabel
    {
        public string type { get; set; }
        public TextStyle darkStyle { get; set; }
        public TextStyle lightStyle { get; set; }
        public bool? visible { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public string position { get; set; }
        public bool? adjustColor { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? autoRotate { get; set; }
        public string field { get; set; }
    }

}
