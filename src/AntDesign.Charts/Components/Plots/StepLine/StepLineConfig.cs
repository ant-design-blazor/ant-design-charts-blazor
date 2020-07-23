using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class StepLineConfig : IStepLineViewConfig, IPlotConfig
    {
        public string step { get; set; }
        public string seriesField { get; set; }
        public bool? smooth { get; set; }
        public bool? connectNulls { get; set; }
        public LineStyle lineStyle { get; set; }
        public LineViewConfigPoint point { get; set; }
        public ValueCatTimeAxis xAxis { get; set; }
        public ValueAxis yAxis { get; set; }
        public Interaction[] interactions { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }//ILooseMap<Meta>
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
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
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
    }

    public interface IStepLineViewConfig : ILineViewConfig
    {
        /// <summary>
        /// 默认为 hv: 'hv','vh','vhv','hvh'
        /// </summary>
        public string step { get; set; }//OneOf <'hv','vh','vhv','hvh'>
        public static string StepHv = "hv";
        public static string StepVh = "vh";
        public static string StepVhv = "vhv";
        public static string StepHvh = "hvh";

    }
}
