using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class BulletConfig : IBulletViewConfig, IPlotConfig
    {
        public BulletViewConfigData[] data { get; set; }
        public int? rangeMax { get; set; }
        public int? measureSize { get; set; }
        public string[] measureColors { get; set; }
        public int? rangeSize { get; set; }
        public string[] rangeColors { get; set; }
        public int? markerSize { get; set; }
        public string[] markerColors { get; set; }
        public string renderer { get; set; }
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
        [JsonIgnore]
        public OneOf<string, object> theme { get; set; }
        [JsonPropertyName("theme")]
        public object themeMapping => theme.Value;
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
        object IViewConfig.data { get; set; }
    }

    public interface IBulletViewConfig : IViewConfig
    {
        public BulletViewConfigData[] data { get; set; }
        /// <summary>
        ///  进度条的色条范围区间的最大值 
        /// </summary>
        public int? rangeMax { get; set; }
        /// <summary>
        ///  实际进度条大小设置 
        /// </summary>
        public int? measureSize { get; set; }
        public string[] measureColors { get; set; }
        /// <summary>
        ///  区间背景条大小设置。ratio number, relative to measureSize 
        /// </summary>
        public int? rangeSize { get; set; }
        /// <summary>
        ///  进度条背景颜色 
        /// </summary>
        public string[] rangeColors { get; set; }
        /// <summary>
        ///  目标值 marker 大小设置。ratio number, relative to measureSize 
        /// </summary>
        public int? markerSize { get; set; }
        /// <summary>
        ///  marker 的填充色 
        /// </summary>
        public string[] markerColors { get; set; }
    }

    public class BulletViewConfigData
    {
        /// <summary>
        ///  子弹图标题 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        ///  进度值，array类型。支持阶段性的进度值（即堆叠） 
        /// </summary>
        public int[] measures { get; set; }
        /// <summary>
        ///  进度条的色条范围区间，相对数值：[0, 1] 
        /// </summary>
        public int[] ranges { get; set; }
        /// <summary>
        ///  目标值，array类型。支持多目标设置 
        /// </summary>
        public int[] targets { get; set; }

        public BulletViewConfigMarkerStyle markerStyle { get; set; }
        /// <summary>
        ///  进度条刻度轴设置 
        /// </summary>
        public BulletAxis axis { get; set; }
        public string stackField { get; set; }
    }

    public class BulletViewConfigMarkerStyle
    {
        /// <summary>
        ///  marker 的宽度，default: 1 
        /// </summary>
        public int? width { get; set; }
        /// <summary>
        ///  marker 的填充色, 若存在 markerColors, 优先取 markerColors 
        /// </summary>
        public string fill { get; set; }
        /*   
         [k: string]: any;
         */
    }

    public interface IBulletAxis
    {
        public bool? visible { get; set; }
        /// <summary>
        /// 'before','after'
        /// </summary>
        public string position { get; set; } //OneOf <'before','after'>
        public static string PositionBefore = "before";
        public static string PositionAfter = "after";

        public TextStyle style { get; set; }
        public int? tickCount { get; set; }
        public BulletAxisTickLine tickLine { get; set; }
        public string formatter { get; set; }//(text: string, idx: number) => string
    }

    public interface IBulletAxisTickLine : ILineStyle
    {
        public bool? visible { get; set; }
    }

    public class BulletAxisTickLine : IBulletAxisTickLine
    {
        public bool? visible { get; set; }
        public string stroke { get; set; }
        public int? lineWidth { get; set; }
        public int[] lineDash { get; set; }
        public int? lineOpacity { get; set; }
        public string shadowColor { get; set; }
        public int? shadowBlur { get; set; }
        public int? shadowOffsetX { get; set; }
        public int? shadowOffsetY { get; set; }
        public string cursor { get; set; }
    }

    public class BulletAxis : IBulletAxis
    {
        public bool? visible { get; set; }
        public string position { get; set; }
        public TextStyle style { get; set; }
        public int? tickCount { get; set; }
        public BulletAxisTickLine tickLine { get; set; }
        public string formatter { get; set; }
    }
}
