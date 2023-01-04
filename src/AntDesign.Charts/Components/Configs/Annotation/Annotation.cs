using System;
using System.Text.Json.Serialization;
using OneOf;

namespace AntDesign.Charts
{
    public class Annotation : IAnnotation
    {
        /// <summary>
        /// 'arc', 'image', 'line', 'text', 'region', 'regionFilter', 'dataMarker', 'dataRegion', 'html', 'shape'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        public static string TypeArc = "arc";
        public static string TypeImage = "image";
        public static string TypeLine = "line";
        public static string TypeText = "text";
        public static string TypeRegion = "region";
        public static string TypeRegionFilter = "regionFilter";
        public static string TypeDataMarker = "dataMarker";
        public static string TypeDataRegion = "dataRegion";
        public static string TypeHtml = "html";
        public static string TypeShape = "shape";

        [JsonPropertyName("style")] 
        public IGraphicStyle Style { get; set; }
        [JsonIgnore] 
        public OneOf<object, object[], string[]> Start { get; set; }
        [JsonPropertyName("start")] 
        public object StartMapping => Start.Value;
        [JsonIgnore] 
        public OneOf<object, object[], string[]> End { get; set; }
        [JsonPropertyName("end")] 
        public object EndMapping => End.Value;
        [Obsolete("X is not recommended. Use Position instead")]
        public int? X { get; set; }
        [Obsolete("Y is not recommended. Use Position instead")]
        public int? Y { get; set; }
        [JsonIgnore] 
        public OneOf<object, object[], string[]> Position { get; set; }
        [JsonPropertyName("position")] 
        public object PositionMapping => Position.Value;
        [JsonPropertyName("content")] 
        public string Content { get; set; }
        [JsonPropertyName("rotate")] 
        public int? Rotate { get; set; }
        [JsonPropertyName("offsetX")] 
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")] 
        public int? OffsetY { get; set; }
        [JsonPropertyName("background")] 
        public AnnotationBackgroundCfg Background { get; set; }
        [JsonPropertyName("maxLength")] 
        public int? MaxLength { get; set; }
        [JsonPropertyName("autoEllipsis")] 
        public bool? AutoEllipsis { get; set; }

        [JsonPropertyName("ellipsisPosition")]
        public object EllipsisPosition { get; set; } //todo: AntDesign documentation lacking example

        [JsonPropertyName("isVertical")] 
        public bool? IsVertical { get; set; }
        [JsonPropertyName("text")] 
        public AnnotationTextCfg Text { get; set; }
        [JsonPropertyName("top")] 
        public bool? Top { get; set; }
        [JsonPropertyName("animate")] 
        public bool? Animate { get; set; }
        [JsonPropertyName("animateOption")] 
        public IAnimation AnimateOption { get; set; }
        [JsonPropertyName("src")] 
        public string Src { get; set; }
        [JsonPropertyName("autoAdjust")] 
        public bool? AutoAdjust { get; set; }
        [JsonPropertyName("point")] 
        public DataMarkerPointCfg Point { get; set; }
        [JsonPropertyName("line")] 
        public DataMarkerLineCfg Line { get; set; }
        [JsonPropertyName("direction")]
        public string Direction { get; set; } //todo incomplete/missing example
        [JsonIgnore] public OneOf<object, string> Html { get; set; } //todo incomplete/missing example
        [JsonPropertyName("htmlContent")] public object HtmlMapping => Html.Value;
        [JsonIgnore] public OneOf<object, string> Container { get; set; } //todo incomplete/missing example
        [JsonPropertyName("container")] public object ContainerMapping => Container.Value;
        [JsonIgnore] public OneOf<object, string> Render { get; set; } //todo incomplete/missing example
        [JsonPropertyName("render")] public object RenderMapping => Render.Value;
        [JsonPropertyName("lineLength")] public int? LineLength { get; set; }
        [JsonPropertyName("region")] public IStateConfig Region { get; set; }
        [JsonPropertyName("color")] public string Color { get; set; }
        [JsonPropertyName("apply")] public string[] Apply { get; set; }
        [JsonPropertyName("alignX")] public string AlignX { get; set; }
        public static string AlignToLeft = "left";
        public static string AlignToMiddle = "middle";
        public static string AlignToRight = "right";
        [JsonPropertyName("alignY")] public string AlignY { get; set; }
        public static string AlignToTop = "top";
        public static string AlignToBottom = "bottom";
    }
}