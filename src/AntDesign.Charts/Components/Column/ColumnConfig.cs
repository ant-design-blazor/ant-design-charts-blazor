using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ColumnConfig : IColumnViewConfig, IPlotConfig
    {
        public string colorField { get; set; }
        public int? columnSize { get; set; }
        public GraphicStyle columnStyle { get; set; }
        public ICatAxis xAxis { get; set; }
        public IValueAxis yAxis { get; set; }
        public ConversionTagOptions conversionTag { get; set; }
        public ColumnViewConfigLabel label { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
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

    public interface IColumnViewConfig : IViewConfig
    {
        public string colorField { get; set; }
        /// <summary>
        ///  百分比, 数值, 最小最大宽度
        /// </summary>
        public int? columnSize { get; set; }
        public GraphicStyle columnStyle { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
        public ICatAxis xAxis { get; set; }
        public IValueAxis yAxis { get; set; }
        public ConversionTagOptions conversionTag { get; set; }
        public ColumnViewConfigLabel label { get; set; } //OneOf<IColumnLabel, IColumnAutoLabel>
        /// <summary>
        /// export type ColumnInteraction =
        ///  | { type: 'slider'; cfg: ISliderInteractionConfig }
        ///  | { type: 'scrollbar'; cfg?: IScrollbarInteractionConfig };
        /// </summary>
        public Interaction[] interactions { get; set; }
    }

    public class ColumnViewConfigLabel : IColumnLabel, IColumnAutoLabel
    {
        public string position { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? adjustColor { get; set; }
        public bool? visible { get; set; }
        public string type { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public bool? autoRotate { get; set; }
        public string field { get; set; }
        public TextStyle darkStyle { get; set; }
        public TextStyle lightStyle { get; set; }
    }

    public interface IColumnLabel : ILabel
    {
        public string position { get; set; }// OneOf<string,'top','middle','bottom'>
        public bool? adjustPosition { get; set; }
        public bool? adjustColor { get; set; }
    }

    public interface IColumnAutoLabel : ILabel
    {
        /// <summary>
        ///  column-auto 下暗色配置 
        /// </summary>
        public TextStyle darkStyle { get; set; }
        /// <summary>
        ///  column-auto 下亮色配置 
        /// </summary>
        public TextStyle lightStyle { get; set; }
    }
}
