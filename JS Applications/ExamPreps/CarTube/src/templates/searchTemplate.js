import { html } from "../modules.js";
import { searchItems } from "../restFunctions.js";
let searchTemplate = (items, click) => html` <section id="search-cars">
  <h1>Filter by year</h1>

  <div class="container">
    <input
      id="search-input"
      type="text"
      name="search"
      placeholder="Enter desired production year"
    />
    <button @click=${click} class="button-list">Search</button>
  </div>

  <h2>Results:</h2>
  <div class="listings">
    <!-- Display all records -->
    ${items && items.length !== 0
      ? items.map(oneItem)
      : html` <p class="no-cars">No results.</p>`}
    <!-- Display if there are no matches -->
  </div>
</section>`;

let oneItem = (item) => html` <div class="listing">
  <div class="preview">
    <img src=${item.imageUrl} />
  </div>
  <h2>${item.brand} ${item.model}</h2>
  <div class="info">
    <div class="data-info">
      <h3>Year: ${item.year}</h3>
      <h3>Price: ${item.price} $</h3>
    </div>
    <div class="data-buttons">
      <a href="/details/${item._id}" class="button-carDetails">Details</a>
    </div>
  </div>
</div>`;
export function searchRoute(ctx) {
  async function onClick(event) {
    event.preventDefault();
    console.log("asd");
    let target = event.target.parentElement;
    let input = Number(target.querySelector("#search-input").value);
    if (typeof input === "number" && input !== 0) {
      let items = await searchItems(input);
      ctx.render(searchTemplate(items, onClick));
    }
  }

  return ctx.render(searchTemplate(undefined, onClick));
}
