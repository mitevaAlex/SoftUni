function calcCircleArea(radius) {
    let inputType = typeof (radius);
    if (inputType === "number") {
        let area = Math.PI * (radius ** 2);
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

// calcCircleArea(5);
// calcCircleArea('name');