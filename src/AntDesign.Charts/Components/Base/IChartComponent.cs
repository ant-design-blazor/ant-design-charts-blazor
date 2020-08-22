using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public interface IChartComponent
    {
        public Task Render();

        public Task Repaint();

        public Task UpdateConfig(object config, object otherConfig = null, bool all = false);

        public Task ChangeData(object data, bool all = false);

        public Task SetActive(object condition, object style);

        public Task SetSelected(object condition, object style);

        public Task SetDisable(object condition, object style);

        public Task SetDefault(object condition, object style);
    }
}
