using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IViewConfig
    {
        public string renderer { get; set; }
        public object data { get; set; }
        public ILooseMap<Meta> meta { get; set; }
        public int? padding { get; set; }//OneOf<int?, int[], string>
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }//OneOf<string, string[],{}>
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
        public Label label { get; set; }//OneOf<Label, any>
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public bool? animation { get; set; }// OneOf<Animation, bool?> 
        public string theme { get; set; }//OneOf<LooseMap, string>
        public object responsiveTheme { get; set; }// OneOf<{},string>
        public IInteractions[] interactions { get; set; }
        public bool? responsive { get; set; }
        public Title title { get; set; }
        public Description description { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        /*
          events?: {
            [k: string]: ((...args: any[]) => any) | boolean;
          };
         */
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
    }

    public class ViewConfigDefaultState
    {
        public StateConfig active { get; set; }
        public StateConfig inActive { get; set; }
        public StateConfig selected { get; set; }
        public StateConfig disabled { get; set; }
    }

    public class Axis : ICatAxis, IValueAxis, ITimeAxis
    {
        public string type { get; set; }
        public bool visible { get; set; }
        public string tickMethod { get; set; }
        public BaseAxisLine line { get; set; }
        public BaseAxisGrid grid { get; set; }
        public BaseAxisLabel label { get; set; }
        public BaseAxisTitle title { get; set; }
        public BaseAxisTickLine tickLine { get; set; }
        public bool? nice { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? minLimit { get; set; }
        public int? maxLimit { get; set; }
        public int? tickCount { get; set; }
        public int? tickInterval { get; set; }
        public int? exponent { get; set; }
        public int? @base { get; set; }
        public string mask { get; set; }
        string ITimeAxis.tickInterval { get; set; }
    }
}


