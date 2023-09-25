function getInfo() {
    let busStopId = document.getElementById('stopId');
    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopId.value}`)
        .then((response) => response.json())
        .then((data) => handleBusData(data))
        .catch((error) => handleError(error));

    function handleBusData(data) {
        let busesList = document.getElementById('buses');
        busesList.innerHTML = '';
        document.getElementById('stopName').textContent = data.name;
        for(let busId in data.buses) {
            busesList.innerHTML += `<li>Bus ${busId} arrives in ${data.buses[busId]} minutes</li>`;
        }
    }

    function handleError(error){
        document.getElementById('stopName').textContent = 'Error';
        document.getElementById('buses').innerHTML = '';
    }
}

