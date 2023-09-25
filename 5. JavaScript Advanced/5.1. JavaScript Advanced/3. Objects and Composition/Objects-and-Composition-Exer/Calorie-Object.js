function foodCalories(foodsInfo) {
    const foods = {};
    for (let i = 0; i < foodsInfo.length - 1; i += 2) {
        foods[foodsInfo[i]] = Number(foodsInfo[i + 1]);
    }

    console.log(foods);
}

// foodCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
// foodCalories(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);