import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { createOrEditForm } from './create.js';
import { container } from './catalog.js';
import { getHeader } from './app.js';

export async function editView(context) {
    let pieceOfFurniture = await fetch(`http://localhost:3030/data/catalog/${context.params.id}`)
        .then(async responce => await responce.json());
    let editInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>`;
    render([editInfo, createOrEditForm(pieceOfFurniture)], container);
}

export async function editFurniture(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let isValid = form.querySelectorAll('.is-invalid').length === 0;
    if (isValid) {
        let furnitureId = event.currentTarget.id;
        let url = `http://localhost:3030/data/catalog/${furnitureId}`;
        let body = {
            make: formData.get('make'),
            model: formData.get('model'),
            year: Number(formData.get('year')),
            description: formData.get('description'),
            price: Number(formData.get('price')),
            img: formData.get('img'),
            material: formData.get('material')
        };
        let header = getHeader('put', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/');
        }
    }
}