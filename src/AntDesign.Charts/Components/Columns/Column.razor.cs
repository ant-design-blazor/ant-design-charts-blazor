using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Column <TItem> : ComponentBase
    {

        [Parameter] public bool ForceFit { get; set; } = true;
        [Parameter] public Title Title { get; set; } = new Title();
        [Parameter] public Description Description { get; set; } = new Description();
        [Inject] public IJSRuntime JS { get; set; }

        protected ElementReference Ref;
        [Parameter] public IEnumerable<TItem> Data { get; set; }
        [Parameter] public string YField { get; set; }
        [Parameter] public string XField { get; set; }
        [Parameter] public Label Label { get; set; } = new Label();
        [Parameter] public object Meta { get; set; }
        [Parameter] public EventCallback OnColumnClick { get; set; }            

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "Column", Ref, Data, new
                {
                    forceFit = ForceFit,
                    title = Title ?? new Title(),
                    description = Description ?? new Description(),
                    xField = XField.ToLower(),
                    yField = YField.ToLower(),
                    label = new  { label = Label.Visible },
                    onColumnClick = OnColumnClick,
                }); 
            }
        }
    }
}