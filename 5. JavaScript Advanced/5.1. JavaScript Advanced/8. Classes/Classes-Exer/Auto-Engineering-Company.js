function produceCars(carsInfo) {
    let carBrands = [];
    for (let carArgs of carsInfo) {
        carArgs = carArgs.split(' | ');
        let brand = carArgs[0];
        let model = carArgs[1];
        let count = Number(carArgs[2]);
        if (!carBrands.hasOwnProperty(brand)) {
            carBrands[brand] = [];
        }

        if (!carBrands[brand].hasOwnProperty(model)) {
            carBrands[brand][model] = 0;
        }

        carBrands[brand][model] += count;
    }

    let result = '';
    for (let brand in carBrands) {
        result += brand + '\n';
        for (let model in carBrands[brand]) {
            result += `###${model} -> ${carBrands[brand][model]}\n`;
        }
    }

    console.log(result.trim());
}

// produceCars(['Audi | Q7 | 1000',
//     'Audi | Q6 | 100',
//     'BMW | X5 | 1000',
//     'BMW | X6 | 100',
//     'Citroen | C4 | 123',
//     'Volga | GAZ-24 | 1000000',
//     'Lada | Niva | 1000000',
//     'Lada | Jigula | 1000000',
//     'Citroen | C4 | 22',
//     'Citroen | C5 | 10']
// );