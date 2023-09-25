let locationName = document.getElementById('location');
let weatherSymbol = {
    'Sunny': '&#x2600',
    'Partly sunny': '&#x26C5',
    'Overcast': '&#x2601',
    'Rain': '&#x2614',
    'Degrees': '&#176'
};

document.getElementById('submit').addEventListener('click', attachEvents);

async function getLocation(locationName) {
    let locationInfo = await fetch('http://localhost:3030/jsonstore/forecaster/locations')
        .then(responce => responce.json())
        .then(data => data.find(x => x.name === locationName.value))
        .catch(error => { forecastElement.textContent = 'Error'; });
    return locationInfo;
}

async function getCurrentCondtions(locationCode) {
    let currentConditions = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`)
        .then(responce => responce.json())
        .catch(error => { forecastElement.textContent = 'Error'; });
    return currentConditions;
}

async function get3DayCondtions(locationCode) {
    let threeDayConditions = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`)
        .then(responce => responce.json())
        .catch(error => { forecastElement.textContent = 'Error'; });
    return threeDayConditions
}

async function attachEvents() {
    document.querySelector('.forecasts')?.remove();
    document.querySelector('.forecast-info')?.remove();
    let forecastElement = document.getElementById('forecast');
    forecastElement.style.display = 'block';
    let locationInfo = await getLocation(locationName);
    let currentConditions = await getCurrentCondtions(locationInfo.code);
    let threeDayConditions = await get3DayCondtions(locationInfo.code);

    document.getElementById('current').innerHTML +=
        `<div class="forecasts">
            <span class="condition symbol">${weatherSymbol[currentConditions.forecast.condition]}</span>
            <span class="condition">
                <span class="forecast-data">${currentConditions.name}</span>
                <span class="forecast-data">${currentConditions.forecast.low}${weatherSymbol.Degrees}/${currentConditions.forecast.high}${weatherSymbol.Degrees}</span>
                <span class="forecast-data">${currentConditions.forecast.condition}</span>
            </span>
        </div>`;

    document.getElementById('upcoming').innerHTML += `<div class="forecast-info"></div>`;
    let upcoming = document.querySelector('#upcoming .forecast-info');
    for (let conditions of threeDayConditions.forecast) {
        upcoming.innerHTML +=
            `<span class="upcoming">
            <span class="symbol">${weatherSymbol[conditions.condition]}</span>
            <span class="forecast-data">${conditions.low}${weatherSymbol.Degrees}/${conditions.high}${weatherSymbol.Degrees}</span>
            <span class="forecast-data">${conditions.condition}</span>
        </span>`;
    }
}

