import { html } from "../modules.js";
import {
  checkIfLiked,
  deleteTheather,
  getOneTheather,
  getTheatherLikes,
  sendLike,
} from "../restFunctions.js";
import { getUserData } from "../session.js";

let detailsTemplate = (
  item,
  isOwner,
  onDelete,
  onClick,
  numberLikes,
  isLiked,
  user
) => html`
  <section id="detailsPage">
    <div id="detailsBox">
      <div class="detailsInfo">
        <h1>Title: ${item.title}</h1>
        <div>
          <img src=${item.imageUrl} />
        </div>
      </div>

      <div class="details">
        <h3>Theater Description</h3>
        <p>${item.description}</p>
        <h4>Date: ${item.date}</h4>
        <h4>Author: ${item.author}</h4>
        <div class="buttons">
          ${btnsTemplate(
            item,
            isOwner,
            onDelete,
            onClick,
            numberLikes,
            isLiked,
            user
          )}
      </div>
      <p class="likes">Likes: ${numberLikes}</p>
    </div>
  </section>
  ;
`;

let btnsTemplate = (
  item,
  isOwner,
  onDelete,
  onClick,
  numberLikes,
  isLiked,
  userData
) => {
  if (isOwner) {
    return html`<a
        @click=${onDelete}
        class="btn-delete"
        href="javascript:void(0)"
      >
        Delete
      </a>
      <a class="btn-edit" href="/edit/${item._id}"> Edit </a>`;
  } else if (!isOwner && isLiked == 0 && userData) {
    return html` <a
      @click=${onClick}
      class="btn-like"
      href="javascript:void(0)"
    >
      Like
    </a>`;
  } else {
    html`${undefined}`;
  }
};
export async function detailsRoute(ctx) {
  let currUser = getUserData();
  let id = ctx.params.id;
  let currTheather = await getOneTheather(id);
  let isOWner = currUser && currUser.id === currTheather._ownerId;
  let numberLikes = await getTheatherLikes(currTheather._id);
  let isLiked = 0;
  if (currUser) {
    isLiked = await checkIfLiked(currTheather._id, currUser.id);
  }
  async function onDelete(event) {
    event.preventDefault();
    let choice = confirm("Are you sure");
    if (choice) {
      await deleteTheather(id);
      ctx.page.redirect("/profile");
    }
  }

  async function onClick(event) {
    event.preventDefault();
    console.log("clicked");
    let theaterId = currTheather._id;
    await sendLike({ theaterId });
    ctx.page.redirect(`/details/${id}`);
  }
  return ctx.render(
    detailsTemplate(
      currTheather,
      isOWner,
      onDelete,
      onClick,
      numberLikes,
      isLiked,
      currUser
    )
  );
}
