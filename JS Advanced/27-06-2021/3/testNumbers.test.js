const { expect } = require("chai");
let testNumbers = require("./testNumbers.js");

describe("Testing testNumbers function", () => {
  it('sumNumbers: Works correctly with (1,2)',() => {
    let result = testNumbers.sumNumbers(1,2);
    let expected = Number(3).toFixed(2);
    expect(result).to.equal(expected);
  })

  it('sumNumbers: Works correctly with (-1,-2)',() => {
    let result = testNumbers.sumNumbers(-1,-2);
    let expected = Number(-3).toFixed(2);
    expect(result).to.equal(expected);
  })

  
  it('sumNumbers: returns undefined with (string,2)',() => {
    let result = testNumbers.sumNumbers('1',2);
    let expected = undefined;
    expect(result).to.equal(expected);
  })

  it('sumNumbers: returns undefined with (1,string)',() => {
    let result = testNumbers.sumNumbers(1,'2');
    let expected = undefined;
    expect(result).to.equal(expected);
  })

  it('sumNumbers: returns undefined with (1,array)',() => {
    let result = testNumbers.sumNumbers(1,[2]);
    let expected = undefined;
    expect(result).to.equal(expected);
  })

  it('sumNumbers: returns undefined with (object,1)',() => {
    let result = testNumbers.sumNumbers({},1);
    let expected = undefined;
    expect(result).to.equal(expected);
  })

  it('numberChecker: Even with 0',() => {
    let result = testNumbers.numberChecker(0);
    let expected = "The number is even!";
    expect(result).to.equal(expected);
  })

  it('numberChecker: Even with 2',() => {
    let result = testNumbers.numberChecker(2);
    let expected = "The number is even!";
    expect(result).to.equal(expected);
  })

  it('numberChecker: Even with -2',() => {
    let result = testNumbers.numberChecker(-2);
    let expected = "The number is even!";
    expect(result).to.equal(expected);
  })

  it('numberChecker: Odd with -1',() => {
    let result = testNumbers.numberChecker(-1);
    let expected = "The number is odd!";
    expect(result).to.equal(expected);
  })

  it('numberChecker: Odd with 1',() => {
    let result = testNumbers.numberChecker(1);
    let expected = "The number is odd!";
    expect(result).to.equal(expected);
  })

  it('numberChecker: Throws error with string',() => {
    expect(()=> testNumbers.numberChecker('asdas')).to.throw();
  })

  it('numberChecker: Throws error with object',() => {
    expect(()=> testNumbers.numberChecker({asdas})).to.throw();
  })

  it('numberChecker: Not Throws error with [1]',() => {
    expect(()=> testNumbers.numberChecker([1])).to.not.throw();
  })

  it('averageSumArray: Works correctly with [1,2,3]',() => {
    let result = testNumbers.averageSumArray([1,2,3]);
    let expected = Number(2);
    expect(result).to.equal(expected);
  })
  
  it('averageSumArray: Works correctly with [-1,-2,-3]',() => {
    let result = testNumbers.averageSumArray([-1,-2,-3]);
    let expected = Number(-2);
    expect(result).to.equal(expected);
  })

});
