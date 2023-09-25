function sum(array, startIndex, endIndex) {
    if (Array.isArray(array) === false) {
        return NaN;
    }

    startIndex = startIndex < 0 ? 0 : startIndex;
    endIndex = endIndex > array.length - 1 ? array.length - 1 : endIndex;

    return array
    .slice(startIndex, endIndex + 1)
        .map(Number)
        .reduce((sum, num) => sum += num, 0);
}

// console.log(sum([10, 20, 30, 40, 50, 60], 3, 300));
// console.log(sum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
// console.log(sum([10, 'twenty', 30, 40], 0, 2));
// console.log(sum([], 1, 2));
// console.log(sum('text', 0, 2));