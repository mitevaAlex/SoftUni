let isOddOrEven = require('../Even-Or-Odd');
let expect = require('chai').expect;

describe ('isOddOrEven', () => {
    it('should return undefined if non-string input', () => {
        let value1 = 1234;
        let value2 = ['alex', 'koko'];
        expect(isOddOrEven(value1)).to.be.undefined;
        expect(isOddOrEven(value2)).to.be.undefined;
    });

    it('should return even if even length of string', () => {
        let value = 'alex';
        expect(isOddOrEven(value)).to.equal('even');
    });

    it('should return odd if odd length of string', () => {
        let value = 'ali';
        expect(isOddOrEven(value)).to.equal('odd');
    });
});