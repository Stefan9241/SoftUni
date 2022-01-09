class Hex {
  constructor(value) {
    this._value = value;
  }

  valueOf() {
    return this._value;
  }

  toString() {
    let hex = "0x";
    hex += this._value.toString(16).toUpperCase();

    return hex;
  }

  plus(number) {
    let result = this._value + Number(number.valueOf());

    return new Hex(result);
  }

  minus(number) {
    let result = this._value - Number(number.valueOf());
    return new Hex(result);
  }

  parse(string ) {
    let newNumber = parseInt(string, 16);

    return newNumber;
  }
}

let FF = new Hex(255);
console.log(FF.toString());
console.log(FF.valueOf() + 1 == 256);
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === "0xF");
console.log(FF.parse("AAA"));
