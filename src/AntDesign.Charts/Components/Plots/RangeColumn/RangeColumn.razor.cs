using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class RangeColumn<TItem> : ChartComponentBase<IEnumerable<TItem>, RangeColumnConfig>
    {
        public RangeColumn() : base("RangeColumn")
        {

        }
    }
}
