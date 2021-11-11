function solve(array) {
    array.sort((a, b) => a - b);
    let firstArray = array.slice(0,array.length / 2);
    let secondArray = array.slice(array.length / 2)
    let arrayToPrint = [];

    if (firstArray.length > secondArray.length) {
        arrayToPrint = firstArray;
    }else{
        arrayToPrint = secondArray
    }

    return arrayToPrint;
}

solve([4, 7, 2, 5]);
solve([3, 19, 14, 7, 2, 19, 6]);