using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IBarLabel : ILabel
    {
        public string position { get; set; }//OneOf <string,'left','middle','right'>
        public static string PositionLeft = "left";
        public static string PositionMiddle = "middle";
        public static string PositionRight = "right";

        public bool? adjustPosition { get; set; }
        public bool? adjustColor { get; set; }


    }

    public class BarLabel : IBarLabel
    {
        public string position { get; set; }
        public bool? adjustPosition { get; set; }
        public bool? adjustColor { get; set; }
        public bool? visible { get; set; }
        public string type { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public bool? autoRotate { get; set; }
        public string field { get; set; }
    }
}
