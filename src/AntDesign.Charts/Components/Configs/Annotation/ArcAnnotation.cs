using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts;

public class ArcAnnotation : IAnnotation
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = Annotation.TypeArc;
    [JsonPropertyName("style")]
    public IGraphicStyle Style { get; set; }
    [JsonIgnore]
    public OneOf<object, object[], string[]> Start { get; set; }
    [JsonPropertyName("start")]
    public object StartMapping => Start.Value;
    [JsonIgnore]
    public OneOf<object, object[], string[]> End { get; set; }
    [JsonPropertyName("end")]
    public object EndMapping => End.Value;
}