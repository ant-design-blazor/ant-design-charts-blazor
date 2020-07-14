using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BarConfig : IBarViewConfig, IPlotConfig
    {
        public string colorField { get; set; }
        public int? barSize { get; set; }
        public IGraphicStyle barStyle { get; set; }
        public ValueAxis xAxis { get; set; }
        public CatAxis yAxis { get; set; }
        public BarViewConfigLabel label { get; set; }
        public ConversionTagOptions conversionTag { get; set; }
        public IInteractions[] interactions { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public string renderer { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public string theme { get; set; }
        public bool? localRefresh { get; set; }
        public IDataItem[] data { get;set; }
        public ILooseMap<Meta> meta { get;set; }
        public int? padding { get;set; }
        public string xField { get;set; }
        public string yField { get;set; }
        public string color { get;set; }
        public Tooltip tooltip { get;set; }
        public Legend legend { get;set; }
        public bool? animation { get;set; }
        public object responsiveTheme { get;set; }
        public bool? responsive { get;set; }
        public Title title { get;set; }
        public Description description { get;set; }
        public GuideLineConfig[] guideLine { get;set; }
        public ViewConfigDefaultState defaultState { get;set; }
        public string name { get;set; }
        Axis IViewConfig.xAxis { get;set; }
        Axis IViewConfig.yAxis { get;set; }
        Label IViewConfig.label { get;set; }
    }


}
