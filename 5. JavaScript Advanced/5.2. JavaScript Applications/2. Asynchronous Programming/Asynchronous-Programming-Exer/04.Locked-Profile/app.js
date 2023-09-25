async function lockedProfile() {
    let main = document.querySelector('#main');
    main.innerHTML = '';
    await fetch('http://localhost:3030/jsonstore/advanced/profiles')
        .then(async responce => await responce.json())
        .then(data => {
            let counter = 1;
            for (let profile of Object.values(data)) {
                main.innerHTML +=
                    `<div class="profile">
                        <img src="./iconProfile2.png" class="userIcon" />
                        <label>Lock</label>
                        <input type="radio" name="user${counter}Locked" value="lock" checked>
                        <label>Unlock</label>
                        <input type="radio" name="user${counter}Locked" value="unlock"><br>
                        <hr>
                        <label>Username</label>
                        <input type="text" name="user${counter}Username" value="${profile.username}" disabled readonly />
                        <div class="user${counter}HiddenFields hiddenInfo">
                            <hr>
                            <label>Email:</label>
                            <input type="email" name="user${counter}Email" value="${profile.email}" disabled readonly />
                            <label>Age:</label>
                            <input type="text" name="user${counter}Age" value="${profile.age}" disabled readonly />
                        </div>
                        <button>Show more</button>
                    </div>`;
                counter++;
            }

            Array.from(main.querySelectorAll('.profile button')).forEach(x => x.addEventListener('click', profileBtnClicked));
        });

    function profileBtnClicked(event) {
        let profileElement = event.target.parentElement;
        let button = event.target;
        if (profileElement.querySelector('input[type="radio"][value="unlock"]').checked) {
            if (button.textContent === 'Show more') {
                profileElement.querySelector('.hiddenInfo').classList.remove('hiddenInfo');
                button.textContent = 'Hide it';
            } else if (button.textContent === 'Hide it') {
                profileElement.querySelector('div').classList.add('hiddenInfo');
                button.textContent = 'Show more';
            }
        }
    }
}

