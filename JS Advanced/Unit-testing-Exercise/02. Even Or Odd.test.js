const { expect } = require("chai");
let isOddOrEven = require("./02. Even Or Odd");

describe("EvenOrOddTesting", () => {
  it("not a string returns undefined with number 1", () => {
    expect(isOddOrEven(1)).to.be.undefined;
  });

  it("not a string returns undefined with object", () => {
    expect(isOddOrEven({})).to.be.undefined;
  });

  it("not a string returns undefined with array 1", () => {
    expect(isOddOrEven([1])).to.be.undefined;
  });

  describe('even string works correctly', () => {
    it('works with string stefan', () => {
      expect(isOddOrEven('stefan')).to.equal('even');
    })

    it('works with string st', () => {
      expect(isOddOrEven('st')).to.equal('even');
    })
  })

  describe('odd string works correctly', () => {
    it('works with string stefane', () => {
      expect(isOddOrEven('stefane')).to.equal('odd');
    })

    it('works with string ste', () => {
      expect(isOddOrEven('ste')).to.equal('odd');
    })
  })
});
