using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    using IPercentStackedAreaViewConfig = IStackedAreaViewConfig;

    public class PercentStackedAreaConfig : IPercentStackedAreaLayerConfig, IPlotConfig
    {
        public string stackField { get; set; }
        public StackedAreaLabel label { get; set; }
        public GraphicStyle areaStyle { get; set; }
        public string seriesField { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }
        public ValueAxis yAxis { get; set; }
        public AreaViewConfigLine line { get; set; }
        public AreaViewConfigPoint point { get; set; }
        public bool? smooth { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        /// <summary>
        /// ILooseMap<Meta>
        /// </summary>
        public object meta { get; set; }//ILooseMap<Meta>
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
        AreaLabel IAreaViewConfig.label { get; set; }
        Label IViewConfig.label { get; set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }


    public interface IPercentStackedAreaLayerConfig : IPercentStackedAreaViewConfig, ILayerConfig { }


    public interface IStackedAreaViewConfig : IAreaViewConfig
    {
        public string stackField { get; set; }
        public StackedAreaLabel label { get; set; }

    }

    public interface IStackedAreaLabel : IAreaTypeLabel, ILineTypeLabel, IAreaLabel
    {

    }

    public interface IAreaTypeLabel : ILabel
    {
        public string type { get; set; }// 'area'
        public bool? autoScale { get; set; }
    }

    public interface ILineTypeLabel : ILabel
    {
        public string type { get; set; }// 'line'
    }

    public class StackedAreaLabel : IStackedAreaLabel
    {
        public string type { get; set; }
        public bool? autoScale { get; set; }
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
