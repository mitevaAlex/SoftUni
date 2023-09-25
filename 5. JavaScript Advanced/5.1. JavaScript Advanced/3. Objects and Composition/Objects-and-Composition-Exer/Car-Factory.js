function assembleCar(requirements) {
    const car = {
        model: requirements.model,
        engine: {},
        carriage: {
            type: requirements.carriage,
            color: requirements.color
        },
        wheels: [0, 0, 0, 0]
    };

    if (requirements.power <= 90) {
        car.engine.power = 90;
        car.engine.volume = 1800;
    } else if (requirements.power <= 120) {
        car.engine.power = 120;
        car.engine.volume = 2400;
    } else if (requirements.power <= 200) {
        car.engine.power = 200;
        car.engine.volume = 3500;
    }

    let wheelsize = requirements.wheelsize % 2 == 0 ? requirements.wheelsize - 1 : requirements.wheelsize;
    car.wheels = car.wheels.fill(wheelsize);
    return car;
}

// console.log(assembleCar({
//     model: 'VW Golf II',
//     power: 90,
//     color: 'blue',
//     carriage: 'hatchback',
//     wheelsize: 14
// }
// ));
// console.log(assembleCar({
//     model: 'Opel Vectra',
//     power: 110,
//     color: 'grey',
//     carriage: 'coupe',
//     wheelsize: 17
// }
// ));