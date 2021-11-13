function solve(array) {
    let newArr = [];
    let biggest = 0;
    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        if (index === 0) {
            biggest = element;
            newArr.push(element);
        }

        if (element > biggest) {
            newArr.push(element);
            biggest = element;
        }
    }

    return newArr;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]));

    solve([1,2,3,4]);
    solve([20, 
        3, 
        2, 
        15,
        6, 
        1]);