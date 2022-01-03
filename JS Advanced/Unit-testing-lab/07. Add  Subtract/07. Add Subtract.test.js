const { expect } = require('chai');
let createCalculator = require('./07. Add Subtract').createCalculator;

describe('Add-subtract testing', () => {
    let calc;

    beforeEach(() => {
        calc = createCalculator();
    })

    it('Returns zero',() => {
        let value = calc.get();
        expect(value).to.be.equal(0);
    });
    
    it('Returns 1, when add(1)',() => {
        calc.add(1);
        expect(calc.get()).to.be.equal(1);
    });

    it('Returns 1, when add(2),subtract(1)',() => {
        calc.add(2);
        calc.subtract(1);
        expect(calc.get()).to.be.equal(1);
    });


    it('Returns 10, when add(20),subtract(10)',() => {
        calc.add(20);
        calc.subtract(10);
        expect(calc.get()).to.be.equal(10);
    });

    it('Returns -10, when subtract(10)',() => {
        calc.subtract(10);
        expect(calc.get()).to.be.equal(-10);
    });

    it('Returns NaN, when subtract(string)',() => {
        calc.subtract('asd');
        expect(calc.get()).to.be.NaN;
    });

    it('Returns NaN, when add(string)',() => {
        calc.add('asd');
        expect(calc.get()).to.be.NaN;
    });
})