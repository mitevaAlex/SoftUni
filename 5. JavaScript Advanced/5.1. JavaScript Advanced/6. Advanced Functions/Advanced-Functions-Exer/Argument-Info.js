function typeAndValueInfo (...values) {
    let typesCount = {};
    for (let value of values) {
        let type = typeof(value);
        console.log(`${type}: ${value}`);
        if(!typesCount.hasOwnProperty(type)) {
            typesCount[type] = 0;
        }

        typesCount[type]++;
    }

    console.log(Object.keys(typesCount).map(type => `${type} = ${typesCount[type]}`).join('\n'));
}

// typeAndValueInfo('cat', 42, function () { console.log('Hello world!'); });