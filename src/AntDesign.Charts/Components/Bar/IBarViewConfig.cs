using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IBarViewConfig : IViewConfig
    {
        public string colorField { get; set; }
        public int? barSize { get; set; }
        public GraphicStyle barStyle { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
        public ValueAxis xAxis { get; set; }
        public CatAxis yAxis { get; set; }
        public BarViewConfigLabel label { get; set; }// OneOf<IBarLabel, IBarAutoLabel>
        public ConversionTagOptions conversionTag { get; set; }
        public Interaction[] interactions { get; set; }
    }

    public class BarViewConfigLabel : IBarLabel, IBarAutoLabel
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
