using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IConversionTagOptions
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("spacing")]
        public int? Spacing { get; set; }
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        [JsonPropertyName("arrow")]
        public ArrowOptions Arrow { get; set; }
        [JsonPropertyName("value")]
        public ValueOptions Value { get; set; }
        [JsonPropertyName("animation")]
        public object Animation { get; set; }//any
        [JsonPropertyName("transpose")]
        public bool? Transpose { get; set; }
    }

    public class ConversionTagOptions : IConversionTagOptions
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("spacing")]
        public int? Spacing { get; set; }
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        [JsonPropertyName("arrow")]
        public ArrowOptions Arrow { get; set; }
        [JsonPropertyName("value")]
        public ValueOptions Value { get; set; }
        [JsonPropertyName("animation")]
        public object Animation { get; set; }
        [JsonPropertyName("transpose")]
        public bool? Transpose { get; set; }
    }
}


