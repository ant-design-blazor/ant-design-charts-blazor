using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Column<TItem> : ChartComponentBase<TItem, ColumnConfig>
    {
        public Column() : base("Column")
        {

        }
    }
}
