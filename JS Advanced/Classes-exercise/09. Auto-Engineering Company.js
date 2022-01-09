function solve(array) {
  let catalogue = new Map();
  for (let i = 0; i < array.length; i++) {
    const element = array[i];
    let [carBrand, carModel, producedCars] = element.split(" | ");

    if (!catalogue.get(carBrand)) {
      catalogue.set(carBrand, []);
    }

    if (!catalogue.get(carBrand).includes(carModel)) {
      catalogue.get(carBrand).push(carModel);
      catalogue.get(carBrand).push(Number(producedCars));
    } else {
      catalogue.get(carBrand)[1] += Number(producedCars);
    }
  }

  for (const key of catalogue) {
    console.log(key[0]);

    for (let i = 0; i < key[1].length; i += 2) {
      const model = key[1][i];
      const cars = key[1][i + 1];
      console.log(`###${model} -> ${cars}`);
    }
  }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);
