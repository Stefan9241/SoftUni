function solve(array) {
    let newArr = [];
    let counter = 1;
    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        if (element === 'add') {
            newArr.push(counter);
        }else{
            newArr.pop();
        }
        counter++;
    }

    if (newArr.length === 0) {
        console.log('Empty');
    }
    else{
        for (const number of newArr) {
        console.log(number);
        }
    }
}

solve(['add', 
'add', 
'add', 
'add']
);

solve(['remove', 
'remove', 
'remove']);

solve(['add', 
'add', 
'remove', 
'add', 
'add']);