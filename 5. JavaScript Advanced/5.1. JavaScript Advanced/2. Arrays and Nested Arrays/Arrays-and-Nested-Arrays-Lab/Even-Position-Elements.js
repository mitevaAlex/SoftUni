function logEvenPositionElements(elements) {
    let evenPositionElements = [];
    for (let i = 0; i < elements.length; i++) {
        if (i % 2 == 0) {
            evenPositionElements[i / 2] = elements[i];
        }
    }

    console.log(evenPositionElements.join(' '));
}

// logEvenPositionElements(['20', '30', '40', '50', '60']);
// logEvenPositionElements(['5', '10']);