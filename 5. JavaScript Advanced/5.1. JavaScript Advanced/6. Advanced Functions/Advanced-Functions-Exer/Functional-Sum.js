function add(num) {
    let sum = num;
    function calculate(newNum) {
        sum += newNum;
        return calculate;
    }

    calculate.toString = function() {
        return sum;
    };

    return calculate;
}

// console.log(add(4)(3).toString());
// console.log(add(1).toString());
// console.log(add(1)(6)(-3).toString());