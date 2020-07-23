using System.Text.Json.Serialization;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IViewConfig
    {
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        /// <summary>
        /// ILooseMap<Meta>
        /// </summary>
        [JsonPropertyName("meta")]
        public object Meta { get; set; }//ILooseMap<Meta>
        [JsonPropertyName("padding")]
        public OneOf<int?, string, int[]> Padding { get; set; }//
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string YField { get; set; }
        [JsonPropertyName("color")]
        public OneOf<string, string[],object> Color { get; set; }
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonPropertyName("label")]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        /// <summary>
        ///OneOf<Animation, bool?> 
        /// </summary>
        [JsonPropertyName("animation")]
        public object Animation { get; set; }//OneOf<Animation, bool?>
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("responsiveTheme")]
        public OneOf<string,object> ResponsiveTheme { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("responsive")]
        public bool? Responsive { get; set; }
        [JsonPropertyName("title")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
        /*
          events?: {
            [k: string]: ((...args: any[]) => any) | boolean;
          };
         */
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ViewConfigDefaultState
    {
        [JsonPropertyName("active")]
        public StateConfig Active { get; set; }
        [JsonPropertyName("inActive")]
        public StateConfig InActive { get; set; }
        [JsonPropertyName("selected")]
        public StateConfig Selected { get; set; }
        [JsonPropertyName("disabled")]
        public StateConfig Disabled { get; set; }
    }

    public class Axis : ICatAxis, IValueAxis, ITimeAxis
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
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
        [JsonPropertyName("mask")]
        public string Mask { get; set; }
        string ITimeAxis.TickInterval { get; set; }
    }
}




