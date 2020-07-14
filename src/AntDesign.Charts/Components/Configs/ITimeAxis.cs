using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ITimeAxis
    {
        public string type { get; set; }// 'time'
        /// <summary>
        ///  tick相关配置 
        /// </summary>
        public string tickInterval { get; set; }
        public int? tickCount { get; set; }
        public string mask { get; set; }
    }
}
