using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class DataMarkerLineCfg
    {
        [JsonPropertyName("style")]
        public IGraphicStyle Style { get; set; }
        [JsonPropertyName("length")]
        public int? Length { get; set; }
    }
}

