function printDeckOfCards(cardsInfo) {
    try {
        let cards = [];
        for (let cardInfo of cardsInfo) {
            let face;
            let suit;
            if (cardInfo.length === 3) {
                face = cardInfo[0] + cardInfo[1];
                suit = cardInfo[2];
            } else if (cardInfo.length === 2) {
                face = cardInfo[0];
                suit = cardInfo[1];
            }

            cards.push(createCard(face, suit));
        }

        console.log(cards.join(' '));
        function createCard(face, suit) {
            let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
            let validSuits = {
                'S': '\u2660',
                'H': '\u2665',
                'D': '\u2666',
                'C': '\u2663'
            };

            if (!validFaces.includes(face) || !Object.keys(validSuits).includes(suit)) {
                throw new Error(face + suit);;
            }

            let card = {
                face,
                suit: validSuits[suit],
                toString() {
                    return this.face + this.suit;
                }
            }

            return card;
        }
    } catch (exception) {
        console.log(`Invalid card: ${exception.message}`);
    }
}

// printDeckOfCards(['AS', '10D', 'KH', '2C']);
// printDeckOfCards(['5S', '3D', 'QD', '1C']);
