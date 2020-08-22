using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public abstract class ChartComponentBase<TItem, TConfig> : ComponentBase, IChartComponent, IDisposable where TConfig : class, new()
    {
        protected string ChartType { get; set; }

        public ChartComponentBase(string chartType, bool isNoDataRender = false)
        {
            ChartType = chartType;
            IsNoDataRender = isNoDataRender;
        }

        #region JS交互

        [Inject]
        protected IJSRuntime JS { get; set; }

        protected ElementReference Ref;

        protected const string InteropCreate = "AntDesignCharts.interop.create";
        protected const string InteropDestroy = "AntDesignCharts.interop.destroy";
        protected const string InteropRender = "AntDesignCharts.interop.render";
        protected const string InteropRepaint = "AntDesignCharts.interop.repaint";
        protected const string InteropUpdateConfig = "AntDesignCharts.interop.updateConfig";
        protected const string InteropChangeData = "AntDesignCharts.interop.changeData";
        protected const string InteropSetActive = "AntDesignCharts.interop.setActive";
        protected const string InteropSetSelected = "AntDesignCharts.interop.setSelected";
        protected const string InteropSetDisable = "AntDesignCharts.interop.setDisable";
        protected const string InteropSetDefault = "AntDesignCharts.interop.setDefault";
        protected const string InteropSetEvent = "AntDesignCharts.interop.setEvent";

        private DotNetObjectReference<ChartComponentBase<TItem, TConfig>> chartRef;

        #endregion

        #region 图表属性

        [Parameter]
        public TItem Data { get; set; }

        //设置当Data没有数据时，图表是否允许要进行初始化绘制,为了结局某些图表当没有数据时，绘制会发生异常的问题
        protected bool IsNoDataRender { get; set; } = false;

        [Parameter]
        public TConfig Config { get; set; }

        [Parameter]
        public object OtherConfig { get; set; }

        #endregion

        #region 图表事件

        [Parameter]
        public EventCallback<IChartComponent> OnCreateAfter { get; set; }

        #endregion

        /// <summary>
        /// 图表是否已经创建
        /// </summary>
        private bool IsCreated = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) new TConfig();
                if (Config is IViewConfig viewConfig)
                    SetIViewConfig(viewConfig);

                if (Data != null || IsNoDataRender == true)
                    await Create();
            }
        }

        /// <summary>
        /// 设置视图配置，支持重写改写设置方式
        /// </summary>
        /// <param name="config"></param>
        protected virtual void SetIViewConfig(IViewConfig config)
        {
            config.Data = Data;
        }

        public async void Dispose()
        {
            try
            {
                await JS.InvokeVoidAsync(InteropDestroy, Ref.Id);
                chartRef?.Dispose();
            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// 创建图表控件
        /// </summary>
        /// <returns></returns>
        private async Task Create()
        {
            await JS.InvokeVoidAsync(InteropCreate, ChartType, Ref, Ref.Id, Config, OtherConfig, Data);
            IsCreated = true;

            if (OnCreateAfter.HasDelegate)
                await OnCreateAfter.InvokeAsync(this);
            chartRef = DotNetObjectReference.Create(this);

            if (OnTitleClick.HasDelegate)
                await JS.InvokeVoidAsync(InteropSetEvent, Ref.Id, "title:click", chartRef, nameof(JsTitleClick));
        }

        #region 图表操作

        /// <summary>
        /// 绘制图表
        /// </summary>
        /// <returns></returns>
        public async Task Render()
        {
            await JS.InvokeVoidAsync(InteropRender, Ref.Id);
        }

        /// <summary>
        /// 重绘图表
        /// </summary>
        /// <returns></returns>
        public async Task Repaint()
        {
            await JS.InvokeVoidAsync(InteropRepaint, Ref.Id);
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="otherConfig"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public async Task UpdateConfig(object config, object otherConfig, bool all = false)
        {
            Config = (TConfig)config;
            OtherConfig = otherConfig;
            await JS.InvokeVoidAsync(InteropUpdateConfig, Ref.Id, Config, OtherConfig, all);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public async Task ChangeData(object data, bool all = false)
        {
            Data = (TItem)data;
            if (Config is IViewConfig viewConfig)
                SetIViewConfig(viewConfig);

            //根据图表是否已经状态决定调用的函数
            if (IsCreated == true)
            {
                await JS.InvokeVoidAsync(InteropChangeData, Ref.Id, Data, all);
            }
            else
            {
                await Create();
                //await JS.InvokeVoidAsync(InteropCreate, ChartType, Ref, Ref.Id, Config, OtherConfig, Data);
            }
        }
        /// <summary>
        /// 设置激活
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public async Task SetActive(object condition, object style)
        {
            await JS.InvokeVoidAsync(InteropSetActive, Ref.Id, condition, style);
        }
        /// <summary>
        /// 设置选中
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public async Task SetSelected(object condition, object style)
        {
            await JS.InvokeVoidAsync(InteropSetSelected, Ref.Id, condition, style);
        }
        /// <summary>
        /// 设置禁用
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public async Task SetDisable(object condition, object style)
        {
            await JS.InvokeVoidAsync(InteropSetDisable, Ref.Id, condition, style);
        }
        /// <summary>
        /// 设置默认
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public async Task SetDefault(object condition, object style)
        {
            await JS.InvokeVoidAsync(InteropSetDisable, Ref.Id, condition, style);
        }

        #endregion


        #region 图表交互事件

        /// <summary>
        /// 标题点击事件
        /// </summary>
        [Parameter]
        public EventCallback<ChartEvent> OnTitleClick { get; set; }

        [JSInvokable]
        public async Task JsTitleClick(System.Text.Json.JsonElement ev) { if (OnTitleClick.HasDelegate) await OnTitleClick.InvokeAsync(new ChartEvent(this, ev)); }


        #endregion


    }
}
