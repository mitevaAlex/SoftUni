function countEqualNeighbors(matrix) {
    let count = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row - 1 >= 0)
                if (matrix[row][col] === matrix[row - 1][col])
                    count++;
            if (row + 1 < matrix.length)
                if (matrix[row][col] === matrix[row + 1][col])
                    count++;
            if (col - 1 >= 0)
                if (matrix[row][col] === matrix[row][col - 1])
                    count++;
            if (col + 1 < matrix[row].length)
                if (matrix[row][col] === matrix[row][col + 1])
                    count++;
        }
    }

    return count / 2;
}

// console.log(countEqualNeighbors([['2', '3', '4', '7', '0'],
// ['4', '0', '5', '3', '4'],
// ['2', '3', '5', '4', '2'],
// ['9', '8', '7', '5', '4']]
// ));
// console.log(countEqualNeighbors([['test', 'yes', 'yo', 'ho'],
// ['well', 'done', 'yo', '6'],
// ['not', 'done', 'yet', '5']]
// ));