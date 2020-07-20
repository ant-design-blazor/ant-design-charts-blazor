using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public interface IChartComponent
    {
        /// <summary>
        /// 立即渲染
        /// </summary>
        /// <returns></returns>
        Task Render();

        /// <summary>
        /// 追加渲染，等到下一次渲染是进行重新渲染
        /// </summary>
        void AppendRender();

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="data"></param>
        void SetData(object data);
    }
}
