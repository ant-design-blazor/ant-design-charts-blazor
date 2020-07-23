using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IGuideLineConfig
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("start")]
        public object[] Start { get; set; }//any[]
        [JsonPropertyName("end")]
        public object[] End { get; set; }//any[]
        [JsonPropertyName("lineStyle")]
        public LineStyle LineStyle { get; set; }
        [JsonPropertyName("text")]
        public GuideLineConfigText Text { get; set; }
    }

    public class GuideLineConfigText
    {
        [JsonPropertyName("position")]
        public string Position { get; set; }//OneOf <'start','center','end'>
        public static string PositionStart = "start";
        public static string PositionCenter = "center";
        public static string PositionEnd = "end";

        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class GuideLineConfig : IGuideLineConfig
    {
[JsonPropertyName("type")]
public string Type { get; set; }
[JsonPropertyName("start")]
public object[] Start { get; set; }
[JsonPropertyName("end")]
public object[] End { get; set; }
[JsonPropertyName("lineStyle")]
public LineStyle LineStyle { get; set; }
[JsonPropertyName("text")]
public GuideLineConfigText Text { get; set; }
    }

}


