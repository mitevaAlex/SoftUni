import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { container } from "./catalog.js";
import { getHeader } from "./app.js";
import { editFurniture } from './edit.js';

export async function createView() {
    let createInfo = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>`;
    render([createInfo, createOrEditForm()], container);
}

export function createOrEditForm(pieceOfFurniture) {
    return html`
    <form>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make">Make</label> 
                    <input class="form-control is-invalid" id="new-make" type="text" name="make" @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.make : ''}>
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model">Model</label>
                    <input class="form-control is-invalid" id="new-model" type="text" name="model"  @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.model : ''}>
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year">Year</label>
                    <input class="form-control is-invalid" id="new-year" type="number" name="year"  @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.year : ''}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description">Description</label>
                    <input class="form-control is-invalid" id="new-description" type="text" name="description"  @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.description : ''}>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price">Price</label>
                    <input class="form-control is-invalid" id="new-price" type="number" name="price"  @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.price : ''}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image">Image</label>
                    <input class="form-control is-invalid" id="new-image" type="text" name="img"  @input=${validateInput} value=${pieceOfFurniture ? pieceOfFurniture.img : ''}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material">Material (optional)</label>
                    <input class="form-control is-valid" id="new-material" type="text" name="material" value=${pieceOfFurniture ? pieceOfFurniture.material : ''}>
                </div>
                <input id=${pieceOfFurniture ? pieceOfFurniture._id : null} type="submit" class="btn btn-primary" value=${pieceOfFurniture ? "Edit" : 'Create'} @click=${pieceOfFurniture ? editFurniture : createFurniture}/>
            </div>
        </div>
    </form>`;
}

async function createFurniture(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let isValid = form.querySelectorAll('.is-invalid').length === 0;
    if (isValid) {
        let url = 'http://localhost:3030/data/catalog';
        let body = {
            make: formData.get('make'),
            model: formData.get('model'),
            year: Number(formData.get('year')),
            description: formData.get('description'),
            price: Number(formData.get('price')),
            img: formData.get('img'),
            material: formData.get('material')
        };
        let header = getHeader('post', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/');
        }
    }
}

function validateInput(event) {
    let input = event.target;
    let valid = () => {
        input.classList.remove('is-invalid');
        input.classList.add('is-valid');
    };
    let invalid = () => {
        input.classList.remove('is-valid');
        input.classList.add('is-invalid');
    };
    switch (input.name) {
        case 'make':
        case 'model':
            if (input.value.length >= 4) {
                valid()
            } else {
                invalid();
            }
            break;
        case 'year':
            if (input.value >= 1950 && input.value <= 2050) {
                valid()
            } else {
                invalid();
            }
            break;
        case 'description':
            if (input.value.length > 10) {
                valid()
            } else {
                invalid();
            }
            break;
        case 'price':
            if (input.value > 0) {
                valid()
            } else {
                invalid();
            }
            break;
        case 'img':
            if (input.value) {
                valid()
            } else {
                invalid();
            }
            break;
    }
}