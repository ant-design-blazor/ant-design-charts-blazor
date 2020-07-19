using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class TinyColumnConfig : ITinyColumnLayerConfig, IPlotConfig
    {
        public object columnStyle { get; set; }
        public object indicator { get; set; }
        public object guideLine { get; set; }
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
        public string theme { get; set; }
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public object parent { get; set; }
        public object canvas { get; set; }
        public bool? forceFit { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        GuideLineConfig[] IViewConfig.guideLine { get; set; }
    }

    public interface ITinyColumnLayerConfig : ITinyColumnViewConfig, ILayerConfig { }

    public interface ITinyColumnViewConfig : ITinyViewConfig
    {
        public object columnStyle { get; set; }
    }

}
