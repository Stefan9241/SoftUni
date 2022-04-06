import { html } from "../modules.js";
import { login } from "../restFunctions.js";

let loginTemplate = (onSubmit) => html`
  <section id="loginPage">
    <form @submit=${onSubmit}>
      <fieldset>
        <legend>Login</legend>

        <label for="email" class="vhide">Email</label>
        <input
          id="email"
          class="email"
          name="email"
          type="text"
          placeholder="Email"
        />

        <label for="password" class="vhide">Password</label>
        <input
          id="password"
          class="password"
          name="password"
          type="password"
          placeholder="Password"
        />

        <button type="submit" class="login">Login</button>

        <p class="field">
          <span
            >If you don't have profile click <a href="/register">here</a></span
          >
        </p>
      </fieldset>
    </form>
  </section>
`;

export function showLogin(ctx) {
  async function onSubmit(event) {
    event.preventDefault();

    let formData = new FormData(event.target);
    let email = formData.get("email");
    let password = formData.get("password");

    if (email == "" || password == "") {
      return alert("All fields are required!");
    }

    await login(email, password);
    ctx.page.redirect("/");
    ctx.updateNav();
  }
  return ctx.render(loginTemplate(onSubmit));
}
