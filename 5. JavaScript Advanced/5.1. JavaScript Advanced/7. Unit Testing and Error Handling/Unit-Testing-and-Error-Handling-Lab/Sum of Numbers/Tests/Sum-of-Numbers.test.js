const sum = require("../Sum-of-Numbers");
let expect = require("chai").expect;

describe('sum', () => {
    it('should return the sum of all integer elements', () => {
        let array = [1, 2, 3];
        let result = sum(array);
        expect(result).to.equal(6);
    });

    it('should return the sum of all decimal elements', () => {
        let array = [1.5, 2.5, 3.5];
        let result = sum(array);
        expect(result).to.equal(7.5);
    });

    it('should parse to number and sum elements', () => {
        let array = ['1', '2', '3'];
        let result = sum(array);
        expect(result).to.equal(6);
    });
});