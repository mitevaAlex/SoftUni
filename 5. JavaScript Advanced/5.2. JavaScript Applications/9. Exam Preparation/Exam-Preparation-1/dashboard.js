import { html, render } from './node_modules/lit-html/lit-html.js';
import { main } from './home.js';

export async function dashboardView(context) {
    let petsInfo = await fetch('http://localhost:3030/data/pets?sortBy=_createdOn%20desc&distinct=name')
        .then(async responce => await responce.json());
    let pets = html`
        <!--Dashboard-->
        <section id="dashboard">
            <h2 class="dashboard-title">Services for every animal</h2>
            <div class="animals-dashboard">
                ${!petsInfo
                ? html`<!--If there is no pets in dashboard-->
                <div>
                    <p class="no-pets">No pets in dashboard</p>
                </div>`
                : petsInfo.map(pet)}
            </div>`;
    render(pets, main);
}

function pet(data) {
    return html`
    <div class="animals-board">
        <article class="service-img">
            <img class="animal-image-cover" src=${data.image.slice(1)}>
        </article>
        <h2 class="name">${data.name}</h2>
        <h3 class="breed">${data.breed}</h3>
        <div class="action">
            <a class="btn" href="/details/${data._id}">Details</a>
        </div>
    </div>`;
}