using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class StackedBarConfig : IStackedBarViewConfig, IPlotConfig
    {
        public string stackField { get;set;}
        public string colorField { get;set;}
        public int? barSize { get;set;}
        public GraphicStyle barStyle { get;set;}
        public ValueAxis xAxis { get;set;}
        public CatAxis yAxis { get;set;}
        public BarViewConfigLabel label { get;set;}
        public ConversionTagOptions conversionTag { get;set;}
        public Interaction[] interactions { get;set;}
        public string renderer { get;set;}
        public object data { get;set;}
        public object meta { get; set; }//ILooseMap<Meta>
        public string padding { get;set;}
        public string xField { get;set;}
        public string yField { get;set;}
        public string[] color { get;set;}
        public Tooltip tooltip { get;set;}
        public Legend legend { get;set;}
        /// <summary>
        /// OneOf<Animation, bool?> 
        /// </summary>
        public object animation { get;set;}
        public string theme { get;set;}
        public object responsiveTheme { get;set;}
        public bool? responsive { get;set;}
        public Title title { get;set;}
        public Description description { get;set;}
        public GuideLineConfig[] guideLine { get;set;}
        public ViewConfigDefaultState defaultState { get;set;}
        public string name { get;set;}
        public bool? forceFit { get;set;}
        public int? width { get;set;}
        public int? height { get;set;}
        public int? pixelRatio { get;set;}
        public bool? localRefresh { get;set;}
        Axis IViewConfig.xAxis { get;set;}
        Axis IViewConfig.yAxis { get;set;}
        Label IViewConfig.label { get;set;}
    }
}
