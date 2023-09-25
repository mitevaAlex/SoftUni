import { html, render } from './node_modules/lit-html/lit-html.js';

export let container = document.querySelector('.container');

export async function catalogView(context) {
    let furnitureInfo = await fetch('http://localhost:3030/data/catalog')
        .then(async responce => await responce.json());
    let welcomeInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>`;
    render([welcomeInfo, furniture(furnitureInfo)], container);
}

function pieceOfFurniture(data) {
    return html`
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                    <img src=${data.img} />
                    <p>${data.description}</p>
                    <footer>
                        <p>Price: <span>${data.price} $</span></p>
                    </footer>
                    <div>
                        <a href="/details/${data._id}" class="btn btn-info">Details</a>
                    </div>
            </div>
        </div>
    </div>`;
}

export function furniture(furnitureInfo) {
    return html`
    <div class="row space-top">
        ${furnitureInfo.map(pieceOfFurniture)}
    </div>`;
}