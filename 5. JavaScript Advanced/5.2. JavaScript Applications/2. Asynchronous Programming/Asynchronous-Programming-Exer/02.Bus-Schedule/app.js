function solve() {
    let currentStop = document.querySelector('#info .info');
    let currentStopId = 'depot';
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentStopId}`)
            .then(responce => responce.json())
            .then(data => {
                currentStop.textContent = `Next stop ${data.name}`;
                departBtn.disabled = true;
                arriveBtn.disabled = false;
            })
            .catch(error => {
                currentStop.textContent = 'Error';
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            });
    }

    function arrive() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentStopId}`)
            .then(responce => responce.json())
            .then(data => {
                currentStop.textContent = `Arriving at ${data.name}`;
                currentStopId = data.next;
                departBtn.disabled = false;
                arriveBtn.disabled = true;
            })
            .catch(error => {
                currentStop.textContent = 'Error';
                departBtn.disabled = true;
                arriveBtn.disabled = true;
            });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();