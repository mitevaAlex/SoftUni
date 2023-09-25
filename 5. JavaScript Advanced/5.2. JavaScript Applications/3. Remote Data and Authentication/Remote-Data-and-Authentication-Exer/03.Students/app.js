document.getElementById('results').onload = loadStudents();
document.getElementById('submit').addEventListener('click', createStudent);

class Student {
    constructor(firstName, lastName, facultyNumber, grade) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.facultyNumber = facultyNumber;
        this.grade = Number(grade);
    }
}

async function createStudent() {
    firstName = document.getElementsByName('firstName')[0];
    lastName = document.getElementsByName('lastName')[0];
    facultyNumber = document.getElementsByName('facultyNumber')[0];
    grade = document.getElementsByName('grade')[0];
    let student = new Student(firstName.value, lastName.value, facultyNumber.value, grade.value);
    await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(student),
    });

    loadStudents();
}

async function loadStudents() {
    let container = document.querySelector('#results tbody');
    container.innerHTML = '';
    let students = await fetch('http://localhost:3030/jsonstore/collections/students')
        .then(async responce => await responce.json())
        .then(data => {
            Object.values(data)
                .forEach(x => {
                    student = new Student(x.firstName, x.lastName, x.facultyNumber, x.grade);
                    let row = document.createElement('tr');
                    for (let tableData in student) {
                        row.appendChild(createTableData(student[tableData]));
                    }

                    container.appendChild(row);
                });
        });
}

function createTableData(textContent) {
    let td = document.createElement('td');
    // if (typeof textContent === 'number') {
    //     textContent = textContent.toFixed(2);
    // }
    td.textContent = textContent;
    return td;
}