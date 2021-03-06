window.addEventListener("load", solve);

function solve() {
  let genreElement = document.getElementById("genre");
  let nameElement = document.getElementById("name");
  let authorElement = document.getElementById("author");
  let dateElement = document.getElementById("date");
  let buttonAddElement = document.getElementById("add-btn");
  let collectionOfSongsDiv = document.querySelector(
    "div[class=all-hits-container]"
  );
  let savedElemet = document.querySelector(".saved-container");
  let likesElement = document.querySelector("div .likes p");
  buttonAddElement.addEventListener("click", addSong);
  let counter = 1;
  function addSong(e) {
    e.preventDefault();

    let genre = genreElement.value;
    let namee = nameElement.value;
    let author = authorElement.value;
    let date = dateElement.value;

    if (genre != "" && namee != "" && author != "" && date != "") {
      let songDiv = createEl(
        "div",
        { className: "hits-info" },
        createEl("img", { src: "./static/img/img.png" }),
        createEl("h2", {}, `Genre: ${genre}`),
        createEl("h2", {}, `Name: ${namee}`),
        createEl("h2", {}, `Author: ${author}`),
        createEl("h3", {}, `Date: ${date}`)
      );

      let saveButton = createEl("button", { className: "save-btn" }, "Save song");
      let likeButton = createEl("button", { className: "like-btn" }, "Like song");
      let deleteButton = createEl("button", { className: "delete-btn" }, "Delete");

      saveButton.addEventListener("click", save);
      likeButton.addEventListener("click", like);
      deleteButton.addEventListener("click", deletee);

      songDiv.appendChild(saveButton);
      songDiv.appendChild(likeButton);
      songDiv.appendChild(deleteButton);

      collectionOfSongsDiv.appendChild(songDiv);
    }

    genreElement.value = "";
    nameElement.value = "";
    authorElement.value = "";
    dateElement.value = "";
  }

  function like(e) {
    let text = `Total Likes: ${counter}`;
    e.target.disabled = true;
    likesElement.textContent = text;
    counter++;
  }
  function deletee(e) {
    e.target.parentElement.remove();
  }
  function save(e) {
    let divToSave = e.target.parentElement;
    let likeButton = e.target.parentElement.querySelector(".like-btn");
    let saveButton = e.target.parentElement.querySelector(".save-btn");

    divToSave.removeChild(likeButton);
    divToSave.removeChild(saveButton);
    savedElemet.appendChild(divToSave);
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
