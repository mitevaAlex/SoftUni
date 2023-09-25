let PaymentPackage = require('../Payment-Package');
let expect = require('chai').expect;

describe("PaymentPackage", () => {
    describe("constructor", () => {
        it("should create object and set given and default values", () => {
            let name = 'HR Services';
            let value = 1500;
            let defaultVAT = 20;
            let defaultActive = true;
            let object = new PaymentPackage(name, value);
            expect(object.name).to.equal(name);
            expect(object.value).to.equal(value);
            expect(object.VAT).to.equal(defaultVAT);
            expect(object.active).to.equal(defaultActive);
            expect(() => new PaymentPackage(name, 0)).not.to.throw('Value must be a non-negative number')
        });
    });

    describe('name', () => {
        it('should get name', () => {
            let name = 'HR Services';
            let object = new PaymentPackage(name, 1500);
            expect(object.name).to.equal(name);
        });

        it('should set valid name', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let newName = 'Consultation';
            object.name = newName;
            expect(object.name).to.equal(newName);
        });

        it('should throw error if invalid name', () => {
            let invalidName1 = '';
            let invalidName2 = 1234;
            let invalidName3 = undefined;
            let invalidName4 = null;
            let value = 1500;
            expect(() => new PaymentPackage(invalidName1, value)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(invalidName2, value)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(invalidName3, value)).to.throw('Name must be a non-empty string');
            expect(() => new PaymentPackage(invalidName4, value)).to.throw('Name must be a non-empty string');
        });
    });

    describe('value', () => {
        it('should get value', () => {
            let value = 1500;
            let object = new PaymentPackage('HR Services', value);
            expect(object.value).to.equal(value);
        });

        it('should set valid value', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let newValue = 2000;
            object.value = newValue;
            expect(object.value).to.equal(newValue);
        });

        it('should throw error if invalid value', () => {
            let invalidValue1 = '1234';
            let invalidValue2 = -1;
            let invalidValue3 = undefined;
            let invalidValue4 = null;
            let name = 'HR Services';
            expect(() => new PaymentPackage(name, invalidValue1)).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage(name, invalidValue2)).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage(name, invalidValue3)).to.throw('Value must be a non-negative number');
            expect(() => new PaymentPackage(name, invalidValue4)).to.throw('Value must be a non-negative number');
        });
    });

    describe('VAT', () => {
        it('should get VAT', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let defaultVAT = 20;
            expect(object.VAT).to.equal(defaultVAT);
        });

        it('should set valid VAT', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let newVAT = 10;
            object.VAT = newVAT;
            expect(object.VAT).to.equal(newVAT);
        });

        it('should throw error if invalid VAT', () => {
            let invalidVAT1 = '30';
            let invalidVAT2 = -1;
            let invalidVAT3 = undefined;
            let invalidVAT4 = null;
            let object = new PaymentPackage('HR Services', 1500);
            expect(() => { object.VAT = invalidVAT1 }).to.throw('VAT must be a non-negative number');
            expect(() => { object.VAT = invalidVAT2 }).to.throw('VAT must be a non-negative number');
            expect(() => { object.VAT = invalidVAT3 }).to.throw('VAT must be a non-negative number');
            expect(() => { object.VAT = invalidVAT4 }).to.throw('VAT must be a non-negative number');
        });
    });

    describe('active', () => {
        it('should get active', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let defaultActive = true;
            expect(object.active).to.equal(defaultActive);
        });

        it('should set valid active', () => {
            let object = new PaymentPackage('HR Services', 1500);
            let newActive = false;
            object.active = newActive;
            expect(object.active).to.equal(newActive);
        });

        it('should throw error if invalid active', () => {
            let invalidActive1 = 'false';
            let invalidActive2 = [true];
            let invalidActive3 = undefined;
            let invalidActive4 = null;
            let object = new PaymentPackage('HR Services', 1500);
            expect(() => { object.active = invalidActive1 }).to.throw('Active status must be a boolean');
            expect(() => { object.active = invalidActive2 }).to.throw('Active status must be a boolean');
            expect(() => { object.active = invalidActive3 }).to.throw('Active status must be a boolean');
            expect(() => { object.active = invalidActive4 }).to.throw('Active status must be a boolean');
        });
    });

    describe('toString', () => {
        it('should return info and show active', () => {
            let name = 'HR Services';
            let value = 1500;
            let object = new PaymentPackage(name, value);
            let defaultVAT = 20;
            let expectedValueWithVAT = value * (1 + defaultVAT / 100);
            let expectedResult = `Package: ${name}\n`;
            expectedResult += `- Value (excl. VAT): ${value}\n`;
            expectedResult += `- Value (VAT ${defaultVAT}%): ${expectedValueWithVAT}`;
            expect(object.toString()).to.equal(expectedResult);
        });

        it('should return info and show inactive', () => {
            let name = 'HR Services';
            let value = 1500;
            let object = new PaymentPackage(name, value);
            object.active = false;
            let defaultVAT = 20;
            let expectedValueWithVAT = value * (1 + defaultVAT / 100);
            let expectedResult = `Package: ${name} (inactive)\n`;
            expectedResult += `- Value (excl. VAT): ${value}\n`;
            expectedResult += `- Value (VAT ${defaultVAT}%): ${expectedValueWithVAT}`;
            expect(object.toString()).to.equal(expectedResult);
        });
    });
});