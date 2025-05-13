describe('AntDesignCharts Events', () => {
    let mockChart;
    let mockDotNetHelper;
    let domId = 'test-chart';

    beforeEach(() => {
        // Mock chart instance
        mockChart = {
            on: jest.fn(),
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
            invokeMethodAsync: jest.fn()
        };

        // Reset chartsContainer before each test
        window.AntDesignCharts.chartsContainer = {};
        window.AntDesignCharts.chartsContainer[domId] = mockChart;
    });

    afterEach(() => {
        jest.clearAllMocks();
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
            expect(console.warn).toHaveBeenCalledWith('No chart found with ID: non-existent');
        });
    });

    describe('setEvent', () => {
        it('should register event handler successfully', () => {
            const eventName = 'click';
            window.AntDesignCharts.interop.setEvent(domId, eventName, mockDotNetHelper, eventName);
            
            expect(mockChart.on).toHaveBeenCalled();
            expect(console.log).toHaveBeenCalledWith(`Registering event handler - Event: ${eventName}, Name: ${eventName}`);
        });

        it('should handle event data correctly', () => {
            const eventName = 'click';
            window.AntDesignCharts.interop.setEvent(domId, eventName, mockDotNetHelper, eventName);

            // Get the event handler function
            const handler = mockChart.on.mock.calls[0][1];

            // Test with primitive data
            handler({ x: 10, y: 20 });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', eventName, { x: 10, y: 20 });

            // Test with Date object
            const date = new Date('2024-01-01');
            handler({ date: date });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', eventName, { date: date.toISOString() });

            // Test with array
            handler({ data: [1, 2, 3] });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', eventName, { data: [1, 2, 3] });

            // Test with function (should be ignored)
            handler({ func: () => {} });
            expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', eventName, {});
        });

        it('should handle errors in event callback', () => {
            const eventName = 'click';
            window.AntDesignCharts.interop.setEvent(domId, eventName, mockDotNetHelper, eventName);

            // Get the event handler function
            const handler = mockChart.on.mock.calls[0][1];

            // Simulate error in invokeMethodAsync
            mockDotNetHelper.invokeMethodAsync.mockRejectedValue(new Error('Test error'));
            
            // This should not throw
            handler({ x: 10 });
            
            expect(console.error).toHaveBeenCalledWith('Error in event handler for click:', expect.any(Error));
        });

        it('should handle non-existent chart gracefully', () => {
            window.AntDesignCharts.interop.setEvent('non-existent', 'click', mockDotNetHelper, 'click');
            expect(console.error).toHaveBeenCalled();
            expect(mockChart.on).not.toHaveBeenCalled();
        });
    });

    describe('chart lifecycle events', () => {
        let mockDomRef, mockChartRef;

        beforeEach(() => {
            mockDomRef = { innerHTML: '' };
            mockChartRef = {
                invokeMethodAsync: jest.fn(),
                dispose: jest.fn()
            };
            global.G2Plot = {
                Line: jest.fn().mockImplementation(() => mockChart)
            };
        });

        it('should handle afterrender event', async () => {
            window.AntDesignCharts.interop.create('Line', mockDomRef, domId, mockChartRef);

            // Get the afterrender handler
            const afterRenderHandler = mockChart.on.mock.calls.find(call => call[0] === 'afterrender')[1];
            
            // Call the handler
            await afterRenderHandler();
            
            expect(mockChartRef.invokeMethodAsync).toHaveBeenCalledWith('AfterChartRender');
        });

        it('should handle beforedestroy event', async () => {
            window.AntDesignCharts.interop.create('Line', mockDomRef, domId, mockChartRef);

            // Get the beforedestroy handler
            const beforeDestroyHandler = mockChart.on.mock.calls.find(call => call[0] === 'beforedestroy')[1];
            
            // Call the handler
            await beforeDestroyHandler();
            
            expect(mockChartRef.dispose).toHaveBeenCalled();
        });

        it('should handle errors in lifecycle events', async () => {
            window.AntDesignCharts.interop.create('Line', mockDomRef, domId, mockChartRef);

            // Get the handlers
            const afterRenderHandler = mockChart.on.mock.calls.find(call => call[0] === 'afterrender')[1];
            const beforeDestroyHandler = mockChart.on.mock.calls.find(call => call[0] === 'beforedestroy')[1];

            // Simulate errors
            mockChartRef.invokeMethodAsync.mockRejectedValue(new Error('AfterRender error'));
            mockChartRef.dispose.mockImplementation(() => { throw new Error('Dispose error'); });

            // These should not throw
            await afterRenderHandler();
            await beforeDestroyHandler();

            expect(console.error).toHaveBeenCalledWith('Error in afterrender callback:', expect.any(Error));
            expect(console.error).toHaveBeenCalledWith('Error in beforedestroy callback:', expect.any(Error));
        });
    });
}); 