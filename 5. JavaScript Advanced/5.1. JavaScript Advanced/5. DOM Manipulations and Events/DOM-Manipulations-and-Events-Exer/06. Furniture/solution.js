function solve() {
    let generateButton = Array.from(document.getElementsByTagName('button')).find(x => x.textContent === 'Generate');
    generateButton.addEventListener('click', generate);

    let buyButton = Array.from(document.getElementsByTagName('button')).find(x => x.textContent === 'Buy');
    buyButton.addEventListener('click', buy);

    function generate(event) {
        let inputObjs = JSON.parse(document.getElementsByTagName('textarea')[0].value);
        let table = document.getElementsByTagName('tbody')[0];
        for (let obj of inputObjs) {
            let row = document.createElement('tr');
            let imgData = document.createElement('td');
            let image = document.createElement('img');
            image.src = obj.img;
            imgData.appendChild(image)
            row.appendChild(imgData);

            let nameData = document.createElement('td');
            let name = document.createElement('p');
            name.textContent = obj.name;
            nameData.appendChild(name);
            row.appendChild(nameData);

            let priceData = document.createElement('td');
            let price = document.createElement('p');
            price.textContent = obj.price;
            priceData.appendChild(price);
            row.appendChild(priceData);

            let decFactorData = document.createElement('td');
            let decFactor = document.createElement('p');
            decFactor.textContent = obj.decFactor;
            decFactorData.appendChild(decFactor);
            row.appendChild(decFactorData);

            let checkData = document.createElement('td');
            let checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkData.appendChild(checkbox);
            row.appendChild(checkData);

            table.appendChild(row);
        }
    }

    function buy(event) {
        let checkedItems = Array.from(document.querySelectorAll('tbody tr')).filter(x => x.getElementsByTagName('input')[0].checked === true);
        let items = [];
        for (let item of checkedItems) {
            let itemObj = {
                name: item.children[1].children[0].textContent,
                price: Number(item.children[2].children[0].textContent),
                decFactor: Number(item.children[3].children[0].textContent)
            }

            items.push(itemObj)
        }

        let outputArea = document.getElementsByTagName('textarea')[1];
        outputArea.value = `Bought furniture: ${items.map(x => x.name).join(', ')}\n`;
        outputArea.value += `Total price: ${items.reduce((sum, item) => sum += item.price, 0).toFixed(2)}\n`;
        outputArea.value += `Average decoration factor: ${items.reduce((sum, item) => sum += item.decFactor, 0) / items.length}`;

    }
}