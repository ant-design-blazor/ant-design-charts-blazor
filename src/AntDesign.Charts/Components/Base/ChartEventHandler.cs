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
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private readonly Dictionary<string, List<Func<JsonElement, Task>>> _eventHandlers = new Dictionary<string, List<Func<JsonElement, Task>>>();
        private readonly HashSet<string> _registeredJsEvents = new HashSet<string>();
        private readonly HashSet<string> _pendingJsEvents = new HashSet<string>();
        private IJSRuntime _js;
        private DotNetObjectReference<ComponentBase> _chartRef;
        private ElementReference _elementRef;
        private const string InteropSetEvent = "AntDesignCharts.interop.setEvent";
        private const string InteropOffEvent = "AntDesignCharts.interop.offEvent";
        private bool _rendered;
        private bool _initialized;

        public void Initialize(
            IJSRuntime js,
            DotNetObjectReference<ComponentBase> chartRef,
            ElementReference elementRef)
        {
            _js = js;
            _chartRef = chartRef;
            _elementRef = elementRef;
            _initialized = true;

            // Try to register any pending events that were added before initialization
            if (_rendered)
            {
                foreach (var eventName in _pendingJsEvents.ToList())
                {
                    if (_eventHandlers.ContainsKey(eventName))
                    {
                        _ = RegisterJsEventAsync(eventName);
                    }
                }
            }
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

        /// <summary>
        /// Register a generic event handler for the chart (async with data)
        /// </summary>
        public void On<T>(string eventName, Func<T, Task> handler)
        {
            RegisterEventHandlerInternal(eventName, async (data) =>
            {
                var typedData = data.Deserialize<T>(JsonOptions);
                await handler(typedData);
            });
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a generic event handler for the chart (sync with data)
        /// </summary>
        public void On<T>(string eventName, Action<T> handler)
        {
            RegisterEventHandlerInternal(eventName, (data) =>
            {
                var typedData = data.Deserialize<T>(JsonOptions);
                handler(typedData);
                return Task.CompletedTask;
            });
            TryRegisterJsEvent(eventName);
        }

        private Func<JsonElement, Task> WrapOnce<T>(string eventName, T handler, Func<T, JsonElement, Task> invoker) where T : Delegate
        {
            return async (JsonElement data) =>
            {
                await invoker(handler, data);
                Off(eventName, handler);
            };
        }

        /// <summary>
        /// Register a one-time event handler for the chart (async with data)
        /// </summary>
        public void Once(string eventName, Func<JsonElement, Task> handler)
        {
            RegisterEventHandlerInternal(eventName, WrapOnce(eventName, handler, (h, data) => h(data)));
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a one-time event handler for the chart (sync with data)
        /// </summary>
        public void Once(string eventName, Action<JsonElement> handler)
        {
            RegisterEventHandlerInternal(eventName, WrapOnce(eventName, handler, (h, data) =>
            {
                h(data);
                return Task.CompletedTask;
            }));
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a one-time event handler for the chart (async without data)
        /// </summary>
        public void Once(string eventName, Func<Task> handler)
        {
            RegisterEventHandlerInternal(eventName, WrapOnce(eventName, handler, (h, _) => h()));
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a one-time event handler for the chart (sync without data)
        /// </summary>
        public void Once(string eventName, Action handler)
        {
            RegisterEventHandlerInternal(eventName, WrapOnce(eventName, handler, (h, _) =>
            {
                h();
                return Task.CompletedTask;
            }));
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a generic one-time event handler for the chart (async with data)
        /// </summary>
        public void Once<T>(string eventName, Func<T, Task> handler)
        {
            RegisterEventHandlerInternal(eventName, async (data) =>
            {
                var typedData = data.Deserialize<T>(JsonOptions);
                await handler(typedData);
                Off(eventName, handler);
            });
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Register a generic one-time event handler for the chart (sync with data)
        /// </summary>
        public void Once<T>(string eventName, Action<T> handler)
        {
            RegisterEventHandlerInternal(eventName, async (data) =>
            {
                var typedData = data.Deserialize<T>(JsonOptions);
                handler(typedData);
                Off(eventName, handler);
            });
            TryRegisterJsEvent(eventName);
        }

        /// <summary>
        /// Unregister a specific handler for an event
        /// </summary>
        public void Off(string eventName, Delegate handler)
        {
            if (eventName != null && _eventHandlers.ContainsKey(eventName))
            {
                switch (handler)
                {
                    case Func<JsonElement, Task> asyncDataHandler:
                        _eventHandlers[eventName].Remove(asyncDataHandler);
                        break;
                    case Action<JsonElement> syncDataHandler:
                        var syncDataWrapper = (Func<JsonElement, Task>)(data =>
                        {
                            syncDataHandler(data);
                            return Task.CompletedTask;
                        });
                        _eventHandlers[eventName].RemoveAll(h => h.Method == syncDataWrapper.Method);
                        break;
                    case Func<Task> asyncHandler:
                        var asyncWrapper = (Func<JsonElement, Task>)(_ => asyncHandler());
                        _eventHandlers[eventName].RemoveAll(h => h.Method == asyncWrapper.Method);
                        break;
                    case Action syncHandler:
                        var syncWrapper = (Func<JsonElement, Task>)(_ =>
                        {
                            syncHandler();
                            return Task.CompletedTask;
                        });
                        _eventHandlers[eventName].RemoveAll(h => h.Method == syncWrapper.Method);
                        break;
                }

                // If no handlers left for this event, remove the event entirely
                if (_eventHandlers[eventName].Count == 0)
                {
                    _eventHandlers.Remove(eventName);
                }
            }
        }

        /// <summary>
        /// Unregister all handlers for a specific event, or all events if eventName is null
        /// </summary>
        public async Task Off(string eventName = null)
        {
            if (eventName == null)
            {
                // Remove all event handlers
                _eventHandlers.Clear();
                // Remove all JS event listeners
                foreach (var registeredEvent in _registeredJsEvents.ToList())
                {
                    await _js.InvokeVoidAsync(InteropOffEvent, _elementRef.Id, registeredEvent);
                }
                _registeredJsEvents.Clear();
            }
            else if (_eventHandlers.ContainsKey(eventName))
            {
                // Remove specific event handlers
                _eventHandlers.Remove(eventName);
                if (_registeredJsEvents.Contains(eventName))
                {
                    // Remove JS event listener
                    await _js.InvokeVoidAsync(InteropOffEvent, _elementRef.Id, eventName);
                    _registeredJsEvents.Remove(eventName);
                }
            }
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
                if (_rendered && _initialized)
                {
                    _ = RegisterJsEventAsync(eventName);
                }
                else
                {
                    _pendingJsEvents.Add(eventName);
                }
            }
        }

        private async Task RegisterJsEventAsync(string eventName)
        {
            if (!_initialized)
            {
                return;
            }

            if (!_registeredJsEvents.Contains(eventName))
            {
                await _js.InvokeVoidAsync(InteropSetEvent, _elementRef.Id, eventName, _chartRef);
                _registeredJsEvents.Add(eventName);
                _pendingJsEvents.Remove(eventName);
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
            if (!_initialized || _rendered)
            {
                return;
            }

            _rendered = true;
            
            // Register all pending JS events
            var pendingEvents = _pendingJsEvents.ToList();
            
            foreach (var eventName in pendingEvents)
            {
                if (_eventHandlers.ContainsKey(eventName))
                {
                    await RegisterJsEventAsync(eventName);
                }
            }
        }

        public async Task Dispose()
        {
            await Off();
        }
    }
} 