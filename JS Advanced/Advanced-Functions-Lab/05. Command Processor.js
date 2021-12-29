function solution() {
    let result = '';

    return {
        append: x => (result += x),
        removeStart: x => (result = result.slice(x)),
        removeEnd: x => (result = result.slice(0, -x)),
        print: () => console.log(result),
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();