function solve(array) {
    let newArr = [];

    for (let index = 1; index < array.length; index+=2) {
        const element = array[index];
        newArr.push(element);
    }

    result = newArr.map(x=> x * 2).reverse();
    return result.join(' ');
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));