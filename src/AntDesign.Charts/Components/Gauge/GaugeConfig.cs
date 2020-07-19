using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class GaugeConfig : IGaugeLayerConfig, IPlotConfig
    {
        public int? startAngle { get; set; }
        public int? endAngle { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? value { get; set; }
        public double[] range { get; set; }
        public string[] color { get; set; }
        public int? rangeSize { get; set; }
        public GraphicStyle rangeStyle { get; set; }
        public GraphicStyle rangeBackgroundStyle { get; set; }
        public string format { get; set; }
        public GaugeAxis axis { get; set; }
        public GaugePivot pivot { get; set; }
        public GaugeStatistic statistic { get; set; }
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
        public Legend legend { get; set; }
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
    }

    public interface IGaugeLayerConfig : GaugeViewConfig, ILayerConfig { }

    public interface GaugeViewConfig : IViewConfig
    {
        public int? startAngle { get; set; }
        public int? endAngle { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? value { get; set; }
        public double[] range { get; set; }
        public string[] color { get; set; }//OneOf<string[], string>
        public int? rangeSize { get; set; }
        public GraphicStyle rangeStyle { get; set; }
        public GraphicStyle rangeBackgroundStyle { get; set; }
        public string format { get; set; }//(...args: any[]) => string
        public GaugeAxis axis { get; set; }
        public GaugePivot pivot { get; set; }
        public GaugeStatistic statistic { get; set; }
    }

    public interface IGaugeAxis
    {
        public bool? visible { get; set; }
        public int? offset { get; set; }
        public int? tickCount { get; set; }
        public GaugeAxisTickLine tickLine { get; set; }
        public GaugeAxisLabel label { get; set; }

    }

    public class GaugeAxisTickLine
    {
        public bool? visible { get; set; }
        public int? length { get; set; }
        public int? thickness { get; set; }
        public LineStyle style { get; set; }
    }

    public class GaugeAxisLabel
    {
        public bool? visible { get; set; }
        public TextStyle style { get; set; }
        public string formatter { get; set; }//() => string
    }

    public class GaugeAxis : IGaugeAxis
    {
        public bool? visible { get; set; }
        public int? offset { get; set; }
        public int? tickCount { get; set; }
        public GaugeAxisTickLine tickLine { get; set; }
        public GaugeAxisLabel label { get; set; }
    }

    public interface IGaugePivot
    {
        public bool? visible { get; set; }
        public int? thickness { get; set; }
        public GaugePivotPointer pointer { get; set; }
        public GaugePivotPin pin { get; set; }
        [JsonPropertyName("base")]
        public GaugePivotBase Base { get; set; }

    }

    public class GaugePivotPointer
    {
        public bool? visible { get; set; }
        public GraphicStyle style { get; set; }
    }

    public class GaugePivotPin
    {
        public bool? visible { get; set; }
        public int? size { get; set; }
        public GraphicStyle style { get; set; }
    }

    public class GaugePivotBase
    {
        public bool? visible { get; set; }
        public int? size { get; set; }
        public GraphicStyle style { get; set; }
    }

    public class GaugePivot : IGaugePivot
    {
        public bool? visible { get; set; }
        public int? thickness { get; set; }
        public GaugePivotPointer pointer { get; set; }
        public GaugePivotPin pin { get; set; }
        public GaugePivotBase Base { get; set; }
    }

    public interface IGaugeStatistic
    {
        public bool? visible { get; set; }
        public string[] position { get; set; }// [string, string]
        public int? size { get; set; }
        public string text { get; set; }
        public string color { get; set; }
    }

    public class GaugeStatistic : IGaugeStatistic
    {
        public bool? visible { get; set; }
        public string[] position { get; set; }
        public int? size { get; set; }
        public string text { get; set; }
        public string color { get; set; }
    }
}
