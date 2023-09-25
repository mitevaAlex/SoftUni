(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) { return str + this; }
        return this.valueOf();
    };
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) { return this + str; }
        return this.valueOf();
    };
    String.prototype.isEmpty = function () {
        if (this.length == 0) { return true; }
        return false;
    };
    String.prototype.truncate = function (n) {
        if (this.length < n) { return this.valueOf(); }

        if (n < 4) {
            return '.'.repeat(n);
        }

        let result = this;
        let words = result.split(' ');
        if (words.length == 1) {
            result = result.slice(0, n - 3) + '...';
        } else {
            while (result.length > n) {
                words = result.split(' ');
                words.pop();
                result = words.join(' ') + '...';
            }
        }

        return result;
    };
    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            string = string.replace(/{\d}/, params[i]);
        }

        return string;
    };
})()

// let str = 'my string';
// str = str.ensureStart('my');
// str = str.ensureStart('hello ');
// str = str.truncate(16);
// str = str.truncate(14);
// str = str.truncate(8);
// str = str.truncate(4);
// str = str.truncate(2);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');