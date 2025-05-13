const { isEmptyObj } = require('../ant-design-charts-blazor.js');

describe('Utility Functions', () => {
    describe('isEmptyObj', () => {
        it('should return true for empty object', () => {
            expect(isEmptyObj({})).toBe(true);
        });

        it('should return false for non-empty object', () => {
            expect(isEmptyObj({ a: 1 })).toBe(false);
        });

        it('should handle non-object inputs', () => {
            expect(isEmptyObj(null)).toBe(true);
            expect(isEmptyObj(undefined)).toBe(true);
            expect(isEmptyObj([])).toBe(true);
            expect(isEmptyObj('')).toBe(true);
            expect(isEmptyObj(0)).toBe(true);
        });
    });
}); 