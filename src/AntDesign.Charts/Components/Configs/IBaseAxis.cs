using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IBaseAxis
    {
        /// <summary>
        ///  轴是否需要显示，默认true 
        /// </summary>
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        ///  轴类型，对应scale类型 
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        public static string TypeLinear = "linear";
        public static string TypeTime = "time";
        public static string TypeTimeCat = "timeCat";
        public static string TypeCat = "cat";
        public static string TypePow = "pow";
        public static string TypeLog = "log";

        /// <summary>
        ///  scale 自定义 tickMethod, perset: cat、time-cat、 wilkinson-extended、r-pretty、time、time-pretty、log、pow、quantile、d3-linear
        /// </summary>
        [JsonPropertyName("tickMethod")]
        public string TickMethod { get; set; }

        [JsonPropertyName("tickMethodFunction")]
        public string TickMethodFunction { get; set; }//OneOf <string, ((cfg: any) => number[])>

        /// <summary>
        /// 轴位置，默认下和左
        /// </summary>
        [JsonPropertyName("line")]
        public BaseAxisLine Line { get; set; }
        /// <summary>
        /// 网格线
        /// </summary>
        [JsonPropertyName("grid")]
        public BaseAxisGrid Grid { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [JsonPropertyName("label")]
        public BaseAxisLabel Label { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [JsonPropertyName("title")]
        public BaseAxisTitle Title { get; set; }
        /// <summary>
        /// 刻度线
        /// </summary>
        [JsonPropertyName("tickLine")]
        public BaseAxisTickLine TickLine { get; set; }
    }

    /// <summary>
    /// 轴位置，默认下和左
    /// </summary>
    public class BaseAxisLine
    {
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }

    /// <summary>
    ///  网格线
    /// </summary>
    public class BaseAxisGrid
    {
        /// <summary>
        ///  网格线是否显示 
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }

        [JsonPropertyName("line")]
        public BaseAxisGridLine Line { get; set; }
        /// <summary>
        ///  网格设置交替的颜色，指定一个值则先渲染偶数层，两个值则交替渲染 
        /// </summary>
        [JsonIgnore]
        public OneOf<string, string[]> AlternateColor { get; set; }//OneOf <string, string[]>
        [JsonPropertyName("alternateColor")]
        public object alternateColorMapping => AlternateColor.Value;
    }
    public class BaseAxisGridLine
    {
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }//OneOf <LineStyle, ((text: string, idx: number, count: number) => LineStyle)>
        /// <summary>
        /// 'line' , 'circle'
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        public static string TypeLine = "line";
        public static string TypeCircle = "circle";
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class BaseAxisLabel
    {
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
        //formatter?: (name: string, tick: any, index: number) => string;
        /// <summary>
        /// 坐标轴文本距离坐标轴线的距离
        /// </summary>
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        /// <summary>
        /// 在 offset 的基础上，设置坐标轴文本在 x 方向上的偏移量
        /// </summary>
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        /// <summary>
        /// 在 offset 的基础上，设置坐标轴文本在 y 方向上的偏移量
        /// </summary>
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        /// <summary>
        /// label 文本旋转的角度，使用角度制
        /// </summary>
        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool AutoRotate { get; set; }
        /// <summary>
        /// 默认的 autoHide 策略，或指定自动隐藏策略
        /// </summary>
        [JsonIgnore]
        public OneOf<bool?, string> AutoHide { get; set; }//OneOf <boolean, string>
        [JsonPropertyName("autoHide")]
        public object autoHideMapping => AutoHide.Value;
    }

    /// <summary>
    /// 标题
    /// </summary>
    public class BaseAxisTitle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        [JsonPropertyName("spacing")]
        public int? Spacing { get; set; }
    }

    /// <summary>
    /// 刻度线
    /// </summary>
    public class BaseAxisTickLine
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public LineStyle Style { get; set; }
    }


}


