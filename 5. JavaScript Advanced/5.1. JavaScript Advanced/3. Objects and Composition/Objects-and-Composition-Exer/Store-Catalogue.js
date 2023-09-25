function createCatalogue(productsInfo) {
    let products = [];
    for (let productInfo of productsInfo) {
        let [productName, price] = productInfo.split(' : ');
        price = Number(price);
        products.push({ productName, price });
    }

    products.sort((a, b) => a.productName.localeCompare(b.productName));
    let dictionary = [];
    for (let product of products) {
        let productFirstLetter = product.productName[0];
        if (dictionary.hasOwnProperty(productFirstLetter)) {
            dictionary[productFirstLetter].push(product);
        } else {
            dictionary[productFirstLetter] = [product];
        }
    }

    for (let letter in dictionary) {
        console.log(`${letter}`);
        console.log(`${dictionary[letter].map(product => `  ${product.productName}: ${product.price}`).join('\n')}`);
    }
}

// createCatalogue(['Appricot : 20.4',
//     'Fridge : 1500',
//     'TV : 1499',
//     'Deodorant : 10',
//     'Boiler : 300',
//     'Apple : 1.25',
//     'Anti-Bug Spray : 15',
//     'T-Shirt : 10']
// );
// createCatalogue(['Banana : 2',
//     "Rubic's Cube : 5",
//     'Raspberry P : 4999',
//     'Rolex : 100000',
//     'Rollon : 10',
//     'Rali Car : 2000000',
//     'Pesho : 0.000001',
//     'Barrel : 10']
// );
