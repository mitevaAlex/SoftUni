function printLargestNum(num1, num2, num3) {
    console.log(`The largest number is ${Math.max(num1, num2, num3)}.`);
}

function secondSolution(...params) {
    console.log(`The largest number is ${Math.max(...params)}.`);
}

//  secondSolution(5, -3, 16);
// printLargestNum(-3, -5, -22.5);
