using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public partial class Progress : ChartComponentBase<ProgressConfig>
    {
        public Progress() : base("Progress")
        {

        }

        protected override void SetIViewConfig(IViewConfig config)
        {
            base.SetIViewConfig(config);

            ((ProgressConfig)config).Percent = (double?)Data;
        }
    }
}

