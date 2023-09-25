let mathEnforcer = require('../Math-Enforcer');
let expect = require('chai').expect;

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return undefined if non-number input', () => {
            let input1 = '18';
            let input2 = [18];
            expect(mathEnforcer.addFive(input1)).to.be.undefined;
            expect(mathEnforcer.addFive(input2)).to.be.undefined;
        });

        it('should return the input increased by 5 if correct input', () => {
            let input1 = 15;
            let input2 = -1.5;
            expect(mathEnforcer.addFive(input1)).to.equal(input1 + 5);
            expect(mathEnforcer.addFive(input2)).to.be.closeTo(input2 + 5, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('should return undefined if non-number input', () => {
            let input1 = '18';
            let input2 = [18];
            expect(mathEnforcer.subtractTen(input1)).to.be.undefined;
            expect(mathEnforcer.subtractTen(input2)).to.be.undefined;
        });

        it('should return the input decreased by 10 if correct input', () => {
            let input1 = 15;
            let input2 = -1.5;
            expect(mathEnforcer.subtractTen(input1)).to.equal(input1 - 10);
            expect(mathEnforcer.subtractTen(input2)).to.be.closeTo(input2 - 10, 0.01);
        });
    });

    describe('sum', () => {
        it('should return undefined if non-number input', () => {
            let invalid1 = '18';
            let invalid2 = [18];
            let valid1 = 5;
            let valid2 = -10;
            expect(mathEnforcer.sum(invalid1, valid1)).to.be.undefined;
            expect(mathEnforcer.sum(valid2, invalid2)).to.be.undefined;
            expect(mathEnforcer.sum(invalid1, invalid2)).to.be.undefined;
        });

        it('should return the input values summed', () => {
            let input1 = 15;
            let input2 = -20;
            let input3 = 5.53;
            let input4 = -15.654;
            expect(mathEnforcer.sum(input1, input2)).to.equal(input1 + input2);
            expect(mathEnforcer.sum(input2, input3)).to.be.closeTo(input2 + input3, 0.01);
            expect(mathEnforcer.sum(input3, input4)).to.be.closeTo(input3 + input4, 0.01);
        });
    });
});