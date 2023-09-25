function heroicInventory(heroesArgs) {
    let heroes = [];
    for (let heroArgs of heroesArgs) {
        heroArgs = heroArgs.split(' / ');
        let hero = {
            name: heroArgs[0],
            level: Number(heroArgs[1]),
            items: heroArgs[2] ? heroArgs[2].split(', ') : []
        }

        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes));
}

// heroicInventory(['Isacc / 25 / Apple, GravityGun',
//     'Derek / 12 / BarrelVest, DestructionSword',
//     'Hes / 1 / Desolator, Sentinel, Antara']
// );
// heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']);