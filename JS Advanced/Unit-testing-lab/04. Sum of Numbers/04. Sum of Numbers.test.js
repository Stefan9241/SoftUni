let { expect } = require('chai');
const { describe } = require('mocha');
let testSum = require('./04. Sum of Numbers');

describe("sum(arr) - sum array of numbers", function () {
    it("should return 3 for [1,2]", function () {
        expect(testSum.sum([1,2])).to.be.equal(3);
    });
    it("should return 1 for [1]", function () {
        expect(testSum.sum([1])).to.be.equal(1);
    });
    it("should return 0 for empty array", function () {
        expect(testSum.sum([])).to.be.equal(0);
    });
    it("should return 3 for [1.5, 2.5, -1]", function () {
        expect(testSum.sum([1.5, 2.5, -1])).to.be.equal(3);
    });
    it("should return NaN for invalid data", function () {
        expect(testSum.sum("invalid data")).to.be.NaN;
    });
});