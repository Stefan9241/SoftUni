let url = "http://localhost:3030/jsonstore/collections/books";
let loadBooksBtn = document.getElementById("loadBooks");
loadBooksBtn.addEventListener("click", displayBooks);
let tbodyElement = document.querySelector("tbody");
let startingForm = document.getElementById("form");
let editForm = document.getElementById("edit");
let savebtn = document.querySelector("#form button");
savebtn.addEventListener("click", save);

async function save(e) {
  e.preventDefault();
  let titleInput = document.querySelector('#form input[name="title"]');
  let authorInput = document.querySelector('#form input[name="author"]');

  let result = await fetch(url, {
    method: "post",
    headers: {
      "Content-Type": "aplication-json",
    },
    body: JSON.stringify({
      title: titleInput.value,
      author: authorInput.value,
    }),
  });

  titleInput.value = "";
  authorInput.value = "";
  await displayBooks();
}
async function displayBooks() {
  tbodyElement.innerHTML = "";
  startingForm.style.display = "block";
  editForm.style.display = "none";

  let response = await fetch(url);
  let desData = await response.json();
  let data = Object.entries(desData);

  data.forEach((x) => {
    let id = x[0];
    let currData = x[1];
    let tr = document.createElement("tr");
    let tdAuthorName = document.createElement("td");
    let tdTitle = document.createElement("td");
    let tdBtns = document.createElement("td");
    let btnEdit = document.createElement("button");
    let btnDelete = document.createElement("button");
    tr.className = id;
    tdAuthorName.textContent = currData.author;
    tdTitle.textContent = currData.title;
    btnDelete.textContent = "Delete";
    btnEdit.textContent = "Edit";

    btnDelete.addEventListener("click", remove);
    btnEdit.addEventListener("click", edit);

    tr.appendChild(tdTitle);
    tr.appendChild(tdAuthorName);

    tdBtns.appendChild(btnEdit);
    tdBtns.appendChild(btnDelete);
    tr.appendChild(tdBtns);

    tbodyElement.appendChild(tr);
  });
}

async function remove(e) {
  let id = e.target.parentElement.parentElement.className;
  let elToRemove = document.getElementsByClassName(id)[0];
  tbodyElement.removeChild(elToRemove);

  let urlToDel = "http://localhost:3030/jsonstore/collections/books/" + id;
  await fetch(urlToDel, {
    method: "delete",
  });
}

async function edit(e) {
  startingForm.style.display = "none";
  editForm.style.display = "block";

  let id = e.target.parentElement.parentElement.className;
  let titleInput = document.querySelector('#edit input[name="title"]');
  let authorInput = document.querySelector('#edit input[name="author"]');

  let btnSave = document.querySelector("#edit button");
  btnSave.addEventListener("click", async () => {
    let url = "http://localhost:3030/jsonstore/collections/books/" + id;
    let options = {
      title: titleInput.value,
      author: authorInput.value,
    };
    await fetch(url, {
      method: "put",
      headers: {
        "Content-Type": "aplication-json",
      },
      body: JSON.stringify(options),
    });
  });
}
