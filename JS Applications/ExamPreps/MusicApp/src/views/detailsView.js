import { html } from "../modules.js";
import { delAlbum, getOneAlbum } from "../restFunctions.js";
import { getUserData } from "../session.js";

let detailsTemplate = (item, isOwner, onDelete) => html` <section
  id="detailsPage"
>
  <div class="wrapper">
    <div class="albumCover">
      <img src=${item.imgUrl} />
    </div>
    <div class="albumInfo">
      <div class="albumText">
        <h1>Name: ${item.name}</h1>
        <h3>Artist: ${item.artist}</h3>
        <h4>Genre: ${item.genre}</h4>
        <h4>Price: $${item.price}</h4>
        <h4>Date: ${item.releaseDate}</h4>
        <p>
          ${item.description}
        </p>
      </div>
      ${isOwner
        ? html`<div class="actionBtn">
            <a href="/edit/${item._id}" class="edit">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="remove"
              >Delete</a
            >
          </div>`
        : undefined}
      <!-- Only for registered user and creator of the album-->
    </div>
  </div>
</section>`;

export async function showDetails(ctx) {
  let userData = getUserData();
  let currAlbum = await getOneAlbum(ctx.params.id);
  let isOwner = currAlbum._ownerId === userData.id;

  async function onDelete(event) {
    event.preventDefault();
    let choice = confirm('Are you sure ?');
    if(choice){
      await delAlbum(currAlbum._id)
      ctx.page.redirect('/catalog');
    }
  }

  return ctx.render(detailsTemplate(currAlbum, isOwner,onDelete));
}
