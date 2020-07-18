using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class DensityHeatmap<TItem> : ChartComponentBase<TItem, DensityHeatmapConfig>
    {
        public DensityHeatmap() : base("DensityHeatmap")
        {

        }
    }
}
