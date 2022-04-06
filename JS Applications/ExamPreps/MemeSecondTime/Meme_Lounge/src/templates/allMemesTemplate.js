import { html } from "../modules.js";
import { getAllMemes } from "../restFunctions.js";
let memesTemplate = (memes) => html`<section id="meme-feed">
  <h1>All Memes</h1>
  <div id="memes">
    <!-- Display : All memes in database ( If any ) -->
    ${memes && memes.length != 0
      ? memes.map(oneMemeCard)
      : html` <p class="no-memes">No memes in database.</p>`}
    <!-- Display : If there are no memes in database -->
  </div>
</section>`;

let oneMemeCard = (item) => html` <div class="meme">
  <div class="card">
    <div class="info">
      <p class="meme-title">${item.title}</p>
      <img class="meme-image" alt="meme-img" src=${item.imageUrl} />
    </div>
    <div id="data-buttons">
      <a class="button" href="/details/${item._id}">Details</a>
    </div>
  </div>
</div>`;

export async function allMemesRoute(ctx) {
  let allMemes = await getAllMemes();
  return ctx.render(memesTemplate(allMemes));
}
