using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public abstract class ChartComponentBase<TItem, TConfig> : ComponentBase, IChartComponent where TConfig : class, new()
    {
        public ChartComponentBase(string chartType)
        {
            ChartType = chartType;
        }

        #region 脚本交互

        protected const string CreateChart = "createChart";
        protected string ChartType { get; set; }

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected ElementReference Ref;

        public bool NeedRedraw = false;

        #endregion 脚本交互

        #region 图表属性

        public TItem _Data;

        [Parameter]
        public TItem Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
            }
        }

        [Parameter]
        public string XField { get; set; }

        [Parameter]
        public string YField { get; set; }

        [Parameter]
        public TConfig Config { get; set; }

        [Parameter]
        public object OtherConfig { get; set; }

        #endregion 图表属性

        /// <summary>
        /// 设置视图配置，支持重写改写设置方式
        /// </summary>
        /// <param name="config"></param>
        protected virtual void SetIViewConfig(IViewConfig config)
        {
            if (Data != null) config.data = Data;
            if (string.IsNullOrWhiteSpace(XField) == false) config.xField = XField;
            if (string.IsNullOrWhiteSpace(YField) == false) config.yField = YField;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender || NeedRedraw == true)
            {
                NeedRedraw = false;
                //Console.WriteLine(NeedRedraw);
                await Render();
            }
        }

        /// <summary>
        /// 立即渲染图形
        /// </summary>
        /// <returns></returns>
        public async Task Render()
        {
            if (Config == null) new TConfig();
            if (Config is IViewConfig viewConfig)
                SetIViewConfig(viewConfig);
            await JS.InvokeVoidAsync(CreateChart, ChartType, Ref, Config, OtherConfig);
        }

        /// <summary>
        /// 标记绘制状态，在下次OnAfterRenderAsync时渲染
        /// </summary>
        public void AppendRender()
        {
            NeedRedraw = true;
        }

        /// <summary>
        /// 设置属性并在下次OnAfterRenderAsync时渲染
        /// </summary>
        /// <param name="data"></param>
        public void SetData(object data)
        {
            Data = (TItem)data;
            AppendRender();
        }
    }
}
