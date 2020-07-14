using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IBaseAxis
    {
        /// <summary>
        ///  轴是否需要显示，默认true 
        /// </summary>
        public bool visible { get; set; }
        /// <summary>
        ///  轴类型，对应scale类型 
        /// </summary>
        public string type { get; set; }//OneOf<'linear' , 'time' , 'timeCat' , 'cat' , 'pow' , 'log'>
        /// <summary>
        ///  scale 自定义 tickMethod 
        /// </summary>
        public string tickMethod { get; set; }// OneOf<string, ((cfg: any) => number[])>
        /// <summary>
        /// 轴位置，默认下和左
        /// </summary>
        public BaseAxisLine line { get; set; }
        /// <summary>
        /// 网格线
        /// </summary>
        public BaseAxisGrid grid { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public BaseAxisLabel label { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public BaseAxisTitle title { get; set; }
        /// <summary>
        /// 刻度线
        /// </summary>
        public BaseAxisTickLine tickLine { get; set; }
    }

    /// <summary>
    /// 轴位置，默认下和左
    /// </summary>
    public class BaseAxisLine
    {
        public bool visible { get; set; }
        public LineStyle style { get; set; }
    }

    /// <summary>
    ///  网格线
    /// </summary>
    public class BaseAxisGrid
    {
        /// <summary>
        ///  网格线是否显示 
        /// </summary>
        public bool visible { get; set; }

        public BaseAxisGridLine line { get; set; }
        /// <summary>
        ///  网格设置交替的颜色，指定一个值则先渲染偶数层，两个值则交替渲染 
        /// </summary>
        public string[] alternateColor { get; set; }// OneOf<string, string[]>
    }
    public class BaseAxisGridLine
    {
        public LineStyle style { get; set; }// OneOf<LineStyle, ((text: string, idx: number, count: number) => LineStyle)>
        public string type { get; set; }// OneOf<'line' , 'circle'>
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class BaseAxisLabel
    {
        public bool visible { get; set; }
        //formatter?: (name: string, tick: any, index: number) => string;
        /// <summary>
        /// 坐标轴文本距离坐标轴线的距离
        /// </summary>
        public int? offset { get; set; }
        /// <summary>
        /// 在 offset 的基础上，设置坐标轴文本在 x 方向上的偏移量
        /// </summary>
        public int? offsetX { get; set; }
        /// <summary>
        /// 在 offset 的基础上，设置坐标轴文本在 y 方向上的偏移量
        /// </summary>
        public int? offsetY { get; set; }
        /// <summary>
        /// label 文本旋转的角度，使用角度制
        /// </summary>
        public int? rotate { get; set; }
        public TextStyle style { get; set; }
        public bool autoRotate { get; set; }
        /// <summary>
        /// 默认的 autoHide 策略，或指定自动隐藏策略
        /// </summary>
        public bool autoHide { get; set; }//OneOf<boolean, string>
    }

    /// <summary>
    /// 标题
    /// </summary>
    public class BaseAxisTitle
    {
        public bool? visible { get; set; }
        public bool? autoRotate { get; set; }
        public string text { get; set; }
        public int? offset { get; set; }
        public TextStyle style { get; set; }
        public int? spacing { get; set; }
    }

    /// <summary>
    /// 刻度线
    /// </summary>
    public class BaseAxisTickLine
    {
        public bool? visible { get; set; }
        public LineStyle style { get; set; }
    }


}
