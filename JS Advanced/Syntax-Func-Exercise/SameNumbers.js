function solve(num){
    let numberToString = num.toString();
    let result = true;
    let sum = 0;
    for (let i = 0; i < numberToString.length; i++) {
        let currNumber = numberToString[i];
        let nextNumber = numberToString[i + 1];
        if (currNumber !== nextNumber && nextNumber != undefined) {
            result = false;
        }
        sum += Number(numberToString[i]);
    }
    return `${result}\n${sum}`

}

console.log(solve(2222222));
console.log(solve(1234));