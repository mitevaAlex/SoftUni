function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    function onClick() {
        let tableRows = document.querySelectorAll('tbody tr');
        let searchItem = document.getElementById('searchField').value;
        document.getElementById('searchField').value = '';
        for (let row = 0; row < tableRows.length; row++) {
            tableRows[row].classList.remove('select');
            let cols = tableRows[row].children;
            for (let col = 0; col < cols.length; col++) {
                if (cols[col].textContent.includes(searchItem)) {
                    tableRows[row].classList.add('select');
                    break;
                }
            }
        }
    }
}
debugger;