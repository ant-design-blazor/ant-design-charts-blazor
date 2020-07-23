using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class LiquidConfig : ILiquidViewConfig, IPlotConfig
    {
        [JsonPropertyName("statistic")]
        public LiquidStatisticStyle Statistic { get; set; }
        [JsonPropertyName("liquidSize")]
        public int? LiquidSize { get; set; }
        [JsonPropertyName("min")]
        public int? Min { get; set; }
        [JsonPropertyName("max")]
        public int? Max { get; set; }
        [JsonPropertyName("value")]
        public int? Value { get; set; }
        [JsonPropertyName("liquidStyle")]
        public object LiquidStyle { get; set; }
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
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
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
    }

    public interface ILiquidViewConfig : IViewConfig
    {
        [JsonPropertyName("statistic")]
        public LiquidStatisticStyle Statistic { get; set; }
        [JsonPropertyName("liquidSize")]
        public int? LiquidSize { get; set; }
        [JsonPropertyName("min")]
        public int? Min { get; set; }
        [JsonPropertyName("max")]
        public int? Max { get; set; }
        [JsonPropertyName("value")]
        public int? Value { get; set; }
        [JsonPropertyName("liquidStyle")]
        public object LiquidStyle { get; set; }//OneOf<LiquidStyle, ((...args: any[]) => LiquidStyle)>

    }

    public interface ILiquidStatisticStyle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }//(value) => string
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }//(...args: any) => string

    }

    public class LiquidStatisticStyle : ILiquidStatisticStyle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }
    }

}


