using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class RoseConfig : IRoseViewConfig, IPlotConfig
    {
        public string radiusField { get; set; }
        public string categoryField { get; set; }
        public string colorField { get; set; }
        public double? radius { get; set; }
        public double? innerRadius { get; set; }
        public GraphicStyle sectorStyle { get; set; }
        public RoseLabel label { get; set; }
        public string renderer { get; set; }
        public object data { get; set; }
        public object meta { get; set; }
        public string padding { get; set; }
        public string xField { get; set; }
        public string yField { get; set; }
        public string[] color { get; set; }
        public Axis xAxis { get; set; }
        public Axis yAxis { get; set; }
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
        Label IViewConfig.label { get; set; }
    }

    public interface IRoseViewConfig : IViewConfig
    {
        public string radiusField { get; set; }
        public string categoryField { get; set; }
        public string colorField { get; set; }
        public double? radius { get; set; }
        public double? innerRadius { get; set; }
        /// <summary>
        ///  每个扇形切片的样式 
        /// </summary>
        public GraphicStyle sectorStyle { get; set; }//OneOf<GraphicStyle, ((...args: any[]) => GraphicStyle)>
        public RoseLabel label { get; set; }
    }

    public interface IRoseLabel : ILabel
    {
        /// <summary>
        /// 'outer','inner'
        /// </summary>
        public string type { get; set; }// OneOfn<'outer','inner'>
        public static string TypeOuter = "outer";
        public static string TypeInner = "inner";

        /// <summary>
        ///  自动调整颜色 
        /// </summary>
        public bool? adjustColor { get; set; }
        /// <summary>
        ///  自动旋转 
        /// </summary>
        public bool? autoRotate { get; set; }

        /// <summary>
        /// label的内容，如果不配置，读取scale中的第一个field对应的值  G2 4.0 就这样实现的
        /// </summary>
        public string content { get; set; }//string | ((...args: any[]) => string);
    }
    public class RoseLabel : IRoseLabel
    {
        public string type { get; set; }
        public bool? adjustColor { get; set; }
        public bool? autoRotate { get; set; }
        public string content { get; set; }
        public bool? visible { get; set; }
        public int? precision { get; set; }
        public string suffix { get; set; }
        public TextStyle style { get; set; }
        public int? offset { get; set; }
        public int? offsetX { get; set; }
        public int? offsetY { get; set; }
        public string position { get; set; }
        public bool? adjustPosition { get; set; }
        public string field { get; set; }
    }
}
