function processOddPositions(nums) {
    let newArr = [];
    for (let i = 1; i < nums.length; i+=2) {
        newArr.push(nums[i] * 2);
    }

    return newArr.reverse().join(' ');
}

// console.log(processOddPositions([10, 15, 20, 25]));
// console.log(processOddPositions([3, 0, 10, 4, 7, 3]));