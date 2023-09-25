import { html, render } from './node_modules/lit-html/lit-html.js';
import page from './node_modules/page/page.mjs';
import { getHeader } from "./app.js";
import { main } from './home.js';

export async function detailsView(context) {
    let album = await fetch(`http://localhost:3030/data/albums/${context.params.id}`)
        .then(async responce => await responce.json());
    let loggedInUser = sessionStorage.getItem('ownerId');
    let totalLikes = await fetch(`http://localhost:3030/data/likes?where=albumId%3D%22${album._id}%22&distinct=_ownerId&count`)
        .then(async responce => await responce.json());
    let likesForUser = await fetch(`http://localhost:3030/data/likes?where=albumId%3D%22${album._id}%22%20and%20_ownerId%3D%22${loggedInUser}%22&count`)
        .then(async responce => await responce.json());
    let detailsElement = html`
        <!-- Details page -->
        <section id="details">
            <div id="details-wrapper">
                <p id="details-title">Album Details</p>
                <div id="img-wrapper">
                    <img src=${album.imageUrl} alt="example1" />
                </div>
                <div id="info-wrapper">
                    <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
                    <p>
                        <strong>Album name:</strong><span id="details-album">${album.album}</span>
                    </p>
                    <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
                    <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
                    <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
                </div>
                <div id="likes">Likes: <span id="likes-count">${totalLikes}</span></div>
                ${loggedInUser === album._ownerId
                ? html`<!--Edit and Delete are only for creator-->
                <div id="action-buttons">
                    <a href="/edit/${context.params.id}" id="edit-btn">Edit</a>
                    <a id=${context.params.id} href="#" id="delete-btn" @click=${deleteAlbum}>Delete</a>
                </div>`
                : loggedInUser && likesForUser === 0
                ? html`<div id="action-buttons">
                <a href="#" id="like-btn" .albumId=${context.params.id} @click=${likeAlbum} >Like</a>
                </div>`
                : ''}
            </div>
        </section>`;
    render(detailsElement, main);
}

async function deleteAlbum(event) {
    let shallDelete = window.confirm('Do you want to delete this album?');
    if (shallDelete) {
        let albumId = event.target.id;
        let url = `http://localhost:3030/data/albums/${albumId}`;
        let header = getHeader('delete');
        let responce = await fetch(url, header);
        if (responce.status === 200) {
            page.redirect('/dashboard');
        }
    }
}

async function likeAlbum(event) {
    let url = 'http://localhost:3030/data/likes';
    let albumId = event.target.albumId;
    let body = {
        albumId
    };
    let header = getHeader('post', body);
    let responce = await fetch(url, header);
    if (responce.status === 200) {
        page.redirect(`/details/${albumId}`);
    }
}