using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public interface ITreemapData<TItem>
    {
        public IEnumerable<TItem> Children { get; set; }
        /// <summary>
        /// 所有Children的Value合计
        /// </summary>
        public int Value { get; set; }
    }




}


