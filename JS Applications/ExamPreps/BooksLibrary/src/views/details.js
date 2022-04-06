import {
  addLike,
  deleteBook,
  getBookDetails,
  getBookLikes,
} from "../api/data.js";
import { getUserData } from "../api/util.js";
import { html } from "../lib.js";

let detailsTemplate = (
  book,
  onDelete,
  isOwner,
  likes,
  hasLiked
) => html`<section id="details-page" class="details">
  <div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl} /></p>
    <div class="actions">
      <!-- Edit/Delete buttons ( Only for creator of this book )  -->
      ${isOwner
        ? html` <a class="button" href="/edit/${book._id}">Edit</a>
            <a @click=${onDelete} class="button" href="javascript:void(0)"
              >Delete</a
            >
            <div class="likes">
              <img class="hearts" src="/images/heart.png" />
              <span id="total-likes">Likes: ${likes}</span>
            </div>`
        : html` <div class="likes">
            <img class="hearts" src="/images/heart.png" />
            <span id="total-likes">Likes: ${likes}</span>
          </div>`}
    </div>
  </div>
  <div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
  </div>
</section>`;

export async function showDetails(ctx) {
  let userData = getUserData();
  let book = await getBookDetails(ctx.params.id);
  let isOwner = userData && userData.id === book._ownerId;
  let likes = await getBookLikes(book._id);
  ctx.render(detailsTemplate(book, onDelete, isOwner, likes, hasLiked));

  async function onDelete(event) {
    event.preventDefault();
    let choice = confirm(`Are you sure you want to delete`);
    if (choice) {
      await deleteBook(book._id);
      ctx.page.redirect("/");
    }
  }

  async function hasLiked(event) {
    event.preventDefault();
    await addLike(book._id);
    ctx.page.redirect(`/details/${ctx.params.id}`);
  }
}
