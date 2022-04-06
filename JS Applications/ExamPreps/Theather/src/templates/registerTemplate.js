import { html } from "../modules.js";
import { register } from "../restFunctions.js";
let registerTemplate = (submit) => html` <section id="registerPage">
  <form @submit=${submit} class="registerForm">
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
  async function submit(event){
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('repeatPassword');

    if(email == '' || password == ''){
      return alert('all fields are required!');
    }

    if(password !== repeatPassword){
      return alert('Passwords must match!');
    }

    await register(email,password);
    ctx.page.redirect('/');
    ctx.updateNav();
  }

  return ctx.render(registerTemplate(submit));
}
