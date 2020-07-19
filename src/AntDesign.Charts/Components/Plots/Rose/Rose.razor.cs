using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Rose<TItem> : ChartComponentBase<TItem, RoseConfig>
    {
        public Rose() : base("Rose")
        {

        }
    }
}
