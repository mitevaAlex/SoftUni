function sort(arr) {
    arr.sort((a, b) => criteria(a, b));

    function criteria(a, b) {
        if (a.length > b.length) return 1;
        if (a.length < b.length) return -1;

        a.toUpperCase();
        b.toUpperCase();
        if (a > b) return 1;
        if (a < b) return -1;
    }

    console.log(arr.join('\n'));
}

// sort(['alpha',
//     'beta',
//     'gamma']
// );
// sort(['Isacc',
//     'Theodor',
//     'Jack',
//     'Harrison',
//     'George']
// );
// sort(['test',
//     'Deny',
//     'omen',
//     'Default']
// );
