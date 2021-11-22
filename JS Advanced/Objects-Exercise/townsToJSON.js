function ex7(arrStr) {
    let arr = [];
    for (let index = 1; index < arrStr.length; index++) {
        const element = arrStr[index];
        let sliced = element.slice(2,element.length - 2);
        let splitted = sliced.split(" | ");
        let town = splitted[0];
        let latitude = Number(Number(splitted[1]).toFixed(2));
        let longitude = Number(Number(splitted[2]).toFixed(2));
        let obj = {
            'Town': town,
            'Latitude': latitude,
            'Longitude': longitude
        }
        arr.push(obj);
    }

    return JSON.stringify(arr);
}

console.log(ex7(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']));