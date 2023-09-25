let createCalculator = require('../Add-or-Subtract');
let expect = require('chai').expect;

describe('createCalculator', () => {
    it('should return an object containing functions add(), subtract() and get()', () => {
        let result = createCalculator();
        let keys = Object.keys(result);
        expect(typeof (result)).to.equal('object');
        expect(keys.includes('add')).to.be.true;
        expect(keys.includes('subtract')).to.be.true;
        expect(keys.includes('get')).to.be.true;
    });

    it('should keep an internal sum that cannot be modified from the outside', () => {
        let calculator = createCalculator();
        let value = calculator.get();
        value += 10;
        expect(calculator.get()).not.to.equal(value);
    });

    it('should return the internal value with get()', () => {
        let calculator = createCalculator();
        expect(calculator.get()).to.equal(0);
    });

    it('should add parsed number', () => {
        let calculator = createCalculator();
        let addValue1 = 10;
        let addValue2 = '20';
        calculator.add(addValue1);
        calculator.add(addValue2);
        expect(calculator.get()).to.equal(addValue1 + Number(addValue2));
    });

    it('should subtract parsed number', () => {
        let calculator = createCalculator();
        let subtractValue1 = 10;
        let subtractValue2 = '20';
        calculator.subtract(subtractValue1);
        calculator.subtract(subtractValue2);
        expect(calculator.get()).to.equal(- subtractValue1 - Number(subtractValue2));
    });
});