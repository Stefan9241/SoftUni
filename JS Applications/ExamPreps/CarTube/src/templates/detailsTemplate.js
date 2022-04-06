import { html } from "../modules.js";
import { deleteCar, getOneCar } from "../restFunctions.js";
import { getUserData } from "../session.js";
let detailTemplate = (item, onDelete, isOwner) => html`<section
  id="listing-details"
>
  <h1>Details</h1>
  <div class="details-info">
    <img src=${item.imageUrl} />
    <hr />
    <ul class="listing-props">
      <li><span>Brand:</span>${item.brand}</li>
      <li><span>Model:</span>${item.model}</li>
      <li><span>Year:</span>${item.year}</li>
      <li><span>Price:</span>${item.price}$</li>
    </ul>

    <p class="description-para">${item.description}</p>

    ${isOwner
      ? html`<div class="listings-buttons">
          <a href="/edit/${item._id}" class="button-list">Edit</a>
          <a @click=${onDelete} href="javascript:void(0)" class="button-list"
            >Delete</a
          >
        </div>`
      : undefined}
  </div>
</section> `;
export async function detailsRoute(ctx) {
  let car = await getOneCar(ctx.params.id);
  let userData = getUserData();
  let isOwner = userData && userData.id === car._ownerId ? true : false;

  async function onDelete(event) {
    event.preventDefault();
    let choice = confirm("Are you sure ?");
    if (choice) {
      await deleteCar(ctx.params.id);
      ctx.page.redirect("/all-listings");
    }
  }
  return ctx.render(detailTemplate(car, onDelete, isOwner));
}
