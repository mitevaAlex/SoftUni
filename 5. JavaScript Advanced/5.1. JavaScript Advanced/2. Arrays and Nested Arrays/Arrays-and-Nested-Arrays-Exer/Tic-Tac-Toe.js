function play(moves) {
    let gameBoard = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    let firstPlayerSymbol = 'X';
    let secondPlayerSymbol = 'O';
    let hasWon = false;
    for (let i = 0; i < moves.length; i++) {
        let row = moves[i].split(' ')[0];
        let col = moves[i].split(' ')[1];
        if (gameBoard[row][col] == false) {
            if (i % 2 == 0) {
                gameBoard[row][col] = firstPlayerSymbol;
            } else {
                gameBoard[row][col] = secondPlayerSymbol;
            }

            if (doesPlayerWin(gameBoard, row, col)) {
                console.log(`Player ${gameBoard[row][col]} wins!`)
                hasWon = true;
                break;
            }
        } else if (!isFull(gameBoard)) {
            console.log("This place is already taken. Please choose another!");
            let temp = firstPlayerSymbol;
            firstPlayerSymbol = secondPlayerSymbol;
            secondPlayerSymbol = temp;
        } 

        if (isFull(gameBoard)) {
            console.log("The game ended! Nobody wins :(");
            break;
        }
    }

    function isFull(gameBoard) {
        for (let row = 0; row < gameBoard.length; row++) {
            for (let col = 0; col < gameBoard[row].length; col++) {
                if (gameBoard[row][col] == false) {
                    return false;
                }
            }
        }

        return true;
    }

    function doesPlayerWin(gameBoard, row, col) {
        let player = gameBoard[row][col];

        if (player == gameBoard[row][0] && player == gameBoard[row][1] && player == gameBoard[row][2]) {
            return true;
        }

        if (player == gameBoard[0][col] && player == gameBoard[1][col] && player == gameBoard[2][col]) {
            return true;
        }

        if (row == col) {
            if (player == gameBoard[0][0] && player == gameBoard[1][1] && player == gameBoard[2][2]) {
                return true;
            }
        }

        if (Math.abs(row - col) == 2 || (row == col && row == 1)) {
            if (player == gameBoard[0][2] && player == gameBoard[1][1] && player == gameBoard[2][0]) {
                return true;
            }
        }

        return false;
    }

    for (let row = 0; row < 3; row++) {
        console.log(gameBoard[row].join('\t'));
    }
}

// play(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// );
// play(["0 0",
//     "0 0",
//     "1 1",
//     "0 1",
//     "1 2",
//     "0 2",
//     "2 2",
//     "1 2",
//     "2 2",
//     "2 1"]
// )
// play(["0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 2",
//     "1 1",
//     "2 1",
//     "2 2",
//     "0 0"]
// );
