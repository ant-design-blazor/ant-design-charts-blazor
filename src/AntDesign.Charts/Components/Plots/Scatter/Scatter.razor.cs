using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Scatter<TItem> : ChartComponentBase<IEnumerable<TItem>, ScatterConfig>
    {
        public Scatter() : base("Scatter")
        {

        }
    }
}
