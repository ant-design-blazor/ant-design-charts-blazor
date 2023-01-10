using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IScrollbar
    {
        /// <summary>
        /// 'horizontal', 'vertical'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonPropertyName("categorySize")]
        public int? CategorySize { get; set; }
        [JsonPropertyName("style")]
        public bool? Animate { get; set; }
        [JsonPropertyName("animate")]
        public ScrollbarStyle Style { get; set; }
    }

    public class Scrollbar : IScrollbar
    {
        /// <summary>
        /// 'horizontal', 'vertical'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height{ get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonPropertyName("categorySize")]
        public int? CategorySize { get; set; }
        [JsonPropertyName("style")]
        public bool? Animate { get; set; }
        [JsonPropertyName("animate")]
        public ScrollbarStyle Style { get; set; }
    }

    public class ScrollbarStyle
    {
        [JsonPropertyName("trackColor")]
        public string TrackColor { get; set; }
        [JsonPropertyName("thumbColor")]
        public string ThumbColor { get; set; }
        [JsonPropertyName("thumbHighlightColor")]
        public string ThumbHighlightColor { get; set; }
        [JsonPropertyName("lineCap")]
        public string LineCap { get; set; }
    }
}
