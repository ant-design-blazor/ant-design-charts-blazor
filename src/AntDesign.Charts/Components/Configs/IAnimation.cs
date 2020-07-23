using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IAnimation
    {
        [JsonPropertyName("appear")]
        public AnimationCfg Appear { get; set; }
        [JsonPropertyName("enter")]
        public AnimationCfg Enter { get; set; }
        [JsonPropertyName("update")]
        public AnimationCfg Update { get; set; }
        [JsonPropertyName("leave")]
        public AnimationCfg Leave { get; set; }
        //  [field: string]: any;
    }

    public class AnimationCfg
    {
        /// <summary>
        ///  动画模式，延伸or缩放 
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        [JsonPropertyName("easing")]
        public string Easing { get; set; }
        [JsonPropertyName("delay")]
        public int? Delay { get; set; }
        //callback?: (...args: any[]) => void;
        //[field: string]: any;


        [JsonPropertyName("animation")]
        public string Animation { get; set; }//补充
    }

    public class Animation : IAnimation
    {
        [JsonPropertyName("appear")]
        public AnimationCfg Appear { get; set; }
        [JsonPropertyName("enter")]
        public AnimationCfg Enter { get; set; }
        [JsonPropertyName("update")]
        public AnimationCfg Update { get; set; }
        [JsonPropertyName("leave")]
        public AnimationCfg Leave { get; set; }
    }
}


