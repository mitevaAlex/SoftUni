class Textbox {
    constructor(selector, regex) {
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = regex;
        this._value = this._elements[0].value;
        Array.from(this.elements).forEach(x => x.addEventListener('change', () => { this.value = x.value; }));
    }

    get value() {
        return this._value;
    }

    set value(input) {
        this._value = input;
        for (let element of Array.from(this.elements)) {
            element.value = input;
        }
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        for (let element of Array.from(this.elements)) {
            if (element.value.match(this._invalidSymbols)) {
                return false;
            }
        }

        return true;
    }
}

// let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
// let inputs = document.getElementsByClassName('.textbox');

// inputs.addEventListener('click', function () { console.log(textbox.value); });
