function checkIfMagic(matrix) {
    let isMatrixMagic = true;
    for (let row = 0; row < matrix.length; row++) {
        let rowSum = 0;
        for (let tempCol = 0; tempCol < matrix[row].length; tempCol++) {
            rowSum += matrix[row][tempCol];
        }

        for (let col = 0; col < matrix[row].length; col++) {
            let colSum = 0;
            for (let tempRow = 0; tempRow < matrix.length; tempRow++) {
                colSum += matrix[tempRow][col];
            }

            if (rowSum != colSum) {
                isMatrixMagic = false;
                break;
            }
        }

        if (!isMatrixMagic) {
            break;
        }
    }

    console.log(isMatrixMagic);
}

// checkIfMagic([[4, 5, 6],
// [6, 5, 4],
// [5, 5, 5]]
// );
// checkIfMagic([[11, 32, 45],
// [21, 0, 1],
// [21, 1, 1]]
// );
// checkIfMagic([[1, 0, 0],
// [0, 0, 1],
// [0, 1, 0]]
// );