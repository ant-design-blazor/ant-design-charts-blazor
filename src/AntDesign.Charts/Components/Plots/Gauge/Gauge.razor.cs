using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Gauge<TItem> : ChartComponentBase<TItem, GaugeConfig>
    {
        public Gauge() : base("Gauge")
        {

        }
    }
}
