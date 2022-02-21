const { expect } = require("chai");
let flowerShop = require("./flowerShop.js");

describe("FlowerShop testing", () => {
  it("calcPriceOfFlowers: throws with invalid flower array", () => {
    expect(() => flowerShop.calcPriceOfFlowers([], 1, 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid flower object", () => {
    expect(() => flowerShop.calcPriceOfFlowers({}, 1, 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid flower number", () => {
    expect(() => flowerShop.calcPriceOfFlowers(1, 1, 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid price", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", [], 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid price array", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", [], 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid price object", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", {}, 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid price string", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", "Gosho", 1)).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid quantity object", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", 1, {})).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid quantity string", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", 1, "Gosho")).to.throw();
  });
  it("calcPriceOfFlowers: throws with invalid quantity array", () => {
    expect(() => flowerShop.calcPriceOfFlowers("Gosho", 1, [])).to.throw();
  });
  it("calcPriceOfFlowers: returns correct price int", () => {
    let flower = "Gosho";
    let price = 10;
    let quantity = 5;
    let resultPrice = (price * quantity).toFixed(2);
    let result = `You need $${resultPrice} to buy ${flower}!`;
    expect(flowerShop.calcPriceOfFlowers(flower, price, quantity)).to.equal(
      result
    );
  });
  it("checkFlowersAvailable: correct answer", () => {
    let flowers = ["Rose", "Lily", "Orchid"];
    let flower = "Rose";
    let result = flowerShop.checkFlowersAvailable(flower, flowers);
    let expected = `The ${flower} are available!`;
    expect(result).to.equal(expected);
  });
  it("checkFlowersAvailable: no flowers answer", () => {
    let flowers = [];
    let flower = "Rose";
    let result = flowerShop.checkFlowersAvailable(flower, flowers);
    let expected = `The ${flower} are sold! You need to purchase more!`;
    expect(result).to.equal(expected);
  });

  it("checkFlowersAvailable: no flowers answer with full array", () => {
    let flowers = ["Lily", "Orchid"];
    let flower = "Rose";
    let result = flowerShop.checkFlowersAvailable(flower, flowers);
    let expected = `The ${flower} are sold! You need to purchase more!`;
    expect(result).to.equal(expected);
  });
  it("sellFlowers: removes correctly deepEqual", () => {
    let flowersArr = ["Rose", "Lily", "Orchid"];
    let index = 1;
    let result = flowerShop.sellFlowers(flowersArr, index);
    let expected = "Rose / Orchid";
    expect(result).to.deep.equal(expected);
  });
  it("sellFlowers: removes correctly equal", () => {
    let flowersArr = ["Rose", "Lily", "Orchid"];
    let index = 1;
    let result = flowerShop.sellFlowers(flowersArr, index);
    let expected = "Rose / Orchid";
    expect(result).to.equal(expected);
  });

  it("sellFlowers: throws when array is string", () => {
    expect(()=> flowerShop.sellFlowers('',1)).to.throw();
  });
  it("sellFlowers: throws when array is undefined", () => {
    expect(()=> flowerShop.sellFlowers(1)).to.throw();
  });
  it("sellFlowers: throws when int is array", () => {
    expect(()=> flowerShop.sellFlowers(["Lily", "Orchid"],[])).to.throw();
  });
  it("sellFlowers: throws when int is string", () => {
    expect(()=> flowerShop.sellFlowers(["Lily", "Orchid"],'asdasd')).to.throw();
  });
  it("sellFlowers: throws when int is undefined", () => {
    expect(()=> flowerShop.sellFlowers(["Lily", "Orchid"])).to.throw();
  });
  it("sellFlowers: throws when int is -1", () => {
    expect(()=> flowerShop.sellFlowers(["Lily", "Orchid"],-1)).to.throw();
  });
  it("sellFlowers: throws when int is more than array 5", () => {
    expect(()=> flowerShop.sellFlowers(["Lily", "Orchid"],5)).to.throw();
  });
});
