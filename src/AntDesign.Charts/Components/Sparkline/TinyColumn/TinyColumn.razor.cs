using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class TinyColumn<TItem> : ChartComponentBase<TItem, TinyColumnConfig>
    {
        public TinyColumn() : base("TinyColumn")
        {

        }
    }
}
