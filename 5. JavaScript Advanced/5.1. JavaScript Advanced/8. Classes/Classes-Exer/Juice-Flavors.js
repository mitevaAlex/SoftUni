function produceBottles(juicesInfo) {
    let juices = [];
    let bottles = [];
    for (let juiceArgs of juicesInfo) {
        juiceArgs = juiceArgs.split(' => ');
        let fruit = juiceArgs[0];
        let quantity = Number(juiceArgs[1]);
        if (!juices.hasOwnProperty(fruit)) {
            juices[fruit] = 0;
        }

        juices[fruit] += quantity;
        if (juices[fruit] >= 1000) {
            let newBottles = Math.floor(juices[fruit] / 1000);
            juices[fruit] -= 1000 * newBottles;
            if (!bottles.hasOwnProperty(fruit)) {
                bottles[fruit] = 0;
            }

            bottles[fruit] += newBottles;
        }
    }

    console.log(Object.keys(bottles).map(fruit => `${fruit} => ${bottles[fruit]}`).join('\n'));
}

// produceBottles(['Orange => 2000',
//     'Peach => 1432',
//     'Banana => 450',
//     'Peach => 600',
//     'Strawberry => 549']
// );

// produceBottles(['Kiwi => 234',
//     'Pear => 2345',
//     'Watermelon => 3456',
//     'Kiwi => 4567',
//     'Pear => 5678',
//     'Watermelon => 6789']
// );