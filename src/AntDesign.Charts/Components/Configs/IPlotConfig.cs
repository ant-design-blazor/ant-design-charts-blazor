using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace AntDesign.Charts
{
    public interface IPlotConfig
    {
        [JsonIgnore]
        [JsonPropertyName("forceFit")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        public OneOf<string, object> Theme { get; set; }//OneOf<LooseMap, string>   LooseMap: [key: string]: T;
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
    }

}


