const { createSerializableObject } = require('../ant-design-charts-blazor.js');

describe('createSerializableObject', () => {
    describe('Basic Types', () => {
        it('should handle primitive types', () => {
            expect(createSerializableObject(42)).toBe(42);
            expect(createSerializableObject('test')).toBe('test');
            expect(createSerializableObject(true)).toBe(true);
            expect(createSerializableObject(null)).toBe(null);
            expect(createSerializableObject(undefined)).toBe(undefined);
        });
    });

    describe('Date Objects', () => {
        it('should convert Date objects to ISO strings', () => {
            const date = new Date('2024-03-20T12:00:00Z');
            expect(createSerializableObject(date)).toBe('2024-03-20T12:00:00.000Z');
        });
    });

    describe('Arrays', () => {
        it('should handle simple arrays', () => {
            const input = [1, 'test', true];
            expect(createSerializableObject(input)).toEqual(input);
        });

        it('should handle nested arrays', () => {
            const input = [1, [2, 3], [4, [5, 6]]];
            expect(createSerializableObject(input)).toEqual(input);
        });

        it('should handle arrays with objects', () => {
            const input = [{ a: 1 }, { b: 2 }];
            expect(createSerializableObject(input)).toEqual(input);
        });
    });

    describe('Objects', () => {
        it('should handle simple objects', () => {
            const input = { a: 1, b: 'test', c: true };
            expect(createSerializableObject(input)).toEqual(input);
        });

        it('should handle nested objects', () => {
            const input = {
                a: { b: { c: 1 } },
                d: { e: 2 }
            };
            expect(createSerializableObject(input)).toEqual(input);
        });

        it('should skip functions', () => {
            const input = {
                a: 1,
                b: () => {},
                c: function() {},
                d: 2
            };
            expect(createSerializableObject(input)).toEqual({ a: 1, d: 2 });
        });

        it('should handle null values in objects', () => {
            const input = { a: null, b: 1, c: { d: null } };
            expect(createSerializableObject(input)).toEqual(input);
        });
    });

    describe('Complex Mixed Objects', () => {
        it('should handle complex nested structures', () => {
            const date = new Date('2024-03-20T12:00:00Z');
            const input = {
                string: 'test',
                number: 42,
                boolean: true,
                date: date,
                array: [1, { nested: true }, [3, 4]],
                object: {
                    a: 1,
                    b: null,
                    c: { d: date },
                    func: () => {},
                },
                nullValue: null,
            };

            const expected = {
                string: 'test',
                number: 42,
                boolean: true,
                date: '2024-03-20T12:00:00.000Z',
                array: [1, { nested: true }, [3, 4]],
                object: {
                    a: 1,
                    b: null,
                    c: { d: '2024-03-20T12:00:00.000Z' },
                },
                nullValue: null,
            };

            expect(createSerializableObject(input)).toEqual(expected);
        });
    });
}); 