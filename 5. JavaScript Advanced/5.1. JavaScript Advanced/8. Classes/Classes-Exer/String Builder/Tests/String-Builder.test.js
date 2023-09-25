let StringBuilder = require('../String-Builder');
let expect = require('chai').expect;

describe('String Builder', () => {
    describe('constructor', () => {
        it('should instantiate object with and without a passed string', () => {
            let string = 'alex';
            expect(new StringBuilder(string)._stringArray.values).to.equal(Array.from(string).values);
            expect(new StringBuilder()._stringArray.values).to.equal([].values);
        });

        it('should validate if the given argument is string', () => {
            let invalidInput = 123;
            expect(() => {new StringBuilder(invalidInput)}).to.throw('Argument must be a string');
        });
    });

    describe('append', () => {
        it('should append the given string characters to the array', () => {
            let string1 = 'alex';
            let string2 = 'miteva';
            let object = new StringBuilder(string1);
            object.append(string2);
            expect(object._stringArray.values).to.equal(Array.from(string1 + string2).values);
        });

        it('should validate if the given argument is string', () => {
            let string = 'alex';
            let invalidInput = 123;
            let object = new StringBuilder(string);
            expect(() => {object.append(invalidInput)}).to.throw('Argument must be a string');
        });
    });

    describe('prepend', () => {
        it('should insert the given string characters into the beginning the array', () => {
            let string1 = 'alex';
            let string2 = 'miteva';
            let object = new StringBuilder(string1);
            object.prepend(string2);
            expect(object._stringArray.values).to.equal(Array.from(string2 + string1).values);
        });

        it('should validate if the given argument is string', () => {
            let string = 'alex';
            let invalidInput = 123;
            let object = new StringBuilder(string);
            expect(() => {object.prepend(invalidInput)}).to.throw('Argument must be a string');
        });
    });

    describe('insertAt', () => { //sth wrong -> no points
        it('should insert the given string characters at the given index', () => {
            let string1 = 'adef';
            let string2 = 'bc';
            let expected = 'abcdef';
            let object = new StringBuilder(string1);
            object.insertAt(string2, 1);
            expect(object._stringArray.values).to.equal(Array.from(expected).values);
        });

        it('should validate if the first given argument is string', () => {
            let string = 'alex';
            let invalidInput = 123;
            let object = new StringBuilder(string);
            expect(() => {object.insertAt(invalidInput, 1)}).to.throw('Argument must be a string');
        });
    });

    describe('remove', () => { //sth wrong -> no points
        it('should remove the given length starting at the given index', () => {
            let string = 'alexmiteva';
            let expected = 'alex';
            let object = new StringBuilder(string);
            object.remove(4, 6);
            expect(object._stringArray.values).to.equal(Array.from(expected).values);
        });
    });

    describe('toString', () => {
        it('should return the array joined by an empty string', () => {
            let string = 'alexmiteva';
            let object = new StringBuilder(string);
            expect(object.toString()).to.equal(string);
        });

        it('everything works correctly', () => {
            let expected = '\n A \n\r B\t123   ';
            let object = new StringBuilder();
        
            expected.split('').forEach(s => {object.append(s); object.prepend(s); });
        
            object.insertAt('test', 4);
        
            object.remove(2, 4);
        
            expect(object.toString()).to.equal('  st21\tB \r\n A \n\n A \n\r B\t123   ');
        });
    });
});
