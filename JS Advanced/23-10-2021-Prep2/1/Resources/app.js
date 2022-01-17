window.addEventListener("load", solve);

function solve() {
  let genreElement = document.querySelector('input[name="genre"]');
  let nameElement = document.querySelector('input[name="name"]');
  let authorElement = document.querySelector('input[name="author"]');
  let dateElement = document.querySelector('input[name="date"]');
  let buttonAddElement = document.getElementById("add-btn");
  let collectionOfSongsDiv = document.querySelector(
    "div[class=all-hits-container]"
  );
  let savedElemet = document.querySelector('.saved-container');
  let likesElement = document.querySelector("div .likes p");
  buttonAddElement.addEventListener("click", addSong);

  function addSong(e) {
    e.preventDefault();

    let genre = genreElement.value;
    let namee = nameElement.value;
    let author = authorElement.value;
    let date = dateElement.value;

    if (genre == "" || namee == "" || author == "" || date == "") {
      return;
    }

    let songDiv = createEl(
      "div",
      { className: "hits-info" },
      createEl("img", { src: "./static/img/img.png" }),
      createEl("h2", {}, `Genre: ${genre}`),
      createEl("h2", {}, `Name: ${namee}`),
      createEl("h2", {}, `Author: ${author}`),
      createEl("h3", {}, `Date: ${date}`)
    );

    let saveButton = createEl("button", { id: "save-btn" }, "Save song");
    let likeButton = createEl("button", { id: "like-btn" }, "Like song");
    let deleteButton = createEl("button", { id: "delete-btn" }, "Delete");

    songDiv.appendChild(saveButton);
    songDiv.appendChild(likeButton);
    songDiv.appendChild(deleteButton);

    songDiv.addEventListener("click", manager);
    collectionOfSongsDiv.appendChild(songDiv);

    genreElement.value = "";
    nameElement.value = "";
    authorElement.value = "";
    dateElement.value = "";

    function manager(e) {
      if (e.target.tagName == "BUTTON") {
        if (e.target.textContent == "Save song") {
          let divToSave = e.target.parentElement;
          divToSave.removeChild(likeButton);
          divToSave.removeChild(saveButton);
          savedElemet.appendChild(divToSave);
        } else if (e.target.textContent == "Like song") {
          e.target.disabled = true;
        } else if (e.target.textContent == "Delete") {
          e.target.parentElement.remove();
        }
      }
    }
  }

  function createEl(type, props, ...content) {
    const element = document.createElement(type);

    for (let prop in props) {
      element[prop] = props[prop];
    }

    for (let entry of content) {
      if (typeof entry == "string" || typeof entry == "number") {
        entry = document.createTextNode(entry);
      }

      element.appendChild(entry);
    }

    return element;
  }
}
