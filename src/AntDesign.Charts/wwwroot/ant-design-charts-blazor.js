// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.AntDesignCharts = {
    chartsContainer: {},
    interop: {
        /**
         * Gets a chart instance by its ID
         * @param {string} domId - The DOM ID of the chart
         * @returns {Object|null} The chart instance or null if not found
         * @throws {Error} If the chart instance is not found
         */
        getChartInstance: (domId) => {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (!chart) {
                console.warn(`No chart found with ID: ${domId}`);
                throw new Error(`Chart not found: ${domId}`);
            }
            return chart;
        },

        create: (type, domRef, domId, chartRef, csConfig, others, jsonConfig, jsConfig) => {
            try {
                domRef.innerHTML = '';
                let config = {};

                if (csConfig) deepObjectMerge(config, csConfig);
                if (others) deepObjectMerge(config, others);

                if (jsonConfig != undefined) {
                    try {
                        let jsonConfigObj = JSON.parse(jsonConfig);
                        deepObjectMerge(config, jsonConfigObj);
                    } catch (err) {
                        console.error('Error parsing JSON config:', err);
                    }
                }

                if (jsConfig != undefined) {
                    try {
                        let jsConfigObj = eval("(" + jsConfig + ")");
                        deepObjectMerge(config, jsConfigObj);
                    } catch (err) {
                        console.error('Error evaluating JS config:', err);
                    }
                }

                console.log('Creating chart with config:', config);
                
                const plot = new G2Plot[type](domRef, config);

                plot.on('afterrender', () => {
                    try {
                        chartRef.invokeMethodAsync('AfterChartRender');
                    } catch (err) {
                        console.error('Error in afterrender callback:', err);
                    }
                });

                plot.on('beforedestroy', () => {
                    try {
                        chartRef.dispose();
                    } catch (err) {
                        console.error('Error in beforedestroy callback:', err);
                    }
                });

                plot.render();
                window.AntDesignCharts.chartsContainer[domId] = plot;
                console.log(`Chart created - ID: ${domId}, Type: ${type}`);
            } catch (err) {
                console.error('Error creating chart:', err);
                throw err;
            }
        },

        destroy: (domId) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.destroy();
                delete window.AntDesignCharts.chartsContainer[domId];
                console.log(`Chart destroyed - ID: ${domId}`);
            } catch (err) {
                console.error('Error destroying chart:', err);
            }
        },

        render: (domId) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.render();
            } catch (err) {
                console.error('Error rendering chart:', err);
            }
        },

        repaint: (domId) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.repaint();
            } catch (err) {
                console.error('Error repainting chart:', err);
            }
        },

        changeData: (domId, data, all = false) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.changeData(data, all);
            } catch (err) {
                console.error('Error changing chart data:', err);
            }
        },

        setEvent: (domId, event, dotnetHelper) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                console.log(`Registering event handler - Event: ${event}`);

                chart.on(event, ev => {
                    try {
                        // Create a serializable event object
                        const eventData = createSerializableObject(ev);
                        console.log(`Event data for ${event}:`, eventData);
                        
                        dotnetHelper.invokeMethodAsync('InvokeEventHandler', event, eventData);
                    } catch (err) {
                        console.error(`Error in event handler for ${event}:`, err);
                    }
                });
            } catch (err) {
                console.error('Error setting event handler:', err);
            }
        },

        offEvent: (domId, event) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                if (event) {
                    console.log(`Unregistering event handler - Event: ${event}`);
                    chart.off(event);
                } else {
                    console.log('Unregistering all event handlers');
                    chart.off();
                }
            } catch (err) {
                console.error('Error removing event handler:', err);
            }
        },

        setActive: (domId, condition, style) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.setActive(condition, style);
            } catch (err) {
                console.error('Error setting active state:', err);
            }
        },

        setSelected: (domId, condition, style) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.setSelected(condition, style);
            } catch (err) {
                console.error('Error setting selected state:', err);
            }
        },

        setDisable: (domId, condition, style) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.setDisable(condition, style);
            } catch (err) {
                console.error('Error setting disable state:', err);
            }
        },

        setDefault: (domId, condition, style) => {
            try {
                const chart = window.AntDesignCharts.interop.getChartInstance(domId);
                chart.setDefault(condition, style);
            } catch (err) {
                console.error('Error setting default state:', err);
            }
        }
    }
};

/**
 * Check if an object is empty
 * @param {Object} o - The object to check
 * @returns {boolean} True if the object is empty
 */
function isEmptyObj(o) {
    for (let attr in o) return false;
    return true;
}

const evalableKeys = ['formatter', 'customContent'];

/**
 * Deep merge objects with special handling for functions and arrays
 * @param {Object} source - Source object
 * @param {Object} target - Target object
 * @param {WeakMap} visited - WeakMap to track visited objects (for circular references)
 * @returns {Object} Merged object
 */
