using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Progress<TItem> : ChartComponentBase<TItem, ProgressConfig>
    {
        public Progress() : base("Progress")
        {

        }
    }
}
