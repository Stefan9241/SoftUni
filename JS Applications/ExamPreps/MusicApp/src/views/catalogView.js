import { nothing } from "../../node_modules/lit-html/lit-html.js";
import { html } from "../modules.js";
import { getAllAlbums } from "../restFunctions.js";
import { getUserData } from "../session.js";

let catalogTemplate = (items, isLogged) => html` <section id="catalogPage">
  <h1>All Albums</h1>
  ${items.length === 0
    ? html` <p>No Albums in Catalog!</p>`
    : items.map((x) => oneCatalogCard(x, isLogged))}
</section>`;

let oneCatalogCard = (item, isLogged) => html` <div class="card-box">
  <img src=${item.imgUrl} />
  <div>
    <div class="text-center">
      <p class="name">Name: ${item.name}</p>
      <p class="artist">Artist: ${item.artist}</p>
      <p class="genre">Genre: ${item.genre}</p>
      <p class="price">Price: $${item.price}</p>
      <p class="date">Release Date: ${item.releaseDate}</p>
    </div>
    ${isLogged
      ? html`<div class="btn-group">
          <a href="/details/${item._id}" id="details">Details</a>
        </div>`
      : nothing}
  </div>
</div>`;

export async function showCatalog(ctx) {
  let albums = await getAllAlbums();
  let isLogged = getUserData();
  return ctx.render(catalogTemplate(albums, isLogged));
}
