class List {
    constructor() {
        this.numbers = [];
        this.size = 0;
    }

    add(element) {
        this.numbers.push(element);
        this.sort();
        this.size++;
    }

    remove(index) {
        if (this.isValid(index)) {
            this.numbers.splice(index, 1);
            this.sort();
            this.size--;
        }
    }

    get(index) {
        if (this.isValid(index)) {
            return this.numbers[index];
        }
    }

    isValid(index) {
        return index >= 0 && index < this.numbers.length;
    }

    sort() {
        this.numbers.sort((a, b) => a - b);
    }
}

// let list = new List();
// list.add(5);
// list.add(6);
// list.add(7);
// console.log(list.get(1));
// list.remove(1);
// console.log(list.get(1));

// console.log(list.size);
