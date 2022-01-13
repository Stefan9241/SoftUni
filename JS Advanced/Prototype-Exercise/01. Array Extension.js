(function () {
  Array.prototype.last = function () {
    return this[this.length - 1];
  };

  Array.prototype.skip = function (n) {
    let result = [];

    for (let i = n; i < this.length; i++) {
      const element = this[i];
      result.push(element);
    }

    return result;
  };

  Array.prototype.take = function (n) {
    let result = [];

    for (let i = 0; i < n; i++) {
      const element = this[i];
      result.push(element);
    }

    return result;
  };

  Array.prototype.sum = function () {
    return this.reduce((a, b) => {
      return a + b;
    }, 0);
  };

  Array.prototype.average = function () {
    return this.sum() / this.length;
  };
})();
