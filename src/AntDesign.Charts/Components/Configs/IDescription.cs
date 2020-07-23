using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IDescription
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("alignTo")]
        public string AlignTo { get; set; }//OneOf <'left','right','middle'>

        public static string AlignToLeft = "left";
        public static string AlignToMiddle = "middle";
        public static string AlignToRight = "right";

    }

    public class Description : IDescription
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("alignTo")]
        public string AlignTo { get; set; }
    }
}


