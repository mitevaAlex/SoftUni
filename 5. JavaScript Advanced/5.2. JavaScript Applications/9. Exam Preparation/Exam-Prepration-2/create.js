import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function createView() {
    let createForm = html`
        <!--Create Page-->
        <section class="createPage">
            <form>
                <fieldset>
                    <legend>Add Album</legend>

                    <div class="container">
                        <label for="name" class="vhide">Album name</label>
                        <input id="name" name="name" class="name" type="text" placeholder="Album name">

                        <label for="imgUrl" class="vhide">Image Url</label>
                        <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" placeholder="Image Url">

                        <label for="price" class="vhide">Price</label>
                        <input id="price" name="price" class="price" type="text" placeholder="Price">

                        <label for="releaseDate" class="vhide">Release date</label>
                        <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" placeholder="Release date">

                        <label for="artist" class="vhide">Artist</label>
                        <input id="artist" name="artist" class="artist" type="text" placeholder="Artist">

                        <label for="genre" class="vhide">Genre</label>
                        <input id="genre" name="genre" class="genre" type="text" placeholder="Genre">

                        <label for="description" class="vhide">Description</label>
                        <textarea name="description" class="description" placeholder="Description"></textarea>

                        <button class="add-album" type="submit" @click=${createAlbum}>Add New Album</button>
                    </div>
                </fieldset>
            </form>
        </section>`;
    render(createForm, main);
}

async function createAlbum(event) {
    event.preventDefault();
    let form = document.querySelector('form');
    let formData = new FormData(form);
    let url = 'http://localhost:3030/data/albums';
    let body = Object.fromEntries(formData);
    if(isValid(body)){
        let header = getHeader('post', body);
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/catalog');
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