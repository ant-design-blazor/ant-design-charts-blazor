using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class ValueCatTimeAxis : IValueAxis, ICatAxis, ITimeAxis
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
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
        [JsonPropertyName("mask")]
        public string Mask { get; set; }
        string ITimeAxis.TickInterval { get; set; }
    }
}


