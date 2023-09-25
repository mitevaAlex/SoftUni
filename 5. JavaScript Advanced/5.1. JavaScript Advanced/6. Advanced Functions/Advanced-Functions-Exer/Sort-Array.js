function sortArray(array, order){
    array.sort((a, b) => a - b);
    if (order === 'desc') {
        array.reverse();
    }

    return array;
}

// sortArray([14, 7, 17, 6, 8], 'asc');
// sortArray([14, 7, 17, 6, 8], 'desc');

