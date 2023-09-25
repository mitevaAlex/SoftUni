function rotateArr(elements, rotationsCount) {
    rotationsCount = rotationsCount / elements.length < 1 ? rotationsCount : Math.floor(rotationsCount / elements.length);
    for (let i = 0; i < rotationsCount; i++) {
        elements.unshift(elements.pop());
    }

    console.log(elements.join(' '));
}

// rotateArr(['1',
//     '2',
//     '3',
//     '4'],
//     2
// );
// rotateArr(['Banana',
//     'Orange',
//     'Coconut',
//     'Apple'],
//     15
// );