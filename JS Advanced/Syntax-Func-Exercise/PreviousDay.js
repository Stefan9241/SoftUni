function solve(year, month, day) {
    var today = new Date();
    today.setFullYear(year, month - 1, day);

    const yesterday = new Date(today)
    yesterday.setDate(yesterday.getDate() - 1)
    var month1 = yesterday.getUTCMonth() + 1;
    var day1 = yesterday.getUTCDate();
    var year1 = yesterday.getUTCFullYear();


    return `${year1}-${month1}-${day1}`
}

console.log(solve(2016, 9, 30));
console.log(solve(2016, 10, 1));