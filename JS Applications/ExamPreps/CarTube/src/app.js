import { render, page } from "./modules.js";
import { logout } from "./restFunctions.js";
import { getUserData } from "./session.js";
import { listingsRoute } from "./templates/allListingsTemplate.js";
import { createRoute } from "./templates/createTemplate.js";
import { detailsRoute } from "./templates/detailsTemplate.js";
import { editRoute } from "./templates/editTemplate.js";
import { homeRoute } from "./templates/homeTemplate.js";
import { loginRoute } from "./templates/loginTemplate.js";
import { myListingsRoute } from "./templates/myListingsTemplate.js";
import { registerRoute } from "./templates/registerTemplate.js";
import { searchRoute } from "./templates/searchTemplate.js";

let main = document.getElementById("site-content");
document.getElementById("logoutBtn").addEventListener("click", onLogoutClick);
updateNav();
page(middleware);
page("/", homeRoute);
page("/login", loginRoute);
page("/register", registerRoute);
page("/all-listings", listingsRoute);
page("/create", createRoute);
page("/details/:id", detailsRoute);
page("/edit/:id", editRoute);
page("/my-listings", myListingsRoute);
page("/search", searchRoute);

page.start();

function middleware(ctx, next) {
  ctx.render = (content) => render(content, main);
  ctx.updateNav = updateNav;
  next();
}

function updateNav() {
  let userData = getUserData();
  if (userData != null) {
    document.getElementById("profile").style.display = "inline-block";
    document.getElementById("guest").style.display = "none";
    document.getElementById(
      "userName"
    ).textContent = `Welcome ${userData.username}`;
  } else {
    document.getElementById("profile").style.display = "none";
    document.getElementById("guest").style.display = "inline-block";
  }
}

async function onLogoutClick(event) {
  event.preventDefault();
  await logout();
  page.redirect("/");
  updateNav();
}
