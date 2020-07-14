using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IBarAutoLabel : ILabel
    {
        /// <summary>
        ///  column-auto 下暗色配置 
        /// </summary>
        public TextStyle darkStyle { get; set; }
        /// <summary>
        ///  column-auto 下亮色配置 
        /// </summary>
        public TextStyle lightStyle { get; set; }
    }

    public class BarAutoLabel : IBarAutoLabel
    {
        public TextStyle darkStyle { get; set; }
        public TextStyle lightStyle { get; set; }
        public bool? visible { get; set; }
        public string type { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public string position { get; set; }
        public bool? adjustColor { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? autoRotate { get; set; }
        public string field { get; set; }
    }
}
