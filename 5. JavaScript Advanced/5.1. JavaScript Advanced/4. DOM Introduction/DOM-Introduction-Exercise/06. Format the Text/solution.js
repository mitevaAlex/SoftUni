function solve() {
    let input = document.getElementById('input').value;
    let output = document.getElementById('output');
    output.innerHTML = '';
    let sentences = input.split('.').filter(x => x.length >= 1);
    let i = 0;
    for (; i < sentences.length - 2; i += 3) {
        output.innerHTML += `<p>${sentences.slice(i, i + 3).join('.')}.</p>`;
    }

    if (sentences.length - i > 0 && sentences.length - i < 3) {
        output.innerHTML += `<p>${sentences.slice(i).join('.')}.</p>`;
    }
}