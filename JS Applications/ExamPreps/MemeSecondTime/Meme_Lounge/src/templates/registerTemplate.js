import { html } from "../modules.js";
import { register } from "../restFunctions.js";
let loginTemplate = (submitFunction) => html`<section id="register">
  <form @submit=${submitFunction} id="register-form">
    <div class="container">
      <h1>Register</h1>
      <label for="username">Username</label>
      <input
        id="username"
        type="text"
        placeholder="Enter Username"
        name="username"
      />
      <label for="email">Email</label>
      <input id="email" type="text" placeholder="Enter Email" name="email" />
      <label for="password">Password</label>
      <input
        id="password"
        type="password"
        placeholder="Enter Password"
        name="password"
      />
      <label for="repeatPass">Repeat Password</label>
      <input
        id="repeatPass"
        type="password"
        placeholder="Repeat Password"
        name="repeatPass"
      />
      <div class="gender">
        <input type="radio" name="gender" id="female" value="female" />
        <label for="female">Female</label>
        <input type="radio" name="gender" id="male" value="male" checked />
        <label for="male">Male</label>
      </div>
      <input type="submit" class="registerbtn button" value="Register" />
      <div class="container signin">
        <p>Already have an account?<a href="/login">Sign in</a>.</p>
      </div>
    </div>
  </form>
</section>`;
export function registerRoute(ctx) {
  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get("email").trim();
    let password = formData.get("password").trim();
    let username = formData.get("username").trim();
    let rePass = formData.get("repeatPass").trim();
    let gender = document.getElementById("male");

    if (!gender.checked) {
      gender = "female";
    }

    if (email == "" || password == "" || username == "" || rePass == "") {
      return alert("all fields are required!");
    }
    await register(username, email, password, gender);
    ctx.page.redirect("/all-memes");
    ctx.updateNav();
  }

  return ctx.render(loginTemplate(submitFunction));
}
