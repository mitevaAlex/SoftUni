function hierarchy() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(units) {
            this.units = units;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }

        get area() {
            return Math.PI * this.radius ** 2;
        }

        get radius() {
            switch (this.units) {
                case 'm': return this._radius / 100;
                case 'cm': return this._radius;
                case 'mm': return this._radius * 10;
            }
        }

        set radius(value) {
            this._radius = value;
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }

        get area() {
            return this.width * this.height;
        }

        get width() {
            switch (this.units) {
                case 'm': return this._width / 100;
                case 'cm': return this._width;
                case 'mm': return this._width * 10;
            }
        }

        set width(value) {
            this._width = value;
        }

        get height() {
            switch (this.units) {
                case 'm': return this._height / 100;
                case 'cm': return this._height;
                case 'mm': return this._height * 10;
            }
        }

        set height(value) {
            this._height = value;
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`
        }
    }

    return { Figure, Circle, Rectangle };
}

// let c = new Circle(5);
// console.log(c.area); // 78.53981633974483
// console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

// let r = new Rectangle(3, 4, 'mm');
// console.log(r.area); // 1200
// console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

// r.changeUnits('cm');
// console.log(r.area); // 12
// console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

// c.changeUnits('mm');
// console.log(c.area); // 7853.981633974483
// console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
