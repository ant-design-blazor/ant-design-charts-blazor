using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Line<TItem> : ComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public string YField { get; set; }

        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "Line", Ref, Data, new
                {
                    xField = XField,
                    yField = YField,
                });
            }
        }
    }
}