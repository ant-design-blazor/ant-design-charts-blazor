using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILayerConfig
    {        /// <summary>
             ///  @ignore 
             /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("x")]
        public int? X { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("y")]
        public int? Y { get; set; }
        /// <summary>
        ///  layer width 
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        ///  layer height 
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("parent")]
        public object Parent { get; set; }//any
        /// <summary>
        ///  @ignore 
        /// </summary>
        [JsonPropertyName("canvas")]
        public object Canvas { get; set; }//ICanvas
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}


