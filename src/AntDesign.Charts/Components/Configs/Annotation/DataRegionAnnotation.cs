using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts;

public class DataRegionAnnotation : IAnnotation
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = Annotation.TypeDataRegion;
    [JsonIgnore]
    public OneOf<object, object[], string[]> Position { get; set; }
    [JsonPropertyName("position")]
    public object PositionMapping => Position.Value;
    [JsonPropertyName("lineLength")]
    public int? LineLength { get; set; }
    [JsonPropertyName("region")]
    public IStateConfig Region { get; set; }
    [JsonPropertyName("text")]
    public AnnotationTextCfg Text { get; set; }
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