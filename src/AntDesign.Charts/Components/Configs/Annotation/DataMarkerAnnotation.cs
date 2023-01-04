using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class DataMarkerAnnotation : IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = Annotation.TypeDataMarker;
        [JsonIgnore]
        public OneOf<object, object[], string[]> Position { get; set; }
        [JsonPropertyName("position")]
        public object PositionMapping => Position.Value;
        [JsonPropertyName("point")]
        public DataMarkerPointCfg Point { get; set; }
        [JsonPropertyName("line")]
        public DataMarkerLineCfg Line { get; set; }
        [JsonPropertyName("text")]
        public AnnotationTextCfg Text { get; set; }
        [JsonPropertyName("autoAdjust")]
        public bool? AutoAdjust { get; set; }
        [JsonPropertyName("direction")]
        public string Direction { get; set; } //todo need checking, incomplete antdesign documentation
    }
}

