import { html } from "../modules.js";
import { login } from "../restFunctions.js";
let loginTemplate = (submit) => html`
  <section id="login">
    <div class="container">
      <form @submit=${submit} id="login-form" action="#" method="post">
        <h1>Login</h1>
        <p>Please enter your credentials.</p>
        <hr />

        <p>Username</p>
        <input placeholder="Enter Username" name="username" type="text" />

        <p>Password</p>
        <input type="password" placeholder="Enter Password" name="password" />
        <input type="submit" class="registerbtn" value="Login" />
      </form>
      <div class="signin">
        <p>Dont have an account? <a href="/register">Sign up</a>.</p>
      </div>
    </div>
  </section>
`;
export function loginRoute(ctx) {
  async function submit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let username = formData.get("username").trim();
    let password = formData.get("password").trim();
    if (username == "" || password == "") {
      return alert("all fields are required!");
    }
    await login(username, password);
    ctx.page.redirect("/all-listings");
    ctx.updateNav();
  }
  return ctx.render(loginTemplate(submit));
}
