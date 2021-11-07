function solve(text){
    let result;

    if (text === 'Monday') {
        result = 1;
    }
    else if (text === 'Tuesday') {
        result = 2;
    }
    else if (text === 'Wednesday') {
        result = 3;
    }
    else if (text === 'Thursday') {
        result = 4;
    }
    else if (text === 'Friday') {
        result = 5;
    }
    else if (text === 'Saturday') {
        result = 6;
    }
    else if (text === 'Sunday') {
        result = 7;
    }
    else{
        result = 'error';
    }

    console.log(result);
}

solve(5);