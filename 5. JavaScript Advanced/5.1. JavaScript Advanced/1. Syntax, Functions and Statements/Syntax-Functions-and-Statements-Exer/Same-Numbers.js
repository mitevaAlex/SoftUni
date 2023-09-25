function checkIfSame(number) {
    let numAsStr = String(number);
    let isTheSame = true;
    let sum = 0;
    for (let i = 0; i < numAsStr.length - 1; i++) {
        sum += Number(numAsStr[i]);
        if (numAsStr[i] != numAsStr[i + 1]) {
            isTheSame = false;
        }
    }

    sum += Number(numAsStr[numAsStr.length - 1]);
    console.log(isTheSame);
    console.log(sum);
}

// checkIfSame(2222222); 
// checkIfSame(1234);