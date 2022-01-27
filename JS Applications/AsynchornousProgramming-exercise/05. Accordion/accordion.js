async function solution() {
  let main = document.getElementById("main");

  let titles = await fetch(
    "http://localhost:3030/jsonstore/advanced/articles/list"
  );
  let desTitles = await titles.json();

  desTitles.forEach((x) => main.appendChild(template(x)));

  console.log(desTitles);
}

function eFactory(tag, className = "", content = "") {
  let e = document.createElement(tag);
  e.className = className;
  e.textContent = content;
  return e;
}

function template({ _id, title }) {
  let wrapper = eFactory("div", "accordion");
  let headDiv = eFactory("div", "head");
  let titleSpan = eFactory("span", "", title);
  let btn = eFactory("button", "button", "More");
  let extraDiv = eFactory("div", "extra");
  extraDiv.style.display = "none";
  let contentP = eFactory("p");
  btn.id = _id;

  headDiv.append(titleSpan, btn);
  extraDiv.appendChild(contentP);
  wrapper.append(headDiv, extraDiv);

  btn.addEventListener("click", async () => {
    if (extraDiv.style.display === "none") {
      let data = await fetch(
        `http://localhost:3030/jsonstore/advanced/articles/details/${_id}`
      );

      let desData = await data.json();

      btn.textContent = "Less";
      extraDiv.style.display = "block";
      contentP.textContent = desData.content;
    } else {
      btn.textContent = "More";
      extraDiv.style.display = "none";
    }
  });

  return wrapper;
}
document.addEventListener("DOMContentLoaded", solution);
