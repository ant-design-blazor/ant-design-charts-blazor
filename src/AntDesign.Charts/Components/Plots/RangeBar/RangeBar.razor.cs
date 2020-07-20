using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class RangeBar<TItem> : ChartComponentBase<IEnumerable<TItem>, RangeBarConfig>
    {
        public RangeBar() : base("RangeBar")
        {

        }
    }
}
