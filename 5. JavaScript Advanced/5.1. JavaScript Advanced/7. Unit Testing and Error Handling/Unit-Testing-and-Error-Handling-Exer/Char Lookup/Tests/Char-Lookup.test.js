let lookupChar = require('../Char-Lookup');
let expect = require('chai').expect;

describe('lookupChar', () => {
    it('should return undefined if a non-string is passed', () => {
        let string1 = 1234;
        let string2 = ['alex'];
        let index = 0;
        expect(lookupChar(string1, index)).to.be.undefined;
        expect(lookupChar(string2, index)).to.be.undefined;
    });

    it('should return undefined if a non-number is passed', () => {
        let string = 'alex';
        let index1 = '1';
        let index2 = [1];
        let index3 = 1.5;
        expect(lookupChar(string, index1)).to.be.undefined;
        expect(lookupChar(string, index2)).to.be.undefined;
        expect(lookupChar(string, index3)).to.be.undefined;
    });

    it('should return "Incorrect index" if a wrong index is passed', () => {
        let string = 'alex';
        let index1 = -1;
        let index2 = string.length;
        let index3 = string.length + 1;
        expect(lookupChar(string, index1)).to.equal('Incorrect index');
        expect(lookupChar(string, index2)).to.equal('Incorrect index');
        expect(lookupChar(string, index3)).to.equal('Incorrect index');
    });

    it('should return char at a given index in a string', () => {
        let string = 'Pesho56';
        let index1 = 0;
        let index2 = string.length - 1;
        let index3 = string.length / 2;
        expect(lookupChar(string, index1)).to.equal(string[index1]);
        expect(lookupChar(string, index2)).to.equal(string[index2]);
        expect(lookupChar(string, index3)).to.equal(string[index3]);
    });
});