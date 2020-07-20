using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Donut<TItem> : ChartComponentBase<IEnumerable<TItem>, DonutConfig>
    {
        public Donut() : base("Donut")
        {

        }
    }
}
