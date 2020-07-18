using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class ColumnLine<TItem> : ChartComponentBase<TItem, ColumnLineConfig>
    {
        public ColumnLine() : base("ColumnLine")
        {

        }
    }
}
