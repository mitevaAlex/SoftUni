function printSmallestTwo (nums) {
    nums.sort((a, b) => a - b);
    let smallestNums = nums.slice(0, 2);
    console.log(smallestNums.join(' '));
}

// printSmallestTwo([30, 15, 50, 5]);
// printSmallestTwo([3, 0, 10, 4, 7, 3]);