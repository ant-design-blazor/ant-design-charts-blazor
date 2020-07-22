using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class TinyLine<TItem> : ChartComponentBase<IEnumerable<TItem>, TinyLineConfig>
    {
        public TinyLine() : base("TinyLine")
        {

        }
    }
}
