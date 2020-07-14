using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public abstract class ChartComponentBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JS { get; set; }

        protected ElementReference Ref;


        [Parameter]
        public object OtherConfig { get; set; }
    }
}
