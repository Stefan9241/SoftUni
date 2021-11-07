function solve(num1,num2,text){
let result;
if(text === '+'){
    result = num1 + num2;
}
else if(text === '-'){
result = num1 - num2;
}
else if(text === '*'){
    result = num1 * num2;
}
else if(text === '/'){
    result = num1 / num2;
}
else if(text === '%'){
    result = num1 % num2;
}
else if(text === '**'){
    result = num1 ** num2;
}

console.log(result);
}
solve(3, 5.5, '*')
solve(5, 6, '+' );
solve(3, 5.5, '**' )