using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class HeatmapConfig : IHeatmapLayerConfig, IPlotConfig
    {
        public string sizeField { get; set; }
        public string colorField { get; set; }
        public int[] shapeSize { get; set; }
        public string shapeType { get; set; }
        public GraphicStyle shapeStyle { get; set; }
        public string[] color { get; set; }
        public MatrixLegendConfig legend { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
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
        Legend IViewConfig.legend { get; set; }
    }

    public interface IHeatmapLayerConfig : IHeatmapViewConfig, ILayerConfig { }

    public interface IHeatmapViewConfig : IViewConfig
    {
        public string sizeField { get; set; }
        public string colorField { get; set; }
        public int[] shapeSize { get; set; }//number[]
        public string shapeType { get; set; }
        public GraphicStyle shapeStyle { get; set; }
        public string[] color { get; set; }
        public MatrixLegendConfig legend { get; set; }
    }

    public interface IMatrixLegendConfig
    {
        public bool? visible { get; set; }
        /// <summary>
        /// export type LegendPosition =
        ///    | 'left-top'  | 'left-center'  | 'left-bottom'  | 'right-top'  | 'right-center'  | 'right-bottom'  | 'top-left'  | 'top-center'  | 'top-right'  | 'bottom-left'  | 'bottom-center'  | 'bottom-right';
        /// </summary>
        public string position { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public MatrixLegendConfigText text { get; set; }
        public LineStyle ticklineStyle { get; set; }
        public GraphicStyle anchorStyle { get; set; }
        public string triggerOn { get; set; }
    }


    public class MatrixLegendConfigText
    {
        public TextStyle style { get; set; }
        //public () => string formatter { get; set; }
    }

    public class MatrixLegendConfig : IMatrixLegendConfig
    {
        public bool? visible { get; set; }
        public string position { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public MatrixLegendConfigText text { get; set; }
        public LineStyle ticklineStyle { get; set; }
        public GraphicStyle anchorStyle { get; set; }
        public string triggerOn { get; set; }
    }
}
