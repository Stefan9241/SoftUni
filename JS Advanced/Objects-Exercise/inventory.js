function ex4(array) {
    let result = [];

    array.forEach(element => {
        let tokens = element.split(" / ");
        let name = tokens[0];
        let level = Number(tokens[1]);

        result.push({
            name,
            level,
            items: tokens[2] ? tokens[2].split(', ') : []
        })
    });

    return JSON.stringify(result);
}

console.log(ex4(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));