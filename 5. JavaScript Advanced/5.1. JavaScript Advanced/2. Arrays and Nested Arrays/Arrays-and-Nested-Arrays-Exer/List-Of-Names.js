function sortNames(names) {
    names.sort((a, b) => a.localeCompare(b)).forEach((value, index) => console.log(`${index + 1}.${value}`));
}

// sortNames(["John", "Bob", "Christina", "Ema"]);