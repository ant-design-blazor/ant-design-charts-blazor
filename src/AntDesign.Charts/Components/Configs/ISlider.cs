using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public interface ISlider
    {
        [JsonPropertyName("start")]
        public double? Start { get; set; }
        [JsonPropertyName("end")]
        public double? End { get; set; }
        [JsonPropertyName("height")]
        public double? Height { get; set; }
        [JsonPropertyName("trendCfg")]
        public TrendCfg TrendCfg { get; set; }
        [JsonPropertyName("backgroundStyle")]
        public IGraphicStyle BackgroundStyle { get; set; }
        [JsonPropertyName("foregroundStyle")]
        public IGraphicStyle ForegroundStyle { get; set; }
        [JsonPropertyName("handlerStyle")]
        public HandlerStyle HandlerStyle { get; set; }
        [JsonPropertyName("textStyle")]
        public IGraphicStyle TextStyle { get; set; }
        [JsonPropertyName("minLimit")]
        public double? MinLimit { get; set; }
        [JsonPropertyName("maxLimit")]
        public double? MaxLimit { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
    }

    public class Slider : ISlider
    {
        [JsonPropertyName("start")]
        public double? Start { get; set; }
        [JsonPropertyName("end")]
        public double? End { get; set; }
        [JsonPropertyName("height")]
        public double? Height { get; set; }
        [JsonPropertyName("trendCfg")]
        public TrendCfg TrendCfg { get; set; }
        [JsonPropertyName("backgroundStyle")]
        public IGraphicStyle BackgroundStyle { get; set; }
        [JsonPropertyName("foregroundStyle")]
        public IGraphicStyle ForegroundStyle { get; set; }
        [JsonPropertyName("handlerStyle")]
        public HandlerStyle HandlerStyle { get; set; }
        [JsonPropertyName("textStyle")]
        public IGraphicStyle TextStyle { get; set; }
        [JsonPropertyName("minLimit")]
        public double? MinLimit { get; set; }
        [JsonPropertyName("maxLimit")]
        public double? MaxLimit { get; set; }
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }
    }

    public class TrendCfg
    {
        [JsonIgnore]
        public OneOf<double[],object> Data { get; set; }
        [JsonPropertyName("data")]
        public object DataMapping => Data.Value;
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("isArea")]
        public bool? IsArea { get; set; }
        [JsonPropertyName("backgroundStyle")]
        public IGraphicStyle BackgroundStyle { get; set; }
        [JsonPropertyName("lineStyle")]
        public IGraphicStyle LineStyle { get; set; }
        [JsonPropertyName("areaStyle")]
        public IGraphicStyle AreaStyle { get; set; }
    }

    public class HandlerStyle
    {
        [JsonPropertyName("width")]
        public double? Width { get; set; }
        [JsonPropertyName("height")]
        public double? Height { get; set; }
        [JsonPropertyName("fill")]
        public string Fill { get; set; }
        [JsonPropertyName("highLightFill")]
        public string HighLightFill { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}
