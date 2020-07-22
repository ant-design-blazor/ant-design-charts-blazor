using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedColumnLine<TItem> : ChartComponentBase<IEnumerable<TItem>, StackedColumnLineConfig>
    {
        public StackedColumnLine() : base("StackedColumnLine")
        {

        }
    }
}
