function createTowns(townsInfo) {
    const towns = {};
    for (let townArgs of townsInfo) {
        townArgs = townArgs.split(' <-> ');
        if (towns[townArgs[0]] == undefined) {
            towns[townArgs[0]] = Number(townArgs[1]);
        } else {
            towns[townArgs[0]] += Number(townArgs[1]);
        }
    }

    for (let town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }
}

// createTowns(['Sofia <-> 1200000',
//     'Montana <-> 20000',
//     'New York <-> 10000000',
//     'Washington <-> 2345000',
//     'Las Vegas <-> 1000000']
// );
// createTowns(['Istanbul <-> 100000',
//     'Honk Kong <-> 2100004',
//     'Jerusalem <-> 2352344',
//     'Mexico City <-> 23401925',
//     'Istanbul <-> 1000']
// );
