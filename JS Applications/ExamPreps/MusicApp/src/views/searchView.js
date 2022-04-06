import { html } from "../modules.js";
import { searchAlbums } from "../restFunctions.js";
import { getUserData } from "../session.js";

let searchTemplate = (onClick, items, userData) => html` <section
  id="searchPage"
>
  <h1>Search by Name</h1>

  <div class="search">
    <input
      id="search-input"
      type="text"
      name="search"
      placeholder="Enter desired albums's name"
    />
    <button @click=${onClick} class="button-list">Search</button>
  </div>

  <h2>Results:</h2>
  ${items && items.length > 0
    ? items.map((x) => resultTemplate(x, userData))
    : html`<div class="search-result">
        <!--If have matches-->
        <!--If there are no matches-->
        <p class="no-result">No result.</p>
      </div>`}
  <!--Show after click Search button-->
</section>`;

let resultTemplate = (item, userData) => html`
<div class="search-result">
  <!--If have matches-->
  <div class="card-box">
    <img src=${item.imgUrl} />
    <div>
      <div class="text-center">
        <p class="name">Name: ${item.name}</p>
        <p class="artist">Artist: ${item.artist}</p>
        <p class="genre">Genre: ${item.genre}</p>
        <p class="price">Price: $${item.price}</p>
        <p class="date">Release Date: ${item.releaseDate}</p>
      </div>
      ${
        userData
          ? html`<div class="btn-group">
              <a href="/details/${item._id}" id="details">Details</a>
            </div>`
          : undefined
      }
      
    </div>
  </div>
  <!--If there are no matches-->
</div>
</section>`;

export function showSearch(ctx) {
  let userData = getUserData();
  async function onClick(event) {
    let input = event.target.parentElement.querySelector("input").value;
    if (input !== "") {
      let albums = await searchAlbums(input);
      return ctx.render(searchTemplate(onClick, albums, userData));
    } else {
      return alert("Field is Empty!");
    }
  }

  return ctx.render(searchTemplate(onClick));
}
