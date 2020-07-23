using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class RadarConfig : IRadarViewConfig, IPlotConfig
    {
        [JsonPropertyName("angleField")]
        public string AngleField { get; set; }
        [JsonPropertyName("radiusField")]
        public string RadiusField { get; set; }
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        [JsonPropertyName("line")]
        public RadarViewConfigLine Line { get; set; }
        [JsonPropertyName("point")]
        public RadarViewConfigPoint Point { get; set; }
        [JsonPropertyName("area")]
        public RadarViewConfigArea Area { get; set; }
        [JsonPropertyName("angleAxis")]
        public CatAxis AngleAxis { get; set; }
        [JsonPropertyName("radiusAxis")]
        public ValueAxis RadiusAxis { get; set; }
        [JsonPropertyName("radius")]
        public int? Radius { get; set; }
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
        public object ThemeMapping => Theme.Value;
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
        [JsonPropertyName("guideLine")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonPropertyName("defaultState")]
        public ViewConfigDefaultState DefaultState { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("forceFit")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
    }

    public interface IRadarViewConfig : IViewConfig
    {
        /// <summary>
        ///  角度字段 
        /// </summary>
        [JsonPropertyName("angleField")]
        public string AngleField { get; set; }
        /// <summary>
        ///  径向字段 
        /// </summary>
        [JsonPropertyName("radiusField")]
        public string RadiusField { get; set; }
        /// <summary>
        ///  分组字段 
        /// </summary>
        [JsonPropertyName("seriesField")]
        public string SeriesField { get; set; }
        /// <summary>
        ///  是否平滑 
        /// </summary>
        [JsonPropertyName("smooth")]
        public bool? Smooth { get; set; }
        /// <summary>
        /// 折线图形样式
        /// </summary>
        [JsonPropertyName("line")]
        public RadarViewConfigLine Line { get; set; }
        /// <summary>
        /// 数据点图形样式
        /// </summary>
        [JsonPropertyName("point")]
        public RadarViewConfigPoint Point { get; set; }
        /// <summary>
        /// area图形样式
        /// </summary>
        [JsonPropertyName("area")]
        public RadarViewConfigArea Area { get; set; }
        /// <summary>
        ///  角度轴配置 
        /// </summary>
        [JsonPropertyName("angleAxis")]
        public CatAxis AngleAxis { get; set; }
        /// <summary>
        ///  径向轴配置 
        /// </summary>
        [JsonPropertyName("radiusAxis")]
        public ValueAxis RadiusAxis { get; set; }
        /// <summary>
        ///  雷达图半径 
        /// </summary>
        [JsonPropertyName("radius")]
        public int? Radius { get; set; }
    }

    public class RadarViewConfigLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }//OneOf<LineStyle, ((...args: any[]) => LineStyle)>
    }

    public class RadarViewConfigPoint
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("shape")]
        public string Shape { get; set; }
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
    }

    public class RadarViewConfigArea
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public GraphicStyle Style { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>

    }
}


