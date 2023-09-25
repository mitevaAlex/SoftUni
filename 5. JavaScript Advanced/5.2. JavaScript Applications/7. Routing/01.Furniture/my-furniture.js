import { html, render } from './node_modules/lit-html/lit-html.js';
import { container, furniture } from './catalog.js';

export async function myFurnitureView(context) {
    let userId = sessionStorage.ownerId;
    let furnitureInfo = await fetch(`http://localhost:3030/data/catalog?where=_ownerId%3D%22${userId}%22`)
        .then(async responce => await responce.json());
    let myFurnitureInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>`;
    render([myFurnitureInfo, furniture(furnitureInfo)], container);
}