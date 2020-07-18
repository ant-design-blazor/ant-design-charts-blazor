using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class GroupedColumnLine<TItem> : ChartComponentBase<TItem, GroupedColumnLineConfig>
    {
        public GroupedColumnLine() : base("GroupedColumnLine")
        {

        }
    }
}
