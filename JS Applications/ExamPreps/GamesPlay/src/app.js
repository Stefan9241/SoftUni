import { logout } from "./api/data.js";
import { getUserData } from "./api/util.js";
import { page, render } from "./lib.js";
import { showCatalog } from "./views/catalog.js";
import { showCreate } from "./views/create.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showHomePage } from "./views/homepage.js";
import { showLogin } from "./views/login.js";
import { showRegister } from "./views/register.js";

let root = document.getElementById('main-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
page(modify);
page('/', showHomePage);
page('/login', showLogin);
page('/register', showRegister);
page('/all-games', showCatalog);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);


updateNav();
page.start();

function modify(ctx,next){
  ctx.render = (content) => render(content,root);
  ctx.updateNav = updateNav;
  next();
}

function updateNav() {
  let userData = getUserData();
  if (userData) {
    document.getElementById("guest").style.display = "none";
    document.getElementById("user").style.display = "inline-block";
  } else {
    document.getElementById("guest").style.display = "inline-block";
    document.getElementById("user").style.display = "none";
  }
}

async function onLogout(event){
  event.preventDefault();

  await logout();
  updateNav();
  page.redirect('/');
}