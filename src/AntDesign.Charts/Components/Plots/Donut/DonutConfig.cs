using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class DonutConfig : IDonutViewConfig, IPlotConfig
    {
        [JsonPropertyName("innerRadius")]
        public double? InnerRadius { get; set; }
        [JsonPropertyName("statistic")]
        public DonutViewConfigStatistic Statistic { get; set; }
        [JsonPropertyName("angleField")]
        public string AngleField { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("pieStyle")]
        public GraphicStyle PieStyle { get; set; }
        [JsonPropertyName("label")]
        public PieLabelConfig Label { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string YField { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonIgnore]
        public OneOf<bool?, Animation, object> Animation { get; set; }
        [JsonPropertyName("animation")]
        public object AnimationMapping => Animation.Value;
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonIgnore]
        public OneOf<string, object> ResponsiveTheme { get; set; }
        [JsonPropertyName("responsiveTheme")]
        public object ResponsiveThemeMapping => ResponsiveTheme.Value;
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("forceFit")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
        OneOf<Label, object> IViewConfig.Label { get; set; }
    }

    public interface IDonutViewConfig : IPieViewConfig
    {
        [JsonPropertyName("innerRadius")]
        public double? InnerRadius { get; set; }

        [JsonPropertyName("statistic")]
        public DonutViewConfigStatistic Statistic { get; set; }
    }

    public class DonutViewConfigStatistic
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        ///  指标卡 总计值 标签 
        /// </summary>
        [JsonPropertyName("totalLabel")]
        public string TotalLabel { get; set; }
        /// <summary>
        ///  触发显示的事件 
        /// </summary>
        [JsonPropertyName("triggerOn")]
        public string TriggerOn { get; set; }// 'mouseenter'
        /// <summary>
        ///  触发隐藏的事件 
        /// </summary>
        [JsonPropertyName("triggerOff")]
        public string TriggerOff { get; set; }//'mouseleave'
        [JsonPropertyName("content")]
        public OneOf<string, DonutStatisticContent> Content { get; set; }
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }//(...args: any) => string
    }

    public interface IDonutStatisticContent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class DonutStatisticContent : IDonutStatisticContent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}


