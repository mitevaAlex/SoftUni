function solve() {
    document.querySelector('button').addEventListener('click', onClick);
    let toOption = document.querySelector('#selectMenuTo');
    toOption.innerHTML = '<option selected value="binary">Binary</option>';
    toOption.innerHTML += '<option selected value="hexadecimal">Hexadecimal</option>';
    function onClick() {
        let input = Number(document.querySelector('#input').value);
        let parser = {
            'binary'(input) {
                return input.toString(2);
            },
            'hexadecimal'(input) {
                return input.toString(16).toUpperCase();
            }
        }

        let output = parser[Array.from(toOption.children).find(x => x.selected == true).value](input);
        document.getElementById('result').value = output;
    }
}