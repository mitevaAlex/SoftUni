function calculate(operatorsAndOperands) {
    let operators = [];
    let calculator = {
        '+'(a, b) {
            return a + b;
        },
        '-'(a, b) {
            return a - b;
        },
        '*'(a, b) {
            return a * b;
        },
        '/'(a, b) {
            return a / b;
        }
    }

    for (let command of operatorsAndOperands) {
        if (typeof (command) === 'number') {
            operators.push(command);
        } else {
            if (operators.length <= 1) {
                console.log('Error: not enough operands!');
                return;
            }

            let fisrtNum = operators[operators.length - 2];
            let secondNum = operators.pop()
            operators[operators.length - 1] = calculator[command](fisrtNum, secondNum);
        }
    }

    if (operators.length > 1) {
        console.log('Error: too many operands!');
        return;
    }

    console.log(operators[0]);
}

// calculate([3,
//     4,
//     '+']
// );
// calculate([5,
//     3,
//     4,
//     '*',
//     '-']
// )
// calculate([7,
//     33,
//     8,
//     '-']
// );
// calculate([15,
//     '/']
// );