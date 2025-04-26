// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.AntDesignCharts = {
    interop: {
        create: (type, domRef, domId, chartRef, csConfig, others, jsonConfig, jsConfig) => {
            domRef.innerHTML = '';

            let config = {}

            if (csConfig) deepObjectMerge(config, csConfig);
            if (others) deepObjectMerge(config, others);

            if (jsonConfig != undefined) {
                let jsonConfigObj = JSON.parse(jsonConfig);
                deepObjectMerge(config, jsonConfigObj);
            }

            if (jsConfig != undefined) {
                let jsConfigObj = eval("(" + jsConfig + ")");
                deepObjectMerge(config, jsConfigObj);
            }

            console.log(config);
            try {
                const plot = new G2Plot[type](domRef, config);

                plot.on('afterrender', (e) => {
                    chartRef.invokeMethodAsync('AfterChartRender')
                });

                plot.on('beforedestroy', (e) => {
                    chartRef.dispose();
                });

                plot.render();
                window.AntDesignCharts.chartsContainer[domId] = plot;
                console.log("create:" + domId)
                console.log("type:" + type);
            } catch (err) {
                console.error(err, config);
            }
        },
        destroy(domId) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].destroy();
            delete window.AntDesignCharts.chartsContainer[domId];
        },
        render(domId) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].render();
        },
        repaint(domId) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].repaint();
        },
        updateConfig(domId, config, others, all) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            deepObjectMerge(config, others);
            window.AntDesignCharts.chartsContainer[domId].updateConfig(config, all);
            window.AntDesignCharts.chartsContainer[domId].render();
        },
        changeData(domId, data, all) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].changeData(data, all);
        },
        setActive(domId, condition, style) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].setActive(condition, style);
        },
        setSelected(domId, condition, style) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].setSelected(condition, style);
        },
        setDisable(domId, condition, style) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].setDisable(condition, style);
        },
        setDefault(domId, condition, style) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;
            window.AntDesignCharts.chartsContainer[domId].setDefault(condition, style);
        },

        setEvent(domId, event, dotnetHelper, func) {
            if (window.AntDesignCharts.chartsContainer[domId] == undefined) return;

            console.log("setEvent");
            window.AntDesignCharts.chartsContainer[domId].on(event, ev => {
                let e = {};
                for (let attr in ev) {
                    if (typeof ev[attr] !== "function" && typeof ev[attr] !== "object") {
                        e[attr] = ev[attr];
                    }
                }
                dotnetHelper.invokeMethodAsync(func, e);
            })
        },

        getEvalJson(jsCode) {
            let jsObj = eval("(" + jsCode + ")");
            return JSON.stringify(jsObj);
        }
    },
    chartsContainer: {}
}

// 判断对象是否为空
function isEmptyObj(o) {
    for (let attr in o) return false;
    return true;
}

const evalableKeys = ['formatter', 'customContent'];

// 深度合并对象 - 简化版
function deepObjectMerge(source, target, visited = new WeakMap()) {
    if (!target || typeof target !== 'object' || visited.has(target)) return source;
    visited.set(target, true);

    Object.keys(target).forEach(key => {
        const value = target[key];
        
        // 跳过 null 和 undefined
        if (value == null) {
            if (source[key] !== undefined) delete source[key];
            return;
        }

        // 处理数组
        if (Array.isArray(value)) {
            source[key] = value
                .filter(item => item != null)
                .map(item => {
                    // 简单值直接返回
                    if (!item || typeof item !== 'object') return item;
                    
                    // 如果是数组，直接返回数组的副本
                    if (Array.isArray(item)) return [...item];
                    
                    // 处理对象
                    const copy = {...item};
                    
                    // 处理对象中属性
                    Object.keys(copy).forEach(prop => {
                        // 移除null值
                        if (copy[prop] == null) {
                            delete copy[prop];
                            return;
                        }
                        
                        // 转换函数字符串
                        if (evalableKeys.includes(prop) && typeof copy[prop] === 'string') {
                            try { copy[prop] = eval('(' + copy[prop] + ')'); } 
                            catch (e) { console.error(`Error in ${prop}:`, e); }
                        } else if (prop.endsWith('Func') && typeof copy[prop] === 'string') {
                            try {
                                copy[prop.replace('Func', '')] = eval('(' + copy[prop] + ')');
                                delete copy[prop];
                            } catch (e) { console.error(`Error in ${prop}:`, e); }
                        }
                        
                        // 递归处理嵌套对象
                        if (typeof copy[prop] === 'object' && copy[prop] !== null && !visited.has(copy[prop])) {
                            if (Array.isArray(copy[prop])) {
                                // 如果是数组，保持数组结构
                                copy[prop] = [...copy[prop]];
                            } else {
                                const nested = {};
                                deepObjectMerge(nested, copy[prop], visited);
                                // 保留非空对象
                                if (!isEmptyObj(nested)) {
                                    copy[prop] = nested;
                                } else {
                                    delete copy[prop];
                                }
                            }
                        }
                    });
                    return copy;
                });
            return;
        }
        // 处理对象
        else if (typeof value === 'object') {
            if (!source[key] || typeof source[key] !== 'object' || Array.isArray(source[key])) {
                source[key] = {};
            }
            deepObjectMerge(source[key], value, visited);
            // 移除空对象(但保留data属性)
            if (isEmptyObj(source[key]) && key !== 'data') {
                delete source[key];
            }
        }
        // 处理formatter等特殊属性
        else if (evalableKeys.includes(key) && typeof value === 'string') {
            try { source[key] = eval('(' + value + ')'); } 
            catch (e) { 
                console.error(`Error in ${key}:`, e);
                source[key] = value;
            }
        }
        // 处理以Func结尾的属性
        else if (key.endsWith('Func') && typeof value === 'string') {
            try {
                source[key.replace('Func', '')] = eval('(' + value + ')');
            } catch (e) {
                console.error(`Error in ${key}:`, e);
                source[key] = value;
            }
        }
        // 普通值直接赋值
        else {
            source[key] = value;
        }
    });

    return source;
}