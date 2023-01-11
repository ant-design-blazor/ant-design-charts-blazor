using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using OneOf;

namespace AntDesign.Charts
{
    public interface ITextStyle : IGraphicStyle
    {
        [JsonIgnore]
        public OneOf<int?, string> FontSize { get; set; }
        [JsonPropertyName("fontSize")] 
        public object FontSizeMapping => FontSize.Value;
        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }
        [JsonPropertyName("fontWeight")]
        public int? FontWeight { get; set; }
        [JsonIgnore]
        public OneOf<int?,string> LineHeight { get; set; }
        [JsonPropertyName("lineHeight")]
        public object LineHeightMapping => LineHeight.Value;
        [JsonPropertyName("textAlign")]
        public string TextAlign { get; set; }
        [JsonPropertyName("textBaseline")]
        public string TextBaseline { get; set; }
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }

        // [field: string]: any;
        //TODO:
    }

    public class TextStyle : ITextStyle
    {
        [JsonIgnore]
        public OneOf<int?, string> FontSize { get; set; }
        [JsonPropertyName("fontSize")]
        public object FontSizeMapping => FontSize.Value;
        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }
        [JsonPropertyName("fontWeight")]
        public int? FontWeight { get; set; }
        [JsonIgnore]
        public OneOf<int?, string> LineHeight { get; set; }
        [JsonPropertyName("lineHeight")]
        public object LineHeightMapping => LineHeight.Value;
        /// <summary>
        /// 'center','left','right'
        /// </summary>
        [JsonPropertyName("textAlign")]
        public string TextAlign { get; set; }
        public static string TextAlignCenter = "center";
        public static string TextAlignLeft = "left";
        public static string TextAlignRight = "right";
        /// <summary>
        /// 'middle','top','bottom'
        /// </summary>
        [JsonPropertyName("textBaseline")]
        public string TextBaseline { get; set; }
        public static string TextBaselineMiddle = "middle";
        public static string TextBaselineTop = "top";
        public static string TextBaselineRight = "right";
        public static string TextBaselineBottom = "bottom";

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
        [JsonPropertyName("radius")]
        public double? Radius { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}


