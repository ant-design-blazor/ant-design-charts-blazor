using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface IMeta
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }
        //  formatter?: (v: any) => string;
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
        [JsonPropertyName("range")]
        public int[] Range { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }//OneOf <'linear','time','timeCat','cat','pow','log'>

        public static string TypeLinear = "linear";
        public static string TypeTime = "time";
        public static string TypeTimeCat = "timeCat";
        public static string TypeCat = "cat";
        public static string TypePow = "pow";
        public static string TypeLog = "log";
    }

    public class Meta : IMeta
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
        [JsonPropertyName("range")]
        public int[] Range { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}


