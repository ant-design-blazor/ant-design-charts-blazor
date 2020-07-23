using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ITextStyle : IGraphicStyle
    {
        [JsonPropertyName("fontSize")]
        public int? FontSize { get; set; }
        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }
        [JsonPropertyName("fontWeight")]
        public int? FontWeight { get; set; }
        [JsonPropertyName("lineHeight")]
        public int? LineHeight { get; set; }
        [JsonPropertyName("textAlign")]
        public string TextAlign { get; set; }//OneOf <'center','left','right'>
        public static string TextAlignCenter = "center";
        public static string TextAlignLeft = "left";
        public static string TextAlignRight = "right";

        [JsonPropertyName("textBaseline")]
        public string TextBaseline { get; set; }//OneOf <'middle','top','bottom'>
        public static string TextBaselineMiddle = "middle";
        public static string TextBaselineTop = "top";
        public static string TextBaselineRight = "right";
        // [field: string]: any;
        //TODO:
    }

    public class TextStyle : ITextStyle
    {
[JsonPropertyName("fontSize")]
public int? FontSize { get; set; }
[JsonPropertyName("fontFamily")]
public string FontFamily { get; set; }
[JsonPropertyName("fontWeight")]
public int? FontWeight { get; set; }
[JsonPropertyName("lineHeight")]
public int? LineHeight { get; set; }
[JsonPropertyName("textAlign")]
public string TextAlign { get; set; }
[JsonPropertyName("textBaseline")]
public string TextBaseline { get; set; }
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
public int? Opacity { get; set; }
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


