using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class DualLineConfig : IDualLineViewConfig, IPlotConfig
    {
        public ValueCatTimeAxis xAxis { get; set; }
        public object tooltip { get; set; }
        public LineConfig[] lineConfigs { get; set; }
        public ITitle title { get; set; }
        public IDescription description { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string xField { get; set; }
        public string[] yField { get; set; }
        public ComboYAxis yAxis { get; set; }
        public ComboLegendConfig legend { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public string renderer { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public string theme { get; set; }
        public bool? localRefresh { get; set; }
        public string padding { get; set; }
        public string[] color { get; set; }
        public Label label { get; set; }
        public object animation { get; set; }
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        string IViewConfig.yField { get; set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
        Tooltip IViewConfig.tooltip { get; set; }
        Legend IViewConfig.legend { get; set; }
        Title IViewConfig.title { get; set; }
        Description IViewConfig.description { get; set; }
    }

    public interface IDualLineViewConfig : IComboViewConfig
    {
        public ValueCatTimeAxis xAxis { get; set; }//OneOf<IValueAxis, ICatAxis, ITimeAxis>
        public object tooltip { get; set; }
        public LineConfig[] lineConfigs { get; set; }
    }

    public interface IComboViewConfig : IViewConfig
    {
        public ITitle title { get; set; }
        public IDescription description { get; set; }
        public object data { get; set; }//DataItem[][]
        public object meta { get; set; }//LooseMap<Meta>
        public string xField { get; set; }
        public string[] yField { get; set; }
        public ComboYAxis yAxis { get; set; }
        public ComboLegendConfig legend { get; set; }
        /*
          events?: {
            [k: string]: ((...args: any[]) => any) | boolean;
          };
         */
    }

    public interface IComboYAxis
    {
        public int? max { get; set; }
        public int? min { get; set; }
        public int? tickCount { get; set; }
        public ComboYAxisConfig leftConfig { get; set; }
        public ComboYAxisConfig rightConfig { get; set; }
    }

    public interface IComboYAxisConfig : IValueAxis
    {
        public bool? colorMapping { get; set; }
    }

    public class ComboYAxisConfig : IComboYAxisConfig
    {
        public bool? colorMapping { get; set; }
        public string type { get; set; }
        public bool? nice { get; set; }
        public double? min { get; set; }
        public double? max { get; set; }
        public int? minLimit { get; set; }
        public int? maxLimit { get; set; }
        public int? tickCount { get; set; }
        public int? tickInterval { get; set; }
        public int? exponent { get; set; }
        public int? @base { get; set; }
        public bool visible { get; set; }
        public string tickMethod { get; set; }
        public BaseAxisLine line { get; set; }
        public BaseAxisGrid grid { get; set; }
        public BaseAxisLabel label { get; set; }
        public BaseAxisTitle title { get; set; }
        public BaseAxisTickLine tickLine { get; set; }
    }

    public class ComboYAxis : IComboYAxis
    {
        public int? max { get; set; }
        public int? min { get; set; }
        public int? tickCount { get; set; }
        public ComboYAxisConfig leftConfig { get; set; }
        public ComboYAxisConfig rightConfig { get; set; }
    }

    public interface IComboLegendConfig
    {
        public bool? visible { get; set; }
        public ComboLegendConfigMarker marker { get; set; }
        public ComboLegendConfigText text { get; set; }
    }

    public class ComboLegendConfigMarker
    {
        public string symbol { get; set; }
        public object style { get; set; }

    }
    public class ComboLegendConfigText
    {
        public TextStyle style { get; set; }
        //public (value: string) => string formatter { get; set; }
    }

    public class ComboLegendConfig : IComboLegendConfig
    {
        public bool? visible { get; set; }
        public ComboLegendConfigMarker marker { get; set; }
        public ComboLegendConfigText text { get; set; }
    }
}
