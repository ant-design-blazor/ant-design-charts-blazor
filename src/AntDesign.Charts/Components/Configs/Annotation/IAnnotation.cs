using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    [JsonDerivedType(typeof(Annotation))]
    [JsonDerivedType(typeof(TextAnnotation))]
    [JsonDerivedType(typeof(LineAnnotation))]
    [JsonDerivedType(typeof(ArcAnnotation))]
    [JsonDerivedType(typeof(ImageAnnotation))]
    [JsonDerivedType(typeof(RegionAnnotation))]
    [JsonDerivedType(typeof(DataMarkerAnnotation))]
    [JsonDerivedType(typeof(DataRegionAnnotation))]
    [JsonDerivedType(typeof(RegionFilterAnnotation))]
    [JsonDerivedType(typeof(HtmlAnnotation))]
    [JsonDerivedType(typeof(ShapeAnnotation))]
    public interface IAnnotation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
