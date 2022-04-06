import { render, page } from "./modules.js";
import { logout } from "./restFunctions.js";
import { getUserData } from "./session.js";
import { showCatalog } from "./views/catalogView.js";
import { showCreate } from "./views/createView.js";
import { showDetails } from "./views/detailsView.js";
import { showEdit } from "./views/editView.js";
import { showHome } from "./views/homeView.js";
import { showLogin } from "./views/loginView.js";
import { showRegister } from "./views/registerView.js";
import { showSearch } from "./views/searchView.js";

let main = document.getElementById("main-content");
let logoutBtn = document.getElementById("logoutBtn");
logoutBtn.addEventListener("click", onLogOut);


page(middleFunction);
page("/", showHome);
page("/login", showLogin);
page("/register", showRegister);
page("/catalog", showCatalog);
page("/create", showCreate);
page("/details/:id", showDetails);
page("/edit/:id", showEdit);
page("/search", showSearch);

updateNav();
page.start();

function middleFunction(ctx, next) {
  ctx.render = (content) => render(content, main);
  ctx.updateNav = updateNav;

  next();
}

function updateNav() {
  let userData = getUserData();
  let nav = document.querySelector("nav");
  if (userData != null) {
    [...nav.querySelectorAll(".user")].forEach(
      (x) => (x.style.display = "inline-block")
    );
    [...nav.querySelectorAll(".guest")].forEach(
      (x) => (x.style.display = "none")
    );
  } else {
    [...nav.querySelectorAll(".user")].forEach(
      (x) => (x.style.display = "none")
    );
    [...nav.querySelectorAll(".guest")].forEach(
      (x) => (x.style.display = "inline-block")
    );
  }
}

async function onLogOut(event) {
  console.log(event);
  await logout();
  page.redirect("/");
  updateNav();
}
