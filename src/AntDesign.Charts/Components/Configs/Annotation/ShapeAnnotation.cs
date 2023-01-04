using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class ShapeAnnotation : IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = Annotation.TypeShape;
        [JsonIgnore]
        public OneOf<object, string> Render { get; set; }//todo incomplete/missing example
        [JsonPropertyName("render")]
        public object RenderMapping => Render.Value;
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