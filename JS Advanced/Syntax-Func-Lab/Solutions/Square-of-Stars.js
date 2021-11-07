function solve(input){
    let star = '* ';
    for (let index = 0; index < input; index++) {
        console.log(star.repeat(input))
    }
}

solve(5);