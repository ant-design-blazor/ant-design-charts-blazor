using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedBar : ChartComponentBase<StackedBarConfig>
    {
        public StackedBar() : base("StackedBar")
        {

        }
    }
}


