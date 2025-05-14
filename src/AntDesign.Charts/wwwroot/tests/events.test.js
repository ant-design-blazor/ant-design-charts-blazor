// Import utility functions
const { isEmptyObj, deepObjectMerge } = require('../ant-design-charts-blazor.js');

describe('AntDesignCharts Events', () => {
    let mockChart;
    let mockDotNetHelper;
    let domId = 'test-chart';
    let originalAntDesignCharts;

    beforeEach(() => {
        // Store original if exists
        originalAntDesignCharts = window.AntDesignCharts;

        // Mock chart instance
        mockChart = {
            on: jest.fn(),
            off: jest.fn(),
            destroy: jest.fn(),
            render: jest.fn(),
            repaint: jest.fn(),
            changeData: jest.fn(),
            setActive: jest.fn(),
            setSelected: jest.fn(),
            setDisable: jest.fn(),
            setDefault: jest.fn()
        };

        // Mock .NET helper
        mockDotNetHelper = {
            invokeMethodAsync: jest.fn(),
            dispose: jest.fn()
        };

        // Setup window.AntDesignCharts before requiring the module
        global.window = { 
            AntDesignCharts: {
                chartsContainer: {}
            }
        };
        global.console = { 
            warn: jest.fn(), 
            error: jest.fn(), 
            log: jest.fn() 
        };

        // Mock G2Plot
        global.G2Plot = {
            Line: jest.fn().mockImplementation(() => mockChart)
        };

        // Add mock chart to container
        window.AntDesignCharts.chartsContainer[domId] = mockChart;

        // Now require the module to get fresh instance
        const antDesignCharts = require('../ant-design-charts-blazor.js');
    });

    afterEach(() => {
        jest.clearAllMocks();
        // Restore original if existed
        if (originalAntDesignCharts) {
            window.AntDesignCharts = originalAntDesignCharts;
        } else {
            delete global.window.AntDesignCharts;
        }
        delete global.console;
        delete global.G2Plot;
    });

    describe('getChartInstance', () => {
        it('should return chart instance when it exists', () => {
            const chart = window.AntDesignCharts.interop.getChartInstance(domId);
            expect(chart).toBe(mockChart);
        });

        it('should throw error when chart does not exist', () => {
            expect(() => {
                window.AntDesignCharts.interop.getChartInstance('non-existent');
            }).toThrow('Chart not found: non-existent');
        });
    });

    describe('setEvent', () => {
        it('should register event handler successfully', () => {
            window.AntDesignCharts.interop.setEvent(domId, 'click', mockDotNetHelper);
            expect(mockChart.on).toHaveBeenCalled();
        });

        it('should handle event data correctly', () => {
            window.AntDesignCharts.interop.setEvent(domId, 'click', mockDotNetHelper);
            
            // Get the event handler function
            const handler = mockChart.on.mock.calls[0][1];

            // Test with primitive data
            handler({ x: 10, y: 20 });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { x: 10, y: 20 });

            // Test with Date object
            const date = new Date('2024-01-01');
            handler({ date: date });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { date: date.toISOString() });

            // Test with array
            handler({ data: [1, 2, 3] });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { data: [1, 2, 3] });
        });
    });

    describe('destroy', () => {
        it('should destroy chart instance', () => {
            window.AntDesignCharts.interop.destroy(domId);
            expect(mockChart.destroy).toHaveBeenCalled();
            expect(window.AntDesignCharts.chartsContainer[domId]).toBeUndefined();
        });
    });

    describe('render', () => {
        it('should call render on chart instance', () => {
            window.AntDesignCharts.interop.render(domId);
            expect(mockChart.render).toHaveBeenCalled();
        });
    });

    describe('repaint', () => {
        it('should call repaint on chart instance', () => {
            window.AntDesignCharts.interop.repaint(domId);
            expect(mockChart.repaint).toHaveBeenCalled();
        });
    });

    describe('changeData', () => {
        it('should call changeData on chart instance', () => {
            const newData = [{ x: 1, y: 2 }];
            window.AntDesignCharts.interop.changeData(domId, newData);
            expect(mockChart.changeData).toHaveBeenCalledWith(newData, false);
        });
    });

    describe('create', () => {
        it('should create a new chart instance', () => {
            const domRef = { innerHTML: '' };
            const config = { data: [1, 2, 3] };
            
            window.AntDesignCharts.interop.create('Line', domRef, 'new-chart', mockDotNetHelper, config);
            
            expect(domRef.innerHTML).toBe('');
            expect(G2Plot.Line).toHaveBeenCalledWith(domRef, expect.objectContaining(config));
            expect(mockChart.render).toHaveBeenCalled();
            expect(window.AntDesignCharts.chartsContainer['new-chart']).toBe(mockChart);
        });

        it('should handle different config types', () => {
            const domRef = { innerHTML: '' };
            const csConfig = { title: 'Test' };
            const others = { legend: true };
            const jsonConfig = '{"data":[1,2,3]}';
            const jsConfig = '({color:"red"})';
            
            window.AntDesignCharts.interop.create(
                'Line', 
                domRef, 
                'new-chart', 
                mockDotNetHelper, 
                csConfig, 
                others, 
                jsonConfig, 
                jsConfig
            );
            
            expect(G2Plot.Line).toHaveBeenCalledWith(domRef, expect.objectContaining({
                title: 'Test',
                legend: true,
                data: [1,2,3],
                color: 'red'
            }));
        });

        it('should set up lifecycle event handlers', () => {
            const domRef = { innerHTML: '' };
            
            window.AntDesignCharts.interop.create('Line', domRef, 'new-chart', mockDotNetHelper);
            
            // Get event handlers
            const afterRenderHandler = mockChart.on.mock.calls.find(call => call[0] === 'afterrender')[1];
            const beforeDestroyHandler = mockChart.on.mock.calls.find(call => call[0] === 'beforedestroy')[1];
            
            // Test afterrender
            afterRenderHandler();
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('AfterChartRender');
            
            // Test beforedestroy
            beforeDestroyHandler();
            expect(mockDotNetHelper.dispose).toHaveBeenCalled();
        });
    });

    describe('offEvent', () => {
        it('should remove specific event handler', () => {
            window.AntDesignCharts.interop.offEvent(domId, 'click');
            expect(mockChart.off).toHaveBeenCalledWith('click');
        });

        it('should remove all event handlers when no event specified', () => {
            window.AntDesignCharts.interop.offEvent(domId);
            expect(mockChart.off).toHaveBeenCalledWith();
        });
    });

    describe('state management', () => {
        const condition = { name: 'test' };
        const style = { color: 'red' };

        it('should set active state', () => {
            window.AntDesignCharts.interop.setActive(domId, condition, style);
            expect(mockChart.setActive).toHaveBeenCalledWith(condition, style);
        });

        it('should set selected state', () => {
            window.AntDesignCharts.interop.setSelected(domId, condition, style);
            expect(mockChart.setSelected).toHaveBeenCalledWith(condition, style);
        });

        it('should set disable state', () => {
            window.AntDesignCharts.interop.setDisable(domId, condition, style);
            expect(mockChart.setDisable).toHaveBeenCalledWith(condition, style);
        });

        it('should set default state', () => {
            window.AntDesignCharts.interop.setDefault(domId, condition, style);
            expect(mockChart.setDefault).toHaveBeenCalledWith(condition, style);
        });
    });
});

