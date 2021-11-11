function equalNeighbours(arr) {
 
    let counter=0;
 
    for (let i=0;i<arr.length;i++) {
        let subArr=arr[i];
        for (let j = 0; j < subArr.length; j++) {
            let checker=subArr[j];
            if(i!==arr.length-1) {
                if(checker===subArr[j+1] || checker===arr[i+1][j]) {
                    counter++;
                }
            }
            else {
                if(checker===subArr[j+1]) {
                    counter++;
                }
            }
        }
 
    }
 
    return counter;
}

console.log(aza(['test', 'yes', 'yo', 'ho', 'well', 'done', 'yo', '6', 'not', 'done', 'yet', '5']));
