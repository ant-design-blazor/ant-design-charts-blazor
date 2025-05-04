describe('deepObjectMerge', () => {
    // 基础类型测试
    test('should handle basic types', () => {
        expect(deepObjectMerge({}, null)).toEqual({});
        expect(deepObjectMerge({}, undefined)).toEqual({});
        expect(deepObjectMerge({}, 123)).toEqual({});
        expect(deepObjectMerge({}, 'string')).toEqual({});
        expect(deepObjectMerge({}, true)).toEqual({});
    });

    // 简单对象合并测试
    test('should merge simple objects', () => {
        const source = { a: 1 };
        const target = { b: 2 };
        expect(deepObjectMerge(source, target)).toEqual({ a: 1, b: 2 });
    });

    // 嵌套对象合并测试
    test('should merge nested objects', () => {
        const source = { 
            a: { x: 1 }, 
            b: 2 
        };
        const target = { 
            a: { y: 2 }, 
            c: 3 
        };
        expect(deepObjectMerge(source, target)).toEqual({
            a: { x: 1, y: 2 },
            b: 2,
            c: 3
        });
    });

    // 数组处理测试
    test('should handle arrays', () => {
        const source = { arr: [1, 2] };
        const target = { arr: [3, 4] };
        expect(deepObjectMerge(source, target)).toEqual({ arr: [3, 4] });

        // 数组中的对象
        const source2 = { arr: [{ x: 1 }] };
        const target2 = { arr: [{ y: 2 }] };
        expect(deepObjectMerge(source2, target2)).toEqual({ arr: [{ y: 2 }] });
    });

    // null 和 undefined 处理测试
    test('should handle null and undefined values', () => {
        const source = { 
            a: 1, 
            b: { x: 1 }, 
            c: [1, 2] 
        };
        const target = { 
            a: null, 
            b: undefined, 
            c: null 
        };
        expect(deepObjectMerge(source, target)).toEqual({});
    });

    // 函数属性处理测试
    test('should handle function properties', () => {
        const source = {};
        const target = {
            colorFunc: "()=>{ return '#ff0000'; }",
            label: {
                formatter: "(val)=>{ return val + '%'; }"
            }
        };
        const result = deepObjectMerge(source, target);
        
        expect(typeof result.color).toBe('function');
        expect(result.color()).toBe('#ff0000');
        expect(typeof result.label.formatter).toBe('function');
        expect(result.label.formatter('100')).toBe('100%');
        expect(result.colorFunc).toBeUndefined();
    });

    // 循环引用测试
    test('should handle circular references', () => {
        const source = {};
        const target = { a: 1 };
        target.self = target;

        const result = deepObjectMerge(source, target);
        expect(result.a).toBe(1);
        expect(result.self).toBeDefined();
        expect(result.self).not.toBe(target); // 应该是一个新对象
    });

    // 共享引用测试
    test('should handle shared references', () => {
        const shared = { x: 1 };
        const source = {};
        const target = {
            a: shared,
            b: shared
        };

        const result = deepObjectMerge(source, target);
        expect(result.a).toEqual({ x: 1 });
        expect(result.b).toEqual({ x: 1 });
        expect(result.a).not.toBe(result.b); // 应该是不同的对象
    });

    // 特殊属性名测试
    test('should handle special property names', () => {
        const source = {};
        const target = {
            '': 1,
            ' ': 2,
            'key with spaces': 3,
            'symbol': Symbol('test'),
            [Symbol('test')]: 4
        };

        const result = deepObjectMerge(source, target);
        expect(result['']).toBe(1);
        expect(result[' ']).toBe(2);
        expect(result['key with spaces']).toBe(3);
        expect(result['symbol']).toBe(target.symbol);
        expect(result[Object.getOwnPropertySymbols(target)[0]]).toBe(4);
    });

    // 大型对象测试
    test('should handle large objects', () => {
        const source = {};
        const target = {};
        
        // 创建一个深层嵌套的大对象
        let current = target;
        for (let i = 0; i < 1000; i++) {
            current.next = { value: i };
            current = current.next;
        }

        expect(() => deepObjectMerge(source, target)).not.toThrow();
        
        // 验证部分值
        let result = deepObjectMerge(source, target);
        expect(result.next.value).toBe(0);
        expect(result.next.next.value).toBe(1);
    });

    // data 属性特殊处理测试
    test('should preserve empty data property', () => {
        const source = {};
        const target = {
            data: {},
            emptyObj: {}
        };

        const result = deepObjectMerge(source, target);
        expect(result.data).toBeDefined();
        expect(result.emptyObj).toBeUndefined();
    });

    // 错误处理测试
    test('should handle invalid function strings', () => {
        const source = {};
        const target = {
            colorFunc: "this is not a function",
            label: {
                formatter: "also not a function"
            }
        };

        expect(() => deepObjectMerge(source, target)).not.toThrow();
    });

    // 嵌套对象中的函数属性测试
    test('should handle function properties in nested objects', () => {
        const source = {};
        const target = {
            chart: {
                colorFunc: "()=>{ return '#ff0000'; }",
                style: {
                    fillFunc: "()=>{ return '#00ff00'; }",
                    stroke: {
                        colorFunc: "()=>{ return '#0000ff'; }"
                    }
                },
                label: {
                    formatter: "(val)=>{ return val + '%'; }"
                }
            },
            series: [{
                colorFunc: "()=>{ return '#999999'; }",
                label: {
                    formatter: "(val)=>{ return '$' + val; }"
                }
            }]
        };

        const result = deepObjectMerge(source, target);
        
        // 测试第一层函数属性
        expect(typeof result.chart.color).toBe('function');
        expect(result.chart.colorFunc).toBeUndefined();
        expect(result.chart.color()).toBe('#ff0000');

        // 测试嵌套对象中的函数属性
        expect(typeof result.chart.style.fill).toBe('function');
        expect(result.chart.style.fillFunc).toBeUndefined();
        expect(result.chart.style.fill()).toBe('#00ff00');

        // 测试深层嵌套的函数属性
        expect(typeof result.chart.style.stroke.color).toBe('function');
        expect(result.chart.style.stroke.colorFunc).toBeUndefined();
        expect(result.chart.style.stroke.color()).toBe('#0000ff');

        // 测试formatter属性
        expect(typeof result.chart.label.formatter).toBe('function');
        expect(result.chart.label.formatter('100')).toBe('100%');

        // 测试数组中的函数属性
        expect(typeof result.series[0].color).toBe('function');
        expect(result.series[0].colorFunc).toBeUndefined();
        expect(result.series[0].color()).toBe('#999999');
        expect(typeof result.series[0].label.formatter).toBe('function');
        expect(result.series[0].label.formatter('100')).toBe('$100');
    });
}); 