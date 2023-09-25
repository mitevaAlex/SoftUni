function solution() {
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let recipes = {
        apple: {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2
        },
        lemonade: {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20
        },
        burger: {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            carbohydrate: 0,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    let cook = {
        restock(microelement, quantity) {
            stock[microelement] += Number(quantity);
            return 'Success';
        },
        prepare(recipe, quantity) {
            quantity = Number(quantity);
            let neededIngredients = [];
            for (let ingredient in recipes[recipe]) {
                if (stock[ingredient] - (recipes[recipe][ingredient] * quantity) < 0) {
                    return `Error: not enough ${ingredient} in stock`;
                }

                neededIngredients[ingredient] = recipes[recipe][ingredient] * quantity;
            }

            for (let ingredient in neededIngredients) {
                stock[ingredient] -= neededIngredients[ingredient];
            }

            return 'Success';
        },
        report() {
            return Object.keys(stock).map(ingredient => `${ingredient}=${stock[ingredient]}`).join(' ');
        }
    }

    return function (command) {
        let commandArgs = command.split(' ');
        return cook[commandArgs[0]](commandArgs[1], commandArgs[2]);
    }
}

// let manager = solution();

// console.log(manager("restock flavour 50")); // Success 
// console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 

// console.log(manager("restock flavour 50"));
// console.log(manager("prepare lemonade 4"));
// console.log(manager("restock carbohydrate 10"));
// console.log(manager("restock flavour 10"));
// console.log(manager("prepare apple 1"));
// console.log(manager("restock fat 10"));
// console.log(manager("prepare burger 1"));
// console.log(manager("report"));

// console.log(manager("prepare turkey 1"));
// console.log(manager("restock protein 10"));
// console.log(manager("prepare turkey 1"));
// console.log(manager("restock carbohydrate 10"));
// console.log(manager("prepare turkey 1"));
// console.log(manager("restock fat 10"));
// console.log(manager("prepare turkey 1"));
// console.log(manager("restock flavour 10"));
// console.log(manager("prepare turkey 1"));
// console.log(manager("report"));
