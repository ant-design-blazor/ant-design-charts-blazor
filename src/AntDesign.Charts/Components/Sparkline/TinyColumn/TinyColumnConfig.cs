using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class TinyColumnConfig : ITinyColumnLayerConfig, IPlotConfig
    {
[JsonPropertyName("columnStyle")]
public object ColumnStyle { get; set; }
[JsonPropertyName("indicator")]
public object Indicator { get; set; }
[JsonPropertyName("guideLine")]
public object GuideLine { get; set; }
[JsonPropertyName("renderer")]
public string Renderer { get; set; }
[JsonPropertyName("data")]
public object Data { get; set; }
[JsonPropertyName("meta")]
public object Meta { get; set; }
[JsonPropertyName("padding")]
public string Padding { get; set; }
[JsonPropertyName("xField")]
public string XField { get; set; }
[JsonPropertyName("yField")]
public string YField { get; set; }
[JsonPropertyName("color")]
public string[] Color { get; set; }
[JsonPropertyName("xAxis")]
public Axis XAxis { get; set; }
[JsonPropertyName("yAxis")]
public Axis YAxis { get; set; }
[JsonPropertyName("label")]
public Label Label { get; set; }
[JsonPropertyName("tooltip")]
public Tooltip Tooltip { get; set; }
[JsonPropertyName("legend")]
public Legend Legend { get; set; }
[JsonPropertyName("animation")]
public object Animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> Theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => Theme.Value;
[JsonPropertyName("responsiveTheme")]
public object ResponsiveTheme { get; set; }
[JsonPropertyName("interactions")]
public Interaction[] Interactions { get; set; }
[JsonPropertyName("responsive")]
public bool? Responsive { get; set; }
[JsonPropertyName("title")]
public Title Title { get; set; }
[JsonPropertyName("description")]
public Description Description { get; set; }
[JsonPropertyName("defaultState")]
public ViewConfigDefaultState DefaultState { get; set; }
[JsonPropertyName("name")]
public string Name { get; set; }
[JsonPropertyName("id")]
public string Id { get; set; }
[JsonPropertyName("x")]
public int? X { get; set; }
[JsonPropertyName("y")]
public int? Y { get; set; }
[JsonPropertyName("width")]
public int? Width { get; set; }
[JsonPropertyName("height")]
public int? Height { get; set; }
[JsonPropertyName("parent")]
public object Parent { get; set; }
[JsonPropertyName("canvas")]
public object Canvas { get; set; }
[JsonPropertyName("forceFit")]
public bool? ForceFit { get; set; }
[JsonPropertyName("pixelRatio")]
public int? PixelRatio { get; set; }
[JsonPropertyName("localRefresh")]
public bool? LocalRefresh { get; set; }
        GuideLineConfig[] IViewConfig.GuideLine { get; set; }
    }

    public interface ITinyColumnLayerConfig : ITinyColumnViewConfig, ILayerConfig { }

    public interface ITinyColumnViewConfig : ITinyViewConfig
    {
[JsonPropertyName("columnStyle")]
public object ColumnStyle { get; set; }
    }

}

