using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedColumn<TItem> : ChartComponentBase<TItem, StackedColumnConfig>
    {
        public StackedColumn() : base("StackedColumn")
        {

        }
    }
}
