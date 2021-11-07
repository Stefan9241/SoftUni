function solve(num1,num2){
    let start = Number(num1);
    let end = Number(num2);

    let result = 0;
    for (let index = start; index <= end; index++) {
        result += index;
    }

    console.log(result)
    }

    solve('1', '5'  );