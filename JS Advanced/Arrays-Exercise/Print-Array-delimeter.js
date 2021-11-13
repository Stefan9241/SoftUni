function solve(array,delimeter) {
    let newArray = [];

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        newArray.push(element);
        if (index == array.length - 1) {
            break;
        }
        newArray.push(delimeter);
    }

    console.log(newArray.join(''));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five'],
    '-');