function notify(message) {
    let messageDiv = document.getElementById('notification');
    messageDiv.textContent = message;
    messageDiv.style.display = 'block';
    messageDiv.addEventListener('click', hideMessage);

    function hideMessage(event) {
        event.target.style.display = 'none';
    }
}