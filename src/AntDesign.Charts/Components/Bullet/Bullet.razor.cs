using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bullet<TItem> : ChartComponentBase<TItem, BulletConfig>
    {
        public Bullet() : base("Bullet")
        {

        }
    }
}
