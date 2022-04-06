
import { html } from "../modules.js";
import { register } from "../restFunctions.js";

let registerTemplate = (onSubmit) => html`
  <section id="registerPage">
    <form @submit=${onSubmit}>
      <fieldset>
        <legend>Register</legend>

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

        <label for="conf-pass" class="vhide">Confirm Password:</label>
        <input
          id="conf-pass"
          class="conf-pass"
          name="conf-pass"
          type="password"
          placeholder="Confirm Password"
        />

        <button type="submit" class="register">Register</button>

        <p class="field">
          <span>If you already have profile click <a href="/login">here</a></span>
        </p>
      </fieldset>
    </form>
  </section>
`;

export function showRegister(ctx) {
  async function onSubmit(event){
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('conf-pass');
    if(email === '' || password === '' || rePass === ''){
      return alert('All fields are required!');
    }

    if(password !== rePass){
      return alert('Passwords must match!')
    }

    await register(email,password);
    ctx.page.redirect('/');
    ctx.updateNav();
  }
  return ctx.render(registerTemplate(onSubmit));
}
