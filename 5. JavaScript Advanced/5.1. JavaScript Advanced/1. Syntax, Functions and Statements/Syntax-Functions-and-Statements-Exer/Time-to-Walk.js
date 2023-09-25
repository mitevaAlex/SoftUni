function calcTime(steps, footprintLengthInMeters, kmPerHour) {
    let distanceInMeters = steps * footprintLengthInMeters;
    let extraMinutes = Math.floor(distanceInMeters / 500);
    let timeInHours =  (distanceInMeters / 1000 / kmPerHour) + (extraMinutes / 60);
    let hours = Math.floor(timeInHours);
    let minutes = Math.floor(timeInHours * 60);
    let seconds = Math.round((timeInHours * 60 - minutes) * 60);
    console.log(`${hours < 10 ? '0' + hours : hours}:${minutes < 10 ? '0' + minutes : minutes}:${seconds < 10 ? '0' + seconds : seconds}`)
}

// calcTime(4000, 0.6, 5);
// calcTime(2564, 0.70, 5.5);
