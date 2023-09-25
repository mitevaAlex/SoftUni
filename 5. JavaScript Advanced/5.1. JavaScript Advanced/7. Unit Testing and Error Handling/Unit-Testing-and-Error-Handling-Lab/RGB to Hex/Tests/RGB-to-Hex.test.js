let rgbToHexColor = require('../RGB-to-Hex');
let expect = require('chai').expect;

describe('rgbToHexColor', () => {
    it('should return undefined if red is invalid', () => {
        let red1 = 5.5;
        let red2 = -1;
        let red3 = 256;
        let red4 = '15';
        expect(rgbToHexColor(red1, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(red2, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(red3, 0, 0)).to.be.undefined;
        expect(rgbToHexColor(red4, 0, 0)).to.be.undefined;
    });

    it('should return undefined if green is invalid', () => {
        let green1 = 5.5;
        let green2 = -1;
        let green3 = 256;
        let green4 = '15';
        expect(rgbToHexColor(0, green1, 0)).to.be.undefined;
        expect(rgbToHexColor(0, green2, 0)).to.be.undefined;
        expect(rgbToHexColor(0, green3, 0)).to.be.undefined;
        expect(rgbToHexColor(0, green4, 0)).to.be.undefined;
    });

    it('should return undefined if blue is invalid', () => {
        let blue1 = 5.5;
        let blue2 = -1;
        let blue3 = 256;
        let blue4 = '15';
        expect(rgbToHexColor(0, 0, blue1)).to.be.undefined;
        expect(rgbToHexColor(0, 0, blue2)).to.be.undefined;
        expect(rgbToHexColor(0, 0, blue3)).to.be.undefined;
        expect(rgbToHexColor(0, 0, blue4)).to.be.undefined;
    });

    it('should return color in hexadecimal', () => {
        let red = 50;
        let green = 50;
        let blue = 50;
        expect(rgbToHexColor(red, green, blue)).to.equal('#323232');
    });

    it('should pad values with zeroes', () => {
        let red = 10;
        let green = 11;
        let blue = 12;
        expect(rgbToHexColor(red, green, blue)).to.equal('#0A0B0C');
    });

    it('should pad values at color min value', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });

    it('should pad values at color max value', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });
});