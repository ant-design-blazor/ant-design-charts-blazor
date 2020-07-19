using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Liquid<TItem> : ChartComponentBase<TItem, LiquidConfig>
    {
        public Liquid() : base("Liquid")
        {

        }
    }
}
