function solver(length, k) {
    let outputArr = [1];
    for(let i = 1; i<length; i++){
        outputArr[i] = sumLastK(outputArr, k);
    }
    // console.log(k); // k has changed after calling sumLastK
    return outputArr;
 
    function sumLastK(arr, k) {
        k = arr.length>k ? k : arr.length;
        let sum = 0;
        for(let i = 1; i<=k; i++){
            sum += arr[arr.length-i];
        }
        return sum;
    }
}

solver(6,3);
/* - new solution
function numSequent(n, k) {
    let output = [1];
    while(n-- > 1) {
        let sum = 0;
        for (let index = output.length - 1; index > output.length - 1 - k; index--) {
            if (typeof(output[index]) == 'number') {
                sum += Number(output[index]);
            }
        }
        output.push(sum);
    }
    console.log(output);
}
*/