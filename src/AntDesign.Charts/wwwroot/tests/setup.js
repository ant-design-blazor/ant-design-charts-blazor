// Import original code
const originalCode = require('../ant-design-charts-blazor.js');

// Export required functions and variables for tests
global.isEmptyObj = originalCode.isEmptyObj;
global.evalableKeys = originalCode.evalableKeys;
global.deepObjectMerge = originalCode.deepObjectMerge;

// Setup window object if not exists
if (typeof window === 'undefined') {
    global.window = {};
}

// Setup AntDesignCharts global object
window.AntDesignCharts = originalCode.default || {
    chartsContainer: {},
    interop: originalCode.interop || {}
};

// Mock console methods
const mockConsole = {
    log: jest.fn(),
    error: jest.fn(),
    warn: jest.fn()
};

// Only mock console methods if they haven't been mocked yet
Object.keys(mockConsole).forEach(method => {
    if (!console[method]?.mock) {
        jest.spyOn(console, method).mockImplementation(mockConsole[method]);
    }
}); 