import { html } from "../modules.js";
import { getAllCars } from "../restFunctions.js";
let listingsTemplate = (items) => html`<section id="car-listings">
  <h1>Car Listings</h1>
  <div class="listings">
    <!-- Display all records -->
    ${items && items.length != 0
      ? items.map(oneCarTemplate)
      : html` <p class="no-cars">No cars in database.</p>`}
    <!-- Display if there are no records -->
  </div>
</section>`;

let oneCarTemplate = (item) => html` <div class="listing">
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
export async function listingsRoute(ctx) {
  let cars = await getAllCars();
  return ctx.render(listingsTemplate(cars));
}
