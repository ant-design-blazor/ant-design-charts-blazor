using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class HtmlAnnotation : IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = Annotation.TypeHtml;
        [JsonIgnore]
        public OneOf<object, string> Html { get; set; } //todo incomplete/missing example
        [JsonPropertyName("htmlContent")]
        public object HtmlMapping => Html.Value;
        [JsonIgnore]
        public OneOf<object, string> Container { get; set; } //todo incomplete/missing example
        [JsonPropertyName("container")]
        public object ContainerMapping => Container.Value;
        [JsonPropertyName("alignX")]
        public string AlignX { get; set; }
        [JsonPropertyName("alignY")]
        public string AlignY { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
    }
}

