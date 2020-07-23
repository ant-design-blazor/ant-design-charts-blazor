using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Area<TItem> : ChartComponentBase<IEnumerable<TItem>, AreaConfig>
    {
        public Area() : base("Area")
        {

        }
    }
}


