function findGCD(num1, num2) {
    while (num2) {
        let temp = num2;
        num2 = num1 % num2;
        num1 = temp;
    }

    console.log(num1);
}

// findGCD(15, 5);
// findGCD(2154, 458);
