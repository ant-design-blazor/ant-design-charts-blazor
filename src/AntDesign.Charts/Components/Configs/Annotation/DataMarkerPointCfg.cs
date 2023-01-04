using System.Text.Json.Serialization;

namespace AntDesign.Charts;

public class DataMarkerPointCfg
{
    [JsonPropertyName("style")]
    public IGraphicStyle Style { get; set; }
}