using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IValueAxis : IBaseAxis
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///  tick相关配置 
        /// </summary>
        [JsonPropertyName("nice")]
        public bool? Nice { get; set; }
        [JsonPropertyName("min")]
        public double? Min { get; set; }
        [JsonPropertyName("max")]
        public double? Max { get; set; }
        [JsonPropertyName("minLimit")]
        public int? MinLimit { get; set; }
        [JsonPropertyName("maxLimit")]
        public int? MaxLimit { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickInterval")]
        public int? TickInterval { get; set; }
        /// <summary>
        ///  pow 指数 
        /// </summary>
        [JsonPropertyName("exponent")]
        public int? Exponent { get; set; }
        /// <summary>
        ///  log 基数 
        /// </summary>
        [JsonPropertyName("base")]
        public int? Base { get; set; }

    }

    public class ValueAxis : IValueAxis
    {
        /// <summary>
        /// 'linear' , 'pow' , 'log'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        public static string TypeLinear = "linear";
        public static string TypePow = "pow";
        public static string TypeLog = "log";

        [JsonPropertyName("nice")]
        public bool? Nice { get; set; }
        [JsonPropertyName("min")]
        public double? Min { get; set; }
        [JsonPropertyName("max")]
        public double? Max { get; set; }
        [JsonPropertyName("minLimit")]
        public int? MinLimit { get; set; }
        [JsonPropertyName("maxLimit")]
        public int? MaxLimit { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("tickInterval")]
        public int? TickInterval { get; set; }
        [JsonPropertyName("exponent")]
        public int? Exponent { get; set; }
        [JsonPropertyName("base")]
        public int? Base { get; set; }
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
        [JsonPropertyName("tickMethod")]
        public string TickMethod { get; set; }
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
    }
}


