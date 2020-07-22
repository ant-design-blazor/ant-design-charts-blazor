using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class GroupedColumnLineConfig : IGroupedColumnLineViewConfig, IPlotConfig
    {
        public string columnGroupField { get; set; }
        public CatAxis xAxis { get; set; }
        public object tooltip { get; set; }
        public string lineSeriesField { get; set; }
        public LineConfig lineConfig { get; set; }
        public ColumnConfig columnConfig { get; set; }
        public ITitle title { get; set; }
        public IDescription description { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string xField { get; set; }
        public string[] yField { get; set; }
        public ComboYAxis yAxis { get; set; }
        public ComboLegendConfig legend { get; set; }
        public string renderer { get; set; }
        public string padding { get; set; }
        public string[] color { get; set; }
        public Label label { get; set; }
        public object animation { get; set; }
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
        public object responsiveTheme { get; set; }
        public Interaction[] interactions { get; set; }
        public bool? responsive { get; set; }
        public GuideLineConfig[] guideLine { get; set; }
        public ViewConfigDefaultState defaultState { get; set; }
        public string name { get; set; }
        public bool? forceFit { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? pixelRatio { get; set; }
        public bool? localRefresh { get; set; }
        string IViewConfig.yField { get; set; }
        Axis IViewConfig.xAxis { get; set; }
        Axis IViewConfig.yAxis { get; set; }
        Tooltip IViewConfig.tooltip { get; set; }
        Legend IViewConfig.legend { get; set; }
        Title IViewConfig.title { get; set; }
        Description IViewConfig.description { get; set; }
    }

    public interface IGroupedColumnLineViewConfig : IColumnLineViewConfig
    {
        public string columnGroupField { get; set; }
    }
}
