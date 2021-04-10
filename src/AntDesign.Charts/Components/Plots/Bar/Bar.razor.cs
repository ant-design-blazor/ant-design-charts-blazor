using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bar : ChartComponentBase<BarConfig>
    {
        public Bar() : base("Bar")
        {

        }
    }
}


