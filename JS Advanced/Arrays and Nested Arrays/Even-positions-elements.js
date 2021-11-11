function solve(array) {
    let newArray = [];
    for (let index = 0; index < array.length; index += 2) {
        const element = array[index];
        newArray.push(element)
    }
    console.log(newArray.join(' '));
}

solve(['20', '30', '40', '50', '60']);
solve(['5', '10']);