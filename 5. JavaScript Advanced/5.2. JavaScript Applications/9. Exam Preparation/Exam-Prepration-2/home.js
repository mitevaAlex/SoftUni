import { html, render } from './node_modules/lit-html/lit-html.js';

export let main = document.querySelector('main');

export function homeView(){
    let home = html`
        <!--Home Page-->
        <section id="welcomePage">
            <div id="welcome-message">
                <h1>Welcome to</h1>
                <h1>My Music Application!</h1>
            </div>

            <div class="music-img">
                <img src="./images/musicIcons.webp">
            </div>
        </section>`;
        
    render(home, main);
}