function solve(input){
    let result;

    let inputType = typeof(input);
    if(inputType === 'number'){
        result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else{
        result = `We can not calculate the circle area, because we receive a ${result}.`;
        console.log(result);
    }
}

solve(5);
solve('name');