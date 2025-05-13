using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace AntDesign.Charts
{
    public abstract class ChartComponentBase<TConfig> : ComponentBase, IChartComponent, IDisposable where TConfig : class, new()
    {
        protected string ChartType { get; set; }
        private ChartEventHandler _eventHandler;

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

        private DotNetObjectReference<ComponentBase> chartRef;

        #endregion

        #region 图表属性

        [Parameter]
        public object Data { get; set; }

        //设置当Data没有数据时，图表是否允许要进行初始化绘制,为了解决某些图表当没有数据时，绘制会发生异常的问题
        protected bool IsNoDataRender { get; set; } = false;

        [Parameter]
        public TConfig Config { get; set; }

        [Parameter]
        public string JsonConfig { get; set; }

        [Parameter]
        public string JsConfig { get; set; }

        [Parameter]
        public object OtherConfig { get; set; }

        #endregion

        #region 图表事件

        /// <summary>
        /// 当图表完成创建后调用
        /// </summary>
        [Parameter]
        public EventCallback<IChartComponent> OnCreateAfter { get; set; }

        /// <summary>
        /// 当图表第一次渲染后触发，可用于填充数据等操作
        /// </summary>
        [Parameter]
        public EventCallback<IChartComponent> OnFirstRender { get; set; }

        /// <summary>
        /// 标题点击事件
        /// </summary>
        [Parameter]
        public EventCallback<ChartEvent> OnTitleClick { get; set; }

        #endregion

        /// <summary>
        /// 图表是否已经创建
        /// </summary>
        private bool IsCreated = false;

        protected override void OnInitialized()
        {
            chartRef = DotNetObjectReference.Create((ComponentBase)this);
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                if (Config == null) Config = new TConfig();
                if (Config is IViewConfig viewConfig)
                    SetIViewConfig(viewConfig);

                // Initialize event handler after Ref is available
                _eventHandler = new ChartEventHandler(this, JS, chartRef, Ref);

                if (OnFirstRender.HasDelegate)
                    await OnFirstRender.InvokeAsync(this);

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

        public void Dispose()
        {
            try
            {
                _ = JS.InvokeVoidAsync(InteropDestroy, Ref.Id);
                chartRef?.Dispose();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Creates the chart control
        /// </summary>
        private async Task Create()
        {
            if (!IsCreated)  // Add null check for Ref.Id
            {
                await JS.InvokeVoidAsync(InteropCreate, ChartType, Ref, Ref.Id, chartRef, Config, OtherConfig, JsonConfig, JsConfig);
                IsCreated = true;
            }
        }

        [JSInvokable]
        public async Task AfterChartRender()
        {
            await _eventHandler.OnChartCreated();

            // Register title click event if it has a delegate
            if (OnTitleClick.HasDelegate)
            {
                On("title:click", async (data) => await OnTitleClick.InvokeAsync(new ChartEvent(this, data)));
            }

            if (OnCreateAfter.HasDelegate)
                await OnCreateAfter.InvokeAsync(this);
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
        /// 更新配置和数据
        /// </summary>
        /// <param name="csConfig"></param>
        /// <param name="csOtherConfig"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public async Task UpdateChart(object csConfig = null, object csOtherConfig = null, string jsonConfig = null, string jsConfig = null, bool all = false, object csData = null)
        {
            if (csConfig != null) Config = (TConfig)csConfig;

            if (Config == null) Config = new TConfig();
            JsonConfig = jsonConfig;
            JsConfig = jsConfig;
            OtherConfig = csOtherConfig;

            if (csData != null && Config is IViewConfig viewConfig)
            {
                Data = csData;
                SetIViewConfig(viewConfig);
            }

            if (!IsCreated)
            {
                await Create();
                IsCreated = true;
            }
            else if (csConfig != null || csOtherConfig != null || !string.IsNullOrWhiteSpace(jsonConfig) || !string.IsNullOrWhiteSpace(jsConfig))
            {
                await JS.InvokeVoidAsync(InteropCreate, ChartType, Ref, Ref.Id, chartRef, Config, OtherConfig, JsonConfig, JsConfig);
            }
            else if (csData != null)
            {
                await JS.InvokeVoidAsync(InteropChangeData, Ref.Id, Data, all);
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
            await JS.InvokeVoidAsync(InteropSetDefault, Ref.Id, condition, style);
        }

        #endregion

        #region 图表交互事件

        /// <summary>
        /// Register an event handler for the chart (async with data)
        /// </summary>
        public void On(string eventName, Func<JsonElement, Task> handler)
        {
            _eventHandler.On(eventName, handler);
        }

        /// <summary>
        /// Register an event handler for the chart (sync with data)
        /// </summary>
        public void On(string eventName, Action<JsonElement> handler)
        {
            _eventHandler.On(eventName, handler);
        }

        /// <summary>
        /// Register an event handler for the chart (async without data)
        /// </summary>
        public void On(string eventName, Func<Task> handler)
        {
            _eventHandler.On(eventName, handler);
        }

        /// <summary>
        /// Register an event handler for the chart (sync without data)
        /// </summary>
        public void On(string eventName, Action handler)
        {
            _eventHandler.On(eventName, handler);
        }

        [JSInvokable]
        public Task InvokeEventHandler(string eventName, JsonElement data) => _eventHandler.InvokeEventHandler(eventName, data);

        #endregion

        /// <summary>
        /// Updates configuration only
        /// </summary>
        public Task UpdateConfig(object config = null, object otherConfig = null, bool all = false)
        {
            return UpdateChart(config, otherConfig, all: all);
        }

        /// <summary>
        /// Updates data only
        /// </summary>
        public Task ChangeData(object data, bool all = false)
        {
            return UpdateChart(csData: data, all: all);
        }
    }
}
