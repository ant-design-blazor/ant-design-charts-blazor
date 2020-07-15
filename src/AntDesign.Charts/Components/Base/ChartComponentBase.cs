using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Charts
{
    public abstract class ChartComponentBase<TItem> : ComponentBase
    {
        protected const string CreateChart = "createChart";

        protected abstract string ChartType { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected ElementReference Ref;

        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public string YField { get; set; }

        [Parameter]
        public object OtherConfig { get; set; }

        protected void SetIViewConfig(IViewConfig config)
        {
            if (Data != null) config.data = Data;
            if (string.IsNullOrWhiteSpace(XField) == false) config.xField = XField;
            if (string.IsNullOrWhiteSpace(YField) == false) config.yField = YField;
        }
    }
}
