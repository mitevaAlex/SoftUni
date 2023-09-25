function sumTable() {
    let tableElements = Array.from(document.getElementsByTagName('table')[0].children[0].getElementsByTagName('td'));
    let sum = 0;
    for (let i = 1; i < tableElements.length - 1; i += 2) {
        sum += Number(tableElements[i].textContent);
    }
    document.getElementById('sum').textContent = sum;
}