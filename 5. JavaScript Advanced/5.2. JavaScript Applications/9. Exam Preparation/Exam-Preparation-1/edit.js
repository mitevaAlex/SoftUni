import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';
import { isValid } from './create.js';

export async function editView(context) {
    let pet = await fetch(`http://localhost:3030/data/pets/${context.params.id}`)
        .then(async responce => await responce.json());
    let editForm = html`
        <!--Edit Page-->
        <section id="editPage">
            <form class="editForm">
                <img src="/images/editpage-dog.jpg">
                <div>
                    <h2>Edit PetPal</h2>
                    <div class="name">
                        <label for="name">Name:</label>
                        <input name="name" id="name" type="text" value=${pet.name}>
                    </div>
                    <div class="breed">
                        <label for="breed">Breed:</label>
                        <input name="breed" id="breed" type="text" value=${pet.breed}>
                    </div>
                    <div class="Age">
                        <label for="age">Age:</label>
                        <input name="age" id="age" type="text" value=${pet.age}>
                    </div>
                    <div class="weight">
                        <label for="weight">Weight:</label>
                        <input name="weight" id="weight" type="text" value=${pet.weight}>
                    </div>
                    <div class="image">
                        <label for="image">Image:</label>
                        <input name="image" id="image" type="text" value=${pet.image}>
                    </div>
                    <button id=${context.params.id} class="btn" type="submit" @click=${editPet}>Edit Pet</button>
                </div>
            </form>
        </section>`;
    render(editForm, main);
}

async function editPet(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let petId = event.currentTarget.id;
    let url = `http://localhost:3030/data/pets/${petId}`;
    let body = Object.fromEntries(formData);
    if (isValid(body)) {
        let header = getHeader('put', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect(`/details/${petId}`);
        }
    }
}