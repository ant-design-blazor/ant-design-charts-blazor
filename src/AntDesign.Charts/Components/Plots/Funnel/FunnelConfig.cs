using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class FunnelConfig : IFunnelViewConfig, IPlotConfig
    {
        public object funnelStyle { get; set; }
        public object percentage { get; set; }
        public bool? transpose { get; set; }
        public bool? dynamicHeight { get; set; }
        public string compareField { get; set; }
        public object compareText { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
        public Label label { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public object animation { get; set; }
        public string theme { get; set; }
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
    }

    public interface IFunnelViewConfig : IViewConfig
    {
        public object funnelStyle { get; set; }//export interface FunnelStyle { [k: string]: any; }
        public object percentage { get; set; }
        /*
           percentage?: Partial<{
                visible: boolean;
                line: Partial<{
                  visible: boolean;
                  style: LineStyle;
                }>;
                text: Partial<{
                  visible: boolean;
                  content: string;
                  style: TextStyle;
                }>;
                value: Partial<{
                  visible: boolean;
                  style: TextStyle;
                  formatter: (yValueUpper: any, yValueLower: any) => string;
                }>;
                offsetX: number;
                offsetY: number;
                spacing: number;
              }>;
        */
        public bool? transpose { get; set; }
        public bool? dynamicHeight { get; set; }
        public string compareField { get; set; }
        public object compareText { get; set; }
        /*
           compareText?: Partial<{
                visible: boolean;
                offsetX: number;
                offsetY: number;
                style: TextStyle;
              }>;
        */
    }


}