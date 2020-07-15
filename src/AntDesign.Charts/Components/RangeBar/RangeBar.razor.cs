using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class RangeBar<TItem> : ChartComponentBase<TItem>
    {
        [Parameter]
        public RangeBarConfig Config { get; set; }
        protected override string ChartType { get; set; } = "RangeBar";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) Config = new RangeBarConfig();
                SetIViewConfig(Config);
                await JS.InvokeVoidAsync(CreateChart, ChartType, Ref, Config, OtherConfig);
            }
        }
    }
}
