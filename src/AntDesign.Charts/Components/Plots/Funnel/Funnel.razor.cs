using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Funnel<TItem> : ChartComponentBase<TItem, FunnelConfig>
    {
        public Funnel() : base("Funnel")
        {

        }
    }
}
