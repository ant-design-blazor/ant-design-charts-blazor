// 导入原始函数
const originalCode = require('../ant-design-charts-blazor.js');

// 导出所需的函数和变量
global.isEmptyObj = originalCode.isEmptyObj;
global.evalableKeys = originalCode.evalableKeys;
global.deepObjectMerge = originalCode.deepObjectMerge;

// 模拟 window 对象
global.window = {
    AntDesignCharts: {
        chartsContainer: {}
    }
};

// 模拟 console
global.console = {
    log: jest.fn(),
    error: jest.fn()
}; 