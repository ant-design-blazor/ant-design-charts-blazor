using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class PercentStackedBar<TItem> : ChartComponentBase<TItem, PercentStackedBarConfig>
    {
        public PercentStackedBar() : base("PercentStackedBar")
        {

        }
    }
}
