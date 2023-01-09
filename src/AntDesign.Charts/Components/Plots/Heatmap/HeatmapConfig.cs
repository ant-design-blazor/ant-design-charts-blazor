using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class HeatmapConfig : IHeatmapLayerConfig, IPlotConfig
    {
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("shapeSize")]
        public int[] ShapeSize { get; set; }
        [JsonPropertyName("shapeType")]
        public string ShapeType { get; set; }
        [JsonPropertyName("shapeStyle")]
        public GraphicStyle ShapeStyle { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("legend")]
        public MatrixLegendConfig Legend { get; set; }
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
        [JsonIgnore]
        [Obsolete("No longer supported")]
        public Title Title { get; set; }
        [JsonPropertyName("description")]
        public Description Description { get; set; }
        [JsonIgnore]
        [Obsolete("No Longer Supported, use annotation instead")]
        public GuideLineConfig[] GuideLine { get; set; }
        [JsonIgnore]
        public OneOf<IAnnotation[], object[]> Annotation { get; set; }
        [JsonPropertyName("annotations")]
        public object AnnotationMapping => Annotation.Value;
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
        [JsonIgnore]
        [Obsolete("No longer supported, use autoFit instead")]
        public bool? ForceFit { get; set; }
        [JsonPropertyName("pixelRatio")]
        public int? PixelRatio { get; set; }
        [JsonPropertyName("localRefresh")]
        public bool? LocalRefresh { get; set; }
        Legend IViewConfig.Legend { get; set; }

        [JsonPropertyName("appendPadding")]
        public int? AppendPadding { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        /// <summary>
        /// Currently only support "density"
        /// </summary>
        [JsonPropertyName("type")]
        public string HeatMapType { get; set; }
    }

    public interface IHeatmapLayerConfig : IHeatmapViewConfig, ILayerConfig { }

    public interface IHeatmapViewConfig : IViewConfig
    {
        [JsonPropertyName("sizeField")]
        public string SizeField { get; set; }
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("shapeSize")]
        public int[] ShapeSize { get; set; }//number[]
        [JsonPropertyName("shapeType")]
        public string ShapeType { get; set; }
        [JsonPropertyName("shapeStyle")]
        public GraphicStyle ShapeStyle { get; set; }
        [JsonIgnore]
        public OneOf<string, string[], object> Color { get; set; }
        [JsonPropertyName("color")]
        public object ColorMapping => Color.Value;
        [JsonPropertyName("legend")]
        public MatrixLegendConfig Legend { get; set; }
        [JsonPropertyName("type")]
        public string HeatMapType { get; set; }
    }

    public interface IMatrixLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        /// export type LegendPosition =
        ///    | 'left-top'  | 'left-center'  | 'left-bottom'  | 'right-top'  | 'right-center'  | 'right-bottom'  | 'top-left'  | 'top-center'  | 'top-right'  | 'bottom-left'  | 'bottom-center'  | 'bottom-right';
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("text")]
        public MatrixLegendConfigText Text { get; set; }
        [JsonPropertyName("ticklineStyle")]
        public LineStyle TicklineStyle { get; set; }
        [JsonPropertyName("anchorStyle")]
        public GraphicStyle AnchorStyle { get; set; }
        [JsonPropertyName("triggerOn")]
        public string TriggerOn { get; set; }
    }


    public class MatrixLegendConfigText
    {
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        //public () => string formatter { get; set; }
    }

    public class MatrixLegendConfig : IMatrixLegendConfig
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        [JsonPropertyName("text")]
        public MatrixLegendConfigText Text { get; set; }
        [JsonPropertyName("ticklineStyle")]
        public LineStyle TicklineStyle { get; set; }
        [JsonPropertyName("anchorStyle")]
        public GraphicStyle AnchorStyle { get; set; }
        [JsonPropertyName("triggerOn")]
        public string TriggerOn { get; set; }
    }
}


