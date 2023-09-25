let chooseYourCar = require('./chooseYourCar');
let expect = require('chai').expect;

describe('chooseYourCar', () => {
    describe('choosingType', () => {
        it('should validate the year', () => {
            let type = 'Sedan';
            let color = 'Red';
            let invalidYear1 = 1899;
            let invalidYear2 = 2023;
            expect(() => { chooseYourCar.choosingType(type, color, invalidYear1) }).to.throw('Invalid Year!');
            expect(() => { chooseYourCar.choosingType(type, color, invalidYear2) }).to.throw('Invalid Year!');
        });

        it('should validate the type', () => {
            let invalidType = 'NotSedan';
            let color = 'Red';
            let year = 2004;
            expect(() => { chooseYourCar.choosingType(invalidType, color, year) }).to.throw('This type of car is not what you are looking for.');
        });

        it('should pick a car', () => {
            let type = 'Sedan';
            let color = 'Red';
            let year1 = 2010;
            let year2 = 2011;
            expect(chooseYourCar.choosingType(type, color, year1)).to.equal(`This ${color} ${type} meets the requirements, that you have.`);
            expect(chooseYourCar.choosingType(type, color, year2)).to.equal(`This ${color} ${type} meets the requirements, that you have.`);
        });

        it('should not pick a car', () => {
            let type = 'Sedan';
            let color = 'Red';
            let year = 2009;
            expect(chooseYourCar.choosingType(type, color, year)).to.equal(`This ${type} is too old for you, especially with that ${color} color.`);
        });
    });

    describe('brandName', () => {
        it('should validate the input arguments', () => {
            let invalidBrands1 = '"BMW", "Toyota"';
            let invalidBrands2 = { brands: ["BMW", "Toyota"]};
            let invalidIndex1 = -1;
            let invalidIndex2 = 2;
            let invalidIndex3 = '0';
            let invalidIndex4 = 1.5;
            let brands1 = ["BMW", "Toyota"];
            let brands2 = [];
            let index = 0;
            expect(() => { chooseYourCar.brandName(invalidBrands1, index) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(invalidBrands2, invalidIndex3) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(invalidBrands1, invalidIndex1) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(brands1, invalidIndex2) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(brands1, invalidIndex3) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(brands1, invalidIndex4) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(brands2, index) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.brandName(brands1, index) }).not.to.throw('Invalid Information!');
        });

        it('should remove at the given index', () => {
            let brands = ["BMW", "Toyota", "Peugeot"];
            let index = 0;
            let expected = 'Toyota, Peugeot';
            expect(chooseYourCar.brandName(brands, index)).to.equal(expected);
            expect(chooseYourCar.brandName(['BMW'], 0)).to.equal('');
            expect(chooseYourCar.brandName(['BMW', 'Toyota'], 0)).to.equal('Toyota');
        })
    });

    describe('carFuelConsumption', () => {
        it('should validate the input arguments', () => {
            let invalidDistance1 = '12';
            let invalidDistance2 = -12;
            let invalidDistance3 = 0;
            let invalidFuel1 = '5';
            let invalidFuel2 = -5;
            let invalidFuel3 = 0;
            let distance = 12;
            let fuel = 5;
            expect(() => { chooseYourCar.carFuelConsumption(invalidDistance1, invalidFuel1) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.carFuelConsumption(invalidDistance2, invalidFuel2) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.carFuelConsumption(invalidDistance3, invalidFuel3) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.carFuelConsumption(distance, invalidFuel1) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.carFuelConsumption(distance, invalidFuel3) }).to.throw('Invalid Information!');
            expect(() => { chooseYourCar.carFuelConsumption(invalidDistance1, fuel) }).to.throw('Invalid Information!');
        });

        it('should return not efficient', () => {
            let distance = 12;
            let fuel = 5;
            let consumption = ((fuel / distance) * 100).toFixed(2);//41.67
            expect(chooseYourCar.carFuelConsumption(distance, fuel)).to.equal(`The car burns too much fuel - ${consumption} liters!`);
        });

        it('should return efficient', () => {
            let distance1 = 75;
            let fuel1 = 1;
            let consumption1 = ((fuel1 / distance1) * 100).toFixed(2);//1.33
            let distance2 = 100;
            let fuel2 = 7;
            let consumption2 = ((fuel2 / distance2) * 100).toFixed(2);//7
            expect(chooseYourCar.carFuelConsumption(distance1, fuel1)).to.equal(`The car is efficient enough, it burns ${consumption1} liters/100 km.`);
            expect(chooseYourCar.carFuelConsumption(distance2, fuel2)).to.equal(`The car is efficient enough, it burns ${consumption2} liters/100 km.`);
        });
    });
});
