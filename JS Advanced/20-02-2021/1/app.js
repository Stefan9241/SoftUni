function solve() {
  let authorElement = document.getElementById("creator");
  let titleElement = document.getElementById("title");
  let categoryElement = document.getElementById("category");
  let contentElement = document.getElementById("content");
  let createBtnElement = document.querySelector("form button");
  let postElementH2 = document.querySelector(".site-content section");
  let ol = document.querySelector("ol");
  createBtnElement.addEventListener("click", onCreate);
  let array = [];
  function onCreate(e) {
    e.preventDefault();
    let author = authorElement.value;
    let title = titleElement.value;
    let category = categoryElement.value;
    let content = contentElement.value;

    let articleEl = document.createElement("article");
    let h1Title = document.createElement("h1");
    h1Title.textContent = title;

    let pCategoryElelent = document.createElement("p");
    pCategoryElelent.textContent = "Category:";
    let strongElement = document.createElement("strong");
    strongElement.textContent = category;

    pCategoryElelent.appendChild(strongElement);

    let pCreatorElement = document.createElement("p");
    pCreatorElement.textContent = "Creator:";
    let strongCreatorElement = document.createElement("strong");
    strongCreatorElement.textContent = author;

    pCreatorElement.appendChild(strongCreatorElement);

    let contentPElement = document.createElement("p");
    contentPElement.textContent = content;

    let divBtns = document.createElement("div");
    divBtns.classList.add("buttons");

    let btnDelete = document.createElement("button");
    btnDelete.classList.add("btn");
    btnDelete.classList.add("delete");
    btnDelete.textContent = "Delete";

    let btnArchive = document.createElement("button");
    btnArchive.classList.add("btn");
    btnArchive.classList.add("archive");
    btnArchive.textContent = "Archive";

    btnDelete.addEventListener("click", (e) => {
      e.target.parentElement.parentElement.remove();
    });

    btnArchive.addEventListener("click", (e) => {
      let article = e.target.parentElement.parentElement.querySelector("h1");
      array.push(article.textContent);

      array = array.sort((a,b)=> a.localeCompare(b));
      ol.innerHTML = '';
      array.forEach(e=>{
         let li = document.createElement('li');
         li.textContent = e;
         ol.appendChild(li);
      })

      e.target.parentElement.parentElement.remove();
    });
    divBtns.appendChild(btnDelete);
    divBtns.appendChild(btnArchive);

    articleEl.appendChild(h1Title);
    articleEl.appendChild(pCategoryElelent);
    articleEl.appendChild(pCreatorElement);
    articleEl.appendChild(contentPElement);
    articleEl.appendChild(divBtns);

    postElementH2.appendChild(articleEl);

    authorElement.value = '';
    titleElement.value = '';
    categoryElement.value = '';
    contentElement.value = '';

  }
}
