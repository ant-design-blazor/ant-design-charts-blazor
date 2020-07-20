using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Waterfall<TItem> : ChartComponentBase<IEnumerable<TItem>, WaterfallConfig>
    {
        public Waterfall() : base("Waterfall")
        {

        }
    }
}
