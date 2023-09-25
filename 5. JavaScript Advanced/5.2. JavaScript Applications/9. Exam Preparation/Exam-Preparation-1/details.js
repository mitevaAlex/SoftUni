import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function detailsView(context) {
    let pet = await fetch(`http://localhost:3030/data/pets/${context.params.id}`)
        .then(async responce => await responce.json());
    let detailsElement = html`
        <!--Details Page-->
        <section id="detailsPage">
            <div class="details">
                <div class="animalPic">
                    <img src=${pet.image.slice(2)}>
                </div>
                <div>
                    <div class="animalInfo">
                        <h1>Name: ${pet.name}</h1>
                        <h3>Breed: ${pet.breed}</h3>
                        <h4>Age: ${pet.age}</h4>
                        <h4>Weight: ${pet.weight}</h4>
                        <h4 class="donation">Donation: 0$</h4>
                    </div>
                    ${sessionStorage.getItem('ownerId') === pet._ownerId
                    ? html`<!-- if there is no registered user, do not display div-->
                    <div class="actionBtn" id=${context.params.id}>
                        <!-- Only for registered user and creator of the pets-->
                        <a href="#" class="edit" @click=${viewEdit}>Edit</a>
                        <a href="#" class="remove" @click=${deletePet}>Delete</a>
                    </div>`
                    : ''}
                </div>
            </div>
        </section>`;
    render(detailsElement, main);
}

async function viewEdit(event){
    page.redirect(`/edit/${event.target.parentElement.id}`);
}

async function deletePet(event){
    let shallDelete = window.confirm('Do you want to delete this pet?');
    if(shallDelete){
        let petId = event.target.parentElement.id;
        let url = `http://localhost:3030/data/pets/${petId}`;
        let header = getHeader('delete');
        let responce = await fetch(url, header);
        if(responce.status === 200){
            page.redirect('/');
        }
    }
}