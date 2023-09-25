function solve() {
    let [task, date] = document.querySelectorAll('form input');
    let description = document.querySelector('form textarea');
    let sections = document.querySelectorAll('section');
    document.querySelector('#add').addEventListener('click', addTask);

    function addTask(event) {
        event.preventDefault();
        if (task.value && description.value && date.value) {
            let outputDiv = sections[1].children[1];
            let outputArticle = document.createElement('article');

            let taskOutput = document.createElement('h3');
            taskOutput.textContent = task.value;

            let descriptionOutput = document.createElement('p');
            descriptionOutput.textContent = 'Description: ' + description.value;

            let dateOutput = document.createElement('p');
            dateOutput.textContent = 'Due Date: ' + date.value;

            let buttonsDiv = document.createElement('div');
            buttonsDiv.classList.add('flex');

            let startBtn = document.createElement('button');
            startBtn.classList.add('green');
            startBtn.textContent = 'Start';
            startBtn.addEventListener('click', moveToProgress);

            let deleteBtn = document.createElement('button');
            deleteBtn.classList.add('red');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteTask);

            buttonsDiv.appendChild(startBtn);
            buttonsDiv.appendChild(deleteBtn);

            outputArticle.appendChild(taskOutput);
            outputArticle.appendChild(descriptionOutput);
            outputArticle.appendChild(dateOutput);
            outputArticle.appendChild(buttonsDiv);

            outputDiv.appendChild(outputArticle);

            task.value = '';
            date.value = '';
            description.value = '';
        }
    }

    function moveToProgress(event) {
        let wholeTaskInfo = event.target.parentElement.parentElement;
        let buttonsDiv = event.target.parentElement;

        let finishBtn = document.createElement('button');
        finishBtn.classList.add('orange');
        finishBtn.textContent = 'Finish';
        finishBtn.addEventListener('click', finish);

        buttonsDiv.appendChild(finishBtn);
        buttonsDiv.removeChild(buttonsDiv.children[0]);

        sections[1].children[1].removeChild(wholeTaskInfo);
        sections[2].children[1].appendChild(wholeTaskInfo);
    }

    function deleteTask(event) {
        event.target.parentElement.parentElement.parentElement.removeChild(
            event.target.parentElement.parentElement);
    }

    function finish(event) {
        let wholeTaskInfo = event.target.parentElement.parentElement;
        wholeTaskInfo.removeChild(wholeTaskInfo.getElementsByTagName('div')[0]);

        sections[2].children[1].removeChild(wholeTaskInfo);
        sections[3].children[1].appendChild(wholeTaskInfo);
    }
}