using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public class AntComponentBase: ComponentBase
    {
        [Parameter] public bool ForceFit { get; set; } = true;
        [Parameter] public Title Title { get; set; } = new Title();
        [Parameter] public Description Description { get; set; } = new Description();

        [Inject] public IJSRuntime JS { get; set; }

        protected ElementReference Ref;

    }
}
