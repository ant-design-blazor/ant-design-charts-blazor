using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ICatAxis : IBaseAxis
    {
    }

    public class CatAxis : ICatAxis
    {
        /// <summary>
        /// 'cat'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        public static string TypeCat = "cat";
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }

        /// <summary>
        ///  scale 自定义 tickMethod 
        /// </summary>
        [JsonPropertyName("tickMethod")]
        public string TickMethod { get; set; }

        [JsonPropertyName("tickMethodFunction")]
        public string TickMethodFunction { get; set; }

        [JsonPropertyName("line")]
        public BaseAxisLine Line { get; set; }
        [JsonPropertyName("grid")]
        public BaseAxisGrid Grid { get; set; }
        [JsonPropertyName("label")]
        public BaseAxisLabel Label { get; set; }
        [JsonPropertyName("title")]
        public BaseAxisTitle Title { get; set; }
        [JsonPropertyName("tickLine")]
        public BaseAxisTickLine TickLine { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
    }
}


