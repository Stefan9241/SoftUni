window.addEventListener("load", solve);

function solve() {
  let modelElement = document.getElementById("model");
  let yearElement = document.getElementById("year");
  let descriptionElement = document.getElementById("description");
  let priceElement = document.getElementById("price");
  let furnitureList = document.getElementById("furniture-list");
  let totalPrice = document.querySelector(".total-price");
  let addButton = document.getElementById("add");
  addButton.addEventListener("click", add);
  let currPrice = 0;

  function add(e) {
    e.preventDefault();
    let model = modelElement.value;
    let year = Number(yearElement.value);
    let description = descriptionElement.value;
    let price = Number(priceElement.value);

    if (model != "" && year >= 0 && description != "" && price >= 0) {
      let trInfo = createEl(
        "tr",
        { className: "info" },
        createEl("td", {}, `${model}`),
        createEl("td", {}, `${price.toFixed(2)}`),
        createEl("button", { className: "moreBtn" }, "More Info"),
        createEl("button", { className: "buyBtn" }, "Buy it")
      );
      let btns = Array.from(trInfo.querySelectorAll("button"));
      let moreInfoBtn = btns[0];
      moreInfoBtn.addEventListener("click", moreInfo);
      let buyBtn = btns[1];
      buyBtn.addEventListener("click", buy);

      let trHide = createEl(
        "tr",
        { className: "hide" },
        createEl("td", {}, `Year: ${year}`),
        createEl("td", { colSpan: "3" }, `Description: ${description}`)
      );
      trInfo.appendChild(trHide);
      furnitureList.appendChild(trInfo);
    }

    modelElement.value = "";
    yearElement.value = "";
    descriptionElement.value = "";
    priceElement.value = "";
  }
  function buy(e) {
    currPrice += Number(price.value);
    totalPrice.textContent = currPrice.toFixed(2);
    e.target.parentElement.remove();
  }
  function moreInfo(e) {
    let target = e.target.parentElement;
    target = target.querySelector(".hide");
    if (e.target.textContent == "More Info") {
      e.target.textContent = "Less Info";
      target.style.display = "contents";
    } else {
      e.target.textContent = "More Info";
      target.style.display = "none";
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
