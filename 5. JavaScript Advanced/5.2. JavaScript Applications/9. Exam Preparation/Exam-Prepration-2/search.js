import { html, render } from './node_modules/lit-html/lit-html.js';
import { main } from './home.js';
import { album } from './catalog.js';

export async function searchView(context) {
    let searchElement = html`
        <!--Search Page-->
        <section id="searchPage">
            <h1>Search by Name</h1>

            <div class="search">
                <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
                <button class="button-list" @click=${searchAlbum}>Search</button>
            </div>

            <h2>Results:</h2>
            
            <section id="results" class="search-result"></section>
        </section>`;

    render(searchElement, main);
}

async function searchAlbum(event) {
    let searchQuery = document.querySelector('#search-input');
    let resultsSection = document.querySelector('#results');
    if (searchQuery.value) {
        let albumsInfo = await fetch(`http://localhost:3030/data/albums?where=name%20LIKE%20%22${searchQuery.value}%22`)
            .then(async responce => await responce.json());
        let results = html`${albumsInfo.length !== 0
            ? albumsInfo.map(album)
            : html`<!--If there are no matches-->
            <p class="no-result">No result.</p>`}`;
        render(results, resultsSection);
    } else {
        render('', resultsSection);
    }
}