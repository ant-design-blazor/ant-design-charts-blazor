using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class PieConfig : IPieViewConfig, IPlotConfig
    {
        public string angleField { get; set; }
        public string colorField { get; set; }
        public double? radius { get; set; }
        public GraphicStyle pieStyle { get; set; }
        public PieLabelConfig label { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
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
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        Label IViewConfig.label { get; set; }
    }

    public interface IPieViewConfig : IViewConfig
    {
        public string angleField { get; set; }
        public string colorField { get; set; }
        public double? radius { get; set; }
        public GraphicStyle pieStyle { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
        public PieLabelConfig label { get; set; }
    }

    public interface IPieLabelConfig : ILabel
    {
        public bool? visible { get; set; }
        public object formatter { get; set; }//OneOf<(text: string, int?, undefined,null, item: any, idx: number, ...extras: any[]) => string>
        /// <summary>
        ///  whether 
        /// </summary>
        public bool? adjustPosition { get; set; }
        /// <summary>
        ///  allow label overlap 
        /// </summary>
        public bool? allowOverlap { get; set; }
        public bool? autoRotate { get; set; }
        public int? labelHeight { get; set; }
        public int? offset { get; set; }//OneOf<int?, string>
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public PieLabelConfigLine line { get; set; }
        public TextStyle style { get; set; }
    }

    public interface PieLabelConfigLine
    {
        public bool? visible { get; set; }
        public bool? smooth { get; set; }
        public string stroke { get; set; }
        public int? lineWidth { get; set; }
    }

    public class PieLabelConfig : IPieLabelConfig
    {
        public bool? visible { get; set; }
        public object formatter { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? allowOverlap { get; set; }
        public bool? autoRotate { get; set; }
        public int? labelHeight { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public PieLabelConfigLine line { get; set; }
        public TextStyle style { get; set; }
        public string type { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public string position { get; set; }
        public bool? adjustColor { get; set; }
        public string field { get; set; }
    }

}
