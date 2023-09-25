class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let addedVeggieTypes = [];
        for (let veggieArgs of vegetables) {
            let [type, quantity, price] = veggieArgs.split(' ');
            quantity = Number(quantity);
            price = Number(price);
            let veggie = this.availableProducts.find(x => x.type === type);
            if (!veggie) {
                this.availableProducts.push({ type, quantity, price });
            } else {
                veggie.quantity += quantity;
                if (veggie.price < price) {
                    veggie.price = price;
                }
            }

            if (!addedVeggieTypes.find(x => x === type)) {
                addedVeggieTypes.push(type);
            }
        }

        return `Successfully added ${addedVeggieTypes.join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;
        for (let veggieArgs of selectedProducts) {
            let [type, quantity] = veggieArgs.split(' ');
            quantity = Number(quantity);
            let veggie = this.availableProducts.find(x => x.type === type);
            if (!veggie) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            if (veggie.quantity < quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            totalPrice += quantity * veggie.price;
            veggie.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        let veggie = this.availableProducts.find(x => x.type === type);
        if (!veggie) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (veggie.quantity < quantity) {
            veggie.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        veggie.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`
    }

    revision() {
        let result = 'Available vegetables:';
        result += '\n' + this.availableProducts
            .sort((a, b) => a.price - b.price)
            .map(x => `${x.type}-${x.quantity}-$${x.price}`)
            .join('\n');
        result += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`
        return result;
    }
}

'Available vegetables:\nCelery-4.5-$2.5,Beans-2-$2.8,Okra-0-$3.5\nThe owner of the store is Jerrie Munro, and the location is 1463 Pette Kyosheta, Sofia.'
'Available vegetables:\nCelery-4.5-$2.5\nBeans-2-$2.8\nOkra-0-$3.5\nThe owner of the store is Jerrie Munro, and the location is 1463 Pette Kyosheta, Sofia.'



// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));


// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.buyingVegetables(["Okra 1"]));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
// console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"]));
