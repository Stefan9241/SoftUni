function solve(array) {
  let mapBottles = new Map();
  let mapJuice = new Map();

  for (let i = 0; i < array.length; i++) {
    let [fruit, quantity] = array[i].split(" => ");
    quantity = Number(quantity);

    if (!mapJuice.has(fruit)) {
      mapJuice.set(fruit, { value: 0 });
    }

    if (mapJuice.get(fruit).value + quantity >= 1000) {
      if (!mapBottles.has(fruit)) {
        mapBottles.set(fruit, { value: 0 });
      }

      let numberBottlesToAdd = parseInt(
        (mapJuice.get(fruit).value + quantity) / 1000
      );
      let juiceLeft = (mapJuice.get(fruit).value + quantity) % 1000;
      mapBottles.get(fruit).value += numberBottlesToAdd;
      mapJuice.get(fruit).value = juiceLeft;
    } else {
      mapJuice.get(fruit).value += quantity;
    }
  }

  for (const key of mapBottles) {
    console.log(`${key[0]} => ${key[1].value}`);
  }
}

solve([
  "Kiwi => 234",
  "Pear => 2345",
  "Watermelon => 3456",
  "Kiwi => 4567",
  "Pear => 5678",
  "Watermelon => 6789",
]);
