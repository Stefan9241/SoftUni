function solve() {
  let text = document.getElementById("text").value;
  let naming = document.getElementById("naming-convention").value;

  let splitted = text.split(' ');
  let result = '';

  if (naming === "Camel Case") {
    result += splitted[0].toLowerCase();

    for (let i = 1; i < splitted.length; i++) {

      result += splitted[i][0].toUpperCase() + splitted[i].slice(1).toLowerCase();

    }
  } else if (naming === "Pascal Case") {
    for (let i = 0; i < splitted.length; i++) {
      result += splitted[i][0].toUpperCase() + splitted[i].slice(1).toLowerCase();
    }
  } else {
    result = "Error!";
  }


  document.getElementById("result").textContent = result;
}