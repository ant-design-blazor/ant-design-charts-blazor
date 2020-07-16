using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class PercentStackedArea<TItem> : ChartComponentBase<TItem, PercentStackedAreaConfig>
    {
        public PercentStackedArea() : base("PercentStackedArea")
        {

        }
    }
}
