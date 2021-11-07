'use strinct';
function solve(a,b,c){
let first = a.length;
let second = b.length;
let third = c.length;
let result = first + second + third;
console.log(result);
console.log(Math.floor(result / 3));
}

solve('chocolate', 'ice cream', 'cake');