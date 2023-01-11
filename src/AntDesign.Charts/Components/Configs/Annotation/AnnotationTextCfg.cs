using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class AnnotationTextCfg
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public IGraphicStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<object, object[], string[]> Position { get; set; }
        [JsonPropertyName("position")]
        public object PositionMapping => Position.Value;
    }
}

