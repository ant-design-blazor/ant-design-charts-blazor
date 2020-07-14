using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILabel
    {
        public bool? visible { get; set; }
        public string type { get; set; }
        /// <summary>
        ///  精度配置，可通过自定义精度来固定数值类型 label 格式 
        /// </summary>
        public int? precision { get; set; }
        /// <summary>
        ///  添加后缀 
        /// </summary>
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }//OneOf<int?, any>
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public string position { get; set; }
        public bool? adjustColor { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? autoRotate { get; set; }
        /// <summary>
        ///  标签对应字段 
        /// </summary>
        public string field { get; set; }
    }

    public class Label : ILabel
    {
        public bool? visible { get;set; }
        public string type { get;set; }
        public int? precision { get;set; }
        public string suffix { get;set; }
        public TextStyle style { get;set; }
        public int? offset { get;set; }
        public int? offsetX { get;set; }
        public int? offsetY { get;set; }
        public string position { get;set; }
        public bool? adjustColor { get;set; }
        public bool? adjustPosition { get;set; }
        public bool? autoRotate { get;set; }
        public string field { get;set; }
    }
}
