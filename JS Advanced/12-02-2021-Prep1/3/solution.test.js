const { expect } = require("chai");
let pizzUni = require("./classToTest");

describe("Testing pizzUni", function () {
  describe("Testing makeAnOrder ", function () {
    it("Throws error if thare is no ordered pizza empty object", function () {
      let obj = {};
      expect(() => pizzUni.makeAnOrder(obj)).to.throw();
    });

    it("Throws error if thare is no ordered pizza obj without orderedPizza", function () {
      let obj = { orderedDrink: "pepsi" };
      expect(() => pizzUni.makeAnOrder(obj)).to.throw();
    });

    it("Throws error if thare is no obj", function () {
      let obj = 1;
      expect(() => pizzUni.makeAnOrder(obj)).to.throw();
    });

    it("works correctly with only pizza no drink", function () {
      let obj = { orderedPizza: "pepperoni" };
      let result = pizzUni.makeAnOrder(obj);

      expect(result).to.be.equal(`You just ordered pepperoni`);
    });

    it("works correctly with only pizza and drink", function () {
      let obj = {
        orderedPizza: "pepperoni",
        orderedDrink: "pepsi",
      };
      let result = pizzUni.makeAnOrder(obj);

      expect(result).to.be.equal(
        `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`
      );
    });
  });

  describe("Testing getRemainingWork ", function () {
    it(`happy path: input -> [{pizzaName: 'a', status: 'ready'}], 
  output -> All orders are complete!`, () => {
      expect(
        pizzUni.getRemainingWork([
          {
            pizzaName: "a",
            status: "ready",
          },
        ])
      ).to.eq("All orders are complete!");
    });

    it("returns the not ready orders", function () {
      let obj = {
        pizzaName: "a",
        status: "preparing",
      };

      let result = pizzUni.getRemainingWork([obj]);

      expect(result).to.be.equal(
        `The following pizzas are still preparing: a.`
      );
    });

    it("returns the not ready orders with 2 uncorrect and 1 correct object", function () {
      let obj = {
        pizzaName: "a",
        status: "preparing",
      };

      let obj1 = {
        pizzaName: "b",
        status: "preparing",
      };

      let obj2 = {
        pizzaName: "c",
        status: "ready",
      };
      let result = pizzUni.getRemainingWork([obj, obj1, obj2]);

      expect(result).to.be.equal(
        `The following pizzas are still preparing: a, b.`
      );
    });

    it(`throws if input not array`, () => {
      expect(() => pizzUni.getRemainingWork(1)).to.throw();
    });
  });

  describe(`testing .orderType() method`, () => {
    it(`input -> [1, 'Carry Out'], output -> 0.9`, () => {
      expect(pizzUni.orderType(1, "Carry Out")).to.eq(0.9);
    });
    it(`input -> [1, 'Delivery'], output -> 1`, () => {
      expect(pizzUni.orderType(1, "Delivery")).to.eq(1);
    });
  });
});
