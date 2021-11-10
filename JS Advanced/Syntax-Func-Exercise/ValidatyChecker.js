function solve(x1,y1,x2,y2) {

    function getResult(x1,y1,x2,y2) {
        let result = Math.sqrt((x2 - x1)**2+(y2-y1)**2);

        return Number.isInteger(result) ? 'valid' : 'invalid';
    }
    
    console.log(`{${x1}, ${y1}} to {0, 0} is ${getResult(x1,y1,0,0)}`)
    console.log(`{${x2}, ${y2}} to {0, 0} is ${getResult(0,0,x2,y2)}`)
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${getResult(x1,y1,x2,y2)}`)
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);