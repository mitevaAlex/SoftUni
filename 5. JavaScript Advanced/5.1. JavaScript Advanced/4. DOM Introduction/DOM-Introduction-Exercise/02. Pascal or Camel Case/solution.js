function solve() {
    let text = document.getElementById('text').value.toLowerCase();
    let format = document.getElementById('naming-convention').value;
    let words = text.split(' ');
    let result;
    switch (format) {
        case 'Pascal Case':
            result = words.map(x => x[0].toUpperCase() + x.slice(1)).join('');
            break;
        case 'Camel Case':
            result = words.shift() + words.map(x => x[0].toUpperCase() + x.slice(1)).join('');
            break;
        default:
            result = 'Error!';
            break;
    }

    document.getElementById('result').textContent = result;
}