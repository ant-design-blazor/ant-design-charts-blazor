using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class LiquidConfig : ILiquidViewConfig, IPlotConfig
    {
        public LiquidStatisticStyle statistic { get; set; }
        public int? liquidSize { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? value { get; set; }
        public object liquidStyle { get; set; }
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
    }

    public interface ILiquidViewConfig : IViewConfig
    {
        public LiquidStatisticStyle statistic { get; set; }
        public int? liquidSize { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? value { get; set; }
        public object liquidStyle { get; set; }//OneOf<LiquidStyle, ((...args: any[]) => LiquidStyle)>

    }

    public interface ILiquidStatisticStyle
    {
        public bool? visible { get; set; }
        public string formatter { get; set; }//(value) => string 
        public TextStyle style { get; set; }
        public bool? adjustColor { get; set; }
        public string htmlContent { get; set; }//(...args: any) => string

    }

    public class LiquidStatisticStyle : ILiquidStatisticStyle
    {
        public bool? visible { get; set; }
        public string formatter { get; set; }
        public TextStyle style { get; set; }
        public bool? adjustColor { get; set; }
        public string htmlContent { get; set; }
    }

}
