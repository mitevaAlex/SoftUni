function extractIncreasingSubset(nums) {
    let increasingSubset = [nums[0]];
    for (let i = 1; i < nums.length; i++) {
        if (increasingSubset[increasingSubset.length - 1] <= nums[i]) {
            increasingSubset.push(nums[i]);
        }
    }

    return increasingSubset;
}

// console.log(extractIncreasingSubset([1,
//     3,
//     8,
//     4,
//     10,
//     12,
//     3,
//     2,
//     24]
// ));
// console.log(extractIncreasingSubset([1,
//     2,
//     3,
//     4]
// ));
// console.log(extractIncreasingSubset([20,
//     3,
//     2,
//     15,
//     6,
//     1]
// ));    
