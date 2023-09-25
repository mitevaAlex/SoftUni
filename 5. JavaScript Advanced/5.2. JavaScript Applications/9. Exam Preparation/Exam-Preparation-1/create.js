import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function createView() {
    let createForm = html`
        <!--Create Page-->
        <section id="createPage">
            <form class="createForm">
                <img src="./images/cat-create.jpg">
                <div>
                    <h2>Create PetPal</h2>
                    <div class="name">
                        <label for="name">Name:</label>
                        <input name="name" id="name" type="text" placeholder="Max">
                    </div>
                    <div class="breed">
                        <label for="breed">Breed:</label>
                        <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
                    </div>
                    <div class="Age">
                        <label for="age">Age:</label>
                        <input name="age" id="age" type="text" placeholder="2 years">
                    </div>
                    <div class="weight">
                        <label for="weight">Weight:</label>
                        <input name="weight" id="weight" type="text" placeholder="5kg">
                    </div>
                    <div class="image">
                        <label for="image">Image:</label>
                        <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
                    </div>
                    <button class="btn" type="submit" @click=${createPet}>Create Pet</button>
                </div>
            </form>
        </section>`;
    render(createForm, main);
}

async function createPet(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let url = 'http://localhost:3030/data/pets';
    let body = Object.fromEntries(formData);
    if(isValid(body)){
        let header = getHeader('post', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/');
        }
    }
}

export function isValid(body){
    for(let key in body){
        if(!body[key]){
            return false;
        }
    }

    return true;
}