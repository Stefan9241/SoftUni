import { logout } from "./api/api.js";
import { getUserData } from "./api/util.js";
import { render, page } from "./lib.js";
import { showCreateMeme } from "./views/createMeme.js";
import { showDetails } from "./views/details.js";
import { showEditPage } from "./views/editMeme.js";
import { showHomePage } from "./views/homePage.js";
import { showLoginPage } from "./views/login.js";
import { showMemes } from "./views/memes.js";
import { showMyProfile } from "./views/profile.js";
import { showRegister } from "./views/register.js";

let root = document.querySelector("main");
document.getElementById("logoutBtn").addEventListener("click", onLogout);

page(decorateFunction);
page("/", showHomePage);
page("/login", showLoginPage);
page("/register", showRegister);
page("/memes", showMemes);
page("/create", showCreateMeme);
page("/details/:id", showDetails);
page("/edit/:id", showEditPage);
page("/profile", showMyProfile);

updateNav();
page.start();

function decorateFunction(ctx, next) {
  ctx.render = (content) => render(content, root);
  ctx.updateNav = updateNav;
  next();
}

function updateNav() {
  let userData = getUserData();
  if (userData) {
    document.querySelector("div .user").style.display = "block";
    document.querySelector("div .guest").style.display = "none";
    document.querySelector(
      ".user span"
    ).textContent = `Welcome, ${userData.email}`;
  } else {
    document.querySelector("div .user").style.display = "none";
    document.querySelector("div .guest").style.display = "block";
  }
}

async function onLogout() {
  logout();
  updateNav();
  page.redirect("/");
}
