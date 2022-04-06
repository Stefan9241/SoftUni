import { html } from "../modules.js";
import { login } from "../restFunctions.js";
let loginTemplate = (submitFunction) => html`<section id="loginPage">
  <form @submit=${submitFunction} class="loginForm">
    <img src="./images/logo.png" alt="logo" />
    <h2>Login</h2>

    <div>
      <label for="email">Email:</label>
      <input
        id="email"
        name="email"
        type="text"
        placeholder="steven@abv.bg"
        value=""
      />
    </div>

    <div>
      <label for="password">Password:</label>
      <input
        id="password"
        name="password"
        type="password"
        placeholder="********"
        value=""
      />
    </div>

    <button class="btn" type="submit">Login</button>

    <p class="field">
      <span>If you don't have profile click <a href="/register">here</a></span>
    </p>
  </form>
</section>`;
export function loginRoute(ctx) {
  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get("email").trim();
    let password = formData.get("password").trim();
    if (email == "" || password == "") {
      return alert("all fields are required!");
    }
    await login(email, password);
    ctx.page.redirect("/");
    ctx.updateNav();
  }
  return ctx.render(loginTemplate(submitFunction));
}
