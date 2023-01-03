using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class FunnelConfig : IFunnelViewConfig, IPlotConfig
    {
        [JsonPropertyName("funnelStyle")]
        public object FunnelStyle { get; set; }
        [JsonPropertyName("percentage")]
        public object Percentage { get; set; }
        [JsonPropertyName("transpose")]
        public bool? Transpose { get; set; }
        [JsonPropertyName("dynamicHeight")]
        public bool? DynamicHeight { get; set; }
        [JsonPropertyName("compareField")]
        public string CompareField { get; set; }
        [JsonPropertyName("compareText")]
        public object CompareText { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("meta")]
        public object Meta { get; set; }
        [JsonIgnore]
        public OneOf<int?, string, int[]> Padding { get; set; }
        [JsonPropertyName("padding")]
        public object PaddingMapping => Padding.Value;
        [JsonPropertyName("xField")]
        public string XField { get; set; }
        [JsonPropertyName("yField")]
        public string YField { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("xAxis")]
        public Axis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public Axis YAxis { get; set; }
        [JsonIgnore]
        public OneOf<Label, object> Label { get; set; }
        [JsonPropertyName("label")]
        public object LabelMapping => Label.Value;
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip { get; set; }
        [JsonPropertyName("legend")]
        public Legend Legend { get; set; }
        [JsonIgnore]
        public OneOf<bool?, Animation, object> Animation { get; set; }
        [JsonPropertyName("animation")]
        public object AnimationMapping => Animation.Value;
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object ThemeMapping => Theme.Value;
        [JsonIgnore]
        public OneOf<string, object> ResponsiveTheme { get; set; }
        [JsonPropertyName("responsiveTheme")]
        public object ResponsiveThemeMapping => ResponsiveTheme.Value;
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
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
    }

    public interface IFunnelViewConfig : IViewConfig
    {
        [JsonPropertyName("funnelStyle")]
        public object FunnelStyle { get; set; }//export interface FunnelStyle { [k: string]: any; }
        [JsonPropertyName("percentage")]
        public object Percentage { get; set; }
        /*
           percentage?: Partial<{
                visible: boolean;
                line: Partial<{
                  visible: boolean;
                  style: LineStyle;
                }>;
                text: Partial<{
                  visible: boolean;
                  content: string;
                  style: TextStyle;
                }>;
                value: Partial<{
                  visible: boolean;
                  style: TextStyle;
                  formatter: (yValueUpper: any, yValueLower: any) => string;
                }>;
                offsetX: number;
                offsetY: number;
                spacing: number;
              }>;
        */
        [JsonPropertyName("transpose")]
        public bool? Transpose { get; set; }
        [JsonPropertyName("dynamicHeight")]
        public bool? DynamicHeight { get; set; }
        [JsonPropertyName("compareField")]
        public string CompareField { get; set; }
        [JsonPropertyName("compareText")]
        public object CompareText { get; set; }
        /*
           compareText?: Partial<{
                visible: boolean;
                offsetX: number;
                offsetY: number;
                style: TextStyle;
              }>;
        */
    }


}

