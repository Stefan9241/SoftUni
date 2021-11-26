function subtract() {
    let firstNum = document.getElementById("firstNumber").value;
    let secNumber = document.getElementById("secondNumber").value;

    document.getElementById("result").textContent = Number(firstNum) - Number(secNumber);
}