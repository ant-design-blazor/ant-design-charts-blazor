using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using OneOf;

namespace AntDesign.Charts
{
    public interface IBarAutoLabel : ILabel
    {
        /// <summary>
        ///  column-auto 下暗色配置 
        /// </summary>
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        /// <summary>
        ///  column-auto 下亮色配置 
        /// </summary>
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
    }

    public class BarAutoLabel : IBarAutoLabel
    {
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("precision")]
        public int? Precision { get; set; }
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("field")]
        public string Field { get; set; }
    }
}


