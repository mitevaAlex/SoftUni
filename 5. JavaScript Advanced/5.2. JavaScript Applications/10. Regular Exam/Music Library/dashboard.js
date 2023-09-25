import { html, render } from './node_modules/lit-html/lit-html.js';
import { main } from './home.js';

export async function dashboardView(context) {
    let albumsInfo = await fetch('http://localhost:3030/data/albums?sortBy=_createdOn%20desc')
        .then(async responce => await responce.json());
    let albums = html`
    <!-- Dashboard page -->
    <section id="dashboard">
        <h2>Albums</h2>
        <ul class="card-wrapper">
            <!-- Display a li with information about every post (if any)-->
            ${albumsInfo.length === 0
            ? html`<!-- Display an h2 if there are no posts -->
            <h2>There are no albums added yet.</h2>`
            : albumsInfo.map(album)}
        </ul>`;
    render(albums, main);
}

export function album(data) {
    return html`
        <li class="card">
            <img src=${data.imageUrl} alt="travis" />
            <p>
                <strong>Singer/Band: </strong><span class="singer">${data.singer}</span>
            </p>
            <p>
                <strong>Album name: </strong><span class="album">${data.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${data.sales}</span></p>
            <a class="details-btn" href="/details/${data._id}">Details</a>
        </li>`;
}