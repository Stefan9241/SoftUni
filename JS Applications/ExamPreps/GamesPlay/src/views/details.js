import { deleteGame, getGameDetails } from "../api/data.js";
import { getUserData } from "../api/util.js";
import { html } from "../lib.js";

let detailsTemplate = (details, onClick, isOwner) => html`<section
  id="game-details"
>
  <h1>Game Details</h1>
  <div class="info-section">
    <div class="game-header">
      <img class="game-img" src=${details.imageUrl} />
      <h1>${details.title}</h1>
      <span class="levels">MaxLevel: ${details.maxLevel}</span>
      <p class="type">${details.category}</p>
    </div>

    <p class="text">${details.summary}</p>

    <!-- Edit/Delete buttons ( Only for creator of this game )  -->
    ${isOwner
      ? html`<div class="buttons">
          <a href="/edit/${details._id}" class="button">Edit</a>
          <a @click=${onClick} href="javascript:void(0)" class="button"
            >Delete</a
          >
        </div>`
      : null}
  </div>
</section> `;

/* <!-- Bonus -->
  <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
  <article class="create-comment">
    <label>Add new comment:</label>
    <form class="form">
      <textarea name="comment" placeholder="Comment......"></textarea>
      <input class="btn submit" type="submit" value="Add Comment" />
    </form>
  </article>
</section>`;

<!-- Bonus ( for Guests and Users ) -->
    <div class="details-comments">
      <h2>Comments:</h2>
      <ul>
        <!-- list all comments for current game (If any) -->
        <li class="comment">
          <p>Content: I rate this one quite highly.</p>
        </li>
        <li class="comment">
          <p>Content: The best game.</p>
        </li>
      </ul>
      <!-- Display paragraph: If there are no games in the database -->
      <p class="no-comment">No comments.</p>
    </div>
    */
export async function showDetails(ctx) {
  let game = await getGameDetails(ctx.params.id);
  let userData = getUserData();
  
  let isOwner = false;
  if (userData) {
    isOwner = userData.id === game._ownerId;
  }
  return ctx.render(detailsTemplate(game, onClick, isOwner));

  async function onClick(event) {
    event.preventDefault();
    let choice = confirm("Are you sure you want to DELETE ?");
    if (choice) {
      await deleteGame(ctx.params.id);
      ctx.page.redirect("/");
    }
  }
}
