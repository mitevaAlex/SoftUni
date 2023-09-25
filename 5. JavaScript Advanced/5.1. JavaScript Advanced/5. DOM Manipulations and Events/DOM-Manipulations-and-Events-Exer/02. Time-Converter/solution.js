function attachEventsListeners() {
    let buttons = Array.from(document.getElementsByTagName('input')).filter(x => x.type === 'button');
    buttons.forEach(x => x.addEventListener('click', convert));

    function convert(event) {
        let inputElement = event.target.parentElement.getElementsByTagName('input')[0];
        let parser = {
            'days'(days) {
                document.getElementById('hours').value = days * 24;
                document.getElementById('minutes').value = days * 24 * 60;
                document.getElementById('seconds').value = days * 24 * 60 * 60;
            },
            'hours'(hours) {
                document.getElementById('days').value = hours / 24;
                document.getElementById('minutes').value = hours * 60;
                document.getElementById('seconds').value = hours * 60 * 60;
            },
            'minutes'(minutes) {
                document.getElementById('days').value = minutes / 24 / 60;
                document.getElementById('hours').value = minutes / 60;
                document.getElementById('seconds').value = minutes * 60;
            },
            'seconds'(seconds) {
                document.getElementById('days').value = seconds / 24 / 60 / 60;
                document.getElementById('hours').value = seconds / 60 / 60;
                document.getElementById('minutes').value = seconds / 60;
            }
        }

        parser[inputElement.id](Number(inputElement.value));
    }
}