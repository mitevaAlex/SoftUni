function checkIfInLimit(speed, area) {
    let limit;
    switch (area) {
        case 'motorway': limit = 130; break;
        case 'interstate': limit = 90; break;
        case 'city': limit = 50; break;
        case 'residential': limit = 20; break;
    }

    if (speed <= limit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`)
    } else {
        let kmOverLimit = speed - limit;
        let status;
        if (kmOverLimit <= 20) {
            status = 'speeding';
        } else if (kmOverLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${kmOverLimit} km/h faster than the allowed speed of ${limit} - ${status}`)
    }
}

// checkIfInLimit(40, 'city');
// checkIfInLimit(21, 'residential');
// checkIfInLimit(120, 'interstate');
// checkIfInLimit(200, 'motorway');