class Stringer {
  constructor(string, lenght) {
    this.innerString = string;
    this.innerLength = lenght;
  }

  increase(length) {
    this.innerLength += length;
  }

  decrease(length) {
    if (this.innerLength - length < 0) {
      this.innerLength = 0;
    } else {
      this.innerLength -= length;
    }
  }

  toString() {
    if (this.innerLength == 0) {
      return "...";
    }

    if (this.innerString.length > this.innerLength) {
      let numberToCut = this.innerString.length - this.innerLength;
      let stringToReturn = this.innerString.slice(0, numberToCut);
      return stringToReturn + '...';
    } else {
      return this.innerString;
    }
  }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
