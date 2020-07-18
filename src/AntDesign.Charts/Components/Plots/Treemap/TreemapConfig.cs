using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class TreemapConfig : ITreemapViewConfig, IPlotConfig
    {
        public object data { get; set; }
        public int? maxLevel { get; set; }
        public string colorField { get; set; }
        public string[] colors { get; set; }
        public GraphicStyle rectStyle { get; set; }
        public TreemapLabelConfig label { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
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

    public interface ITreemapViewConfig : IViewConfig
    {
        public object data { get; set; }
        public int? maxLevel { get; set; }
        public string colorField { get; set; }
        public string[] colors { get; set; }
        public GraphicStyle rectStyle { get; set; }
        public TreemapLabelConfig label { get; set; }
        public Interaction[] interactions { get; set; }//TreemapInteraction
    }

    public interface ITreemapLabelConfig
    {
        public bool? visible { get; set; }
        public string formatter { get; set; }// (...args: any[]) => string
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public object style { get; set; }
    }

    public class TreemapLabelConfig : ITreemapLabelConfig
    {
        public bool? visible { get; set; }
        public string formatter { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public object style { get; set; }
    }

}
