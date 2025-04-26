// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.AntDesignCharts = {
    interop: {
        create: (type, domRef, domId, chartRef, csConfig, others, jsonConfig, jsConfig) => {
            domRef.innerHTML = '';

            let config = {}

            removeNullItem(csConfig);
            deepObjectMerge(config, csConfig);

            removeNullItem(others);
            deepObjectMerge(config, others);

            if (jsonConfig != undefined) {
                let jsonConfigObj = JSON.parse(jsonConfig);
                removeNullItem(jsonConfigObj);
                deepObjectMerge(config, jsonConfigObj);
            }

            if (jsConfig != undefined) {
                let jsConfigObj = eval("(" + jsConfig + ")");
                removeNullItem(jsConfigObj);
                deepObjectMerge(config, jsConfigObj);
            }

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
                console.log(config);
                // console.log("config:" + JSON.stringify(config, null, 2));
            } catch (err) {
                console.error(err, config);
            }
        },
        destroy(domId) {
            //console.log("destroy:" + domId);
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
            removeNullItem(config)
            deepObjectMerge(config, others)
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


//清除没有赋值的项
function isEmptyObj(o) {
    for (let attr in o) return !1;
    return !0
}

function processArray(arr) {
    for (let i = arr.length - 1; i >= 0; i--) {
        if (arr[i] === null || arr[i] === undefined) arr.splice(i, 1);
        else if (typeof arr[i] == 'object') removeNullItem(arr[i], arr, i);
    }
    return arr.length == 0
}

function proccessObject(o) {
    for (let attr in o) {
        if (o[attr] === null || o[attr] === undefined) delete o[attr];
        else if (typeof o[attr] == 'object') {
            removeNullItem(o[attr]);
            if (isEmptyObj(o[attr]) && attr != "data") delete o[attr];
        }
    }
}

function removeNullItem(o, arr, i) {
    let s = ({}).toString.call(o);
    if (s == '[object Array]') {
        if (processArray(o) === true) { //o也是数组，并且删除完子项，从所属数组中删除
            if (arr) arr.splice(i, 1);
        }
    } else if (s == '[object Object]') {
        proccessObject(o);
        if (arr && isEmptyObj(o)) arr.splice(i, 1);
    }
}

const evalableKeys = ['formatter', 'customContent'];

// 将字符串转换为函数的安全方法
function safeStringToFunction(str) {
    if (!str) return null;
    
    // Check if it's a function declaration with parameters
    if (str.trim().startsWith('function')) {
        try {
            // For function declaration, extract parameters and body
            const funcMatch = str.match(/function\s*\(([^)]*)\)\s*{([\s\S]*)}/);
            if (funcMatch) {
                const params = funcMatch[1].split(',').map(p => p.trim());
                const body = funcMatch[2];
                return new Function(...params, body);
            }
        } catch (e) {
            console.error('Error converting function declaration:', e);
        }
    } 
    
    // Check if it's an arrow function
    if (str.includes('=>')) {
        try {
            // For arrow functions - more careful parsing to handle nested braces
            // First capture the parameters part
            const arrowParamsMatch = str.match(/^\s*(?:\(([^)]*)\)|([^=>\s]+))\s*=>/);
            if (arrowParamsMatch) {
                const params = arrowParamsMatch[1] || arrowParamsMatch[2] || '';
                const paramsList = params.split(',').map(p => p.trim());
                
                // Get the body part (everything after the =>)
                const bodyStartIndex = str.indexOf('=>') + 2;
                let bodyContent = str.substring(bodyStartIndex).trim();
                
                // Check if it's a block body (has { })
                if (bodyContent.startsWith('{')) {
                    // It's a block body, need to find the matching closing brace
                    // accounting for nested objects/braces
                    let openBraces = 1;
                    let closingBraceIndex = -1;
                    
                    // Skip the opening brace
                    for (let i = 1; i < bodyContent.length; i++) {
                        if (bodyContent[i] === '{') {
                            openBraces++;
                        } else if (bodyContent[i] === '}') {
                            openBraces--;
                            if (openBraces === 0) {
                                closingBraceIndex = i;
                                break;
                            }
                        }
                    }
                    
                    // Extract the body without outer braces
                    if (closingBraceIndex !== -1) {
                        bodyContent = bodyContent.substring(1, closingBraceIndex);
                    } else {
                        // If we couldn't find the matching brace, just remove the first {
                        bodyContent = bodyContent.substring(1);
                    }
                    
                    // For block bodies, use the content as is
                    return new Function(...paramsList, bodyContent);
                } else {
                    // For expression bodies, add 'return'
                    return new Function(...paramsList, `return ${bodyContent}`);
                }
            }
        } catch (e) {
            console.error('Error converting arrow function:', e);
        }
    }
    
    // For simple expressions, wrap them in a function
    try {
        return new Function('...args', `return ${str}`);
    } catch (e) {
        console.error('Error converting expression to function:', e);
        return null;
    }
}

// 深度合并对象 - 精简版
function deepObjectMerge(source, target) {
    if (!target || typeof target !== 'object') return source;
    
    Object.keys(target).forEach(key => {
        const value = target[key];
        if (value == null) return;
        
        if (Array.isArray(value)) {
            source[key] = value.map(item => {
                if (item && typeof item === 'object') {
                    // Process objects in arrays (copy to avoid reference issues)
                    return processObjectProps(Array.isArray(item) ? [...item] : {...item});
                }
                return item;
            });
        } else if (typeof value === 'object') {
            // For objects, merge recursively
            source[key] = deepObjectMerge(
                source[key] && typeof source[key] === 'object' && !Array.isArray(source[key]) ? source[key] : {}, 
                value
            );
        } else if ((evalableKeys.includes(key) || key.endsWith('Func')) && typeof value === 'string') {
            // Convert string to function safely
            try {
                if (key.endsWith('Func')) {
                    source[key.replace('Func', '')] = safeStringToFunction(value);
                } else {
                    source[key] = safeStringToFunction(value);
                }
            } catch (e) {
                console.error(`Error converting ${key} to function:`, e);
                source[key] = value;
            }
        } else {
            // Default: copy value
            source[key] = value;
        }
    });
    
    return source;
}

// Process object properties recursively
function processObjectProps(obj) {
    Object.keys(obj).forEach(key => {
        const value = obj[key];
        
        if (value && typeof value === 'object') {
            // Recursively process nested objects and arrays
            obj[key] = Array.isArray(value) 
                ? value.map(item => typeof item === 'object' && item ? processObjectProps({...item}) : item)
                : deepObjectMerge({}, value);
        } else if ((evalableKeys.includes(key) || key.endsWith('Func')) && typeof value === 'string') {
            try {
                if (key.endsWith('Func')) {
                    obj[key.replace('Func', '')] = safeStringToFunction(value);
                    delete obj[key];
                } else {
                    obj[key] = safeStringToFunction(value);
                }
            } catch (e) {
                console.error(`Error converting ${key} to function:`, e);
            }
        }
    });
    
    return obj;
}