using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    using IPercentStackedAreaViewConfig = IStackedAreaViewConfig;

    public class PercentStackedAreaConfig : IPercentStackedAreaLayerConfig, IPlotConfig
    {
        [JsonPropertyName("stackField")]
        public string StackField { get; set; }
        [JsonPropertyName("label")]
        public StackedAreaLabel Label { get; set; }
        [JsonPropertyName("areaStyle")]
        public GraphicStyle AreaStyle { get; set; }
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        [JsonPropertyName("xAxis")]
        public ValueCatTimeAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public ValueAxis YAxis { get; set; }
        [JsonPropertyName("line")]
        public AreaViewConfigLine Line { get; set; }
        [JsonPropertyName("point")]
        public AreaViewConfigPoint Point { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("interactions")]
        public Interaction[] Interactions { get; set; }
        [JsonPropertyName("renderer")]
        public string Renderer { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }
        /// <summary>
        /// ILooseMap<Meta>
        /// </summary>
        [JsonPropertyName("meta")]
        public object Meta { get; set; }//ILooseMap<Meta>
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
        AreaLabel IAreaViewConfig.Label { get; set; }
        OneOf<Label, object> IViewConfig.Label { get; set; }
        Axis IViewConfig.XAxis { get; set; }
        Axis IViewConfig.YAxis { get; set; }

        [JsonPropertyName("appendPadding")]
        public int AppendPadding { get; set; }


    }


    public interface IPercentStackedAreaLayerConfig : IPercentStackedAreaViewConfig, ILayerConfig { }


    public interface IStackedAreaViewConfig : IAreaViewConfig
    {
        [JsonPropertyName("stackField")]
        public string StackField { get; set; }
        [JsonPropertyName("label")]
        public StackedAreaLabel Label { get; set; }

    }

    public interface IStackedAreaLabel : IAreaTypeLabel, ILineTypeLabel, IAreaLabel
    {

    }

    public interface IAreaTypeLabel : ILabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }// 'area'
        [JsonPropertyName("autoScale")]
        public bool? AutoScale { get; set; }
    }

    public interface ILineTypeLabel : ILabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }// 'line'
    }

    public class StackedAreaLabel : IStackedAreaLabel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("autoScale")]
        public bool? AutoScale { get; set; }
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("precision")]
        public int? Precision { get; set; }
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("adjustColor")]
        public bool? AdjustColor { get; set; }
        [JsonPropertyName("adjustPosition")]
        public bool? AdjustPosition { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("field")]
        public string Field { get; set; }
    }
}


