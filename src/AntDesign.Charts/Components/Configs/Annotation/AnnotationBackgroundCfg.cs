using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class AnnotationBackgroundCfg
    {
        [JsonPropertyName("style")]
        public IGraphicStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<int?, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
    }
}

