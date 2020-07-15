using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Line<TItem> : ChartComponentBase<TItem>
    {
        [Parameter]
        public BarConfig Config { get; set; }
        protected override string ChartType { get; set; } = "Line";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) Config = new BarConfig();
                SetIViewConfig(Config);
                await JS.InvokeVoidAsync(CreateChart, ChartType, Ref, Config, OtherConfig);
            }
        }
    }
}
