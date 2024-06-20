using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILineStyle
    {
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("strokeOpacity")]
        public double? StrokeOpacity { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [Obsolete("No Longer Supported, use strokeOpacity instead")]
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
        [JsonPropertyName("shadowColor")]
        public string ShadowColor { get; set; }
        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }
        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }
        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
        // [field: string]: any;
    }

    public class LineStyle : ILineStyle
    {
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("strokeOpacity")]
        public double? StrokeOpacity { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [Obsolete("No Longer Supported, use strokeOpacity instead")]
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
        [JsonPropertyName("shadowColor")]
        public string ShadowColor { get; set; }
        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }
        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }
        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}


