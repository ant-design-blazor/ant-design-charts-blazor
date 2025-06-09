using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILegend
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        /// <summary>
        ///  位置 
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; }// | 'left-top' | 'left-center' | 'left-bottom' | 'right-top' | 'right-center' | 'right-bottom' | 'top-left' | 'top-center' | 'top-right' | 'bottom-left' | 'bottom-center' | 'bottom-right'
        /// <summary>
        ///  翻页 
        /// </summary>
        [JsonPropertyName("flipPage")]
        public bool? FlipPage { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("clickable")]
        public bool? Clickable { get; set; }
        [JsonPropertyName("title")]
        public LegendTitle Title { get; set; }
        [JsonPropertyName("marker")]
        public LegendMarker Marker { get; set; }
        [JsonPropertyName("text")]
        public LegendText Text { get; set; }
        [JsonPropertyName("selected")]
        public Dictionary<string, bool> Selected { get; set; }

        [JsonPropertyName("custom")]
        public bool Custom { get; set; }
    }

    public class LegendTitle
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
    }

    public class LegendMarker
    {
        /// <summary>
        /// preset symbols: "circle" | "square" | "line" | "diamond" | "triangle" | "triangle-down" | "hexagon" | "bowtie" | "cross" | "tick" | "plus" | "hyphen"
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// (x: number, y: number, r: number) => PathCommand
        /// <para>
        /// DEMO: https://g2plot.antv.antgroup.com/zh/examples/component/legend#legend-marker-customize
        /// </para>
        /// </summary>
        [JsonPropertyName("symbolFunction")]
        public string SymbolFunction { get; set; }

        [JsonPropertyName("style")]
        public LegendMarkerStyle Style { get; set; }
    }

    public class LegendText
    {
        [JsonPropertyName("style")]
        public TextStyle Style { get; set; }
        //formatter?: (text: string, cfg: any) => string;
    }

    public class Legend : ILegend
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
        [JsonPropertyName("flipPage")]
        public bool? FlipPage { get; set; }
        [JsonPropertyName("offsetX")]
        public int? OffsetX { get; set; }
        [JsonPropertyName("offsetY")]
        public int? OffsetY { get; set; }
        [JsonPropertyName("clickable")]
        public bool? Clickable { get; set; }
        [JsonPropertyName("title")]
        public LegendTitle Title { get; set; }
        [JsonPropertyName("marker")]
        public LegendMarker Marker { get; set; }
        [JsonPropertyName("text")]
        public LegendText Text { get; set; }
        [JsonPropertyName("selected")]
        public Dictionary<string, bool> Selected { get; set; }

        [JsonPropertyName("custom")]
        public bool Custom { get; set; }
    }
}


