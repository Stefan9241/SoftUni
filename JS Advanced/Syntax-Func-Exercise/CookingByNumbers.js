function solve(num,com1,com2,com3,com4,com5) {
    let number = +num;
    let array = [com1,com2,com3,com4,com5];

    for (let index = 0; index < array.length; index++) {
        let element = array[index];

        if (element === 'chop') {
            number = number / 2;
        }
        else if (element === 'dice') {
            number = Math.sqrt(number);
        }
        else if (element === 'spice') {
            number += 1;
        }
        else if (element === 'bake') {
            number *= 3;
        }
        else if (element === 'fillet') {
            number = number * 0.80;
        }

        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');