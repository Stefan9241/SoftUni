const { expect } = require("chai");
let numberOperations = require("./03. Number Operations_Resources.js");

describe("Testing operations", () => {
  it("powNumber: works correctly", () => {
    let result = numberOperations.powNumber(2);
    let expected = 2 * 2;

    expect(result).to.be.equal(expected);
  });

  it("powNumber: negative number", () => {
    let result = numberOperations.powNumber(-2);
    let expected = (-2) * (-2);

    expect(result).to.be.equal(expected);
  });

  it("numberChecker: works correctly under 100", () => {
    let result = numberOperations.numberChecker(-2);
    let expected = "The number is lower than 100!";

    expect(result).to.be.equal(expected);
  });
  it("numberChecker: works correctly under [100]", () => {
    let result = numberOperations.numberChecker([-2]);
    let expected = "The number is lower than 100!";

    expect(result).to.be.equal(expected);
  });

  it("numberChecker: works correctly with 100", () => {
    let result = numberOperations.numberChecker(100);
    let expected = "The number is greater or equal to 100!";

    expect(result).to.be.equal(expected);
  });

  it("numberChecker: works correctly above 100", () => {
    let result = numberOperations.numberChecker(200);
    let expected = "The number is greater or equal to 100!";

    expect(result).to.be.equal(expected);
  });

  it("numberChecker: error with string", () => {
    expect(()=> numberOperations.numberChecker('string')).to.throw();
  });

  it("numberChecker: error with object", () => {
    expect(()=> numberOperations.numberChecker({})).to.throw();
  });

  it("sumArrays: works correctly", () => {
    let array1 = [1,2,3];
    let array2 = [3,2,1];

    let result = numberOperations.sumArrays(array1,array2);
    let expected = [4,4,4];

    expect(result).to.deep.equal(expected);
  });

  it("sumArrays: works correctly different lenght", () => {
    let array1 = [1,2,3,6];
    let array2 = [3,2,1];

    let result = numberOperations.sumArrays(array1,array2);
    let expected = [4,4,4,6];

    expect(result).to.deep.equal(expected);
  });

  it("sumArrays: works correctly empty arr", () => {
    let array1 = [];
    let array2 = [];

    let result = numberOperations.sumArrays(array1,array2);
    let expected = [];

    expect(result).to.deep.equal(expected);
  });
});
