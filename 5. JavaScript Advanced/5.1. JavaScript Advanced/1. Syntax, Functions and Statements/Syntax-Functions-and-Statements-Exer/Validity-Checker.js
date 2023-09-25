function validatePoints(x1, y1, x2, y2) {
    let firstPointToBeginningDistance = Math.sqrt(x1 ** 2 + y1 ** 2);
    let secondPointToBeginningDistance = Math.sqrt(x2 ** 2 + y2 ** 2);
    let firstPointToSecondPointDistance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
    console.log(`{${x1}, ${y1}} to {0, 0} is ${validationResult(firstPointToBeginningDistance)}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${validationResult(secondPointToBeginningDistance)}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validationResult(firstPointToSecondPointDistance)}`);

    function validationResult(distance) {
        if (Number.isInteger(distance)) {
            return 'valid';
        } else {
            return 'invalid';
        } 
    }
}

// validatePoints(3, 0, 0, 4);
// validatePoints(2, 1, 1, 1);