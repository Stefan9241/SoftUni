function attachEvents() {
  document.getElementById("btnLoad").addEventListener("click", display);
  document.getElementById("btnCreate").addEventListener("click", createPerson);
}
let ul = document.getElementById("phonebook");
let nameElement = document.getElementById("person");
let phoneElement = document.getElementById("phone");
async function createPerson() {
  let name = nameElement.value;
  let phone1 = phoneElement.value;

  let data = { person: name, phone: phone1 };

  await fetch("http://localhost:3030/jsonstore/phonebook", {
    method: "post",
    headers: { "Content-Type": "aplication-json" },
    body: JSON.stringify(data),
  });

  await display();
  nameElement.value = "";
  phoneElement.value = "";
}
async function display() {
  ul.innerHTML = "";
  let response = await fetch("http://localhost:3030/jsonstore/phonebook");
  let desData = await response.json();

  let result = Object.values(desData);

  createLi(result);
}

function createLi(data) {
  for (const obj of data) {
    let li = document.createElement("li");
    li.id = obj._id;
    li.textContent = `${obj.person}: ${obj.phone}`;
    let btn = document.createElement("button");
    btn.textContent = "Delete";
    btn.addEventListener("click", deleteLi);

    li.appendChild(btn);

    ul.appendChild(li);
  }
}

async function deleteLi(e) {
  let id = e.target.parentElement.id;
  let url = "http://localhost:3030/jsonstore/phonebook/" + id;
  await fetch(url, {
    method: "delete",
  });
  e.target.parentElement.remove();
}
attachEvents();
