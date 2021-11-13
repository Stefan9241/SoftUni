function solve(array) {
    array = array.sort((a,b) => a.localeCompare(b));

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        console.log(`${index + 1}.${element}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"]);