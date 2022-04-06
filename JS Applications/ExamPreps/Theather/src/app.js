import { render, page } from "./modules.js";
import { logout } from "./restFunctions.js";
import { getUserData } from "./session.js";
import { createRoute } from "./templates/createTemplate.js";
import { detailsRoute } from "./templates/detailsTemplate.js";
import { editRoute } from "./templates/editTemplate.js";
import { homeRoute } from "./templates/homeTemplate.js";
import { loginRoute } from "./templates/loginTemplate.js";
import { profileRoute } from "./templates/profileTemplate.js";
import { registerRoute } from "./templates/registerTemplate.js";

let nav = document.querySelector("nav");
let main = document.getElementById("content");
document.getElementById("logoutBtn").addEventListener("click", onLogout);
updateNav();

page(middleware);
page("/", homeRoute);
page("/login", loginRoute);
page("/register", registerRoute);
page("/create", createRoute);
page("/profile", profileRoute);
page("/details/:id", detailsRoute);
page("/edit/:id", editRoute);

page.start();

async function onLogout(event) {
  event.preventDefault();
  await logout();
  page.redirect("/");
  updateNav();
}
function middleware(ctx, next) {
  ctx.render = (content) => render(content, main);
  ctx.updateNav = updateNav;

  next();
}

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
