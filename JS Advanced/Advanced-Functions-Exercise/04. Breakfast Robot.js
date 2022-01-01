function solution(input) {
    let recipes = {
        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, flavour: 3, fat: 7},
        eggs: {flavour: 1, fat: 1,protein: 5},
        turkey: {carbohydrate: 10,flavour: 10,fat: 10,protein: 10},
    }

    let storage = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0,
    }
    function restock(element, quantity) {
        storage[element] += +quantity;
        return "Success";
    }

    function prepare(recipe, quantity) {
        let remainingStorage = {};

        for (const recipeElement in recipes[recipe]) {
            let remaining = storage[recipeElement] - Number(recipes[recipe][recipeElement]) * quantity;
            if (remaining < 0) {
                return `Error: not enough ${recipeElement} in stock`;
            }

            remainingStorage[recipeElement] = remaining;

        }

        Object.assign(storage, remainingStorage);
        return "Success";
    }

    function report() {
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
    }


    function controller(array) {
        let [command, element, amount] = array.split(" ");
        switch (command) {
            case "prepare":
                return prepare(element, amount);
            case "report":
                return report();
            case "restock":
                return restock(element, amount);
        }
    }

    return controller;
}

let manager = solution();
console.log(manager("restock flavour 50"));// Success
console.log(manager("prepare lemonade 4"));// Error: not enough carbohydrate in stock

