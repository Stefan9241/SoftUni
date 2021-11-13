function solve(array) {
    array = array.sort((a,b)=> a-b);

    for (let index = 0; index < array.length; index+=2) {
        const element = array.pop();
        array.splice(index + 1,0,element);
    }

    return array;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));