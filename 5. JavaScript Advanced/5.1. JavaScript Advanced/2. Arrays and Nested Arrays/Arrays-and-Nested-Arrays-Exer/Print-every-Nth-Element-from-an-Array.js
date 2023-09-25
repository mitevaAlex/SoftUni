function printNewArr(elements, step) {
    let newArr = [];
    for (let i = 0; i < elements.length; i += step) {
        newArr.push(elements[i]);
    }

    return newArr;
}

// console.log(printNewArr(['5',
//     '20',
//     '31',
//     '4',
//     '20'],
//     2
// ));
// console.log(printNewArr(['dsa',
//     'asd',
//     'test',
//     'tset'],
//     2
// ));
// console.log(printNewArr(['1',
//     '2',
//     '3',
//     '4',
//     '5'],
//     6
// ));