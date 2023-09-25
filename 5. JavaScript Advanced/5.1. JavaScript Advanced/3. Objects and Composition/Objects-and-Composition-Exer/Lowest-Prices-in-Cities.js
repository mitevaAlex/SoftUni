function printLowestPrices(productsInfo) {
    let products = [];
    for (let productInfo of productsInfo) {
        let [town, productName, price] = productInfo.split(' | ');
        price = Number(price);
        if (!products.hasOwnProperty(productName)) {
            products[productName] = {
                town,
                price
            };
        } else {
            if (products[productName].price > price) {
                products[productName].price = price;
                products[productName].town = town;
            }
        }
    }

    for (let productName in products) {
        console.log(`${productName} -> ${products[productName].price} (${products[productName].town})`);
    }
}

// printLowestPrices(['Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10']
// );