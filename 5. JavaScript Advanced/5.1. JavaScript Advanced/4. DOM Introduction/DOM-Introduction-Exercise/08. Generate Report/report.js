function generateReport() {
    let cols = document.getElementsByTagName('th');
    let reportObjects = [];
    let rows = document.querySelectorAll('tbody tr');
    for (let row of rows) {
        let rowObj = {};
        for (let i = 0; i < cols.length; i++) {
            if (cols[i].children[0].checked == true) {
                rowObj[cols[i].children[0].name] = row.children[i].textContent;
            }
        }

        reportObjects.push(rowObj);
    }

    document.getElementById('output').textContent = JSON.stringify(reportObjects, null, 2);
}