function calculate(num1, num2, operator) {
    let result;
    switch (operator) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            result = num1 / num2;
            break;
        case '%':
            result = num1 % num2;
            break;
        case '**':
            result = num1 ** num2;
            break;
    }

    console.log(result);
}

// calculate(5, 6, '+');
// calculate(3, 5.5, '*');