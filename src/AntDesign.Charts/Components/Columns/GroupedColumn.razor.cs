using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class GroupedColumn<TItem> : ComponentBase
    {
        [Parameter] public IEnumerable<TItem> Data { get; set; }
        [Parameter] public bool ForceFit { get; set; } = true;
        [Parameter] public IEnumerable<string> Color { get; set; }
        [Parameter] public string XField { get; set; }
        [Parameter] public string YField { get; set; }
        [Parameter] public long Width { get; set; } = 400;
        [Parameter] public long Height { get; set; } = 400;
        [Parameter] public string GroupField { get; set; }
        [Parameter] public Title Title { get; set; }
        [Parameter] public Description Description { get; set; }
        [Parameter] public Label Label { get; set; } = new Label();
        [Parameter] public Legend Legend { get; set; } = new Legend();

        [Inject] private IJSRuntime JS { get; set; }

        private ElementReference Ref;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await JS.InvokeVoidAsync("createChart", "GroupedColumn", Ref, Data, new
                {
                    width = Width,
                    height = Height,
                    forceFit = ForceFit,
                    title = Title ?? new Title(),
                    description = Description ?? new Description(),
                    label = new { visible = Label.Visible, position = Label.Position },
                    xField = XField.ToLower(),
                    yField = YField.ToLower(),
                    legend =  new  { visible = Legend.Visible, position = Legend.Position },
                    groupField = GroupField.ToLower(),
                });             }
        }

    }
}
