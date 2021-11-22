function rectangle(width, height, color) {
    color = color[0].toUpperCase() + color.slice(1);
    let rect = {
        'width': Number(width),
        'height': Number(height),
        'color': color,
        calcArea: function calc() {
            return this.width * this.height;
        }
    }

    return rect;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
