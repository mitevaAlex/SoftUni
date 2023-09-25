function sortAndReturnHalf(nums) {
    nums.sort((a, b) => a - b);
    return nums.slice(nums.length / 2);
}

// console.log(sortAndReturnHalf([4, 7, 2, 5]));
// console.log(sortAndReturnHalf([3, 19, 14, 7, 2, 19, 6]));