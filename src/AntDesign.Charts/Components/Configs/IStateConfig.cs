using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IStateConfig
    {
        //  condition: () => any | StateCondition;
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }
        [JsonPropertyName("related")]
        public string[] Related { get; set; }
    }

    public class StateConfig : IStateConfig
    {
[JsonPropertyName("style")]
public GraphicStyle Style { get; set; }
[JsonPropertyName("related")]
public string[] Related { get; set; }
    }
}


