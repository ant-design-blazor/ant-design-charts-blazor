using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Column<TItem> : ComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public bool ForceFit { get; set; } = true;


        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public Title Title { get; set; }

        [Parameter]
        public Label Label { get; set; }

        [Parameter]
        public Legend Legend { get; set; }

        [Parameter]
        public string YField { get; set; }


        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var type = new { alias = "类别" };
            var sales = new { alias = "销售额(万)" };

            var Meta = new { type, sales };

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "Column", Ref, Data, new
                {
                    forceFit = ForceFit,
                    title = Title,                           
                    xField = XField,
                    yField = YField, 
                    lebel = Label,
                    meta = Meta,

                }); 
            }
        }
    }
}