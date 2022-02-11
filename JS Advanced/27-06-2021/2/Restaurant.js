class Restaurant {
  constructor(budgetMoney) {
    this.budgetMoney = budgetMoney;
    this.menu = {};
    this.stockProducts = {};
    this.history = [];
  }

  loadProducts(productsArr) {
    // array from strings
    productsArr.forEach((product) => {
      let [pName, pQuantity, pTotalPrice] = product.split(" ");
      pTotalPrice = Number(pTotalPrice);
      pQuantity = Number(pQuantity);
      if (this.budgetMoney >= pTotalPrice) {
        let pExist = this.stockProducts[pName];

        if (pExist != undefined) {
          pExist.quantity += pQuantity;
          this.history.push(`Successfully loaded ${pQuantity} ${pName}`);
        } else {
          let objProduct = {
            name: pName,
            quantity: pQuantity,
          };

          this.stockProducts[pName] = objProduct;
          this.history.push(`Successfully loaded ${pQuantity} ${pName}`);
        }
        this.budgetMoney -= pTotalPrice;
      } else {
        this.history.push(
          `There was not enough money to load ${pQuantity} ${pName}`
        );
      }
    });

    return this.history.join("\n");
  }

  addToMenu(meal, neededProducts, price) {
    let currMeal = this.menu[meal];
    if (currMeal == undefined) {
      this.menu[meal] = {
        name: meal,
        products: [],
        price: Number(price),
      };

      neededProducts.forEach((x) => {
        let [productName, productQuantity] = x.split(" ");
        productQuantity = Number(productQuantity);
        console.log(this.menu[meal]);
        let isSame = this.menu[meal].products.some((x) => {
          let name = x.name;
          return name === productName;
        });
        if (isSame) {
          let prod = this.menu[meal].products.find(x=> x.name === productName);
          prod.quantity += productQuantity;
        } else {
          this.menu[meal].products.push({
            name: productName,
            quantity: productQuantity,
          });
        }
      });
    } else {
      return `The ${meal} is already in the our menu, try something different.`;
    }

    if (Object.keys(this.menu).length == 1) {
      return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
    } else {
      return `Great idea! Now with the ${meal} we have ${
        Object.keys(this.menu).length
      } meals in the menu, other ideas?`;
    }
  }

  showTheMenu() {
    if (Object.keys(this.menu).length == 0) {
      return `Our menu is not ready yet, please come later...`;
    }

    let result = [];
    Object.entries(this.menu).forEach((x) => {
      result.push(`${x[0]} - $ ${x[1].price}`);
    });

    return result.join("\n");
  }

  makeTheOrder(mealName) {
    let meal = Object.keys(this.menu).find((x) => x === mealName);
    if (meal == undefined) {
      return `There is not ${mealName} yet in our menu, do you want to order something else?`;
    }

    let isEnoughProducts = true;

    let productsNeeded = Object.values(this.menu[mealName]);

    productsNeeded[1].forEach((obj) => {
      let stockProduct = Object.entries(this.stockProducts).find(
        (x) => x[0] === obj.name
      );
      if (obj.quantity > stockProduct[1].quantity) {
        isEnoughProducts = false;
      }
    });

    if (isEnoughProducts == false) {
      return `For the time being, we cannot complete your order (${mealName}), we are very sorry...`;
    }

    productsNeeded[1].forEach((obj) => {
      let stockProduct = Object.entries(this.stockProducts).find(
        (x) => x[0] === obj.name
      );
      if (obj.quantity > stockProduct[1].quantity) {
        stockProduct[1].quantity -= obj.quantity;
      }
    });

    let objPrice = this.menu[mealName].price;
    return `Your order (${mealName}) will be completed in the next 30 minutes and will cost you ${objPrice}.`;
  }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts([
  "Yogurt 30 3",
  "Yogurt 30 3",
  "Honey 50 4",
  "Strawberries 20 10",
  "Banana 5 1",
]);
kitchen.addToMenu(
  "frozenYogurt",
  ["Yogurt 1", "Yogurt 1", "Honey 1", "Banana 1", "Strawberries 10"],
  9.99
);
console.log(kitchen.makeTheOrder("frozenYogurt"));
