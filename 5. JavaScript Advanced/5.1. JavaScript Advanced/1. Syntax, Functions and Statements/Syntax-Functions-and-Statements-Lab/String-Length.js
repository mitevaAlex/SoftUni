function calculateLengths(string1, string2, string3) {
    let lengthsSum = string1.length + string2.length + string3.length;
    let averageLength = Math.floor(lengthsSum / 3);
    console.log(lengthsSum);
    console.log(averageLength);
}

// calculateLengths('chocolate', 'ice cream', 'cake');
// calculateLengths('pasta', '5', '22.3');