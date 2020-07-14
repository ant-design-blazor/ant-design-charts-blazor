using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bar<TItem> : ChartComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public string YField { get; set; }

        [Parameter]
        public BarConfig Config { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) Config = new BarConfig();
                if (string.IsNullOrWhiteSpace(XField) == false) Config.xField = XField;
                if (string.IsNullOrWhiteSpace(YField) == false) Config.yField = YField;

                await JS.InvokeVoidAsync("createChart", "Bar", Ref, Data, Config, OtherConfig);
            }
        }
    }
}
