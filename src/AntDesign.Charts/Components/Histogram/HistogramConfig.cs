using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class HistogramConfig : IHistogramViewConfig, IPlotConfig
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
        public string binField { get;set; }
        public int? binWidth { get;set; }
        public int? binNumber { get;set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
        Label IViewConfig.label { get; set; }
    }

    public interface IHistogramViewConfig : IColumnViewConfig
    {
        public string binField { get; set; }
        public int? binWidth { get; set; }
        public int? binNumber { get; set; }
    }
}
