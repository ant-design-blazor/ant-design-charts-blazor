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
                let jsConfigObj = new Function('return ' + jsConfig)();
                removeNullItem(jsConfigObj);
                deepObjectMerge(config, jsConfigObj);
            }

            console.log(domRef,config)
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
                console.log("config:" + JSON.stringify(config, null, 2));
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
            // Use Function constructor instead of eval - safer approach
            let jsObj = new Function('return ' + jsCode)();
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

// Helper function to create function from string
function createFunctionFromString(str) {
    // Match function parameters and body
    const arrowFuncMatch = str.match(/^\s*\(([^)]*)\)\s*=>\s*(.+)$/s);
    const regularFuncMatch = str.match(/^\s*function\s*\(([^)]*)\)\s*{(.+)}$/s);
    
    let params = '';
    let body = '';
    
    if (arrowFuncMatch) {
        params = arrowFuncMatch[1];
        body = arrowFuncMatch[2];
        // If the body doesn't have explicit return and isn't wrapped in curly braces, add return
        if (!body.includes('return') && !body.trim().startsWith('{')) {
            body = 'return ' + body;
        }
    } else if (regularFuncMatch) {
        params = regularFuncMatch[1];
        body = regularFuncMatch[2];
    } else {
        // Fallback for other patterns
        return new Function('return ' + str)();
    }
    
    // Create the function using Function constructor (safer than eval)
    return new Function(...params.split(',').map(p => p.trim()), body);
}

// 深度合并对象
function deepObjectMerge(source, target) {
    for (var key in target) {
        if (source[key] && source[key].toString() === "[object Object]") {
            deepObjectMerge(source[key], target[key])
        } else if (typeof target[key] == 'object' && !Array.isArray(target[key])) {
            source[key] = {};
            deepObjectMerge(source[key], target[key])
        } else if (Array.isArray(target[key])) {
            source[key] = [];
            for (var i = 0; i < target[key].length; i++) {
                if (typeof target[key][i] == 'object') {
                    let o = {};
                    deepObjectMerge(o, target[key][i])
                    source[key].push(o);
                } else {
                    source[key].push(target[key][i])
                }
            }
        } else if (evalableKeys.includes(key)) {
            console.log(source)
            source[key] = createFunctionFromString(target[key]);
        } else if (key.endsWith('Func')) {
            source[key.replace('Func', '')] = createFunctionFromString(target[key]);
        } else {
            source[key] = target[key]
        }
    }
    return source;
}