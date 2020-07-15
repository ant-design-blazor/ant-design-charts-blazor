using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ILayerConfig
    {        /// <summary>
             ///  @ignore 
             /// </summary>
        public string id { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        public int? x { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        public int? y { get; set; }
        /// <summary>
        ///  layer width 
        /// </summary>
        public int? width { get; set; }
        /// <summary>
        ///  layer height 
        /// </summary>
        public int? height { get; set; }
        /// <summary>
        ///  @ignore 
        /// </summary>
        public object parent { get; set; }//any
        /// <summary>
        ///  @ignore 
        /// </summary>
        public object canvas { get; set; }//ICanvas
        public string name { get; set; }
    }
}
