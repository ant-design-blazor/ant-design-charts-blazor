using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ITimeAxis
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }// 'time'
        /// <summary>
        ///  tick相关配置 
        /// </summary>
        [JsonPropertyName("tickInterval")]
        public string TickInterval { get; set; }
        [JsonPropertyName("tickCount")]
        public int? TickCount { get; set; }
        [JsonPropertyName("mask")]
        public string Mask { get; set; }
    }
}


