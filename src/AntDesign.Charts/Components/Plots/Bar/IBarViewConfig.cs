using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IBarViewConfig : IViewConfig
    {
        [JsonPropertyName("colorField")]
        public string ColorField { get; set; }
        [JsonPropertyName("barSize")]
        public int? BarSize { get; set; }
        [JsonPropertyName("barStyle")]
        public GraphicStyle BarStyle { get; set; }//OneOf <GraphicStyle, ((...args: any[]) => GraphicStyle)>
        [JsonPropertyName("xAxis")]
        public new ValueAxis XAxis { get; set; }
        [JsonPropertyName("yAxis")]
        public new CatAxis YAxis { get; set; }
        [JsonPropertyName("label")]
        public new BarViewConfigLabel Label { get; set; }//OneOf <IBarLabel, IBarAutoLabel>
        [JsonPropertyName("conversionTag")]
        public ConversionTagOptions ConversionTag { get; set; }
        [JsonPropertyName("scrollbar")]
        public IScrollbar Scrollbar { get; set; }
        [JsonPropertyName("slider")]
        public ISlider Slider { get; set; }
        [JsonPropertyName("isStack")]
        public bool? IsStack { get; set; }
        [JsonPropertyName("isRange")]
        public bool? IsRange { get; set; }
        [JsonPropertyName("isPercent")]
        public bool? IsPercent { get; set; }
    }

    public class BarViewConfigLabel : IBarLabel, IBarAutoLabel
    {
        [JsonPropertyName("darkStyle")]
        public TextStyle DarkStyle { get; set; }
        [JsonPropertyName("lightStyle")]
        public TextStyle LightStyle { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
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
        [JsonPropertyName("layout")]
        public LayoutType[] Layout { get; set; }
    }
}


