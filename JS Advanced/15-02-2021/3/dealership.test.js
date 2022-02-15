const { expect } = require('chai');
let dealership = require('./dealership.js');

describe('Testing', () => {
  it('newCarCost: works correctly and discouts', () => {
    let result = dealership.newCarCost('Audi A4 B8', 20000);
    let expected = 5000;

    expect(result).to.equal(expected);
  })

  it('newCarCost: works correctly and returns no discout', () => {
    let result = dealership.newCarCost('Audi', 20000);
    let expected = 20000;

    expect(result).to.equal(expected);
  })

  it('carEquipment: returns the correct array', () => {
    let extrasArr = ['heated seats', 'sliding roof', 'sport rims', 'navigation'];
    let indexArr = [0,2];
    let result = dealership.carEquipment(extrasArr,indexArr);
    let expected = ['heated seats','sport rims'];

    expect(result).to.deep.equal(expected);
  })

  it('carEquipment: returns empty array', () => {
    let extrasArr = [];
    let indexArr = [];
    let result = dealership.carEquipment(extrasArr,indexArr);
    let expected = [];

    expect(result).to.deep.equal(expected);
  })

  it('euroCategory: works correctly with cat 4', () => {
    let result = dealership.euroCategory(4);
    let expected = `We have added 5% discount to the final price: 14250.`;

    expect(result).to.equal(expected);
  })

  it('euroCategory: works correctly with cat under 4', () => {
    let result = dealership.euroCategory(2);
    let expected = "Your euro category is low, so there is no discount from the final price!";

    expect(result).to.equal(expected);
  })
})
