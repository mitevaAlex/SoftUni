let isSymmetric = require('../Check-for-Symmetry');
let expect = require("chai").expect;

describe('isSymetric', () => {
    it('should return false when a non-array is given', () => {
        let input = 'bob';
        let result = isSymmetric(input);
        expect(result).to.be.false;
    });

    it('should return true when a string array is symmetric', () => {
        let input = ['b', 'o', 'b'];
        let result = isSymmetric(input);
        expect(result).to.be.true;
    });

    it('should return false when a string array is not symmetric', () => {
        let input = ['a', 'l', 'e', 'x'];
        let result = isSymmetric(input);
        expect(result).to.be.false;
    });

    it('should return true when a number array is symmetric', () => {
        let input = [1, 0, 1];
        let result = isSymmetric(input);
        expect(result).to.be.true;
    });

    it('should return false when a number array is not symmetric', () => {
        let input = [1, 2, 3, 4];
        let result = isSymmetric(input);
        expect(result).to.be.false;
    });

    it('should return true when an object array is symmetric', () => {
        let input = [1, { a: '15' }, false, false, { a: '15' }, 1];
        let result = isSymmetric(input);
        expect(result).to.be.true;
    });
});