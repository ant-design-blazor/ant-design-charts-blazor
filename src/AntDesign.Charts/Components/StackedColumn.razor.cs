using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StackedColumn<TItem> : ComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public bool ForceFit { get; set; } = true;

        [Parameter]
        public IEnumerable<string> Color { get; set; }

        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public Title Title { get; set; }

        [Parameter]
        public Description Description { get; set; }

        [Parameter]
        public Label Label { get; set; }

        [Parameter]
        public Legend Legend { get; set; }

        [Parameter]
        public string YField { get; set; }

        [Parameter]
        public string StackField { get; set; }

        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "StackedColumn", Ref, Data, new
                {
                    forceFit = ForceFit,
                    title = Title,
                    description = Description,
                    label = Label,
                    color = Color,               
                    xField = XField,
                    yField = YField,               
                    stackField = StackField,
                    legend = Legend,
                }); 
            }
        }
    }
}