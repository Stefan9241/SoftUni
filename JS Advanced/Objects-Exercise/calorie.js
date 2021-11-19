function ex1(arr) {

    let result = {};

    for (let i = 0; i < arr.length; i+=2) {
        let name = arr[i];
        let number = Number(arr[i + 1]);
        
        result[name] = number;
    }

    return result;
}
console.log(ex1(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));