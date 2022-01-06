const { expect } = require('chai');
let lookupChar = require('./03. Char Lookup');

describe('Testing lookupChar', () => {
  it('returns undefined when uncorrect input with number', () => {
    expect(lookupChar(1, 0)).to.be.undefined;
  })

  it('returns undefined when uncorrect input with array', () => {
    expect(lookupChar([], 0)).to.be.undefined;
  })

  it('returns undefined when uncorrect input with object', () => {
    expect(lookupChar({}, 0)).to.be.undefined;
  })

  it('returns undefined when uncorrect input with double', () => {
    expect(lookupChar(1.1, 0)).to.be.undefined;
  })

  it('returns undefined when uncorrect input with double and correct string', () => {
    expect(lookupChar('asd', 1.1)).to.be.undefined;
  })

  it('returns undefined when uncorrect input with array and correct string', () => {
    expect(lookupChar('asd', [])).to.be.undefined;
  })

  it('returns undefined when uncorrect input with object and correct string', () => {
    expect(lookupChar('asd', {})).to.be.undefined;
  })

  it('returns "Incorrect index" when index is more than the string', () => {
    expect(lookupChar('asd',5)).to.be.equal("Incorrect index");
  })

  it('returns "Incorrect index" when index is less than the string', () => {
    expect(lookupChar('asd',-5)).to.be.equal("Incorrect index");
  })

  it('returns correct char with 0', () => {
    expect(lookupChar('asd',0)).to.be.equal("a");
  })

  it('returns correct char with max edge case', () => {
    expect(lookupChar('asd',2)).to.be.equal("d");
  })
})