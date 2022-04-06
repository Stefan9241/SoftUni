import { deleteById, getItemById } from "../api/data.js";
import { getUserData } from "../api/util.js";
import { html } from "../lib.js";

let detailsTemplate = (meme, owner, currUser, onDelete) => html` <section
  id="meme-details"
>
  <h1>Meme Title: ${meme.title}</h1>
  <div class="meme-details">
    <div class="meme-img">
      <img alt="meme-alt" src=${meme.imageUrl} />
    </div>
    <div class="meme-description">
      <h2>Meme Description</h2>
      <p>${meme.description}</p>
      ${owner == currUser
        ? html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button @click=${onDelete} class="button danger">Delete</button>`
        : null}
      <!--
         Buttons Edit/Delete should be displayed only for creator of this meme  -->
    </div>
  </div>
</section>`;

export async function showDetails(ctx) {
  let memeId = ctx.params.id;
  let meme = await getItemById(memeId);

  let ownerId = meme._ownerId;
  let currUserData = getUserData();
  let currUserId = currUserData.id;
  ctx.render(detailsTemplate(meme, ownerId, currUserId, onDelete));

  async function onDelete(event) {
    event.preventDefault();
    let choice = confirm("Are you sure you want to DELETE?");

    if (choice) {
      await deleteById(memeId);
      ctx.page.redirect("/memes");
    }
  }
}
