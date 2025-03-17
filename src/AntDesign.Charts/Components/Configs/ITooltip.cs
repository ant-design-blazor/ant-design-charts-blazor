using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using OneOf;

namespace AntDesign.Charts
{
    public interface ITooltip
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        [JsonPropertyName("shared")]
        public bool? Shared { get; set; }
        [JsonPropertyName("showTitle")]
        public bool? ShowTitle { get; set; }
        [JsonPropertyName("titleField")]
        public string TitleField { get; set; }

        /// <summary>
        /// The funcion of formatter. Such as: (datum: Datum) => {  return { name: datum.x, value: datum.y + '%' }; },
        /// </summary>
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }

        [JsonPropertyName("showCrosshairs")]
        public bool? ShowCrosshairs { get; set; }
        [JsonPropertyName("crosshairs")]
        public object Crosshairs { get; set; }
        [JsonPropertyName("offset")]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("showMarkers")]
        public bool? ShowMarkers { get; set; }
        /*
          domStyles?: {
            'g2-tooltip'?: any;
            'g2-tooltip-title'?: any;
            'g2-tooltip-list'?: any;
            'g2-tooltip-marker'?: any;
            'g2-tooltip-value'?: any;
          };
         */
        [JsonPropertyName("follow")]
        public bool? Follow { get; set; }

        /*
         custom?: {
            container?: string | HTMLElement;
            customContent?: (title: string, data: any[]) => string | void;
            onChange?: (tooltipDom: HTMLElement, cfg: CustomTooltipConfig) => void;
          };
         */

        /// <summary>
        /// custom content. (title, data) => string | void;
        /// </summary>
        [JsonPropertyName("customContent")]
        public string CustomContent { get; set; }

        [JsonPropertyName("itemtpl")]
        public string Itemtpl {get;set;}
    }

    public class Tooltip : ITooltip
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("fields")]
        public string[] Fields { get; set; }
        [JsonPropertyName("shared")]
        public bool? Shared { get; set; }
        [JsonPropertyName("showTitle")]
        public bool? ShowTitle { get; set; }
        [JsonPropertyName("titleField")]
        public string TitleField { get; set; }
        [JsonPropertyName("showCrosshairs")]
        public bool? ShowCrosshairs { get; set; }
        [JsonPropertyName("crosshairs")]
        public object Crosshairs { get; set; }
        [JsonIgnore]
        public OneOf<int?, object> Offset { get; set; }
        [JsonPropertyName("offset")]
        public object OffsetMapping => Offset.Value;
        [JsonPropertyName("showMarkers")]
        public bool? ShowMarkers { get; set; }
        [JsonPropertyName("follow")]
        public bool? Follow { get; set; }
        
        /// <summary>
        /// The funcion of formatter. Such as: (datum: Datum) => {  return { name: datum.x, value: datum.y + '%' }; },
        /// </summary>
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }

        [JsonPropertyName("customContent")]
        public string CustomContent { get; set; }

        [JsonPropertyName("itemtpl")]
        public string Itemtpl {get;set;}
    }
}


