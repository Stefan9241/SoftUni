function solve() {
  let input = document.getElementById("input").value;
  let splittedInput = input.split(".").filter((el) => el != '');

  let result = '';
  let counter = 0;
  for (let i = 0; i < splittedInput.length; i++) {
    counter++;
    if (counter == 3) {
      result += splittedInput[i] + "." + "</p>";
      counter = 0;
    }
    else if (counter == 1) {
      result += "<p>" + splittedInput[i] + ".";
    }
    else {
      result += splittedInput[i];
    }
  }


  document.getElementById("output").innerHTML = result;
}