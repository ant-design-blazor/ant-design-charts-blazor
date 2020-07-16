using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class StepLine<TItem> : ChartComponentBase<TItem, StepLineConfig>
    {
        public StepLine() : base("StepLine")
        {

        }
    }
}
