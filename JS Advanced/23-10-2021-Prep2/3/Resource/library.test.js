const { expect } = require("chai");
let library = require("./library");

describe("Testing library", () => {
  it("calcPriceOfBook: throws not an integer with []", () => {
    expect(() => library.calcPriceOfBook("hubavata", [])).to.throw(
      "Invalid input"
    );
  });
  it("calcPriceOfBook: no input", () => {
    expect(() => library.calcPriceOfBook()).to.throw("Invalid input");
  });
  it("calcPriceOfBook: throws not an integer with '", () => {
    expect(() => library.calcPriceOfBook("hubavata", "")).to.throw(
      "Invalid input"
    );
  });

  it("calcPriceOfBook: throws not an integer with {}", () => {
    expect(() => library.calcPriceOfBook("hubavata", {})).to.throw(
      "Invalid input"
    );
  });

  it("calcPriceOfBook: throws not an string with {}", () => {
    expect(() => library.calcPriceOfBook({}, "hubavata")).to.throw(
      "Invalid input"
    );
  });
  it("calcPriceOfBook: throws not an string with []", () => {
    expect(() => library.calcPriceOfBook([], "hubavata")).to.throw(
      "Invalid input"
    );
  });

  it("calcPriceOfBook: throws not an string with 1", () => {
    expect(() => library.calcPriceOfBook(1, "hubavata")).to.throw(
      "Invalid input"
    );
  });

  it("calcPriceOfBook: works correctly under 1980 year", () => {
    expect(library.calcPriceOfBook("hubavata", 1000)).to.equal(
      `Price of hubavata is 10.00`
    );
  });

  it("calcPriceOfBook: works correctly above 1980 year", () => {
    expect(library.calcPriceOfBook("hubavata", 2000)).to.equal(
      `Price of hubavata is 20.00`
    );
  });

  it("findBook: throws error when empty array", () => {
    expect(() => library.findBook([], "asdasd"));
  });
  it("findBook: works correctly with right book", () => {
    let result = library.findBook(["Harry"], "Harry");
    let expectedResult = `We found the book you want.`;
    expect(result).to.equal(expectedResult);
  });

  it("findBook: works correctly with wrong book", () => {
    let result = library.findBook(["Harry"], "Haaaaaarry");
    let expectedResult = "The book you are looking for is not here!";
    expect(result).to.equal(expectedResult);
  });

  it("arrangeTheBooks: throws error when not and integer string", () => {
    expect(() => library.arrangeTheBooks("23124124")).to.throw();
  });

  it("arrangeTheBooks: throws error when not and integer array", () => {
    expect(() => library.arrangeTheBooks(["23124124"])).to.throw();
  });

  it("arrangeTheBooks: throws error when not and integer string", () => {
    expect(() => library.arrangeTheBooks("23124124")).to.throw();
  });

  it("arrangeTheBooks: throws error when not and integer {}", () => {
    expect(() => library.arrangeTheBooks({})).to.throw();
  });

  it("arrangeTheBooks: throws error when not and integer string", () => {
    expect(() => library.arrangeTheBooks("23124124")).to.throw();
  });

  it("arrangeTheBooks: throws error when not and integer negative number", () => {
    expect(() => library.arrangeTheBooks(-10)).to.throw();
  });

  it("arrangeTheBooks: correctly with 40", () => {
    let result = library.arrangeTheBooks(40);
    let expectedResult = "Great job, the books are arranged.";
    expect(result).to.eq(expectedResult);
  });

  it("arrangeTheBooks: correctly with 30", () => {
    let result = library.arrangeTheBooks(30);
    let expectedResult = "Great job, the books are arranged.";
    expect(result).to.eq(expectedResult);
  });

  it("arrangeTheBooks: insufficient space", () => {
    let result = library.arrangeTheBooks(50);
    let expectedResult =
      "Insufficient space, more shelves need to be purchased.";
    expect(result).to.eq(expectedResult);
  });
});
