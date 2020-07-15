using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class PercentStackedBar<TItem> : ChartComponentBase<TItem> 
    {
        [Parameter]
        public PercentStackedBarConfig Config { get; set; }
        protected override string ChartType { get; set; } = "PercentStackedBar";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) Config = new PercentStackedBarConfig();
                SetIViewConfig(Config);
                await JS.InvokeVoidAsync(CreateChart, ChartType, Ref, Config, OtherConfig);
            }
        }
    }
}
