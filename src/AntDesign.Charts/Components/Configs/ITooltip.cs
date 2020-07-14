using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ITooltip
    {
        public bool? visible { get; set; }
        public string[] fields { get; set; }
        public bool? shared { get; set; }
        public bool? showTitle { get; set; }
        public string titleField { get; set; }
        //  formatter?: (...args: any) => { name: string; value: number };
        public bool? showCrosshairs { get; set; }
        public object crosshairs { get; set; }
        public int? offset { get; set; }
        public bool? showMarkers { get; set; }
        /*
          domStyles?: {
            'g2-tooltip'?: any;
            'g2-tooltip-title'?: any;
            'g2-tooltip-list'?: any;
            'g2-tooltip-marker'?: any;
            'g2-tooltip-value'?: any;
          };
         */
        public bool? follow { get; set; }

        /*
         custom?: {
            container?: string | HTMLElement;
            customContent?: (title: string, data: any[]) => string | void;
            onChange?: (tooltipDom: HTMLElement, cfg: CustomTooltipConfig) => void;
          };
         */
    }

    public class Tooltip : ITooltip
    {
        public bool? visible { get; set; }
        public string[] fields { get; set; }
        public bool? shared { get; set; }
        public bool? showTitle { get; set; }
        public string titleField { get; set; }
        public bool? showCrosshairs { get; set; }
        public object crosshairs { get; set; }
        public int? offset { get; set; }
        public bool? showMarkers { get; set; }
        public bool? follow { get; set; }
    }
}
