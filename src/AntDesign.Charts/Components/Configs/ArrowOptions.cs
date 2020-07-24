using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ArrowOptions
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("headSize")]
        public int? HeadSize { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }//any
    }
}


