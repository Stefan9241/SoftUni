import { render, page } from "./modules.js";
import { logout } from "./restFunctions.js";
import { getUserData } from "./session.js";
import { createRoute } from "./templates/createTemplate.js";
import { dashboardRoute } from "./templates/dashboardTemplate.js";
import { detailsRoute } from "./templates/detailsTemplate.js";
import { editRoute } from "./templates/editTemplate.js";
import { homeRoute } from "./templates/homeTemplate.js";
import { loginRoute } from "./templates/loginTemplate.js";
import { registerRoute } from "./templates/registerTemplate.js";
let nav = document.querySelector("nav");
let main = document.getElementById("content");
document
  .getElementById("logoutBtn")
  .addEventListener("click", onLogoutFunction);
updateNav();
page(middleware);
page("/", homeRoute);
page("/login", loginRoute);
page("/register", registerRoute);
page("/dashboard", dashboardRoute);
page("/create", createRoute);
page("/details/:id", detailsRoute);
page("/edit/:id", editRoute);

page.start();

function updateNav() {
  let userData = getUserData();
  if (userData != null) {
    let arrUser = Array.from(nav.querySelectorAll(".user"));
    arrUser.forEach((x) => (x.style.display = "inline-block"));
    let arrGuest = Array.from(nav.querySelectorAll(".guest"));
    arrGuest.forEach((x) => (x.style.display = "none"));
  } else {
    let arrUser = Array.from(nav.querySelectorAll(".user"));
    arrUser.forEach((x) => (x.style.display = "none"));
    let arrGuest = Array.from(nav.querySelectorAll(".guest"));
    arrGuest.forEach((x) => (x.style.display = "inline-block"));
  }
}

function middleware(ctx, next) {
  ctx.render = (content) => render(content, main);
  ctx.updateNav = updateNav;
  next();
}

async function onLogoutFunction(event) {
  event.preventDefault();
  await logout();
  page.redirect("/");
  updateNav();
}
