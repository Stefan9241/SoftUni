import { html } from "../modules.js";
import { login } from "../restFunctions.js";
let loginTemplate = (submitFunction) => html`<section id="login">
  <form @submit=${submitFunction} id="login-form">
    <div class="container">
      <h1>Login</h1>
      <label for="email">Email</label>
      <input id="email" placeholder="Enter Email" name="email" type="text" />
      <label for="password">Password</label>
      <input
        id="password"
        type="password"
        placeholder="Enter Password"
        name="password"
      />
      <input type="submit" class="registerbtn button" value="Login" />
      <div class="container signin">
        <p>Dont have an account?<a href="/register">Sign up</a>.</p>
      </div>
    </div>
  </form>
</section>`;
export function loginRoute(ctx) {
  async function submitFunction(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get("email");
    let password = formData.get("password");
    if (email == "" || password == "") {
      return alert("all fields are required!");
    }
    await login(email, password);
    ctx.page.redirect("/all-memes");
    ctx.updateNav();
  }

  return ctx.render(loginTemplate(submitFunction));
}
