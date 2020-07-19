using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class DualLine<TItem> : ChartComponentBase<TItem, DualLineConfig>
    {
        public DualLine() : base("DualLine")
        {

        }
    }
}
