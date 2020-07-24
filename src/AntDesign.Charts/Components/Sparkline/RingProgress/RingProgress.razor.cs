using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class RingProgress : ChartComponentBase<double, RingProgressConfig>
    {
        public RingProgress() : base("RingProgress")
        {

        }

        protected override void SetIViewConfig(IViewConfig config)
        {
            base.SetIViewConfig(config);

            ((RingProgressConfig)config).Percent = Data;
        }
    }
}

