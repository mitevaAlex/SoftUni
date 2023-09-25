let bookSelection = require('./solution');
let expect = require('chai').expect;

describe('bookSelection', () => {
    describe('isGenreSuitable', () => {
        it('should return unsuitable if age <= 12 and genre is horror or thriller', () => {
            let age1 = 12;
            let age2 = 5;
            let genre1 = 'Horror';
            let genre2 = 'Thriller';
            expect(bookSelection.isGenreSuitable(genre1, age1)).to.equal(`Books with ${genre1} genre are not suitable for kids at ${age1} age`);
            expect(bookSelection.isGenreSuitable(genre2, age2)).to.equal(`Books with ${genre2} genre are not suitable for kids at ${age2} age`);
        });

        it('should return suitable otherwise', () => {
            let age1 = 13;
            let age2 = 5;
            let genre1 = 'Horror';
            let genre2 = 'Fantasy';
            expect(bookSelection.isGenreSuitable(genre1, age1)).to.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable(genre2, age2)).to.equal(`Those books are suitable`);
        });
    });

    describe('isItAffordable', () => {
        it('should validate number input', () => { 
            let invalid1 = '15';
            let invalid2 = [45];
            expect(() => {bookSelection.isItAffordable(invalid1, invalid2)}).to.throw('Invalid input');
            expect(() => {bookSelection.isItAffordable(invalid1, 45)}).to.throw('Invalid input');
            expect(() => {bookSelection.isItAffordable(15, invalid2)}).to.throw('Invalid input');
        });

        it('should return no enough money if budget is not enough', () => { 
            let price = 45;
            let budget = 15;
            expect(bookSelection.isItAffordable(price, budget)).to.equal("You don't have enough money");
        });

        it('should return book bought if enough budget', () => { 
            let price = 15;
            let budget = 45;
            let difference = budget - price;
            expect(bookSelection.isItAffordable(price, budget)).to.equal(`Book bought. You have ${difference}$ left`);
        });
    });

    describe('suitableTitles', () => {
        it('should validate array and string input', () => { 
            let invalidArray1 = '[{ title: "The Da Vinci Code", genre: "Thriller" }]';
            let invalidString1 = ['Horror'];
            expect(() => {bookSelection.suitableTitles(invalidArray1, invalidString1)}).to.throw('Invalid input');
            expect(() => {bookSelection.suitableTitles(invalidArray1, 'Horror')}).to.throw('Invalid input');
            expect(() => {bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller" }], invalidString1)}).to.throw('Invalid input');
        });

        it('should return the books of wanted genre', () => { 
            let books = [
                { title: "The Da Vinci Code", genre: "Thriller" }, 
                {title: "Hobbit", genre: "Fantasy"},
                {title: "After", genre: "Romantic"},
                {title: "It", genre: "Horror"},
                {title: "50 Shades of Grey", genre: "Romantic"}
            ];
            let wantedGenre = 'Romantic';
            let expected = books.filter(x => x.genre === wantedGenre).map(x => x.title);
            expect(bookSelection.suitableTitles(books, wantedGenre).values).to.equal(expected.values);
        });
    });
});
