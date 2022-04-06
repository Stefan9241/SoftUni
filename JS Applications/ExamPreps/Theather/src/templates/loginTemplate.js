import { html } from "../modules.js";
import { login } from "../restFunctions.js";

let loginTemplate = (submit) => html` <section id="loginaPage">
  <form @submit=${submit} class="loginForm">
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

  async function submit(event){
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');

    if(email == '' || password == ''){
      return alert('all fields are required!');
    }

    await login(email,password);
    ctx.page.redirect('/');
    ctx.updateNav();
  }
  return ctx.render(loginTemplate(submit));
}
