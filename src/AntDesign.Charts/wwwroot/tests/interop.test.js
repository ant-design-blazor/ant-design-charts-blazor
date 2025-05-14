const { interop } = require('../ant-design-charts-blazor.js');

describe('AntDesignCharts Interop', () => {
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
    });

    afterEach(() => {
        jest.clearAllMocks();
        if (originalAntDesignCharts) {
            window.AntDesignCharts = originalAntDesignCharts;
        } else {
            delete global.window.AntDesignCharts;
        }
        delete global.console;
        delete global.G2Plot;
    });

    describe('Chart Instance Management', () => {
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
                
                expect(G2Plot.Line).toHaveBeenCalledWith(
                    domRef,
                    expect.any(Object)
                );
                expect(mockChart.render).toHaveBeenCalled();
            });

            it('should handle creation errors', () => {
                const domRef = { innerHTML: '' };
                global.G2Plot.Line.mockImplementationOnce(() => {
                    throw new Error('Creation failed');
                });

                expect(() => {
                    window.AntDesignCharts.interop.create('Line', domRef, 'new-chart', mockDotNetHelper);
                }).toThrow('Creation failed');
                expect(console.error).toHaveBeenCalledWith('Error creating chart:', expect.any(Error));
            });

            it('should handle invalid JSON config', () => {
                const domRef = { innerHTML: '' };
                const config = { title: 'Test' };
                
                console.error = jest.fn();
                
                // Create chart with invalid JSON config
                window.AntDesignCharts.interop.create(
                    'Line',
                    domRef,
                    'new-chart',
                    mockDotNetHelper,
                    config,
                    null,
                    'not a valid json',
                    null
                );
                
                // 验证错误被记录且图表创建继续
                expect(console.error).toHaveBeenCalledWith(
                    'Error parsing JSON config:',
                    expect.any(SyntaxError)
                );
                expect(G2Plot.Line).toHaveBeenCalledWith(
                    domRef,
                    expect.objectContaining({ title: 'Test' })
                );
            });

            it('should handle invalid JS config', () => {
                const domRef = { innerHTML: '' };
                const config = { title: 'Test' };
                
                console.error = jest.fn();
                
                // Create chart with invalid JS config
                window.AntDesignCharts.interop.create(
                    'Line',
                    domRef,
                    'new-chart',
                    mockDotNetHelper,
                    config,
                    null,
                    null,
                    'not a valid js'  // 明显无效的 JS
                );
                
                // 验证错误被记录且图表创建继续
                expect(console.error).toHaveBeenCalledWith(
                    'Error evaluating JS config:',
                    expect.any(SyntaxError)
                );
                expect(G2Plot.Line).toHaveBeenCalledWith(
                    domRef,
                    expect.objectContaining({ title: 'Test' })
                );
            });

            it('should handle valid JSON config', () => {
                const domRef = { innerHTML: '' };
                const config = { title: 'Test' };
                const validJson = '{"color":"blue","data":[1,2,3]}';
                
                console.error = jest.fn();
                
                window.AntDesignCharts.interop.create(
                    'Line',
                    domRef,
                    'new-chart',
                    mockDotNetHelper,
                    config,
                    null,
                    validJson,
                    null
                );
                
                // 验证没有错误被记录
                expect(console.error).not.toHaveBeenCalled();
                // 验证配置被正确合并
                expect(G2Plot.Line).toHaveBeenCalledWith(
                    domRef,
                    expect.objectContaining({
                        title: 'Test',
                        color: 'blue',
                        data: [1,2,3]
                    })
                );
            });

            it('should handle valid JS config', () => {
                const domRef = { innerHTML: '' };
                const config = { title: 'Test' };
                const validJs = '({formatter: (v) => v + "%", color: "red"})';
                
                console.error = jest.fn();
                
                window.AntDesignCharts.interop.create(
                    'Line',
                    domRef,
                    'new-chart',
                    mockDotNetHelper,
                    config,
                    null,
                    null,
                    validJs
                );
                
                // 验证没有错误被记录
                expect(console.error).not.toHaveBeenCalled();
                // 验证配置被正确合并
                const callConfig = G2Plot.Line.mock.calls[0][1];
                expect(callConfig.title).toBe('Test');
                expect(callConfig.color).toBe('red');
                expect(typeof callConfig.formatter).toBe('function');
                expect(callConfig.formatter(100)).toBe('100%');
            });
        });

        describe('destroy', () => {
            it('should destroy chart instance', () => {
                window.AntDesignCharts.interop.destroy(domId);
                expect(mockChart.destroy).toHaveBeenCalled();
                expect(window.AntDesignCharts.chartsContainer[domId]).toBeUndefined();
            });
        });
    });

    describe('Chart Operations', () => {
        describe('render', () => {
            it('should call render on chart instance', () => {
                window.AntDesignCharts.interop.render(domId);
                expect(mockChart.render).toHaveBeenCalled();
            });

            it('should handle render errors', () => {
                mockChart.render.mockImplementationOnce(() => {
                    throw new Error('Render failed');
                });
                window.AntDesignCharts.interop.render(domId);
                expect(console.error).toHaveBeenCalledWith('Error rendering chart:', expect.any(Error));
            });
        });

        describe('repaint', () => {
            it('should call repaint on chart instance', () => {
                window.AntDesignCharts.interop.repaint(domId);
                expect(mockChart.repaint).toHaveBeenCalled();
            });

            it('should handle repaint errors', () => {
                mockChart.repaint.mockImplementationOnce(() => {
                    throw new Error('Repaint failed');
                });
                window.AntDesignCharts.interop.repaint(domId);
                expect(console.error).toHaveBeenCalledWith('Error repainting chart:', expect.any(Error));
            });
        });

        describe('changeData', () => {
            it('should call changeData on chart instance', () => {
                const newData = [{ x: 1, y: 2 }];
                window.AntDesignCharts.interop.changeData(domId, newData);
                expect(mockChart.changeData).toHaveBeenCalledWith(newData, false);
            });

            it('should handle changeData errors', () => {
                mockChart.changeData.mockImplementationOnce(() => {
                    throw new Error('Change data failed');
                });
                window.AntDesignCharts.interop.changeData(domId, []);
                expect(console.error).toHaveBeenCalledWith('Error changing chart data:', expect.any(Error));
            });
        });
    });

    describe('Event Handling', () => {
        describe('setEvent', () => {
            it('should register event handler successfully', () => {
                window.AntDesignCharts.interop.setEvent(domId, 'click', mockDotNetHelper);
                expect(mockChart.on).toHaveBeenCalled();
            });

            it('should handle event data correctly', () => {
                window.AntDesignCharts.interop.setEvent(domId, 'click', mockDotNetHelper);
                
                const handler = mockChart.on.mock.calls[0][1];

                handler({ x: 10, y: 20 });
                expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { x: 10, y: 20 });

                const date = new Date('2024-01-01');
                handler({ date: date });
                expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { date: date.toISOString() });

                handler({ data: [1, 2, 3] });
                expect(mockDotNetHelper.invokeMethodAsync).toHaveBeenCalledWith('InvokeEventHandler', 'click', { data: [1, 2, 3] });
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

            it('should handle offEvent errors', () => {
                mockChart.off.mockImplementationOnce(() => {
                    throw new Error('Off event failed');
                });
                window.AntDesignCharts.interop.offEvent(domId);
                expect(console.error).toHaveBeenCalledWith('Error removing event handler:', expect.any(Error));
            });
        });
    });

    describe('State Management', () => {
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

        it('should handle setActive errors', () => {
            mockChart.setActive.mockImplementationOnce(() => {
                throw new Error('Set active failed');
            });
            window.AntDesignCharts.interop.setActive(domId, {}, {});
            expect(console.error).toHaveBeenCalledWith('Error setting active state:', expect.any(Error));
        });

        it('should handle setSelected errors', () => {
            mockChart.setSelected.mockImplementationOnce(() => {
                throw new Error('Set selected failed');
            });
            window.AntDesignCharts.interop.setSelected(domId, {}, {});
            expect(console.error).toHaveBeenCalledWith('Error setting selected state:', expect.any(Error));
        });

        it('should handle setDisable errors', () => {
            mockChart.setDisable.mockImplementationOnce(() => {
                throw new Error('Set disable failed');
            });
            window.AntDesignCharts.interop.setDisable(domId, {}, {});
            expect(console.error).toHaveBeenCalledWith('Error setting disable state:', expect.any(Error));
        });

        it('should handle setDefault errors', () => {
            mockChart.setDefault.mockImplementationOnce(() => {
                throw new Error('Set default failed');
            });
            window.AntDesignCharts.interop.setDefault(domId, {}, {});
            expect(console.error).toHaveBeenCalledWith('Error setting default state:', expect.any(Error));
        });
    });

    describe('Error Handling', () => {
        describe('lifecycle events', () => {
            it('should handle afterrender callback errors', () => {
                const domRef = { innerHTML: '' };
                
                // Mock the async method to throw an error
                mockDotNetHelper.invokeMethodAsync.mockImplementation(() => {
                    throw new Error('Callback failed');
                });
                
                window.AntDesignCharts.interop.create('Line', domRef, 'new-chart', mockDotNetHelper);
                const afterRenderHandler = mockChart.on.mock.calls.find(call => call[0] === 'afterrender')[1];
                
                // Call the handler
                afterRenderHandler();
                
                // Verify error was logged
                expect(console.error).toHaveBeenCalledWith('Error in afterrender callback:', expect.any(Error));
            });

            it('should handle beforedestroy callback errors', () => {
                const domRef = { innerHTML: '' };
                
                // Mock the dispose method to throw an error
                mockDotNetHelper.dispose.mockImplementation(() => {
                    throw new Error('Dispose failed');
                });
                
                window.AntDesignCharts.interop.create('Line', domRef, 'new-chart', mockDotNetHelper);
                const beforeDestroyHandler = mockChart.on.mock.calls.find(call => call[0] === 'beforedestroy')[1];
                
                // Call the handler
                beforeDestroyHandler();
                
                // Verify error was logged
                expect(console.error).toHaveBeenCalledWith('Error in beforedestroy callback:', expect.any(Error));
            });
        });

        describe('chart operations', () => {
            beforeEach(() => {
                console.error.mockClear();
            });

            it('should handle render errors', () => {
                mockChart.render.mockImplementationOnce(() => {
                    throw new Error('Render failed');
                });
                window.AntDesignCharts.interop.render(domId);
                expect(console.error).toHaveBeenCalledWith('Error rendering chart:', expect.any(Error));
            });

            it('should handle repaint errors', () => {
                mockChart.repaint.mockImplementationOnce(() => {
                    throw new Error('Repaint failed');
                });
                window.AntDesignCharts.interop.repaint(domId);
                expect(console.error).toHaveBeenCalledWith('Error repainting chart:', expect.any(Error));
            });

            it('should handle changeData errors', () => {
                mockChart.changeData.mockImplementationOnce(() => {
                    throw new Error('Change data failed');
                });
                window.AntDesignCharts.interop.changeData(domId, []);
                expect(console.error).toHaveBeenCalledWith('Error changing chart data:', expect.any(Error));
            });
        });

        describe('state management errors', () => {
            beforeEach(() => {
                console.error.mockClear();
            });

            it('should handle setActive errors', () => {
                mockChart.setActive.mockImplementationOnce(() => {
                    throw new Error('Set active failed');
                });
                window.AntDesignCharts.interop.setActive(domId, {}, {});
                expect(console.error).toHaveBeenCalledWith('Error setting active state:', expect.any(Error));
            });

            it('should handle setSelected errors', () => {
                mockChart.setSelected.mockImplementationOnce(() => {
                    throw new Error('Set selected failed');
                });
                window.AntDesignCharts.interop.setSelected(domId, {}, {});
                expect(console.error).toHaveBeenCalledWith('Error setting selected state:', expect.any(Error));
            });

            it('should handle setDisable errors', () => {
                mockChart.setDisable.mockImplementationOnce(() => {
                    throw new Error('Set disable failed');
                });
                window.AntDesignCharts.interop.setDisable(domId, {}, {});
                expect(console.error).toHaveBeenCalledWith('Error setting disable state:', expect.any(Error));
            });

            it('should handle setDefault errors', () => {
                mockChart.setDefault.mockImplementationOnce(() => {
                    throw new Error('Set default failed');
                });
                window.AntDesignCharts.interop.setDefault(domId, {}, {});
                expect(console.error).toHaveBeenCalledWith('Error setting default state:', expect.any(Error));
            });
        });

        describe('event handling errors', () => {
            it('should handle offEvent errors', () => {
                mockChart.off.mockImplementationOnce(() => {
                    throw new Error('Off event failed');
                });
                window.AntDesignCharts.interop.offEvent(domId);
                expect(console.error).toHaveBeenCalledWith('Error removing event handler:', expect.any(Error));
            });
        });
    });
}); 