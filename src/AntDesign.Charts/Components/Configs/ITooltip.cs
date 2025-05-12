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
        [JsonPropertyName("domStyles")]
        public TooltipDomStyles DomStyles { get; set; }

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

        [JsonPropertyName("itemTpl")]
        public string ItemTpl {get;set;}

        [JsonPropertyName("containerTpl")]
        public string ContainerTpl { get; set; }
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

        /// <summary>
        /// The dom styles of tooltip
        /// </summary>
        [JsonPropertyName("domStyles")]
        public TooltipDomStyles DomStyles { get; set; }

        [JsonPropertyName("follow")]
        public bool? Follow { get; set; }
        
        /// <summary>
        /// The funcion of formatter. Such as: (datum: Datum) => {  return { name: datum.x, value: datum.y + '%' }; },
        /// </summary>
        [JsonPropertyName("formatter")]
        public string Formatter { get; set; }

        [JsonPropertyName("customContent")]
        public string CustomContent { get; set; }

        [JsonPropertyName("itemTpl")]
        public string ItemTpl {get;set;}

        [JsonPropertyName("containerTpl")]
        public string ContainerTpl { get; set; }
    }

    public class TooltipDomStyles
    {
        /// <summary>
        /// The dom styles of tooltip, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip")]
        public object G2Tooltip { get; set; }

        /// <summary>
        /// The dom styles of tooltip title, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-title")]
        public object G2TooltipTitle { get; set; }

        /// <summary>
        /// The dom styles of tooltip list, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-list")]
        public object G2TooltipList { get; set; }

        /// <summary>
        /// The dom styles of tooltip list item, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-list-item")]
        public object G2TooltipListItem { get; set; }

        /// <summary>
        /// The dom styles of tooltip marker, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-marker")]
        public object G2TooltipMarker { get; set; }

        /// <summary>
        /// The dom styles of tooltip value, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-value")]
        public object G2TooltipValue { get; set; }

        /// <summary>
        /// The dom styles of tooltip name, the value type is CSSProperties.
        /// </summary>
        [JsonPropertyName("g2-tooltip-name")]
        public object G2TooltipName { get; set; }
    }
}


