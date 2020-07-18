using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Radar<TItem> : ChartComponentBase<TItem, RadarConfig>
    {
        public Radar() : base("Radar")
        {

        }
    }
}
