using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace AntDesign.Charts
{
    internal class ChartEventHandler
    {
        private readonly Dictionary<string, List<Func<JsonElement, Task>>> _eventHandlers = new Dictionary<string, List<Func<JsonElement, Task>>>();
        private readonly HashSet<string> _registeredJsEvents = new HashSet<string>();
        private readonly ComponentBase _component;
        private readonly IJSRuntime _js;
        private readonly DotNetObjectReference<ComponentBase> _chartRef;
        private readonly ElementReference _elementRef;

        public ChartEventHandler(
            ComponentBase component,
            IJSRuntime js,
            DotNetObjectReference<ComponentBase> chartRef,
            ElementReference elementRef)
        {
            _component = component;
            _js = js;
            _chartRef = chartRef;
            _elementRef = elementRef;
        }

        /// <summary>
        /// Register an event handler for the chart (async with data)
        /// </summary>
        public void On(string eventName, Func<JsonElement, Task> handler)
        {
            RegisterEventHandlerInternal(eventName, handler);
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register an event handler for the chart (sync with data)
        /// </summary>
        public void On(string eventName, Action<JsonElement> handler)
        {
            RegisterEventHandlerInternal(eventName, (data) =>
            {
                handler(data);
                return Task.CompletedTask;
            });
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register an event handler for the chart (async without data)
        /// </summary>
        public void On(string eventName, Func<Task> handler)
        {
            RegisterEventHandlerInternal(eventName, (_) => handler());
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register an event handler for the chart (sync without data)
        /// </summary>
        public void On(string eventName, Action handler)
        {
            RegisterEventHandlerInternal(eventName, (_) =>
            {
                handler();
                return Task.CompletedTask;
            });
            TryRegisterJsEvent(eventName);
        }

        private void RegisterEventHandlerInternal(string eventName, Func<JsonElement, Task> handler)
        {
            if (!_eventHandlers.ContainsKey(eventName))
            {
                _eventHandlers[eventName] = new List<Func<JsonElement, Task>>();
            }

            if (!_eventHandlers[eventName].Contains(handler))
            {
                _eventHandlers[eventName].Add(handler);
            }
        }

        private void TryRegisterJsEvent(string eventName)
        {
            if (!_registeredJsEvents.Contains(eventName))
            {
                _ = RegisterJsEventAsync(eventName);
            }
        }

        private async Task RegisterJsEventAsync(string eventName)
        {
            if (!_registeredJsEvents.Contains(eventName))
            {
                await _js.InvokeVoidAsync("AntDesignCharts.interop.setEvent", _elementRef.Id, eventName, _chartRef, eventName);
                _registeredJsEvents.Add(eventName);
            }
        }

        public async Task InvokeEventHandler(string eventName, JsonElement data)
        {
            if (_eventHandlers.TryGetValue(eventName, out var handlers))
            {
                try
                {
                    // Execute all event handlers in parallel
                    await Task.WhenAll(handlers.Select(handler => handler(data)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing event handlers for {eventName}: {ex}");
                }
            }
        }

        public async Task OnChartCreated()
        {
            // Register all JS events for handlers that were added before chart creation
            foreach (var eventName in _eventHandlers.Keys.ToList())
            {
                if (!_registeredJsEvents.Contains(eventName))
                {
                    await RegisterJsEventAsync(eventName);
                }
            }
        }
    }
} 