using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IRangeBarLabelConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
                                            //  formatter?: (...args: any[]) => string;


        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
        [JsonPropertyName("leftStyle")]
        public object LeftStyle { get; set; }
        [JsonPropertyName("rightStyle")]
        public object RightStyle { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
    }

    public class RangeBarLabelConfig : IRangeBarLabelConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        /// 'outer','inner'
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        public static string PositionOuter = "outer";
        public static string PositionInner = "inner";
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }
        [JsonPropertyName("leftStyle")]
        public object LeftStyle { get; set; }
        [JsonPropertyName("rightStyle")]
        public object RightStyle { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
    }
}


