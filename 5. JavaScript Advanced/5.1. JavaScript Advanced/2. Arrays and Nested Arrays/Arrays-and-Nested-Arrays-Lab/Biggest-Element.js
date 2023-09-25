function findBiggestInMatrix(matrix) {
    matrix.forEach(row => { row[0] = Math.max(...row); });
    let biggestNum = Number.MIN_SAFE_INTEGER;
    for(let i = 0; i < matrix.length; i++) {
        if (biggestNum < matrix[i][0]) {
            biggestNum = matrix[i][0]; 
        }
    }
    return biggestNum;
}

// console.log(findBiggestInMatrix([[20, 50, 10],
// [8, 33, 145]]
// ));
// console.log(findBiggestInMatrix([[3, 5, 7, 12],
// [-1, 4, 33, 2],
// [8, 3, 0, 4]]
// ));   