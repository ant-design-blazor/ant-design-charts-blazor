using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Line<TItem> : ChartComponentBase<TItem, LineConfig>
    {
        public Line() : base("Line")
        {

        }
    }
}
