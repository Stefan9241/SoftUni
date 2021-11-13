function solve(array, number) {
    let newArr = [];
    for (let index = 0; index < array.length; index+= number) {
        const element = array[index];
        newArr.push(element);
    }

    return newArr;
}

console.log(solve(['5',
    '20',
    '31',
    '4',
    '20'],
    2));

    console.log(solve(['1', 
    '2',
    '3', 
    '4', 
    '5'], 
    6));