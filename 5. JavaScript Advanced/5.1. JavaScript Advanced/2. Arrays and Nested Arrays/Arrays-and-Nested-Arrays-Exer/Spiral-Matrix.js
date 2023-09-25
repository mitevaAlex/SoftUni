function printSpiralMatrix(rows, cols) {
    let matrix = [];
    let count = 1;
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = false;
        }
    }

    for (let row = 0, col = 0; row < rows && col < cols; col++, row++) {
        let tempRow = row;
        let tempCol = col;
        for (; tempCol < cols - col - 1; tempCol++) {
            matrix[tempRow][tempCol] = count++;
        }

        for (; tempRow < rows - row - 1; tempRow++) {
            matrix[tempRow][tempCol] = count++;
        }

        for (; tempCol > col; tempCol--) {
            matrix[tempRow][tempCol] = count++;
        }

        for (; tempRow > row; tempRow--) {
            matrix[tempRow][tempCol] = count++;
        }
    }


    if (rows % 2 != 0 && cols % 2 != 0) {
        matrix[Math.floor(rows / 2)][Math.floor(cols / 2)] = count;
    }
    console.log(matrix.map(x => x.join(' ')).join('\n'));
}

// printSpiralMatrix(3, 3); 
// printSpiralMatrix(5, 5);
// printSpiralMatrix(2, 2);

