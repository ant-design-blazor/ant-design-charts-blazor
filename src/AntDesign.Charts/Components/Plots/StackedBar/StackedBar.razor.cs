using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedBar<TItem> : ChartComponentBase<TItem, StackedBarConfig>
    {
        public StackedBar() : base("StackedBar")
        {

        }
    }
}
