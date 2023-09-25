function sort(nums) {
    nums.sort((a, b) => a - b);
    let sorted = [];
    for (let i = 0; i < nums.length / 2; i++) {
        sorted.push(nums[i]);
        sorted.push(nums[nums.length - i - 1]);
    }

    if (nums.length % 2 != 0) {
        sorted.pop();
    }
    return sorted;
}

// console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));