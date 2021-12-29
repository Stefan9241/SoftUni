function solution(num) {
    let result = num;

    return function add(num) {
        return result + num;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));