function deepObjectMerge(source, target, visited = new WeakMap()) {
    if (!target || typeof target !== 'object') return source;
    if (visited.has(target)) return source;
    visited.set(target, true);

    // Handle arrays
    if (Array.isArray(target)) {
        return target
            .filter(item => item != null)
            .map(item => {
                if (!item || typeof item !== 'object') return item;
                if (Array.isArray(item)) return [...item];
                if (visited.has(item)) return {...item};
                return deepObjectMerge({}, item, visited);
            });
    }

    // Collect function properties
    const funcProps = {};
    
    // Process properties (both regular and Symbol)
    const processProperties = (props) => {
        props.forEach(key => {
            const value = target[key];
            if (typeof value === 'string') {
                try {
                    if (key.toString().endsWith('Function')) {
                        const newKey = key.toString().replace('Function', '');
                        funcProps[newKey] = eval('(' + value + ')');
                        delete target[key];
                    } else if (evalableKeys.includes(key.toString()) && value.trim().startsWith('(')) {
                        funcProps[key] = eval('(' + value + ')');
                    }
                } catch (e) {
                    console.error(`Error evaluating function for ${key}:`, e);
                }
            }
        });
    };

    // Process both regular and Symbol properties
    processProperties(Object.keys(target));
    processProperties(Object.getOwnPropertySymbols(target));

    // Process all properties (including Symbol)
    const allProps = [...Object.keys(target), ...Object.getOwnPropertySymbols(target)];
    allProps.forEach(key => {
        const value = target[key];
        
        // Handle null/undefined
        if (value == null) {
            delete source[key];
            return;
        }

        // Handle nested objects
        if (typeof value === 'object') {
            if (visited.has(value)) {
                source[key] = Array.isArray(value) ? [...value] : {...value};
                return;
            }
            source[key] = deepObjectMerge(
                (!source[key] || typeof source[key] !== 'object' || Array.isArray(source[key])) ? {} : source[key],
                value,
                visited
            );
            // Remove empty objects (except data property)
            if (isEmptyObj(source[key]) && key !== 'data') {
                delete source[key];
            }
            return;
        }

        // Handle primitive values
        source[key] = value;
    });

    // Merge function properties
    Object.assign(source, funcProps);

    return source;
}

/**
 * Creates a serializable version of an object by recursively processing its properties
 * @param {*} obj - The object to make serializable
 * @returns {*} A serializable version of the object
 */
function createSerializableObject(obj) {
    const seen = new Set();

    function serialize(obj, path = '') {
        if (!obj || typeof obj !== 'object') {
            return obj;
        }

        // Handle special cases
        if (obj instanceof Date) {
            return obj.toISOString();
        }

        // Skip DOM elements and window
        if (obj instanceof Element || obj instanceof Window) {
            return `[${obj.constructor.name}]`;
        }

        // Generate a unique path for this object
        const currentPath = path ? `${path}.${obj.constructor.name}` : obj.constructor.name;
        
        // Check for circular references
        if (seen.has(obj)) {
            return `[Circular Reference to ${currentPath}]`;
        }
        seen.add(obj);

        try {
            // Handle arrays
            if (Array.isArray(obj)) {
                const result = obj.map((item, index) => 
                    serialize(item, `${currentPath}[${index}]`));
                seen.delete(obj);
                return result;
            }

            // Handle regular objects
            const result = {};
            for (const key of Object.keys(obj)) {
                try {
                    const value = obj[key];
                    
                    // Skip functions and symbols
                    if (typeof value === 'function' || typeof value === 'symbol') {
                        continue;
                    }

                    // Skip parent references (common source of circular refs)
                    if (key === 'parent' || key === '_parent') {
                        result[key] = '[Parent Reference]';
                        continue;
                    }

                    // Handle null
                    if (value === null) {
                        result[key] = null;
                        continue;
                    }

                    // Recursively serialize object properties
                    result[key] = serialize(value, `${currentPath}.${key}`);
                } catch (err) {
                    console.warn(`Error serializing property ${key}:`, err);
                    result[key] = '[Error]';
                }
            }
            seen.delete(obj);
            return result;
        } catch (err) {
            seen.delete(obj);
            console.error('Error in serialization:', err);
            return '[Error]';
        }
    }

    try {
        // Extract only the essential properties we need
        const eventData = obj.data || obj;
        const result = serialize(eventData);

        // Verify the result can be stringified
        JSON.stringify(result);
        return result;
    } catch (err) {
        console.error('Failed to create serializable object:', err);
        return { error: 'Failed to serialize event data' };
    }
}

// Export for testing
if (typeof module !== 'undefined' && module.exports) {
    module.exports = {
        isEmptyObj,
        evalableKeys,
        deepObjectMerge,
        createSerializableObject,
        interop: window.AntDesignCharts.interop
    };
}