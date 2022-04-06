import { html } from "../modules.js";
import { register } from "../restFunctions.js";
let registerTemplate = (submit) => html` <section id="register">
  <div class="container">
    <form @submit=${submit} id="register-form">
      <h1>Register</h1>
      <p>Please fill in this form to create an account.</p>
      <hr />

      <p>Username</p>
      <input
        type="text"
        placeholder="Enter Username"
        name="username"
        required
      />

      <p>Password</p>
      <input
        type="password"
        placeholder="Enter Password"
        name="password"
        required
      />

      <p>Repeat Password</p>
      <input
        type="password"
        placeholder="Repeat Password"
        name="repeatPass"
        required
      />
      <hr />

      <input type="submit" class="registerbtn" value="Register" />
    </form>
    <div class="signin">
      <p>Already have an account? <a href="/login">Sign in</a>.</p>
    </div>
  </div>
</section>`;
export function registerRoute(ctx) {
  async function submit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let username = formData.get("username").trim();
    let password = formData.get("password").trim();
    let repeatPass = formData.get("repeatPass").trim();
    if (username == "" || password == "" || repeatPass == "") {
      return alert("all fields are required!");
    }

    if (repeatPass !== password) {
      return alert("Passwords must match!");
    }

    await register(username, password);
    ctx.page.redirect("/all-listings");
    ctx.updateNav();
  }
  return ctx.render(registerTemplate(submit));
}
