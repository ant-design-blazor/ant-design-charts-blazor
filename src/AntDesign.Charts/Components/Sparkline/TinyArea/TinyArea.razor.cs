using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class TinyArea<TItem> : ChartComponentBase<IEnumerable<TItem>, TinyAreaConfig>
    {
        public TinyArea() : base("TinyArea")
        {

        }
    }
}
