import { html } from "../modules.js";
import { register } from "../restFunctions.js";
let registerTemplate = (submitFunction) => html`<section id="registerPage">
  <form @submit=${submitFunction} class="registerForm">
    <img src="./images/logo.png" alt="logo" />
    <h2>Register</h2>
    <div class="on-dark">
      <label for="email">Email:</label>
      <input
        id="email"
        name="email"
        type="text"
        placeholder="steven@abv.bg"
        value=""
      />
    </div>

    <div class="on-dark">
      <label for="password">Password:</label>
      <input
        id="password"
        name="password"
        type="password"
        placeholder="********"
        value=""
      />
    </div>

    <div class="on-dark">
      <label for="repeatPassword">Repeat Password:</label>
      <input
        id="repeatPassword"
        name="repeatPassword"
        type="password"
        placeholder="********"
        value=""
      />
    </div>

    <button class="btn" type="submit">Register</button>

    <p class="field">
      <span>If you have profile click <a href="/login">here</a></span>
    </p>
  </form>
</section>`;
export function registerRoute(ctx) {
  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get("email").trim();
    let password = formData.get("password").trim();
    let rePass = formData.get("repeatPassword").trim();
    if (email == "" || password == "" || rePass == "") {
      return alert("all fields are required!");
    }

    if (rePass !== password) {
      return alert("Passwords must match!");
    }
    await register(email, password);
    ctx.page.redirect("/");
    ctx.updateNav();
  }
  return ctx.render(registerTemplate(submitFunction));
}
