using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class PercentStackedColumn<TItem> : ChartComponentBase<IEnumerable<TItem>, PercentStackedColumnConfig>
    {
        public PercentStackedColumn() : base("PercentStackedColumn")
        {

        }
    }
}
