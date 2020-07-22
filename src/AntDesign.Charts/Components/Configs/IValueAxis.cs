using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public interface IValueAxis : IBaseAxis
    {
        public string type { get; set; }//OneOf <'linear' , 'pow' , 'log'>
        public static string TypeLinear = "linear";
        public static string TypePow = "pow";
        public static string TypeLog = "log";

        /// <summary>
        ///  tick相关配置 
        /// </summary>
        public bool? nice { get; set; }
        public double? min { get; set; }
        public double? max { get; set; }
        public int? minLimit { get; set; }
        public int? maxLimit { get; set; }
        public int? tickCount { get; set; }
        public int? tickInterval { get; set; }
        /// <summary>
        ///  pow 指数 
        /// </summary>
        public int? exponent { get; set; }
        /// <summary>
        ///  log 基数 
        /// </summary>
        [JsonPropertyName("base")]
        public int? Base { get; set; }

    }

    public class ValueAxis : IValueAxis
    {
        public string type { get; set; }
        public bool? nice { get; set; }
        public double? min { get; set; }
        public double? max { get; set; }
        public int? minLimit { get; set; }
        public int? maxLimit { get; set; }
        public int? tickCount { get; set; }
        public int? tickInterval { get; set; }
        public int? exponent { get; set; }
        [JsonPropertyName("base")]
        public int? Base { get; set; }
        public bool visible { get; set; }
        public string tickMethod { get; set; }
        public BaseAxisLine line { get; set; }
        public BaseAxisGrid grid { get; set; }
        public BaseAxisLabel label { get; set; }
        public BaseAxisTitle title { get; set; }
        public BaseAxisTickLine tickLine { get; set; }
    }
}
