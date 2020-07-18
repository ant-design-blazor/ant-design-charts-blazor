// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.createChart = (type, domRef, options, others) => {
    domRef.innerHTML = '';

    removeNullItem(options)
    deepObjectMerge(options, others)

    console.log(options);

    const plot = new G2Plot[type](domRef, options);
    plot.render();
}


window.ccc = (type, domRef, options, others) => {
    domRef.innerHTML = '';
    removeNullItem(options)
    const data1 = [
        { year: '1991', value: 3 },
        { year: '1992', value: 4 },
        { year: '1993', value: 3.5 },
        { year: '1994', value: 5 },
        { year: '1995', value: 4.9 },
        { year: '1996', value: 6 },
        { year: '1997', value: 7 },
        { year: '1998', value: 9 },
        { year: '1999', value: 13 },
    ];

    const data2 = [
        { year: '1991', count: 10 },
        { year: '1992', count: 4 },
        { year: '1993', count: 5 },
        { year: '1994', count: 5 },
        { year: '1995', count: 4.9 },
        { year: '1996', count: 35 },
        { year: '1997', count: 7 },
        { year: '1998', count: 1 },
        { year: '1999', count: 20 },
    ];

    const data = [
        { year: '1991', value: 3 },
        { year: '1992', value: 4 },
        { year: '1993', value: 3.5 },
        { year: '1994', value: 5 },
        { year: '1995', value: 4.9 },
        { year: '1996', value: 6 },
        { year: '1997', value: 7 },
        { year: '1998', value: 9 },
        { year: '1999', value: 13 },
    ];
    console.log(options);

    let ss = {
        title: {
            visible: true,
            text: '双折线图',
        },
        description: {
            visible: true,
            text: '双折线混合图表',
        },
        data: [data1, data2],
        xField: 'year',
        yField: ['value', 'count'],
    };
 
    console.log(ss);

    const plot = new G2Plot[type](domRef, options);
    plot.render();
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
