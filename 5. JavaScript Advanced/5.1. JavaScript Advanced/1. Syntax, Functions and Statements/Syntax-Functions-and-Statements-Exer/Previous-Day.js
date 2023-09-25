function printPreviousDate(year, month, day) {
    let previous = new Date(year, month - 1, day);
    previous.setDate(previous.getDate() - 1);

    console.log(`${previous.getFullYear()}-${previous.getMonth() + 1}-${previous.getDate()}`);
}

// printPreviousDate(2016, 9, 30);
// printPreviousDate(2016, 10, 1);