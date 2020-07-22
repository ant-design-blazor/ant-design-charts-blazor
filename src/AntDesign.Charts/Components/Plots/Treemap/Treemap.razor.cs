using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Treemap<TItem> : ChartComponentBase<ITreemapData<TItem>, TreemapConfig>
    {
        public Treemap() : base("Treemap")
        {

        }
    }
}
