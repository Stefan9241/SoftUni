function solve(array,first,second) {
    let startIndex = array.indexOf(first);
    let endIndex = array.indexOf(second);

    let newArr = array.slice(startIndex,endIndex + 1);

    return newArr;
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'));