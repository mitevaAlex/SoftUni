window.addEventListener("load", solve);

function solve() {
    let submitBtn = document.querySelector('#right button');
    submitBtn.addEventListener('click', submit);

    let product = document.getElementById('type-product');
    let description = document.getElementById('description');
    let clientName = document.getElementById('client-name');
    let clientPhone = document.getElementById('client-phone');
    let receivedOrders = document.getElementById('received-orders');
    let completedOrders = document.getElementById('completed-orders');

    let clearBtn = completedOrders.querySelector('.clear-btn');
    clearBtn.addEventListener('click', clear);

    function submit(event) {
        event.preventDefault();
        if (description.value && clientName.value && clientPhone.value) {
            receivedOrders.innerHTML +=
                `<div class="container">
                    <h2>Product type for repair: ${product.value}</h2>
                    <h3>Client information: ${clientName.value}, ${clientPhone.value}</h3>
                    <h4>Description of the problem: ${description.value}</h4>
                    <button class="start-btn">Start repair</button>
                    <button class="finish-btn" disabled>Finish repair</button>
                </div>`;
            let startBtn = receivedOrders.lastChild.querySelector('.start-btn');
            startBtn.addEventListener('click', start);
            let finishBtn = receivedOrders.lastChild.querySelector('.finish-btn');
            finishBtn.addEventListener('click', finish);

            product.value = 'Computer';
            description.value = '';
            clientName.value = '';
            clientPhone.value = '';
        }
    }

    function start(event) {
        event.target.disabled = true;
        event.target.parentElement.querySelector('.finish-btn').disabled = false;
    }

    function finish(event) {
        let startBtn = event.target.parentElement.querySelector('.start-btn');
        let finishBtn = event.target;
        let currentOrderDiv = event.target.parentElement;
        currentOrderDiv.removeChild(startBtn);
        currentOrderDiv.removeChild(finishBtn);
        receivedOrders.removeChild(currentOrderDiv);
        completedOrders.appendChild(currentOrderDiv);
    }

    function clear(event){
        let orders = completedOrders.querySelectorAll('.container');
        for(let order of orders){
            completedOrders.removeChild(order);
        }
    }
}