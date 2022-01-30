//document.addEventListener("DOMContentLoaded", displayStudents);
let resultsElement = document.querySelector("#results > tbody");
let submitBtn = document.getElementById("submit");
submitBtn.addEventListener("click", addStudent);

let firstNameEl = document.querySelector('input[name="firstName"]');
let lastNameEl = document.querySelector('input[name="lastName"]');
let facultyNumberEl = document.querySelector('input[name="facultyNumber"]');
let gradeEl = document.querySelector('input[name="grade"]');

async function addStudent(event) {
  event.preventDefault();
  let firstName = firstNameEl.value;
  let lastName = lastNameEl.value;
  let facNumber = facultyNumberEl.value;
  let grade = Number(gradeEl.value);

  if (
    firstName == "" ||
    lastName == "" ||
    facNumber == "" ||
    isNaN(grade) ||
    grade == ""
  ) {
    alert("Invalid input");
    firstNameEl.value = "";
    lastNameEl.value = "";
    facultyNumberEl.value = "";
    gradeEl.value = "";
    return;
  }
  let url = "http://localhost:3030/jsonstore/collections/students";

  let options = { firstName, lastName, facultyNumber: facNumber, grade };
  let result = await fetch(url, {
    method: "post",
    headers: { "Content-Type": "Aplication-json" },
    body: JSON.stringify(options),
  });

  console.log(result);
  await displayStudents();
  firstNameEl.value = "";
  lastNameEl.value = "";
  facultyNumberEl.value = "";
  gradeEl.value = "";
}
async function displayStudents() {
  let url = "http://localhost:3030/jsonstore/collections/students";
  let response = await fetch(url);
  let desData = await response.json();

  let arrayData = Object.values(desData);
  appendStudents(arrayData);
}

function appendStudents(data) {
  console.log(data);
  data.forEach((x, i) => {
    let tr = document.createElement("tr");
    let thFirstName = document.createElement("th");
    let thLastName = document.createElement("th");
    let thFacultyNumber = document.createElement("th");
    let thGrade = document.createElement("th");

    thFirstName.textContent = x.firstName;
    thLastName.textContent = x.lastName;
    thFacultyNumber.textContent = x.facultyNumber;
    thGrade.textContent = x.grade;

    tr.appendChild(thFirstName);
    tr.appendChild(thLastName);
    tr.appendChild(thFacultyNumber);
    tr.appendChild(thGrade);
    tr.className = i + 1;
    resultsElement.appendChild(tr);
  });
}
