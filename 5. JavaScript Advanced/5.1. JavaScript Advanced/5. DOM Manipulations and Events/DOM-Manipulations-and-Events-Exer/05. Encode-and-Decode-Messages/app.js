function encodeAndDecodeMessages() {
    let sendButton = document.getElementsByTagName('button')[0];
    sendButton.addEventListener('click', encodeAndSend);
    let decodeButton = document.getElementsByTagName('button')[1];
    decodeButton.addEventListener('click', decodeAndRead);

    function encodeAndSend(event) {
        let sender = document.getElementsByTagName('textarea')[0];
        let message = sender.value;
        sender.value = '';
        let messageChars = message.split('').map(x => String.fromCharCode((x.charCodeAt(0) + 1)));
        let receiver = document.getElementsByTagName('textarea')[1];
        receiver.textContent = messageChars.join('');
    }

    function decodeAndRead(event) {
        let receiver = document.getElementsByTagName('textarea')[1];
        let message = receiver.textContent;
        let messageChars = message.split('').map(x => String.fromCharCode((x.charCodeAt(0) - 1)));
        receiver.textContent = messageChars.join('');
    }
}