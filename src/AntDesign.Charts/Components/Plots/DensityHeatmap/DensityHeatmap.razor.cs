using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    [Obsolete("No longer supported, use HeatMap Instead")]
    public partial class DensityHeatmap : ChartComponentBase<DensityHeatmapConfig>
    {
        public DensityHeatmap() : base("DensityHeatmap")
        {

        }
    }
}


