using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class RegionFilterAnnotation : IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = Annotation.TypeRegionFilter;
        [JsonIgnore]
        public OneOf<object, object[], string[]> Start { get; set; }
        [JsonPropertyName("start")]
        public object StartMapping => Start.Value;
        [JsonIgnore]
        public OneOf<object, object[], string[]> End { get; set; }
        [JsonPropertyName("end")]
        public object EndMapping => End.Value;
        [JsonPropertyName("style")]
        public IGraphicStyle Style { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("apply")]
        public string[] Apply { get; set; }
        [JsonPropertyName("top")]
        public bool? Top { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("animate")]
        public bool? Animate { get; set; }
        [JsonPropertyName("animateOption")]
        public IAnimation AnimateOption { get; set; }
    }
}