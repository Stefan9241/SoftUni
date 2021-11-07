function solve(num1,num2){
    var days = function(num1,num2) {
        return new Date(num2, num1, 0).getDate();
     };

     console.log(days(num1,num2))
}

solve(2,2021);