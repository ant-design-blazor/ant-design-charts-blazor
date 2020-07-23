using System.Text.Json.Serialization;

namespace AntDesign.Charts
{
    public class ValueOptions
    {
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("style")]
        public object Style { get; set; }//any
        //  formatter?: (valueUpper: any, valueLower: any) => string;
    }
}


