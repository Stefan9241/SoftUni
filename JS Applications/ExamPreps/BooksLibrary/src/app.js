import { logout } from "./api/api.js";
import { getUserData } from "./api/util.js";
import { render, page } from "./lib.js";
import { showCreate } from "./views/create.js";
import { showDashboard } from "./views/dashboard.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showLogin } from "./views/login.js";
import { showProfile } from "./views/profile.js";
import { showRegister } from "./views/register.js";

let root = document.getElementById("site-content");
document.getElementById("logoutBtn").addEventListener("click", onLogout);
page(decContex);
page("/", showDashboard);
page("/login", showLogin);
page("/register", showRegister);
page("/create", showCreate);
page("/details/:id", showDetails);
page("/edit/:id", showEdit);
page("/profile", showProfile);

updateNav();
page.start();

function decContex(ctx, next) {
  ctx.render = (content) => render(content, root);
  ctx.updateNav = updateNav;
  next();
}

function updateNav() {
  let userData = getUserData();
  if (userData) {
    document.getElementById("guest").style.display = "none";
    document.getElementById("user").style.display = "inline-block";
    document.querySelector(
      "#user span"
    ).textContent = `Welcome, ${userData.email}`;
  } else {
    document.getElementById("guest").style.display = "inline-block";
    document.getElementById("user").style.display = "none";
  }
}

function onLogout() {
  logout();
  updateNav();
  page.redirect("/");
}
