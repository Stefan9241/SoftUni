function solve() {
  let fNameElement = document.getElementById("fname");
  let lNameElement = document.getElementById("lname");
  let emailElement = document.getElementById("email");
  let birthElement = document.getElementById("birth");
  let positionElement = document.getElementById("position");
  let salaryElement = document.getElementById("salary");
  let salaryMustBe = 0;

  let tboDy = document.getElementById("tbody");
  let sum = document.getElementById("sum");
  let bntHire = document.getElementById("add-worker");
  bntHire.addEventListener("click", (e) => {
    e.preventDefault();
    let fName = fNameElement.value;
    let lName = lNameElement.value;
    let email = emailElement.value;
    let birth = birthElement.value;
    let position = positionElement.value;
    let salary = Number(salaryElement.value);
    if (
      fName !== "" &&
      lName !== "" &&
      email !== "" &&
      birth !== "" &&
      position !== "" &&
      !isNaN(salary)
    ) {
      let tr = document.createElement("tr");
      let tdFName = document.createElement("td");
      tdFName.textContent = fName;
      let tdLName = document.createElement("td");
      tdLName.textContent = lName;
      let tdEmail = document.createElement("td");
      tdEmail.textContent = email;
      let tdBirth = document.createElement("td");
      tdBirth.textContent = birth;
      let tdPosition = document.createElement("td");
      tdPosition.textContent = position;
      let tdSalary = document.createElement("td");
      tdSalary.textContent = salary;

      let tdBtns = document.createElement("td");
      let btnFired = document.createElement("button");
      btnFired.classList.add("fired");
      btnFired.textContent = "Fired";
      btnFired.addEventListener("click", (e) => {
        let target = e.target.parentElement.parentElement;
        let tds = Array.from(target.querySelectorAll("td"));
        let salary = Number(tds[5].textContent);
        salaryMustBe -= salary;
        sum.textContent = salaryMustBe.toFixed(2);
        e.target.parentElement.parentElement.remove();
      });
      tdBtns.appendChild(btnFired);

      let btnEdit = document.createElement("button");
      btnEdit.classList.add("edit");
      btnEdit.textContent = "Edit";
      btnEdit.addEventListener("click", (e) => {
        let target = e.target.parentElement.parentElement;
        let tds = Array.from(target.querySelectorAll("td"));
        let salary = Number(tds[5].textContent);
        salaryMustBe -= salary;
        sum.textContent = salaryMustBe.toFixed(2);
        fNameElement.value = tds[0].textContent;
        lNameElement.value = tds[1].textContent;
        emailElement.value = tds[2].textContent;
        birthElement.value = tds[3].textContent;
        positionElement.value = tds[4].textContent;
        salaryElement.value = salary;
        e.target.parentElement.parentElement.remove();
      });
      tdBtns.appendChild(btnEdit);

      tr.appendChild(tdFName);
      tr.appendChild(tdLName);
      tr.appendChild(tdEmail);
      tr.appendChild(tdBirth);
      tr.appendChild(tdPosition);
      tr.appendChild(tdSalary);
      tr.appendChild(tdBtns);

      tboDy.appendChild(tr);

      salaryMustBe += salary;
      sum.textContent = salaryMustBe.toFixed(2);

      fNameElement.value = "";
      lNameElement.value = "";
      emailElement.value = "";
      birthElement.value = "";
      positionElement.value = "";
      salaryElement.value = "";
    }
  });
}
solve();
