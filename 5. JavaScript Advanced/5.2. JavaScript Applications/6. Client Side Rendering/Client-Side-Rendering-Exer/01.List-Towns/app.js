import { html, render } from './node_modules/lit-html/lit-html.js';

let form = document.querySelector('form');
form.addEventListener('submit', loadTowns);
let body = document.getElementById('root');

function loadTowns(event) {
    event.preventDefault();
    let formData = new FormData(form);
    let { towns } = Object.fromEntries(formData);
    towns = towns.split(', ');
    let townList = html`
        <ul>
            ${towns.map((town) => html`<li>${town}</li>`)}
        </ul>`;
    render(townList, body);
}