describe('Utility Functions', () => {
    describe('isEmptyObj', () => {
        it('should return true for empty object', () => {
            expect(isEmptyObj({})).toBe(true);
        });

        it('should return false for non-empty object', () => {
            expect(isEmptyObj({ a: 1 })).toBe(false);
        });
    });

    describe('deepObjectMerge', () => {
        it('should merge primitive values', () => {
            const source = { a: 1 };
            const target = { b: 2 };
            expect(deepObjectMerge(source, target)).toEqual({ a: 1, b: 2 });
        });

        it('should merge arrays', () => {
            const source = { arr: [1] };
            const target = { arr: [2, 3] };
            expect(deepObjectMerge(source, target)).toEqual({ arr: [2, 3] });
        });

        it('should handle nested objects', () => {
            const source = { nested: { a: 1 } };
            const target = { nested: { b: 2 } };
            expect(deepObjectMerge(source, target)).toEqual({ nested: { a: 1, b: 2 } });
        });

        it('should handle function properties', () => {
            const source = {};
            const target = { 
                formatterFunction: '(value) => value + 1',
                formatter: '(value) => value * 2'
            };
            const result = deepObjectMerge(source, target);
            expect(typeof result.formatter).toBe('function');
            expect(result.formatter(2)).toBe(4);
        });

        it('should handle null values', () => {
            const source = { a: 1 };
            const target = { a: null };
            expect(deepObjectMerge(source, target)).toEqual({});
        });

        it('should handle circular references', () => {
            const source = { a: 1 };
            const target = { b: 2 };
            target.self = target;
            expect(() => deepObjectMerge(source, target)).not.toThrow();
        });
    });
}); 