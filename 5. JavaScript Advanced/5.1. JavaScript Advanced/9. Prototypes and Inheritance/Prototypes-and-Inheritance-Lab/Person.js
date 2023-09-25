function createPerson(firstName, lastName) {
    class Person {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + ' ' + lastName;
        }

        get fullName() { return this.firstName + ' ' + this.lastName; }

        set fullName(value) {
            let names = value.split(' ');
            if(names.length == 2) {
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }
    }

    return new Person(firstName, lastName);
}

// let person = createPerson("Peter", "Ivanov");
// console.log(person.fullName); //Peter Ivanov
// person.firstName = "George";
// console.log(person.fullName); //George Ivanov
// person.lastName = "Peterson";
// console.log(person.fullName); //George Peterson
// person.fullName = "Nikola Tesla";
// console.log(person.firstName); //Nikola
// console.log(person.lastName); //Tesla

// let person = createPerson("Albert", "Simpson");
// console.log(person.fullName); //Albert Simpson
// person.firstName = "Simon";
// console.log(person.fullName); //Simon Simpson
// person.fullName = "Peter";
// console.log(person.firstName);  // Simon
// console.log(person.lastName);  // Simpson