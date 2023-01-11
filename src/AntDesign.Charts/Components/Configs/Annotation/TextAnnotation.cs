using System;
using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class TextAnnotation : IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = Annotation.TypeText;
        [JsonPropertyName("style")]
        public IGraphicStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<object, object[], string[]> Position { get; set; }
        [JsonPropertyName("position")]
        public object PositionMapping => Position.Value;
        [Obsolete("X is not recommended. Use Position instead")]
        public int? X { get; set; }
        [Obsolete("Y is not recommended. Use Position instead")]
        public int? Y { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("background")]
        public AnnotationBackgroundCfg Background { get; set; }
        [JsonPropertyName("maxLength")]
        public int? MaxLength { get; set; }
        [JsonPropertyName("autoEllipsis")]
        public bool? AutoEllipsis { get; set; }
        [JsonPropertyName("ellipsisPosition")]
        public object EllipsisPosition { get; set; } //todo: AntDesign documentation lacking example
        [JsonPropertyName("isVertical")]
        public bool? IsVertical { get; set; }
    }
}