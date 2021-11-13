function solve(array,times) {
    for (let index = 0; index < times; index++) {
        array.unshift(array.pop())
    }

    console.log(array.join(' '));
}

solve(['1', 
'2', 
'3', 
'4'], 
2);