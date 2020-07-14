using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Pie<TItem> : ComponentBase
    {
        [Parameter] public IEnumerable<TItem> Data { get; set; }
        [Parameter] public bool ForceFit { get; set; } = true;
        [Parameter] public string[] Color { get; set; }
        [Parameter] public string AngleField { get; set; }
        [Parameter] public string ColorField { get; set; }
        [Parameter] public long Width { get; set; } = 400;
        [Parameter] public long Height { get; set; } = 400;
        [Parameter] public double Radius { get; set; }
        [Parameter] public Title Title { get; set; }
        [Parameter] public Description Description { get; set; }
        [Parameter] public Label Label { get; set; }
        [Parameter] public Legend Legend { get; set; }

        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "Pie", Ref, Data, new
                {
                    width = Width,
                    height = Height,
                    angleField = AngleField.ToLower(),
                    colorField = ColorField.ToLower(),
                    radius = Radius,
                    forceFit = ForceFit,
                    title = Title ?? new Title(),
                    label = new { visible = true, type = "outer" },
                    description = Description ?? new Description(), 
                                          
                });
            }
        }

    }
}
