// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.createChart = (type, domRef, options, others) => {
    domRef.innerHTML = '';

    removeNullItem(options)
    deepObjectMerge(options, others)
    console.warn(options);
    try {
        const plot = new G2Plot[type](domRef, options);
        plot.render();
    } catch (err) {
        console.error(err, options);
    }
}


window.ccc = (options) => {

    console.log(options);
    removeNullItem(options)
    console.log(options);
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
            if (isEmptyObj(o[attr])) delete o[attr];
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

// 深度合并对象
function deepObjectMerge(source, target) {
    for (var key in target) {
        if (source[key] && source[key].toString() === "[object Object]") {
            deepObjectMerge(source[key], target[key])
        } else {
            source[key] = target[key]
        }
    }
    return source;
}
