import { html, render } from './node_modules/lit-html/lit-html.js';
import { main } from './home.js';

export async function catalogView(context) {
    let albumsInfo = await fetch('http://localhost:3030/data/albums?sortBy=_createdOn%20desc&distinct=name')
        .then(async responce => await responce.json());
    let albums = html`
        <!--Catalog-->
        <section id="catalogPage">
            <h1>All Albums</h1>
            ${albumsInfo.length === 0
            ? html`<!--No albums in catalog-->
            <p>No Albums in Catalog!</p>`
            : albumsInfo.map(album)}
        </section>`;
    render(albums, main);
}

export function album(data) {
    return html`
        <div class="card-box">
            <img src=${data.imgUrl}>
            <div>
                <div class="text-center">
                    <p class="name">Name: ${data.name}</p>
                    <p class="artist">Artist: ${data.artist}</p>
                    <p class="genre">Genre: ${data.genre}</p>
                    <p class="price">Price: $${data.price}</p>
                    <p class="date">Release Date: ${data.releaseDate}</p>
                </div>
                ${sessionStorage.getItem('accessToken')
                ? html`
                <div class="btn-group">
                <a href="/details/${data._id}" id="details">Details</a>
                </div>`
                : ''}
            </div>
        </div>`;
}