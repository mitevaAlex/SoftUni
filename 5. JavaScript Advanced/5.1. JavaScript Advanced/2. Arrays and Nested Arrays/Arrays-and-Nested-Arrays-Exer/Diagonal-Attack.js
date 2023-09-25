function checkDiagonalsSums(numsAsStr) {
    let matrix = [];
    numsAsStr.forEach(numRow => matrix.push(numRow.split(' ').map(num => Number(num))));
    let mainDiagonalSum = matrix.reduce((sum, value, index) => sum += value[index], 0);
    let secondaryDiagonalSum = matrix.reduce((sum, value, index) => sum += value[value.length - index - 1], 0);
    if (mainDiagonalSum == secondaryDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row != col && row + col != matrix[row].length - 1) {
                    matrix[row][col] = mainDiagonalSum;
                }
            }
        }
    }

    console.log(matrix.map(row => row.join(' ')).join('\n'));
}

// checkDiagonalsSums(['5 3 12 3 1',
//     '11 4 23 2 5',
//     '101 12 3 21 10',
//     '1 4 5 2 2',
//     '5 22 33 11 1']
// );
// checkDiagonalsSums(['1 1 1',
//     '1 1 1',
//     '1 1 0']
// );