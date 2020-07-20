using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedArea<TItem> : ChartComponentBase<IEnumerable<TItem>, StackedAreaConfig>
    {
        public StackedArea() : base("StackedArea")
        {

        }
    }
}
