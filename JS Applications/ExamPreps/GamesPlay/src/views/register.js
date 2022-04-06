import { register } from "../api/data.js";
import { html } from "../lib.js";

let registerTemplate = (onSubmit) => html`<section
  id="register-page"
  class="content auth"
>
  <form @submit=${onSubmit} id="register">
    <div class="container">
      <div class="brand-logo"></div>
      <h1>Register</h1>

      <label for="email">Email:</label>
      <input
        type="email"
        id="email"
        name="email"
        placeholder="maria@email.com"
      />

      <label for="pass">Password:</label>
      <input type="password" name="password" id="register-password" />

      <label for="con-pass">Confirm Password:</label>
      <input type="password" name="confirm-password" id="confirm-password" />

      <input class="btn submit" type="submit" value="Register" />

      <p class="field">
        <span>If you already have profile click <a href="/login">here</a></span>
      </p>
    </div>
  </form>
</section>`;

export async function showRegister(ctx) {
  return ctx.render(registerTemplate(onSubmit));

  async function onSubmit(event) {
    event.preventDefault();

    let formData = new FormData(event.target);
    let email = formData.get("email").trim();
    let password = formData.get("password").trim();
    let rePass = formData.get("confirm-password").trim();

    if (email == "" || password == "") {
      return alert("All fields are required!");
    }

    if (rePass == "") {
      return alert("All fields are required!");
    }
    if (password !== rePass) {
      return alert("Passwords must match!");
    }

    await register(email, password);

    ctx.updateNav();
    ctx.page.redirect("/");
  }
}
