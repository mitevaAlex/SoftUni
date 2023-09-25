function diagonalSums(matrix) {
    let mainDiagSum = 0;
    let secondaryDiagSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        mainDiagSum += matrix[i][i];
        secondaryDiagSum += matrix[matrix.length - i - 1][i];
    }

    console.log(`${mainDiagSum} ${secondaryDiagSum}`);
}

// diagonalSums([[20, 40],
// [10, 60]]
// );
// diagonalSums([[3, 5, 17],
// [-1, 7, 14],
// [1, -8, 89]]
// );