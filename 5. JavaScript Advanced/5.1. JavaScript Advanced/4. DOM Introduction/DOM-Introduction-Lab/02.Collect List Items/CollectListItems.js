function extractText() {
    let elements = Array.from(document.getElementById('items').children);
    document.getElementById('result').textContent = elements.map(x => x.textContent).join('\n');
}