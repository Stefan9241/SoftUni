import { page, render } from "./modules.js";
import { logout } from "./restFunctions.js";
import { getUserData } from "./session.js";
import { allMemesRoute } from "./templates/allMemesTemplate.js";
import { createRoute } from "./templates/createTemplate.js";
import { detailsRoute } from "./templates/detailsTemplate.js";
import { editRoute } from "./templates/editTemplate.js";
import { homeRoute } from "./templates/homeTemplates.js";
import { loginRoute } from "./templates/loginTemplate.js";
import { profileRoute } from "./templates/myProfile.js";
import { registerRoute } from "./templates/registerTemplate.js";

let main = document.querySelector("main");
document
  .getElementById("logoutBtn")
  .addEventListener("click", onLogoutFunction);

page(middleware);
page("/", homeRoute);
page("/login", loginRoute);
page("/create", createRoute);
page("/register", registerRoute);
page("/all-memes", allMemesRoute);
page("/details/:id", detailsRoute);
page("/edit/:id", editRoute);
page("/my-profile", profileRoute);

updateNav();
page.start();
function updateNav() {
  let userData = getUserData();
  if (userData != null) {
    document.querySelector(".user").style.display = "block";
    document.querySelector(".guest").style.display = "none";
    document.querySelector(
      ".user span"
    ).textContent = `Welcome, ${userData.email}`;
  } else {
    document.querySelector(".user").style.display = "none";
    document.querySelector(".guest").style.display = "block";
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
