import { html } from "../modules.js";
import { deleteMeme, getOneMeme } from "../restFunctions.js";
import { getUserData } from "../session.js";
let detailsTemplate = (item, isOwner, onDeleteClick) => html`<section
  id="meme-details"
>
  <h1>Meme Title: ${item.title}</h1>
  <div class="meme-details">
    <div class="meme-img">
      <img alt="meme-alt" src=${item.imageUrl} />
    </div>
    <div class="meme-description">
      <h2>Meme Description</h2>
      <p>${item.description}</p>

      ${isOwner
        ? html`<a class="button warning" href="/edit/${item._id}">Edit</a>
            <button @click=${onDeleteClick} class="button danger">
              Delete
            </button>`
        : undefined}
      <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
    </div>
  </div>
</section> `;
export async function detailsRoute(ctx) {
  let meme = await getOneMeme(ctx.params.id);
  let user = getUserData();
  let isOwner = user && user.id === meme._ownerId;

  async function onDeleteClick(event) {
    event.preventDefault();
    let choice = confirm("Are you sure?");
    if (choice) {
      await deleteMeme(ctx.params.id);
      ctx.page.redirect("/all-memes");
    }
  }
  return ctx.render(detailsTemplate(meme, isOwner, onDeleteClick));
}
