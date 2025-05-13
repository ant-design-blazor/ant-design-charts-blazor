using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AntDesign.Charts
{
    public interface IChartComponent
    {
        /// <summary>
        /// Register an event handler for the chart (async with data)
        /// </summary>
        void On(string eventName, Func<JsonElement, Task> handler);

        /// <summary>
        /// Register an event handler for the chart (sync with data)
        /// </summary>
        void On(string eventName, Action<JsonElement> handler);

        /// <summary>
        /// Register an event handler for the chart (async without data)
        /// </summary>
        void On(string eventName, Func<Task> handler);

        /// <summary>
        /// Register an event handler for the chart (sync without data)
        /// </summary>
        void On(string eventName, Action handler);

        /// <summary>
        /// Renders the chart with current configuration
        /// </summary>
        Task Render();

        /// <summary>
        /// Repaints the chart, typically used after layout changes
        /// </summary>
        Task Repaint();

        /// <summary>
        /// Updates chart configuration and data
        /// </summary>
        /// <param name="config">New chart configuration</param>
        /// <param name="otherConfig">Additional configuration options</param>
        /// <param name="jsonConfig">JSON format configuration string</param>
        /// <param name="jsConfig">JavaScript format configuration string</param>
        /// <param name="all">Whether to update all data</param>
        /// <param name="data">New chart data</param>
        Task UpdateChart(object config = null, object otherConfig = null, string jsonConfig = null, string jsConfig = null, bool all = false, object data = null);

        /// <summary>
        /// Updates chart configuration only
        /// </summary>
        /// <param name="config">New chart configuration</param>
        /// <param name="otherConfig">Additional configuration options</param>
        /// <param name="all">Whether to update all configuration</param>
        Task UpdateConfig(object config = null, object otherConfig = null, bool all = false);

        /// <summary>
        /// Updates chart data only
        /// </summary>
        /// <param name="data">New chart data</param>
        /// <param name="all">Whether to update all data</param>
        Task ChangeData(object data, bool all = false);

        /// <summary>
        /// Sets elements to active state based on condition
        /// </summary>
        /// <param name="condition">Condition to select elements</param>
        /// <param name="style">Style to apply to active elements</param>
        Task SetActive(object condition, object style);

        /// <summary>
        /// Sets elements to selected state based on condition
        /// </summary>
        /// <param name="condition">Condition to select elements</param>
        /// <param name="style">Style to apply to selected elements</param>
        Task SetSelected(object condition, object style);

        /// <summary>
        /// Sets elements to disabled state based on condition
        /// </summary>
        /// <param name="condition">Condition to select elements</param>
        /// <param name="style">Style to apply to disabled elements</param>
        Task SetDisable(object condition, object style);

        /// <summary>
        /// Resets elements to default state based on condition
        /// </summary>
        /// <param name="condition">Condition to select elements</param>
        /// <param name="style">Style to apply to default elements</param>
        Task SetDefault(object condition, object style);
    }
}
