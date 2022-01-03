function createCard(input1, input2) {

    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663',
    }
    if (!validFaces.includes(input1)) {
        throw new Error("Erorr");
    }

    if (Object.keys(suits).includes(input2) == false) {
        throw new Error("Erorr");
    }
    return {
        input1,
        suit: suits[input2],
        toString() {
            return this.input1 + this.suit;
        }
    }
}


let card1 = createCard('10', 'H');
console.log(card1.toString());