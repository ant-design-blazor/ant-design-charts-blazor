using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bar<TItem> : ChartComponentBase<TItem> 
    {
        [Parameter]
        public BarConfig Config { get; set; }
        protected override string ChartType { get; set; } = "Bar";

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
