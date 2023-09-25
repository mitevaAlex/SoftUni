function editElement(reference, match, replacer) {
    let matcher = new RegExp(match, 'g');
    reference.textContent = reference.textContent.replace(matcher, replacer);
}