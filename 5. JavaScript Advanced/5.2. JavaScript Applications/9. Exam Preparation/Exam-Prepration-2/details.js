import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function detailsView(context) {
    let album = await fetch(`http://localhost:3030/data/albums/${context.params.id}`)
        .then(async responce => await responce.json());
    let detailsElement = html`
        <!--Details Page-->
        <section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src=${album.imgUrl}>
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: $${album.price}</h4>
                        <h4>Date: ${album.releaseDate}</h4>
                        <p>Description: ${album.description}</p>
                    </div>
                    ${sessionStorage.getItem('ownerId') === album._ownerId
                    ? html`<!-- Only for registered user and creator of the album-->
                    <div class="actionBtn">
                        <a href="/edit/${context.params.id}" class="edit">Edit</a>
                        <a id=${context.params.id} href="#" class="remove" @click=${deleteAlbum}>Delete</a>
                    </div>`
                    : ''}
                </div>
            </div>
        </section>`;
    render(detailsElement, main);
}

async function deleteAlbum(event){
    let shallDelete = window.confirm('Do you want to delete this album?');
    if(shallDelete){
        let albumId = event.target.id;
        let url = `http://localhost:3030/data/albums/${albumId}`;
        let header = getHeader('delete');
        let responce = await fetch(url, header);
        if(responce.status === 200){
            page.redirect('/catalog');
        }
    }
}

