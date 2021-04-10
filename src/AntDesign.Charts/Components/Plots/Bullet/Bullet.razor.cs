using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Bullet : ChartComponentBase<BulletConfig>
    {
        public Bullet() : base("Bullet", isNoDataRender: true)
        {

        }
    }
}


