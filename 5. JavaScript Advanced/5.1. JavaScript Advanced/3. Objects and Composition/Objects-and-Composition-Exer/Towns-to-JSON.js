function createTownsJSON(townsInfo) {
    let towns = []
    for (let i = 1; i < townsInfo.length; i++) {
        let [Town, Latitude, Longitude] = townsInfo[i].split(/[ ]*\|[ ]*/).filter(x => x);
        Latitude = Number(Number(Latitude).toFixed(2));
        Longitude = Number(Number(Longitude).toFixed(2));
        let town = { Town, Latitude, Longitude };
        towns.push(town);
    }

    return JSON.stringify(towns)
}

// console.log(createTownsJSON(['| Town | Latitude | Longitude |',
//     '| Sofia | 42.696552 | 23.32601 |',
//     '| Beijing | 39.913818 | 116.363625 |']
// ));
// console.log(createTownsJSON(['| Town | Latitude | Longitude |',
//     '| Veliko Turnovo | 43.0757 | 25.6172 |',
//     '| Monatevideo | 34.50 | 56.11 |']
// ));