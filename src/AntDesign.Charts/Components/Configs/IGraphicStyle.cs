using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    [JsonDerivedType(typeof(TextStyle))]
    [JsonDerivedType(typeof(LegendMarkerStyle))]
    [JsonDerivedType(typeof(GraphicStyle))]
    public interface IGraphicStyle
    {
        [JsonPropertyName("fill")]
        public string Fill { get; set; }
        [JsonPropertyName("fillOpacity")]
        public decimal? FillOpacity { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
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
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        //  [field: string]: any;
    }

    public class GraphicStyle : IGraphicStyle
    {
        [JsonPropertyName("fill")]
        public string Fill { get; set; }
        [JsonPropertyName("fillOpacity")]
        public decimal? FillOpacity { get; set; }
        [JsonPropertyName("stroke")]
        public string Stroke { get; set; }
        [JsonPropertyName("lineWidth")]
        public int? LineWidth { get; set; }
        [JsonPropertyName("lineDash")]
        public int[] LineDash { get; set; }
        [JsonPropertyName("lineOpacity")]
        public int? LineOpacity { get; set; }
        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
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
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
    }
}


