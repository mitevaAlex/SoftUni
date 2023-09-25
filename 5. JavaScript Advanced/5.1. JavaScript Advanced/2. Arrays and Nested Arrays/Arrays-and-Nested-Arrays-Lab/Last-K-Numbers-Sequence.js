function numsSequence(n, k) {
    let sequence =  [1];
    for (let j = 1; j < n; j++) {
        let currentNum = 0;
        for (let i = (j - k < 0) ? 0 : j - k; i < k + i; i++) {
            if(!sequence[i]) break;
            currentNum += sequence[i];
        }

        sequence.push(currentNum);
    }

    return sequence;
}

// console.log(numsSequence(6, 3));
// console.log(numsSequence(8, 2));