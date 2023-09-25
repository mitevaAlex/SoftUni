import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { container } from "./catalog.js";
import { getHeader } from './app.js';

export async function detailsView(context) {
    let pieceOfFurniture = await fetch(`http://localhost:3030/data/catalog/${context.params.id}`)
        .then(async responce => await responce.json());
    let detailsInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>`;
    let detailsElement = html`
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${pieceOfFurniture.img.slice(1)} />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${pieceOfFurniture.make}</span></p>
                <p>Model: <span>${pieceOfFurniture.model}</span></p>
                <p>Year: <span>${pieceOfFurniture.year}</span></p>
                <p>Description: <span>${pieceOfFurniture.description}</span></p>
                <p>Price: <span>${pieceOfFurniture.price} $</span></p>
                <p>Material: <span>${pieceOfFurniture.material}</span></p>
                ${sessionStorage.getItem('ownerId') === pieceOfFurniture._ownerId
                ? html`
                <div id=${context.params.id}>
                    <a href="#" class="btn btn-info"  @click=${viewEdit}>Edit</a>
                    <a href="#" class="btn btn-red" @click=${deleteFurniture}>Delete</a>
                </div>`
                : ''}
            </div>
        </div>`;
    render([detailsInfo, detailsElement], container);
}

async function viewEdit(event){
    page.redirect(`/edit/${event.target.parentElement.id}`);
}

async function deleteFurniture(event){
    let shallDelete = window.confirm('Do you want to delete this piece of furniture?');
    if(shallDelete){
        let furnitureId = event.target.parentElement.id;
        let url = `http://localhost:3030/data/catalog/${furnitureId}`;
        let header = getHeader('delete');
        let responce = await fetch(url, header);
        if(responce.status === 200){
            page.redirect('/');
        }
    }
}