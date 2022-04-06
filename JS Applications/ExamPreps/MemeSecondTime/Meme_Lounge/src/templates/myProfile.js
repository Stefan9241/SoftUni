import { html } from "../modules.js";
import { getUserMemes } from "../restFunctions.js";
import { getUserData } from "../session.js";
let profileTemplate = (user, memes) => html` <section
  id="user-profile-page"
  class="user-profile"
>
  <article class="user-info">
    <img
      id="user-avatar-url"
      alt="user-profile"
      src="/images/${user.gender}.png"
    />
    <div class="user-content">
      <p>Username: ${user.username}</p>
      <p>Email: ${user.email}</p>
      <p>My memes count: ${memes ? memes.length : 0}</p>
    </div>
  </article>
  <h1 id="user-listings-title">User Memes</h1>
  <div class="user-meme-listings">
    <!-- Display : All created memes by this user (If any) -->
    ${memes && memes.length != 0
      ? memes.map(oneMemeTemplate)
      : html`<p class="no-memes">No memes in database.</p>`}
    <!-- Display : If user doesn't have own memes  -->
  </div>
</section>`;

let oneMemeTemplate = (item) => html` <div class="user-meme">
  <p class="user-meme-title">${item.title}</p>
  <img class="userProfileImage" alt="meme-img" src=${item.imageUrl} />
  <a class="button" href="/details/${item._id}">Details</a>
</div>`;

export async function profileRoute(ctx) {
  let user = getUserData();
  let memes = await getUserMemes(user.id);
  return ctx.render(profileTemplate(user, memes));
}
