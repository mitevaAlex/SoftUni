function solve() {
    let addBtn = document.querySelector('#add-new button');
    addBtn.addEventListener('click', addMovie);
    let clearBtn = document.querySelector('#archive button');
    clearBtn.addEventListener('click', clearArchive);

    function addMovie(event) {
        event.preventDefault();
        let inputs = Array.from(document.querySelectorAll('#add-new input'));
        let nameInput = inputs.find(x => x.placeholder == 'Name');
        let hallInput = inputs.find(x => x.placeholder == 'Hall');
        let priceInput = inputs.find(x => x.placeholder == 'Ticket Price');
        if (nameInput.value && hallInput.value && priceInput.value && !isNaN(Number(priceInput.value))) {
            let movieList = document.querySelector('#movies ul');
            let listItem = document.createElement('li');
            listItem.innerHTML = `<span>${nameInput.value}</span>
            <strong>Hall: ${hallInput.value}</strong>
            <div>
            <strong>${Number(priceInput.value).toFixed(2)}</strong>
            <input placeholder = "Tickets Sold">
            <button>Archive</button>
            </div>`;
            let archiveBtn = listItem.querySelector('button');
            archiveBtn.addEventListener('click', archiveMovie);
            movieList.appendChild(listItem);
            nameInput.value = '';
            hallInput.value = '';
            priceInput.value = '';
        }
    }

    function archiveMovie(event) {
        let ticketsSold = event.target.parentElement.querySelector('input');
        if(ticketsSold.value && !isNaN(Number(ticketsSold.value))){
            let movieInfo = event.target.parentElement.parentElement;
            let name = movieInfo.querySelector('span');
            let price = movieInfo.querySelectorAll('strong')[1];
            let listItem = document.createElement('li');
            listItem.innerHTML = `<span>${name.textContent}</span>
            <strong>Total amount: ${(Number(ticketsSold.value) * Number(price.textContent)).toFixed(2)}</strong>
            <button>Delete</button>`;
            let deleteBtn = listItem.querySelector('button');
            deleteBtn.addEventListener('click', deleteMovie);
            let archiveList = document.querySelector('#archive ul');
            archiveList.appendChild(listItem);
            let movieList = document.querySelector('#movies ul');
            movieList.removeChild(movieInfo);
        }
    }

    function deleteMovie(event){
        let archiveList = document.querySelector('#archive ul');
        archiveList.removeChild(event.target.parentElement); 
    }

    function clearArchive(event){
        let archiveList = document.querySelector('#archive ul');
        archiveList.remove(archiveList.children); 
    }
}