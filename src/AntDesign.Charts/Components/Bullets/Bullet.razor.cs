using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bullet<TItem> : ComponentBase
    {
        [Parameter] public IEnumerable<TItem> Data { get; set; }
        [Parameter] public bool ForceFit { get; set; } = true;
        [Parameter] public IEnumerable<string> RangeColors { get; set; }
        [Parameter] public int RangeMax { get; set; }
        [Parameter] public long Width { get; set; } = 400;
        [Parameter] public long Height { get; set; } = 400; 
        [Parameter] public Title Title { get; set; }
        [Parameter] public Description Description { get; set; } 
        [Parameter] public Legend Legend { get; set; }
        [Parameter] public ToolTip ToolTip { get; set; }

        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "Bullet", Ref, Data, new
                {
                    width = Width,
                    height = Height,                  
                    forceFit = ForceFit,
                    title = Title ?? new Title(),                
                    description = Description ?? new Description(),
                    rangeMax = RangeMax,
                    rangeColors = RangeColors,
                });
            }
        }

    }
}
