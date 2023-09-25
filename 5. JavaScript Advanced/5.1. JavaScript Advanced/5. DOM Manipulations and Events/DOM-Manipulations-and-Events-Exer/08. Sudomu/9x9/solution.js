function solve() {
    let checkBtn = document.getElementsByTagName('button')[0];
    checkBtn.addEventListener('click', check);

    let clearBtn = document.getElementsByTagName('button')[1];
    clearBtn.addEventListener('click', clear);

    function check(event) {
        let rows = document.querySelectorAll('tbody tr');
        let matrix = [];
        for (let row of rows) {
            matrix.push(Array.from(row.children).map(x => Number(x.children[0].value)));
        }
        
        for (let row = 0; row < matrix.length; row++) {
            if (matrix[row].filter(x => x > matrix.length || x < 1).length > 0) {
                wrong();
                return;
            }

            for (let i = 1; i <= matrix.length; i++) {
                if (matrix[row].filter(y => y === i).length > 1) {
                    wrong();
                    return;
                }
            }
        }

        for (let col = 0; col < matrix.length; col++) {
            let colArr = [];
            for (let row = 0; row < matrix.length; row++) {
                colArr.push(matrix[row][col]);
            }

            for (let i = 1; i <= matrix.length; i++) {
                if (colArr.filter(y => y === i).length > 1) {
                    wrong();
                    return;
                }
            }
        }

        correct();
        return;

        function correct() {
            document.getElementsByTagName('table')[0].style.border = '2px solid green';
            let resultParagraph = document.querySelector('#check p');
            resultParagraph.textContent = 'You solve it! Congratulations!';
            resultParagraph.style.color = 'green';
        }

        function wrong() {
            document.getElementsByTagName('table')[0].style.border = '2px solid red';
            let resultParagraph = document.querySelector('#check p');
            resultParagraph.textContent = 'NOP! You are not done yet...';
            resultParagraph.style.color = 'red';
        }
    }

    function clear() {
        document.getElementsByTagName('table')[0].style.border = 'none';
        document.querySelector('#check p').textContent = '';
        Array.from(document.querySelectorAll('tbody tr td input')).forEach(x => x.value = '');
    }
}