﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Histogram<TItem> : ChartComponentBase<IEnumerable<TItem>, HistogramConfig>
    {
        public Histogram() : base("Histogram")
        {

        }
    }
}
