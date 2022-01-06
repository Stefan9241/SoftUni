const { expect } = require("chai");
const exp = require("constants");
let mathEnforcer = require("./04. Math Enforcer");

describe("testing matEnforcer", () => {
  it('AddFive returns undefined with string', ()=>{
    expect(mathEnforcer.addFive('asd')).to.be.undefined;
  })

  it('AddFive returns undefined with object', ()=>{
    expect(mathEnforcer.addFive({})).to.be.undefined;
  })

  it('AddFive returns undefined with array', ()=>{
    expect(mathEnforcer.addFive([])).to.be.undefined;
  })

  it('AddFive returns number + 5', ()=>{
    expect(mathEnforcer.addFive(5)).to.be.equal(10);
  })

  it('AddFive returns double + 5', ()=>{
    expect(mathEnforcer.addFive(5.5)).to.be.closeTo(10.5,0.1);
  })

  it('AddFive returns negative double + 5', ()=>{
    expect(mathEnforcer.addFive(-5.5)).to.be.closeTo(-0.5,0.1);
  })
  describe('Testing subtract', () => {
    it('Subtract returns undefined with string', () => {
      expect(mathEnforcer.subtractTen('asd')).to.be.undefined;
    })

    it('Subtract returns undefined with object', () => {
      expect(mathEnforcer.subtractTen({})).to.be.undefined;
    })

    it('Subtract returns undefined with array', () => {
      expect(mathEnforcer.subtractTen([])).to.be.undefined;
    })

    it('Subtract correct number with 5', () => {
      expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
    })

    it('Subtract correct number with 20', () => {
      expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
    })
    it('Subtract correct number with 5.5', () => {
      expect(mathEnforcer.subtractTen(5.5)).to.be.equal(-4.5);
    })


    it('Subtract returns double - 10', ()=>{
      expect(mathEnforcer.subtractTen(15.5)).to.be.closeTo(5.5,0.1);
    })
  
    it('Subtract returns negative double - 10', ()=>{
      expect(mathEnforcer.subtractTen(-15.5)).to.be.closeTo(-25.5,0.1);
    })
  })

  describe('testing sum', () => {
    it('returns undefined when firstNumber is not a number with string', () => {
      expect(mathEnforcer.sum('string',5)).to.be.undefined;
    })

    it('returns undefined when firstNumber is not a number with array', () => {
      expect(mathEnforcer.sum(['string'],5)).to.be.undefined;
    })

    it('returns undefined when firstNumber is not a number with object', () => {
      expect(mathEnforcer.sum({},5)).to.be.undefined;
    })

    it('returns undefined when secondNumber is not a number with string', () => {
      expect(mathEnforcer.sum(5,'asd')).to.be.undefined;
    })

    it('returns undefined when secondNumber is not a number with array', () => {
      expect(mathEnforcer.sum(5,['asd'])).to.be.undefined;
    })

    it('returns undefined when secondNumber is not a number with object', () => {
      expect(mathEnforcer.sum(5,{})).to.be.undefined;
    })

    it('returns correct sum with (5,5)', () => {
      expect(mathEnforcer.sum(5,5)).to.be.equal(10);
    })

    it('returns correct sum with (-5,5)', () => {
      expect(mathEnforcer.sum(-5,5)).to.be.equal(0);
    })

    it('returns correct sum with (10.5,1.5)', () => {
      expect(mathEnforcer.sum(10.5,1.5)).to.be.closeTo(12,0.1);
    })

    it('returns correct sum with (-10.5,-5.5)', () => {
      expect(mathEnforcer.sum(-10.5,-5.5)).to.be.closeTo(-16,0.1);
    })
  })
});
