class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.contactElement = this.createDOMElement();
        this.online = false;
    }

    get online() {
        return this._online;
    }

    set online(value) {
        if (value === true) {
            this.contactElement.querySelector('.title').classList.add('online');
        } else {
            this.contactElement.querySelector('.title').classList.remove('online');
        }

        this._online = value;
    }

    render(id) {
        let container = document.getElementById(id);
        container.appendChild(this.contactElement);
    }

    createDOMElement() {
        let contact = document.createElement('article');
        contact.innerHTML =
            `<div class="title">${this.firstName} ${this.lastName}<button>&#8505;</button><div>
            <div style="display:none;" class="info">
                <span>&phone; ${this.phone}</span>
                <span>&#9993; ${this.email}</span>
            </div>`;
        let showInfoBtn = contact.querySelector('button');
        showInfoBtn.addEventListener('click', this.showInfo);
        return contact;
    }

    showInfo(event) {
        event.target.parentElement
            .parentElement.querySelector('.info').style.display = 'block';
    }
}

// let contacts = [
//     new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
//     new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
//     new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
// ];
// contacts.forEach(c => c.render('main'));

// // After 1 second, change the online status to true
// setTimeout(() => contacts[1].online = true, 2000);
