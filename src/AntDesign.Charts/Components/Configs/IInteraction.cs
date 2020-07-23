using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IInteraction
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("cfg")]
        public object Cfg { get; set; }// [field: string]: any;
    }

    public class Interaction : IInteraction
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("cfg")]
        public object Cfg { get; set; }
    }

}


