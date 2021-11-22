function colorize() {
    let array = Array.from(document.getElementsByTagName('tr'));

    for (let index = 1; index < array.length; index+=2) {
        array[index].style.background = "Teal";
    }
}