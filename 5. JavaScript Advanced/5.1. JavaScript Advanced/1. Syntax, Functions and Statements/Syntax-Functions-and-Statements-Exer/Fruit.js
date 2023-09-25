function calculateMoney(fruit, weight, pricePerKilo) {
    let money = weight / 1000 * pricePerKilo;
    console.log(`I need $${money.toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${fruit}.`)
}

// calculateMoney('orange', 2500, 1.80);
// calculateMoney('apple', 1563, 2.35);