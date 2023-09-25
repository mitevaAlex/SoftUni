function wordsToUpperCase(text) {
    let words = text.split(/\W/).filter(a => a);
    for (let i = 0; i < words.length; i++) {
        words[i] = words[i].toUpperCase();
    }

    console.log(words.join(', '));
}

// wordsToUpperCase('Hi, how are you?');
// wordsToUpperCase('hello');