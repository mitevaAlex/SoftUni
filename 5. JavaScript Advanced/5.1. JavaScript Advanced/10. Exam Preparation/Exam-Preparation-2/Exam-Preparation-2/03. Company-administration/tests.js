let companyAdministration = require('./companyAdministration');
let expect = require('chai').expect;

describe('companyAdministration', () => {
    describe('hiringEmployee', () => {
        it("should throw an exception if non-Programmer position", () => {
            let name = 'alex';
            let invalidPosition = 'QA';
            let yearsExperience = 5;
            expect(() => { companyAdministration.hiringEmployee(name, invalidPosition, yearsExperience); }).to.throw(`We are not looking for workers for this position.`);
        });

        it("should hire if experience >= 3", () => {
            let name = 'alex';
            let position = 'Programmer';
            let yearsExperience1 = 3;
            let yearsExperience2 = 5;
            expect(companyAdministration.hiringEmployee(name, position, yearsExperience1)).to.equal(`${name} was successfully hired for the position ${position}.`);
            expect(companyAdministration.hiringEmployee(name, position, yearsExperience2)).to.equal(`${name} was successfully hired for the position ${position}.`);
        });

        it("should not hire if experience < 3", () => {
            let name = 'alex';
            let position = 'Programmer';
            let yearsExperience = 2;
            expect(companyAdministration.hiringEmployee(name, position, yearsExperience)).to.equal(`${name} is not approved for this position.`);
        });
    });

    describe('calculateSalary', () => {
        it("should calculate salary with BGN 15 per hour", () => {
            let hours = 100;
            let expected = hours * 15;
            expect(companyAdministration.calculateSalary(hours)).to.equal(expected);
        });

        it("should calculate salary with a bonus for over 160 hours", () => {
            let hours = 161;
            let expected = hours * 15 + 1000;
            expect(companyAdministration.calculateSalary(hours)).to.equal(expected);
        });

        it("should throw an exception if invalid hours", () => {
            let invalid1 = '100';
            let invalid2 = -1;
            expect(() => { companyAdministration.calculateSalary(invalid1); }).to.throw(`Invalid hours`);
            expect(() => { companyAdministration.calculateSalary(invalid2); }).to.throw(`Invalid hours`);
        });
    });

    describe('firedEmployee', () => {
        it("should remove the employee at index", () => {
            let employees = ['ivan', 'georgi', 'pesho'];
            let index = 1;
            let expected = 'ivan, pesho';
            expect(companyAdministration.firedEmployee(employees, index)).to.equal(expected);
        });

        it("should throw an exception if invalid index", () => {
            let employees = ['ivan', 'georgi', 'pesho'];
            let invalidIndex1 = 4;
            let invalidIndex2 = -1;
            let invalidIndex3 = '1';
            expect(() => { companyAdministration.firedEmployee(employees, invalidIndex1); }).to.throw(`Invalid input`);
            expect(() => { companyAdministration.firedEmployee(employees, invalidIndex2); }).to.throw(`Invalid input`);
            expect(() => { companyAdministration.firedEmployee(employees, invalidIndex3); }).to.throw(`Invalid input`);
        });

        it("should throw an exception if invalid array", () => {
            let invalidEmployees1 = "'ivan', 'georgi', 'pesho'";
            let invalidEmployees2 = {ivan: 'ivan', georgi: 'georgi', pesho: 'pesho'};
            let index = 1;
            expect(() => { companyAdministration.firedEmployee(invalidEmployees1, index); }).to.throw(`Invalid input`);
            expect(() => { companyAdministration.firedEmployee(invalidEmployees2, index); }).to.throw(`Invalid input`);
        });
    });
});
